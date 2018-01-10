using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace PGCafe.Object.Config {
    
    /// <summary>
    /// Provide base config structure, inherit this and add public property to be Config-Item.
    /// * Use XML Serialize to Save/Load. ( can use XmlAttribute to determine property for ignore, node name, attribute ... )
    /// </summary>
    public abstract class XmlConfig {

        #region Load

        /// <summary> Load config from xml file. </summary>
        /// <typeparam name="T">Type of config class</typeparam>
        /// <param name="FilePath">File full name of xml file.</param>
        /// <param name="ParentNodeXPath">XPath of node which contains Config-Node</param>
        /// <returns>Success with Config object or not with null of Config object.</returns>
        public static SingleResult<T> Load<T>( string FilePath, string ParentNodeXPath = null ) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load( FilePath );
                return Load<T>( doc, ParentNodeXPath );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public SingleResult<T> Load<T>( string FilePath, string ParentNodeXPath = null )


        /// <summary> Load config from xml document. </summary>
        /// <typeparam name="T">Type of config class</typeparam>
        /// <param name="Document">Xml document to load.</param>
        /// <param name="ParentNodeXPath">XPath of node which contains Config-Node</param>
        /// <returns>Success with Config object or not with null of Config object.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static SingleResult<T> Load<T>( XmlDocument Document, string ParentNodeXPath = null ) {
            // argument check
            if ( Document == null ) return new ArgumentNullException( nameof( Document ) );

            try {
                // get config node from document
                var configNodePath = GetConfigNodePath( typeof( T ), GetParentPath( Document, ParentNodeXPath ) );
                var configNode = Document.SelectSingleNode( configNodePath );
                if ( configNode == null )
                    return new XmlException( $"The config node path \"{configNodePath}\" could not be found" );

                // load config from xml node.
                return Load<T>( configNode );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> Load<T>( XmlDocument Document, string ParentNodeXPath = null )


        /// <summary> Load config from xml node. </summary>
        /// <typeparam name="T">Type of config class</typeparam>
        /// <param name="ConfigNode">Xml setting node to load.</param>
        /// <returns> Success with Config object or not with null of Config object. </returns>
        /// <exception cref="ArgumentNullException"/>
        public static SingleResult<T> Load<T>( XmlNode ConfigNode ) {
            // argument check
            if ( ConfigNode == null ) return new ArgumentNullException( nameof( ConfigNode ) );
            
            try { // deserialize xml from node
                using ( var reader = ConfigNode.CreateNavigator().ReadSubtree() )
                    return PGSerialization.XmlDeserialize<T>( reader );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> Load<T>( XmlNode ConfigNode )

        #endregion

        #region GetParentPath, GetConfigNodePath

        /// <summary> Gets ParentNode path or root name or default name "root".</summary>
        /// <param name="Document">Document to get default root path.</param>
        /// <param name="ParentNodeXPath">XPath of node which contains Config-Node</param>
        /// <returns>Full path with ParentPath.</returns>
        private static string GetParentPath( XmlDocument Document, string ParentNodeXPath = null ) {
            // if ParentNodeXPath is empty, use root name or "root" for default.
            if ( ParentNodeXPath.IsNullOrWhiteSpace() )
                ParentNodeXPath = Document.FirstChild?.Name ?? "root";
            else {
                if ( Document.SelectSingleNode( ParentNodeXPath ) == null ) {
                    // try select node with ParentNodeXPath with root node path.
                    var newPath = Document.FirstChild?.Name + "/" + ParentNodeXPath;

                    // if has found node, return new path.
                    if ( Document.SelectSingleNode( newPath ) != null ) return newPath;
                } // if
            } // else

            return ParentNodeXPath;
        } // private static string GetParentPath( XmlDocument Document, string ParentNodeXPath = null )

        /// <summary> Gets the configuration node path from attribute or class name, combine with ParentNodeXPath.</summary>
        /// <param name="ConfigType">Type of config class.</param>
        /// <param name="ParentNodeXPath">XPath of node which contains Config-Node</param>
        /// <returns>Full path with ParentNodeXPath and config node name.</returns>
        private static string GetConfigNodePath( Type ConfigType, string ParentNodeXPath ) {
            // try find config node name from XmlRootAttribute
            var configNodeName = ConfigType.GetCustomAttributes( typeof( XmlRootAttribute ), true )
                ?.FirstOrDefault()?.As<XmlRootAttribute>()?.ElementName;
            
            // try find config node name from XmlElementAttribute
            if ( configNodeName == null ) 
                configNodeName = ConfigType.GetCustomAttributes( typeof( XmlElementAttribute ), true )
                ?.FirstOrDefault()?.As<XmlElementAttribute>()?.ElementName;
                
            // if no setup XmlRootAttribute and XmlElementAttribute, get node name by class name.
            if ( configNodeName == null ) 
                configNodeName = ConfigType.Name;
            
            // combind ParentNodeXPath and config node name.
            var configNodePath = ParentNodeXPath.Trim( '/' ) + "/" + configNodeName;

            return configNodePath;
        } // private static XmlNode GetConfigNodePath( Type ConfigType, string ParentNodeXPath )

        #endregion

        #region Save

        /// <summary> Save config to xml file. </summary>
        /// <param name="FilePath">File full name of xml file. ( only update target node )</param>
        /// <param name="ParentNodeXPath">XPath of node which contains Config-Node</param>
        /// <returns> Success or not with exception. </returns>
        public virtual EmptyResult Save( string FilePath, string ParentNodeXPath = null ) {
            try {
                // if file is exist, load it.
                XmlDocument doc = new XmlDocument();
                if ( File.Exists( FilePath ) )
                    doc.Load( FilePath );

                // save config to document. ( should only update target node )
                var saveResult = this.Save( doc, ParentNodeXPath );
                if ( !saveResult.Success )
                    return saveResult;

                // if success, save it.
                var folderOfFile = Path.GetDirectoryName( FilePath );
                if ( !folderOfFile.IsNullOrWhiteSpace() )
                    Directory.CreateDirectory( folderOfFile );

                doc.Save( FilePath );
                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public virtual EmptyResult Save( string FilePath, string ParentNodeXPath = null )

        /// <summary>Save config to xml document.</summary>
        /// <param name="Document">XmlDocument to save. ( only update target node )</param>
        /// <param name="ParentNodeXPath">XPath of node which contains Config-Node</param>
        /// <returns> Success or not with exception. </returns>
        public virtual EmptyResult Save( XmlDocument Document, string ParentNodeXPath = null ) {
            try {
                ParentNodeXPath = GetParentPath( Document, ParentNodeXPath );

                // get parent node.
                var parentNode = Document.SelectSingleNode( ParentNodeXPath );
                if ( parentNode == null )
                    parentNode = Document.CreateNodes( ParentNodeXPath );
                
                // create config node.
                var doc = new XmlDocument();
                using ( var writer = doc.CreateNavigator().AppendChild() ) {
                    var serializeResult = PGSerialization.XmlSerialize( writer, this );
                    if ( !serializeResult.Success )
                        return serializeResult.Exception;
                } // using

                // get exist config node.
                var configNodePath = GetConfigNodePath( this.GetType(), ParentNodeXPath );
                var configNode = Document.SelectSingleNode( configNodePath );

                // if config node is not exist, append it.
                if ( configNode == null )
                    parentNode.AppendChild( Document.ImportNode( doc.DocumentElement, true ) );
                else // else if config node is exist, replace it.
                    parentNode.ReplaceChild( Document.ImportNode( doc.DocumentElement, true ), configNode );

                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public virtual EmptyResult Save( XmlDocument Document, string ParentNodeXPath = null )
        
        #endregion

    } // public abstract class XmlConfig

} // namespace PGCafe.Object.Config
