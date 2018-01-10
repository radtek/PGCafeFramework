using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PGCafe.Object {

    /// <summary> Make interface can be serialize with xml. </summary>
    /// <typeparam name="TInterface">type of interface</typeparam>
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    public sealed class XmlSerializableInterface<TInterface> : IXmlSerializable {

        #region Property & Constructor

        /// <summary> Value </summary>
        public TInterface Value { get; set; }

        /// <summary> Initializes a new instance of the <see cref="XmlSerializableInterface{TInterface}"/> class. </summary>
        public XmlSerializableInterface() { }
        
        /// <summary> Initializes a new instance of the <see cref="XmlSerializableInterface{TInterface}"/> class. </summary>
        /// <param name="Value">Value to hold</param>
        public XmlSerializableInterface( TInterface Value ) { this.Value = Value; }

        #endregion
        
        #region Implement IXmlSerializable
        
        /// <summary> </summary>
        public XmlSchema GetSchema() { return ( null ); }
        
        /// <summary> </summary>
        public void WriteXml( XmlWriter writer ) {
            if ( Value == null ) {
                writer.WriteAttributeString( "type", "null" );
                return;
            } // if

            var type = this.Value.GetType();
            var serializer = new XmlSerializer( type );
            writer.WriteAttributeString( "type", type.AssemblyQualifiedName );
            serializer.Serialize( writer, this.Value );
        } // public void WriteXml( XmlWriter writer )

        /// <summary> </summary>
        public void ReadXml( XmlReader reader ) {
            if ( !reader.HasAttributes )
                throw new FormatException( "expected a type attribute!" );

            var type = reader.GetAttribute( "type" );
            reader.Read(); // consume the value
            if ( type == "null" )
                return;// leave T at default value

            var serializer = new XmlSerializer( Type.GetType( type ) );
            this.Value = (TInterface)serializer.Deserialize( reader );
            reader.ReadEndElement();
        } // public void ReadXml( XmlReader reader )

        #endregion

        #region implicit operator
        
        /// <summary> </summary>
        public static implicit operator TInterface( XmlSerializableInterface<TInterface> source ){
            return source.Value;
        } // public static implicit operator TInterface( XmlSerializableInterface<TInterface> source )
        
        /// <summary> </summary>
        public static implicit operator XmlSerializableInterface<TInterface>( TInterface source ){
            return new XmlSerializableInterface<TInterface>( source );
        } // public static implicit operator XmlSerializableInterface<TInterface>( TInterface source )
        
        #endregion

    } // public sealed class XmlSerializableInterface<TInterface> : IXmlSerializable

} // namespace PGCafe.Object
