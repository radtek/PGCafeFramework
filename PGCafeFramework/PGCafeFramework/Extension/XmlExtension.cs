using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// Xml's Extension( Xmldocument, XmlNode, ... )
    /// </summary>
    public static class XmlExtension {

        #region Xmldocument

        /// <summary> Create all nodes by XPath.</summary>
        /// <param name="source">The source.</param>
        /// <param name="XPath">The XPath of node path.( the XPath should only have node name and it's spliter )</param>
        /// <returns>Last node in XPath.</returns>
        /// <exception cref="System.ArgumentNullException"/>
        public static XmlNode CreateNodes( this XmlDocument source, string XPath ) {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );
            if ( XPath.IsNullOrEmpty() ) throw new ArgumentNullException( nameof( XPath ) );
            
            // split XPath to single node name.
            var nodeNames = XPath.Trim( '/' ).Split( '/' );

            /// create all not exist node, and then append it to source.
            /// to rollback any error occur when create node or append node.
            
            /// find exist node.
            var existNode = source as XmlNode;
            int i = 0;
            for ( var nextNode = existNode ; i < nodeNames.Length ; i++ ) {
                nextNode = existNode.SelectSingleNode( nodeNames[i] );
                if ( nextNode == null ) break;
                else existNode = nextNode;
            } // for
            
            // if all node is exist, return last node of XPath.
            if ( i == nodeNames.Length ) return existNode;
            
            /// create not exist node.
            // create root node
            XmlNode newNodeRoot = source.CreateElement( nodeNames[i] );
            var curNewNode = newNodeRoot;
            for ( i = i + 1 ; i < nodeNames.Length ; i++ ) {
                var newNode = source.CreateElement( nodeNames[i] );
                curNewNode = curNewNode.AppendChild( newNode );
            } // for
            
            // after create all node without error, add not exist node to exist node
            existNode.AppendChild( newNodeRoot );

            // return last node of XPath.
            return curNewNode;
        } // public static XmlNode CreateNodes( this XmlDocument source, string XPath )

        #endregion

    } // public class XmlExtension
} // namespace PGCafe
