using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PGCafe.Object.UI {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class RectangleFConverter : TypeConverter {
    
        /// <devdoc>
        ///      Determines if this converter can convert an object in the given source
        ///      type to the native type of the converter.
        /// </devdoc>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
 
        /// <devdoc>
        ///    <para>Gets a value indicating whether this converter can
        ///       convert an object to the given destination type using the context.</para>
        /// </devdoc>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
 
        /// <devdoc>
        ///      Converts the given object to the converter's native type.
        /// </devdoc>        
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
 
            string strValue = value as string;
        
            if (strValue != null) {
            
                string text = strValue.Trim();
            
                if (text.Length == 0) {
                    return null;
                }
                else {
                
                    // Parse 4 integer values.
                    //
                    if (culture == null) {
                        culture = CultureInfo.CurrentCulture;
                    }                                        
                    char sep = culture.TextInfo.ListSeparator[0];
                    string[] tokens = text.Split(new char[] {sep});
                    float[] values = new float[tokens.Length];
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(float));
                    for (int i = 0; i < values.Length; i++) {
                        // Note: ConvertFromString will raise exception if value cannot be converted.
                        values[i] = (float)intConverter.ConvertFromString(context, culture, tokens[i]);
                    }
                    
                    if (values.Length == 4) {
                        return new RectangleF(values[0], values[1], values[2], values[3]);
                    }
                    else {
                        throw new ArgumentException();
                    }
                }
            }
            
            return base.ConvertFrom(context, culture, value);
        }
 
        /// <devdoc>
        ///      Converts the given object to another type.  The most common types to convert
        ///      are to and from a string object.  The default implementation will make a call
        ///      to ToString on the object if the object is valid and if the destination
        ///      type is string.  If this cannot convert to the desitnation type, this will
        ///      throw a NotSupportedException.
        /// </devdoc>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == null) {
                throw new ArgumentNullException("destinationType");
            }
 
            if( value is RectangleF ){
                if (destinationType == typeof(string)) {
                    RectangleF rect = (RectangleF)value;
                    
                    if (culture == null) {
                        culture = CultureInfo.CurrentCulture;
                    }                                        
                    string sep = culture.TextInfo.ListSeparator + " ";
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(float));
                    string[] args = new string[4];
                    int nArg = 0;
                    
                    // Note: ConvertToString will raise exception if value cannot be converted.
                    args[nArg++] = intConverter.ConvertToString(context, culture, rect.X);
                    args[nArg++] = intConverter.ConvertToString(context, culture, rect.Y);
                    args[nArg++] = intConverter.ConvertToString(context, culture, rect.Width);
                    args[nArg++] = intConverter.ConvertToString(context, culture, rect.Height);
                    
                    return string.Join(sep, args);
                }
                if (destinationType == typeof(InstanceDescriptor)) {
                    RectangleF rect = (RectangleF)value;
                    ConstructorInfo ctor = typeof(RectangleF).GetConstructor(new Type[] {
                        typeof(float), typeof(float), typeof(float), typeof(float)});
                        
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {
                            rect.X, rect.Y, rect.Width, rect.Height});
                    }
                }
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
 
        /// <devdoc>
        ///      Creates an instance of this type given a set of property values
        ///      for the object.  This is useful for objects that are immutable, but still
        ///      want to provide changable properties.
        /// </devdoc>        
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues) {
            if( propertyValues == null ){
                throw new ArgumentNullException( "propertyValues" );
            }
 
            object x = propertyValues["X"];
            object y = propertyValues["Y"];
            object width =  propertyValues["Width"];
            object height =  propertyValues["Height"];            
 
            if(x == null || y == null || width == null || height == null ||
                !(x is float) || !(y is float) || !(width is float) || !(height is float) ) {
                    throw new ArgumentException();
            }
            return new RectangleF((float)x,
                                     (float)y,
                                     (float)width,
                                     (float)height);
        }
 
        /// <devdoc>
        ///      Determines if changing a value on this object should require a call to
        ///      CreateInstance to create a new value.
        /// </devdoc>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) {
            return true;
        }
        
        /// <devdoc>
        ///      Retrieves the set of properties for this type.  By default, a type has
        ///      does not return any properties.  An easy implementation of this method
        ///      can just call TypeDescriptor.GetProperties for the correct data type.
        /// </devdoc>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(RectangleF), attributes);
                return props.Sort(new string[] {"X", "Y", "Width", "Height"});
        }
       
        /// <devdoc>
        ///      Determines if this object supports properties.  By default, this
        ///      is false.
        /// </devdoc>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true;
        }
        
    }


    ///// <summary>
    ///// RectangleFConverter 的摘要说明。
    ///// </summary>
    //public class RectangleFConverter : TypeConverter {
    //    // Methods
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="RectangleFConverter"/> class.
    //    /// </summary>
    //    public RectangleFConverter() {
    //    }
    //    /// <summary>
    //    /// 會傳回這個轉換子是否可以使用指定內容，將指定型別的物件轉換為這個轉換子的型別。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <param name="sourceType"><see cref="T:System.Type" />，表示要轉換的來源型別。</param>
    //    /// <returns>
    //    /// 如果這個轉換子可以執行轉換，則為 true，否則為 false。
    //    /// </returns>
    //    public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType ) {
    //        return ( ( sourceType == typeof( string ) ) || base.CanConvertFrom( context, sourceType ) );
    //    }
    //    /// <summary>
    //    /// 傳回值，指出這個轉換子是否可以使用指定的內容，將物件轉換成指定的型別。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <param name="destinationType"><see cref="T:System.Type" />，表示要轉換成的型別。</param>
    //    /// <returns>
    //    /// 如果這個轉換子可以執行轉換，則為 true，否則為 false。
    //    /// </returns>
    //    public override bool CanConvertTo( ITypeDescriptorContext context, Type destinationType ) {
    //        return ( ( destinationType == typeof( InstanceDescriptor ) ) || base.CanConvertTo( context, destinationType ) );
    //    }
    //    /// <summary>
    //    /// 使用指定的內容和文化特性資訊，將指定物件轉換為這個轉換子的型別。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <param name="culture">當做目前文化特性使用的 <see cref="T:System.Globalization.CultureInfo" />。</param>
    //    /// <param name="value">要進行轉換的 <see cref="T:System.Object" />。</param>
    //    /// <returns>
    //    ///   <see cref="T:System.Object" />，表示轉換過的值。
    //    /// </returns>
    //    /// <exception cref="ArgumentException">格式不正确！</exception>
    //    public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value ) {
    //        if ( !( value is string ) ) {
    //            return base.ConvertFrom( context, culture, value );
    //        }
    //        string text = ( (string)value ).Trim();
    //        if ( text.Length == 0 ) {
    //            return null;
    //        }
    //        if ( culture == null ) {
    //            culture = CultureInfo.CurrentCulture;
    //        }
    //        char ch = culture.TextInfo.ListSeparator[0];
    //        string[] textArray = text.Split( new char[] { ch } );
    //        float[] numArray = new float[textArray.Length];
    //        TypeConverter converter = TypeDescriptor.GetConverter( typeof( float ) );
    //        for ( int i = 0 ; i < numArray.Length ; i++ ) {
    //            numArray[i] = (float)converter.ConvertFromString( context, culture, textArray[i] );
    //        }
    //        if ( numArray.Length != 4 ) {
    //            throw new ArgumentException( "格式不正确！" );
    //        }
    //        return new RectangleF( numArray[0], numArray[1], numArray[3], numArray[4] );

    //    }
    //    /// <summary>
    //    /// 會使用指定的內容和文化特性資訊，將指定值物件轉換成指定型別。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <param name="culture"><see cref="T:System.Globalization.CultureInfo" />。如果傳遞 null，會假設目前的文化特性。</param>
    //    /// <param name="value">要進行轉換的 <see cref="T:System.Object" />。</param>
    //    /// <param name="destinationType">要將 <paramref name="value" /> 參數轉換成的 <see cref="T:System.Type" />。</param>
    //    /// <returns>
    //    ///   <see cref="T:System.Object" />，表示轉換過的值。
    //    /// </returns>
    //    /// <exception cref="ArgumentNullException">destinationType</exception>
    //    public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType ) {
    //        if ( destinationType == null ) {
    //            throw new ArgumentNullException( "destinationType" );
    //        }
    //        if ( ( destinationType == typeof( string ) ) && ( value is RectangleF ) ) {
    //            RectangleF pointf = (RectangleF)value;
    //            if ( culture == null ) {
    //                culture = CultureInfo.CurrentCulture;
    //            }
    //            string separator = culture.TextInfo.ListSeparator + " ";
    //            TypeConverter converter = TypeDescriptor.GetConverter( typeof( float ) );
    //            string[] textArray = new string[4];
    //            int num = 0;
    //            textArray[num++] = converter.ConvertToString( context, culture, pointf.X );
    //            textArray[num++] = converter.ConvertToString( context, culture, pointf.Y );
    //            textArray[num++] = converter.ConvertToString( context, culture, pointf.Width );
    //            textArray[num++] = converter.ConvertToString( context, culture, pointf.Height );
    //            return string.Join( separator, textArray );
    //        }
    //        if ( ( destinationType == typeof( InstanceDescriptor ) ) && ( value is RectangleF ) ) {
    //            RectangleF pointf2 = (RectangleF)value;
    //            ConstructorInfo member = typeof( RectangleF ).GetConstructor( new Type[] { typeof( float ), typeof( float ), typeof( float ), typeof( float ) } );
    //            if ( member != null ) {
    //                return new InstanceDescriptor( member, new object[] { pointf2.X, pointf2.Y, pointf2.Width, pointf2.Height } );
    //            }
    //        }
    //        return base.ConvertTo( context, culture, value, destinationType );

    //    }
    //    /// <summary>
    //    /// 會使用指定的內容，建立與這個 <see cref="T:System.ComponentModel.TypeConverter" /> 關聯之型別的執行個體，並為物件設定了一組屬性值。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <param name="propertyValues">新屬性值的 <see cref="T:System.Collections.IDictionary" />。</param>
    //    /// <returns>
    //    ///   <see cref="T:System.Object" />，表示指定的 <see cref="T:System.Collections.IDictionary" />，如果無法建立物件，則為 null。這個方法永遠傳回 null。
    //    /// </returns>
    //    public override object CreateInstance( ITypeDescriptorContext context, IDictionary propertyValues ) {
    //        return new RectangleF( (float)propertyValues["X"], (float)propertyValues["Y"], (float)propertyValues["Width"], (float)propertyValues["Height"] );
    //    }
    //    /// <summary>
    //    /// 會使用指定的內容，傳回在這個物件上變更值是否需要呼叫 <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> 來建立新值。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <returns>
    //    /// 如果在這個物件上變更屬性需要呼叫 <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> 來建立新值，則為 true，否則為 false。
    //    /// </returns>
    //    public override bool GetCreateInstanceSupported( ITypeDescriptorContext context ) {
    //        return true;
    //    }
    //    /// <summary>
    //    /// 會使用指定的內容和屬性 (Attribute)，傳回由值參數所指定之陣列型別的屬性 (Property) 集合。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <param name="value"><see cref="T:System.Object" />，指定要為其取得屬性之陣列的型別。</param>
    //    /// <param name="attributes"><see cref="T:System.Attribute" /> 型別的陣列，可當做篩選條件使用。</param>
    //    /// <returns>
    //    ///   <see cref="T:System.ComponentModel.PropertyDescriptorCollection" />，具有為這個資料型別所公開的屬性，如果沒有屬性，則為 null。
    //    /// </returns>
    //    public override PropertyDescriptorCollection GetProperties( ITypeDescriptorContext context, object value, Attribute[] attributes ) {
    //        return TypeDescriptor.GetProperties( typeof( RectangleF ), attributes ).Sort( new string[] { "X", "Y", "Width", "Height" } );
    //    }
    //    /// <summary>
    //    /// 會使用指定的內容傳回數值，表示這個物件是否支援屬性。
    //    /// </summary>
    //    /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
    //    /// <returns>
    //    /// 如果應該呼叫 <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> 以尋找這個物件的屬性，則為 true，否則為 false。
    //    /// </returns>
    //    public override bool GetPropertiesSupported( ITypeDescriptorContext context ) {
    //        return true;
    //    }
    //}
} // namespace PGCafe.Object.UI
