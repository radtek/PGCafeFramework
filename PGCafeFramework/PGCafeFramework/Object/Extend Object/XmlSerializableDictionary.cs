using System.Collections.Generic;
using System.Xml.Serialization;

namespace PGCafe.Object {

    /// <summary> Serializable Dictionary object, please just use the object need to be serialize. </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <seealso cref="System.Collections.Generic.Dictionary{TKey, TValue}" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    public class XmlSerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable {

        /// <summary> Initializes a new instance of the <see cref="XmlSerializableDictionary{TKey, TValue}"/> class. </summary>
        public XmlSerializableDictionary() : base(){ }

        /// <summary> Initializes a new instance of the <see cref="XmlSerializableDictionary{TKey, TValue}"/> class from dictionary. </summary>
        /// <param name="source">The source.</param>
        public XmlSerializableDictionary( Dictionary<TKey,TValue> source ) : base( source ){ }

        #region Implement IXmlSerializable
        
        /// <summary> </summary>
        public System.Xml.Schema.XmlSchema GetSchema() => null;
            
        /// <summary> </summary>
        public void ReadXml( System.Xml.XmlReader reader ) {
            XmlSerializer keySerializer = new XmlSerializer( typeof( TKey ) );
            XmlSerializer valueSerializer = new XmlSerializer( typeof( TValue ) );

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if ( wasEmpty )
                return;

            while ( reader.NodeType != System.Xml.XmlNodeType.EndElement ) {
                reader.ReadStartElement( "item" );

                reader.ReadStartElement( "key" );
                TKey key = (TKey)keySerializer.Deserialize( reader );
                reader.ReadEndElement();

                reader.ReadStartElement( "value" );
                TValue value = (TValue)valueSerializer.Deserialize( reader );
                reader.ReadEndElement();

                this.Add( key, value );

                reader.ReadEndElement();
                reader.MoveToContent();
            } // while

            reader.ReadEndElement();
        } // public void ReadXml( System.Xml.XmlReader reader )
        
        /// <summary> </summary>
        public void WriteXml( System.Xml.XmlWriter writer ) {
            XmlSerializer keySerializer = new XmlSerializer( typeof( TKey ) );
            XmlSerializer valueSerializer = new XmlSerializer( typeof( TValue ) );

            foreach ( TKey key in this.Keys ) {
                writer.WriteStartElement( "item" );

                writer.WriteStartElement( "key" );
                keySerializer.Serialize( writer, key );
                writer.WriteEndElement();

                writer.WriteStartElement( "value" );
                TValue value = this[key];
                valueSerializer.Serialize( writer, value );
                writer.WriteEndElement();

                writer.WriteEndElement();
            } // foreach
        } // public void WriteXml( System.Xml.XmlWriter writer )

        #endregion

    } // public class XmlSerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable

} // namespace PGCafe.Object
