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
    /// PointFConverter 的摘要说明。
    /// </summary>
    public class PointFConverter : TypeConverter {
        // Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="PointFConverter"/> class.
        /// </summary>
        public PointFConverter() {
        }
        /// <summary>
        /// 會傳回這個轉換子是否可以使用指定內容，將指定型別的物件轉換為這個轉換子的型別。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <param name="sourceType"><see cref="T:System.Type" />，表示要轉換的來源型別。</param>
        /// <returns>
        /// 如果這個轉換子可以執行轉換，則為 true，否則為 false。
        /// </returns>
        public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType ) {
            return ( ( sourceType == typeof( string ) ) || base.CanConvertFrom( context, sourceType ) );
        }
        /// <summary>
        /// 傳回值，指出這個轉換子是否可以使用指定的內容，將物件轉換成指定的型別。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <param name="destinationType"><see cref="T:System.Type" />，表示要轉換成的型別。</param>
        /// <returns>
        /// 如果這個轉換子可以執行轉換，則為 true，否則為 false。
        /// </returns>
        public override bool CanConvertTo( ITypeDescriptorContext context, Type destinationType ) {
            return ( ( destinationType == typeof( InstanceDescriptor ) ) || base.CanConvertTo( context, destinationType ) );
        }
        /// <summary>
        /// 使用指定的內容和文化特性資訊，將指定物件轉換為這個轉換子的型別。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <param name="culture">當做目前文化特性使用的 <see cref="T:System.Globalization.CultureInfo" />。</param>
        /// <param name="value">要進行轉換的 <see cref="T:System.Object" />。</param>
        /// <returns>
        ///   <see cref="T:System.Object" />，表示轉換過的值。
        /// </returns>
        /// <exception cref="ArgumentException">格式不正确！</exception>
        public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value ) {
            if ( !( value is string ) ) {
                return base.ConvertFrom( context, culture, value );
            }
            string text = ( (string)value ).Trim();
            if ( text.Length == 0 ) {
                return null;
            }
            if ( culture == null ) {
                culture = CultureInfo.CurrentCulture;
            }
            char ch = culture.TextInfo.ListSeparator[0];
            string[] textArray = text.Split( new char[] { ch } );
            float[] numArray = new float[textArray.Length];
            TypeConverter converter = TypeDescriptor.GetConverter( typeof( float ) );
            for ( int i = 0 ; i < numArray.Length ; i++ ) {
                numArray[i] = (float)converter.ConvertFromString( context, culture, textArray[i] );
            }
            if ( numArray.Length != 2 ) {
                throw new ArgumentException( "格式不正确！" );
            }
            return new PointF( numArray[0], numArray[1] );

        }
        /// <summary>
        /// 會使用指定的內容和文化特性資訊，將指定值物件轉換成指定型別。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <param name="culture"><see cref="T:System.Globalization.CultureInfo" />。如果傳遞 null，會假設目前的文化特性。</param>
        /// <param name="value">要進行轉換的 <see cref="T:System.Object" />。</param>
        /// <param name="destinationType">要將 <paramref name="value" /> 參數轉換成的 <see cref="T:System.Type" />。</param>
        /// <returns>
        ///   <see cref="T:System.Object" />，表示轉換過的值。
        /// </returns>
        /// <exception cref="ArgumentNullException">destinationType</exception>
        public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType ) {
            if ( destinationType == null ) {
                throw new ArgumentNullException( "destinationType" );
            }
            if ( ( destinationType == typeof( string ) ) && ( value is PointF ) ) {
                PointF pointf = (PointF)value;
                if ( culture == null ) {
                    culture = CultureInfo.CurrentCulture;
                }
                string separator = culture.TextInfo.ListSeparator + " ";
                TypeConverter converter = TypeDescriptor.GetConverter( typeof( float ) );
                string[] textArray = new string[2];
                int num = 0;
                textArray[num++] = converter.ConvertToString( context, culture, pointf.X );
                textArray[num++] = converter.ConvertToString( context, culture, pointf.Y );
                return string.Join( separator, textArray );
            }
            if ( ( destinationType == typeof( InstanceDescriptor ) ) && ( value is PointF ) ) {
                PointF pointf2 = (PointF)value;
                ConstructorInfo member = typeof( PointF ).GetConstructor( new Type[] { typeof( float ), typeof( float ) } );
                if ( member != null ) {
                    return new InstanceDescriptor( member, new object[] { pointf2.X, pointf2.Y } );
                }
            }
            return base.ConvertTo( context, culture, value, destinationType );

        }
        /// <summary>
        /// 會使用指定的內容，建立與這個 <see cref="T:System.ComponentModel.TypeConverter" /> 關聯之型別的執行個體，並為物件設定了一組屬性值。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <param name="propertyValues">新屬性值的 <see cref="T:System.Collections.IDictionary" />。</param>
        /// <returns>
        ///   <see cref="T:System.Object" />，表示指定的 <see cref="T:System.Collections.IDictionary" />，如果無法建立物件，則為 null。這個方法永遠傳回 null。
        /// </returns>
        public override object CreateInstance( ITypeDescriptorContext context, IDictionary propertyValues ) {
            return new PointF( (float)propertyValues["X"], (float)propertyValues["Y"] );
        }
        /// <summary>
        /// 會使用指定的內容，傳回在這個物件上變更值是否需要呼叫 <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> 來建立新值。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <returns>
        /// 如果在這個物件上變更屬性需要呼叫 <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> 來建立新值，則為 true，否則為 false。
        /// </returns>
        public override bool GetCreateInstanceSupported( ITypeDescriptorContext context ) {
            return true;
        }
        /// <summary>
        /// 會使用指定的內容和屬性 (Attribute)，傳回由值參數所指定之陣列型別的屬性 (Property) 集合。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <param name="value"><see cref="T:System.Object" />，指定要為其取得屬性之陣列的型別。</param>
        /// <param name="attributes"><see cref="T:System.Attribute" /> 型別的陣列，可當做篩選條件使用。</param>
        /// <returns>
        ///   <see cref="T:System.ComponentModel.PropertyDescriptorCollection" />，具有為這個資料型別所公開的屬性，如果沒有屬性，則為 null。
        /// </returns>
        public override PropertyDescriptorCollection GetProperties( ITypeDescriptorContext context, object value, Attribute[] attributes ) {
            return TypeDescriptor.GetProperties( typeof( PointF ), attributes ).Sort( new string[] { "X", "Y" } );
        }
        /// <summary>
        /// 會使用指定的內容傳回數值，表示這個物件是否支援屬性。
        /// </summary>
        /// <param name="context">提供格式內容的 <see cref="T:System.ComponentModel.ITypeDescriptorContext" />。</param>
        /// <returns>
        /// 如果應該呼叫 <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> 以尋找這個物件的屬性，則為 true，否則為 false。
        /// </returns>
        public override bool GetPropertiesSupported( ITypeDescriptorContext context ) {
            return true;
        }
    }
} // namespace PGCafe.Object.UI
