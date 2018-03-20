using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PGCafe {
    /// <summary>
    /// Convert something to something or Check is can be convert or not.
    /// </summary>
    public static class ConvertExtension {

        /// <summary>
        /// Cast source to T use source As T, if cast fail return defaultValue.
        /// </summary>
        /// <typeparam name="T"> type to cast. </typeparam>
        /// <param name="source"> source </param>
        /// <param name="defaultValue"> return this if convert failed. </param>
        /// <returns> source of type T or defaultValue. </returns>
        public static T As<T>( this object source, T defaultValue = default( T ) ) where T : class {
            return source as T ?? defaultValue;
        } // public static T As<T>( this object source, T defaultValue = default( T ) ) where T : class

        /// <summary>
        /// Cast source to T use (T)source, if cast fail return defaultValue.
        /// </summary>
        /// <typeparam name="T"> type to cast. </typeparam>
        /// <param name="source"> source </param>
        /// <param name="defaultValue"> return this if convert failed. </param>
        /// <returns> source of type T or defaultValue. </returns>
        public static T CastTo<T>( this object source, T defaultValue = default( T ) ) {
            try { return (T)source; }
            catch { return defaultValue; }
        } // public static T CastTo<T>( this object source, T defaultValue = default( T ) )

        #region TryToType, ToType

        #region Generic

        /// <summary>
        /// Try convert source to Type T.
        /// if convert fail throw exception if [throwExceptionIfCannotConvert] is true, otherwise just return false.
        /// if convert success, set the result to [result].
        /// </summary>
        /// <param name="source"> Object to convert to T. </param>
        /// <param name="result"> result of convert object will be set if convert success. </param>
        /// <param name="throwExceptionIfCannotConvert"> if can not convert, throw NotSupportException. </param>
        /// <returns> T of object or default value. </returns>
        private static bool TryToType<T>( this object source, ref T result, bool throwExceptionIfCannotConvert ) {
            var TType = typeof( T );

            #region get result here ##if ( source is T || source == null || source is DBNull )
            // if source is null or is same type with T, return source direct.
            if ( source is T ) {
                result = (T)source;
                return true;
            } // if
            else if ( source == null ) {

                // if type is primitive type, can't convert from null
                if ( TType.IsPrimitive ) {
                    if ( throwExceptionIfCannotConvert ) // if need throw exception, throw it.
                        throw new NotSupportedException( $"null value can't convert to type {TType.FullName}" );
                    else // else return defaultValue.
                        return false;
                } // if

                // if type is not value type ( it can be null, return null. )
                else { // use default( T ) to avoid compiler error of "T maybe value type, and it can't be null."
                    result = default( T );
                    return true;
                } // else
            } // else if
            else if ( source is DBNull ) {

                // if type is primitive type, can't convert from null
                if ( TType.IsPrimitive ) {
                    if ( throwExceptionIfCannotConvert ) // if need throw exception, throw it.
                        throw new NotSupportedException( $"DBNull can't convert to type {TType.FullName}" );
                    else // else return defaultValue.
                        return false;
                } // if

                // if type is not value type ( it can be null, return null. )
                else { // use default( T ) to avoid compiler error of "T maybe value type, and it can't be null."
                    result = default( T );
                    return true;
                } // else
            } // else if
            #endregion

            // check source's type and T type is primitive or not.
            var sourceType = source.GetType();
            var sourceNullableType = Nullable.GetUnderlyingType( sourceType );
            var TNullableType = Nullable.GetUnderlyingType( TType );

            #region get result here ##if ( source is Primitive or Primitive? && T is Primitive or Primitive? )
            // special case of both type is primitive or nullable primitive.
            if ( sourceType.IsPrimitive || ( sourceNullableType?.IsPrimitive ?? false ) ) {
                if ( TType.IsPrimitive || ( TNullableType?.IsPrimitive ?? false ) ) {
                    result = (T)Convert.ChangeType( source, TNullableType ?? TType );
                    return true;
                } // if
            } // if
            #endregion
            

            #region get result here ##if ( source or T is decimal or decimal? && other one is [Primitive or Primitive? but not bool] )
            // special case of two type is decimal( not primitive ) and primitive type( but not boolean ).
            if ( ( source is decimal || source is decimal? )
                 && ( TType != typeof( bool ) && TType != typeof( bool? ) ) ) {
                if ( TType.IsPrimitive || ( TNullableType?.IsPrimitive ?? false ) ) {
                    result = (T)Convert.ChangeType( source, TNullableType ?? TType );
                    return true;
                } // if
            } // if
            else if ( ( TType == typeof( decimal ) || TType == typeof( decimal? ) )
                      && ( !( source is bool ) && !( source is bool? ) ) ) {
                if ( sourceType.IsPrimitive || ( sourceNullableType?.IsPrimitive ?? false ) ) {
                    result = (T)Convert.ChangeType( source, TNullableType ?? TType );
                    return true;
                } // if
            } // if
            #endregion

            
            #region get result here ##if ( source or T is decimal or decimal? && other one is bool or bool? )
            // special case of two type is decimal( not primitive ) and boolean.
            // decimal can't convert with bool by default.
            if ( ( source is decimal || source is decimal? )
                 && ( TType == typeof( bool ) || TType == typeof( bool? ) ) ) {
                result = (T)(object)Convert.ToBoolean( (decimal)source );
                return true;
            } // if
            else if ( ( TType == typeof( decimal ) || TType == typeof( decimal? ) )
                      && ( source is bool || source is bool ) ) {
                result = (T)(object)Convert.ToDecimal( (bool)source );
                return true;
            } // if
            #endregion

            
            #region get result here ##use converter
            // other case, convert it from converter.
            var converter = TypeDescriptor.GetConverter( TType );
            if ( converter == null ) {
                if ( throwExceptionIfCannotConvert ) throw new NotSupportedException( $"the type {TType.FullName} has no Converter" );
                else return false;
            } // if

            // check can convert or not.
            if ( !converter.CanConvertFrom( sourceType ) ) {
                // if can't convert, but the target type is string, call the ToString() method.
                if ( TType == typeof( string ) ) {
                    result = (T)(object)source.ToString();
                    return true;
                } // if
                // if can convert from string, convert source to string and try convert it from string.
                else if ( converter.CanConvertFrom( typeof ( string ) ) ) {
                    try {
                        result = (T)( converter.ConvertFrom( source.ToString() ) );
                        return true;
                    } catch ( Exception ex ) {
                        if ( throwExceptionIfCannotConvert )
                            throw new NotSupportedException( $"Convert fail.", ex );
                        else return false;
                    } // try-catch
                } // else if
                // else return false.
                else return false;
            } // if
            else {
                try {
                    result = (T)( converter.ConvertFrom( source ) );
                    return true;
                } catch ( Exception ex ) {
                    if ( throwExceptionIfCannotConvert )
                        throw new NotSupportedException( $"Convert fail.", ex );
                    else return false;
                } // try-catch
            } // else
            #endregion

        } // private static T TryToType<T>( this object source, ref T result, bool throwExceptionIfCannotConvert )
        


        /// <summary>
        /// Try convert source to Type T.
        /// return convert success or not.
        /// </summary>
        /// <param name="source"> Object to convert to T. </param>
        /// <param name="result"> result of convert object will be set if convert success. </param>
        /// <returns> T of object or default value. </returns>
        public static bool TryToType<T>( this object source, ref T result ) {
            return source.TryToType( ref result, false );
        } // public static bool TryToType<T>( this object source, ref T result )


        /// <summary> Test the object can convert to type or not. ( would try convert to type when test ) </summary>
        /// <param name="source"> Object to convert to T. </param>
        /// <returns> T of object or default value. </returns>
        public static bool CanToType<T>( this object source ) {
            T value = default( T );
            return source.TryToType( ref value, false );
        } // public static bool CanToType<T>( this object source )


        /// <summary>
        /// Try convert source to type T.
        /// return default value if convert fail.
        /// </summary>
        /// <param name="source"> Object to convert to T. </param>
        /// <param name="defaultValue"> if convert failed, return default value. </param>
        /// <returns> T of object or default value. </returns>
        public static T ToType<T>( this object source, T defaultValue ) {
            // try convert.
            T result = default( T ); // use default to create result, do not use defaultValue to avoid copy when T is struct.
            var success = source.TryToType( ref result, false );

            // if success return result, else return defaultValue.
            return success ? result : defaultValue;
        } // public static T ToType<T>( this object source, T defalutValue )

        
        /// <summary>
        /// Try convert source to type T.
        /// throw exception if convert fail.
        /// </summary>
        /// <param name="source"> Object to convert to T. </param>
        /// <returns> T of object or default value. </returns>
        public static T ToType<T>( this object source ) {
            // try convert.
            T result = default( T ); // use default to create result.
            var success = source.TryToType( ref result, true );

            // if success return result, else return defaultValue.
            return result;
        } // public static T ToType<T>( this object source )

        #endregion

        #region Non-Generic

        /// <summary> TryToType method list has created. </summary>
        private static Dictionary<Type,MethodInfo> mTryToTypeMethods = null;

        /// <summary> Makes the TryToType method and save it to reuse. </summary>
        /// <param name="Type">The type of generic method.</param>
        private static MethodInfo MakeGenericMethod( Type Type ) {
            mTryToTypeMethods = mTryToTypeMethods ?? new Dictionary<Type, MethodInfo>();

            // if not is exist, create and save it
            if ( !mTryToTypeMethods.ContainsKey( Type ) ) {
                var convertor = typeof( ConvertExtension ).GetMethods( BindingFlags.NonPublic | BindingFlags.Static )
                    .First( item => item.Name == nameof( ConvertExtension.TryToType ) && item.GetParameters().Count() == 3 )
                    .MakeGenericMethod( Type );

                mTryToTypeMethods.Add( Type, convertor );
            } // if

            // return convertor.
            return mTryToTypeMethods[Type];
        } // private static MethodInfo MakeGenericMethod( Type Type )
        

        /// <summary>
        /// Try convert source to Type.
        /// if convert fail throw exception if [throwExceptionIfCannotConvert] is true, otherwise just return false.
        /// if convert success, set the result to [result].
        /// </summary>
        /// <param name="source"> Object to convert to Type. </param>
        /// <param name="Type"> Object to convert to Type. </param>
        /// <param name="result"> result of convert object will be set if convert success. </param>
        /// <param name="throwExceptionIfCannotConvert"> if can not convert, throw NotSupportException. </param>
        /// <returns> Type of object or default value. </returns>
        private static bool TryToType( this object source, Type Type, ref object result, bool throwExceptionIfCannotConvert ) {
            // get convertor.
            var convertor = MakeGenericMethod( Type );

            // convert and set value.
            var args = new object[] { source, null, throwExceptionIfCannotConvert };
            try {
                var success = (bool)convertor.Invoke( null, args );
            
                // if success, set result to result object.
                if ( success ) result = args[1];

                // return success or not.
                return success;
            } catch ( System.Reflection.TargetInvocationException ex ){
                // iterator TargetInvocationException exception of dynamic invoke method.
                var actualException = ex.InnerException;
                throw actualException;
            } // try-catch
        } // private static bool TryToType( this object source, Type Type, ref object result, bool throwExceptionIfCannotConvert )
        

        /// <summary>
        /// Try convert source to Type.
        /// return convert success or not.
        /// </summary>
        /// <param name="source"> Object to convert to Type. </param>
        /// <param name="Type"> Object to convert to Type. </param>
        /// <param name="result"> result of convert object will be set if convert success. </param>
        /// <returns> Type of object or default value. </returns>
        public static bool TryToType( this object source, Type Type, ref object result ) {
            return source.TryToType( Type, ref result, false );
        } // public static bool TryToType( this object source, Type Type, ref object result )


        /// <summary>
        /// Try convert source to Type.
        /// return default value if convert fail.
        /// </summary>
        /// <param name="source"> Object to convert to Type. </param>
        /// <param name="Type"> Object to convert to Type. </param>
        /// <param name="defaultValue"> if convert failed, return default value. </param>
        /// <returns> Type of object or default value. </returns>
        public static object ToType( this object source, Type Type, object defaultValue ) {
            // try convert.
            object result = null;
            var success = source.TryToType( Type, ref result, false );

            // if success return result, else return defaultValue.
            return success ? result : defaultValue;
        } // public static object ToType<T>( this object source, Type Type, object defalutValue )

        
        /// <summary>
        /// Try convert source to Type.
        /// throw exception if convert fail.
        /// </summary>
        /// <param name="source"> Object to convert to Type. </param>
        /// <param name="Type"> Object to convert to Type. </param>
        /// <returns> Type of object or default value. </returns>
        public static object ToType( this object source, Type Type ) {
            // try convert.
            object result = null;
            var success = source.TryToType( Type, ref result, true );

            // if success return result, else return defaultValue.
            return result;
        } // public static object ToType( this object source, Type Type )

        #endregion
        
        #endregion
        
        #region StringAlignment <=> HorizontalAlignment

        /// <summary>
        /// Convert HorizontalAlignment to StringAlignment with Left to Near, Right to Far.
        /// Return default value if value is not Left, Center, Right.
        /// </summary>
        /// <param name="source"> Value to convert. </param>
        /// <param name="defaultValue"> if convert failed, return default value. </param>
        /// <returns> StringAlignment of HorizontalAlignment or default value. </returns>
        public static StringAlignment ToStringAlignment( this HorizontalAlignment source, StringAlignment defaultValue = StringAlignment.Near ) {
            switch ( source ) {
                case HorizontalAlignment.Left:
                    return StringAlignment.Near;
                case HorizontalAlignment.Center:
                    return StringAlignment.Center;
                case HorizontalAlignment.Right:
                    return StringAlignment.Far;
                default:
                    return defaultValue;
            } // switch
        } // public static StringAlignment ToStringAlignment( this HorizontalAlignment source, StringAlignment defaultValue = StringAlignment.Near )


        /// <summary>
        /// Convert StringAlignment to HorizontalAlignment with Near to Left, Far to Right.
        /// Return default value if value is not Near, Center, Far.
        /// </summary>
        /// <param name="source"> Value to convert. </param>
        /// <param name="defaultValue"> if convert failed, return default value. </param>
        /// <returns> HorizontalAlignment of StringAlignment or default value. </returns>
        public static HorizontalAlignment ToHorizontalAlignment( this StringAlignment source, HorizontalAlignment defaultValue = HorizontalAlignment.Left ) {
            switch ( source ) {
                case StringAlignment.Near:
                    return HorizontalAlignment.Left;
                case StringAlignment.Center:
                    return HorizontalAlignment.Center;
                case StringAlignment.Far:
                    return HorizontalAlignment.Right;
                default:
                    return defaultValue;
            } // switch
        } // public static StringAlignment ToHorizontalAlignment( this StringAlignment source, HorizontalAlignment defaultValue = HorizontalAlignment.Left )

        #endregion
        
        #region String To DateTime, 

        /// Reference From https://support.microsoft.com/zh-tw/kb/329488/zh-tw
        /// <summary>
        /// Convert String to DateTime with format.
        /// return null if convert fail.
        /// </summary>
        /// <param name="source"> String to convert to DateTime. </param>
        /// <param name="format"> format of date. </param>
        /// <returns> DateTime of String or default value. </returns>
        public static DateTime? ToDateTime( this string source, string format ) {
            DateTime result = DateTime.MinValue;
            var success = DateTime.TryParseExact( source, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out result );
            if ( success ) return result;
            else return null;
        } // public static DateTime? ToDateTime( this string source, string format )

        #endregion

        #region Nullable<T>.ToString

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this DateTime? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this DateTime? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this decimal? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this decimal? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this double? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this double? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this float? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this float? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this long? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this long? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this int? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this int? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this byte? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this byte? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this ulong? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this ulong? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this uint? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this uint? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this ushort? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this ushort? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this short? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this short? source, string Format )

        /// <summary> Call ToString( Format ) with source.Value, if source is null, return empty. </summary>
        /// <param name="source"> source </param>
        /// <param name="Format"> Format to convert to string. </param>
        public static string ToString( this sbyte? source, string Format ) {
            if ( source.HasValue ) return source.Value.ToString( Format );
            else return string.Empty;
        } // public static string ToString( this sbyte? source, string Format )

        #endregion
        
        #region CopyFrom

        private static void CopyProperty<T1, T2>( ref T1 source, ref T2 FromData,
            ICollection<string> ContainList, ICollection<string> ExceptList, BindingFlags BindingFlags ){
            
            Type T1Type = typeof( T1 ), T2Type = typeof( T2 );
            bool getNonPublic = BindingFlags.HasFlag( BindingFlags.NonPublic );

            // get property that only have public getter and setter.
            var t1Properties = T1Type.GetProperties( BindingFlags )
                .Where( item => item.GetSetMethod( getNonPublic ) != null )
                .Where( item => item.GetIndexParameters().IsNullOrEmpty() );
            var t2Properties = T2Type.GetProperties( BindingFlags )
                .Where( item => item.GetGetMethod( getNonPublic ) != null )
                .Where( item => item.GetIndexParameters().IsNullOrEmpty() );

            // for each property, try get value from datarow.
            foreach ( var t1Property in t1Properties ) {

                // if t2 property has no same name, continue.
                var t2Property = t2Properties.FirstOrDefault( item => item.Name == t1Property.Name );
                if ( t2Property == null ) continue;

                // if not contains in copy list, continue.
                if ( ContainList != null && !ContainList.Contains( t1Property.Name ) ) continue ;

                // if contains in this list, continue.
                if ( ExceptList != null && ExceptList.Contains( t1Property.Name ) ) continue ;

                // copy value.
                try {
                    // get value.
                    var valueObj = t2Property.GetValue( FromData, null );

                    // if is same type, just copy
                    if ( t1Property.PropertyType == t2Property.PropertyType ) {
                        t1Property.SetValue( source, valueObj, null );
                    } // if
                    else { // if is not same type, try to convert it.
                        // convert and set value.
                        var value = valueObj.ToType( t1Property.PropertyType, t1Property.PropertyType.DefaultValue() );
                        t1Property.SetValue( source, value, null );
                    } // else
                } catch {
                    continue;
                } // try-catch
            } // foreach
        } // private static void CopyProperty<T1, T2>( ref T1 source, ref T2 FromData, ... )

        private static void CopyField<T1, T2>( ref T1 source, ref T2 FromData,
            ICollection<string> ContainList, ICollection<string> ExceptList, BindingFlags BindingFlags ){
            
            Type T1Type = typeof( T1 ), T2Type = typeof( T2 );

            // get property that only have public getter and setter.
            var t1Fields = T1Type.GetFields( BindingFlags );
            var t2Fields = T2Type.GetFields( BindingFlags );

            // for each property, try get value from datarow.
            foreach ( var t1Field in t1Fields ) {

                // if t2 property has no same name, continue.
                var t2Field = t2Fields.FirstOrDefault( item => item.Name == t1Field.Name );
                if ( t2Field == null ) continue;

                // if not contains in copy list, continue.
                if ( ContainList != null && !ContainList.Contains( t1Field.Name ) ) continue ;

                // if contains in this list, continue.
                if ( ExceptList != null && ExceptList.Contains( t1Field.Name ) ) continue ;

                // copy value.
                try {
                    // get value.
                    var valueObj = t2Field.GetValue( FromData );

                    // if is same type, just copy
                    if ( t1Field.FieldType == t2Field.FieldType ) {
                        t1Field.SetValue( source, valueObj );
                    } // if
                    else { // if is not same type, try to convert it.
                        // convert and set value.
                        var value = valueObj.ToType( t1Field.FieldType, t1Field.FieldType.DefaultValue() );
                        t1Field.SetValue( source, value );
                    } // else
                } catch {
                    continue;
                } // try-catch
            } // foreach
        } // private static void CopyField<T1, T2>( ref T1 source, ref T2 FromData, ... )

        
        /// <summary> 
        /// Copy property or field from <paramref name="FromData"/> to <paramref name="source"/> and return source self.
        /// ( won't copy indexer property )
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="FromData"> Data to copy from </param>
        /// <param name="CopyProperty"> Copy property or not. </param>
        /// <param name="CopyField"> Copy field or not. </param>
        /// <param name="CopyNonPublic"> Copy non public property/field. ( if set it to true, will add BindingFlags.NonPublic to <paramref name="BindingFlags"/> ) </param>
        /// <param name="ContainList"> copy property/field only in this list. ( pass null to copy all property/field ) </param>
        /// <param name="ExceptList"> the property/field in this list will not copy. ( even it is in <paramref name="ContainList"/> </param>
        /// <param name="BindingFlags"> Specify binding attribute to get property and field. </param>
        public static T1 CopyFrom<T1, T2>( this T1 source, T2 FromData,
            bool CopyProperty = true, bool CopyField = false, bool CopyNonPublic = false,
            ICollection<string> ContainList = null, ICollection<string> ExceptList = null,
            BindingFlags BindingFlags = BindingFlags.Public | BindingFlags.Instance ) {
            
            if ( CopyNonPublic ) BindingFlags |= BindingFlags.NonPublic;

            if ( CopyProperty )
                ConvertExtension.CopyProperty( ref source, ref FromData, ContainList, ExceptList, BindingFlags );

            if ( CopyField )
                ConvertExtension.CopyField( ref source, ref FromData, ContainList, ExceptList, BindingFlags );

            return source;
        } // public static T1 CopyFrom<T1, T2>( this T1 source, T2 FromData ... )
        
        #endregion

    } // public static class ConvertExtension

    
} // namespace PGCafe
