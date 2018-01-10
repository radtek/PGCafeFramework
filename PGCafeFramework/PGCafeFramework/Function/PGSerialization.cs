using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PGCafe.Object;

namespace PGCafe {

    /// <summary>
    /// Serialization static extension method.
    /// </summary>
    public class PGSerialization {

        #region Binary Serialize

        /// <summary> Binary serialize to path with object. </summary>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        public static EmptyResult BinarySerialize<T>( Stream stream, T obj ) {
            try {
                new BinaryFormatter().Serialize( stream, obj );
                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult BinarySerialize<T>( Stream stream, T obj )


        /// <summary> Binary serialize to path with object. </summary>
        /// <param name="path"> file path to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        public static EmptyResult BinarySerialize<T>( string path, T obj ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Create ) )
                    new BinaryFormatter().Serialize( fStream, obj );

                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult BinarySerialize<T>( string path, T obj )


        /// <summary> Binary deserialize from path to object. </summary>
        /// <param name="path"> file path to deserialize to object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> BinaryDeserialize<T>( string path ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Open ) )
                    return (T)new BinaryFormatter().Deserialize( fStream );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> BinaryDeserialize<T>( string path )


        /// <summary> Binary deserialize from path to object. </summary>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> BinaryDeserialize<T>( Stream stream ) {
            try {
                return (T)new BinaryFormatter().Deserialize( stream );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> BinaryDeserialize<T>( Stream stream )

        #endregion

        #region XML Serialization

        /// <summary> Call back with XML Serialization. </summary>
        public interface IXmlSerializationCallback {
            /// <summary> call back before serialize </summary>
            void BeforeSerialize();

            /// <summary> call back after serialize </summary>
            void AfterSerialized();

            /// <summary> call back after deserialize </summary>
            void AfterDeserialized();
        } // public interface IXmlSerializationCallback
        
        
        /// <summary>
        /// Xml serialize to path with object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="path"> file path to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        public static EmptyResult XmlSerialize( string path, object obj ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Create ) ) {
                    // call OnXmlSerializing first.
                    if ( obj is IXmlSerializationCallback )
                        obj.As<IXmlSerializationCallback>().BeforeSerialize();

                    new XmlSerializer( obj.GetType() ).Serialize( fStream, obj );
                    
                    fStream.Flush();  fStream.Close();

                    // call OnXmlSerialized first.
                    if ( obj is IXmlSerializationCallback )
                        obj.As<IXmlSerializationCallback>().AfterSerialized();

                    return true;
                } // using
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult XmlSerialize( string path, object obj )
        
        
        /// <summary>
        /// Xml serialize to path with object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        /// <param name="namespaces"> namespaces of XmlSerializer, if pass null, use empty namespaces. </param>
        public static EmptyResult XmlSerialize( Stream stream, object obj, XmlSerializerNamespaces namespaces = null ) {
            try {
                // call OnXmlSerializing first.
                if ( obj is IXmlSerializationCallback )
                    obj.As<IXmlSerializationCallback>().BeforeSerialize();

                if ( namespaces == null ) {
                    namespaces = new XmlSerializerNamespaces();
                    namespaces.Add( "", "" );
                } // if

                new XmlSerializer( obj.GetType() ).Serialize( stream, obj, namespaces );
                stream.Flush();

                // call OnXmlSerialized first.
                if ( obj is IXmlSerializationCallback )
                    obj.As<IXmlSerializationCallback>().AfterSerialized();

                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult XmlSerialize( Stream stream, object obj, XmlSerializerNamespaces namespaces = null )
        
        
        /// <summary>
        /// Xml serialize to <see cref="XmlWriter"/> with object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="writer"> writer to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        /// <param name="namespaces"> namespaces of XmlSerializer, if pass null, use empty namespaces. </param>
        public static EmptyResult XmlSerialize( XmlWriter writer, object obj, XmlSerializerNamespaces namespaces = null ) {
            try {
                // call OnXmlSerializing first.
                if ( obj is IXmlSerializationCallback )
                    obj.As<IXmlSerializationCallback>().BeforeSerialize();

                if ( namespaces == null ) {
                    namespaces = new XmlSerializerNamespaces();
                    namespaces.Add( "", "" );
                } // if

                new XmlSerializer( obj.GetType() ).Serialize( writer, obj, namespaces );
                writer.Flush();

                // call OnXmlSerialized first.
                if ( obj is IXmlSerializationCallback )
                    obj.As<IXmlSerializationCallback>().AfterSerialized();

                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult XmlSerialize( XmlWriter stream, object obj, XmlSerializerNamespaces namespaces = null )


        /// <summary>
        /// Xml deserialize from path to object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="path"> file path to deserialize to object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> XmlDeserialize<T>( string path ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Open ) ) {
                    var result = new XmlSerializer( typeof( T ) ).Deserialize( fStream );
                    // call OnXmlDeserialization.
                    if ( result is IXmlSerializationCallback )
                        result.As<IXmlSerializationCallback>().AfterDeserialized();

                    return (T)result;
                } // using
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> XmlDeserialize<T>( string path )


        /// <summary>
        /// Xml deserialize from path to object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> XmlDeserialize<T>( Stream stream ) {
            try {
                var result = new XmlSerializer( typeof( T ) ).Deserialize( stream );

                // call OnXmlDeserialization.
                if ( result is IXmlSerializationCallback )
                    result.As<IXmlSerializationCallback>().AfterDeserialized();

                return (T)result;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> XmlDeserialize<T>( Stream stream )
        

        /// <summary>
        /// Xml deserialize from <see cref="XmlReader"/> to object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="reader"> reader to serialize the object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> XmlDeserialize<T>( XmlReader reader ) {
            try {
                var result = new XmlSerializer( typeof( T ) ).Deserialize( reader );

                // call OnXmlDeserialization.
                if ( result is IXmlSerializationCallback )
                    result.As<IXmlSerializationCallback>().AfterDeserialized();

                return (T)result;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> XmlDeserialize<T>( Stream stream )


        /// <summary>
        /// Xml deserialize from path to object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="Type"> type to deserialize to object. </param>
        /// <param name="path"> file path to deserialize to object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<object> XmlDeserialize( Type Type, string path ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Open ) ) {
                    var result = new XmlSerializer( Type ).Deserialize( fStream );
                    // call OnXmlDeserialization.
                    if ( result is IXmlSerializationCallback )
                        result.As<IXmlSerializationCallback>().AfterDeserialized();

                    return result;
                } // using
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<object> XmlDeserialize<T>( Type Type, string path )


        /// <summary>
        /// Xml deserialize from path to object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="Type"> type to deserialize to object. </param>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<object> XmlDeserialize( Type Type, Stream stream ) {
            try {
                var result = new XmlSerializer( Type ).Deserialize( stream );

                // call OnXmlDeserialization.
                if ( result is IXmlSerializationCallback )
                    result.As<IXmlSerializationCallback>().AfterDeserialized();

                return result;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<object> XmlDeserialize( Type Type, Stream stream )
        

        /// <summary>
        /// Xml deserialize from <see cref="XmlReader"/> to object.
        /// hint: implement IXmlSerializationCallback to do something in call back when serialization.
        /// </summary>
        /// <param name="Type"> type to deserialize to object. </param>
        /// <param name="reader"> reader to serialize the object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<object> XmlDeserialize( Type Type, XmlReader reader ) {
            try {
                var result = new XmlSerializer( Type ).Deserialize( reader );

                // call OnXmlDeserialization.
                if ( result is IXmlSerializationCallback )
                    result.As<IXmlSerializationCallback>().AfterDeserialized();

                return result;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<object> XmlDeserialize( Type Type, Stream stream )

        #endregion
        
        #region DataContract Serialize

        /// <summary> DataContract serialize to path with object. </summary>
        /// <param name="path"> file path to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        public static EmptyResult DataContractSerialize( string path, object obj ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Create ) )
                    new DataContractSerializer( obj.GetType() ).WriteObject( fStream, obj );

                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult DataContractSerialize( string path, object obj )

        /// <summary> DataContract serialize to path with object. </summary>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <param name="obj"> the object to be serialize. </param>
        public static EmptyResult DataContractSerialize( Stream stream, object obj ) {
            try {
                new DataContractSerializer( obj.GetType() ).WriteObject( stream, obj );
                return true;
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static EmptyResult DataContractSerialize( Stream stream, object obj )

        /// <summary> DataContract deserialize from path to object. </summary>
        /// <param name="path"> file path to deserialize to object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> DataContractDeserialize<T>( string path ) {
            try {
                using ( FileStream fStream = new FileStream( path, FileMode.Open ) )
                    return (T)new DataContractSerializer( typeof( T ) ).ReadObject( fStream );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> DataContractDeserialize<T>( string path )

        /// <summary> DataContract deserialize from path to object. </summary>
        /// <param name="stream"> stream to serialize the object. </param>
        /// <returns> object aht deserialize. </returns>
        public static SingleResult<T> DataContractDeserialize<T>( Stream stream ) {
            try {
                return (T)new DataContractSerializer( typeof( T ) ).ReadObject( stream );
            } catch ( Exception ex ) {
                return ex;
            } // try-catch
        } // public static SingleResult<T> DataContractDeserialize<T>( Stream stream )

        #endregion

    } // public class PGSerialization

} // namespace PGCafe
