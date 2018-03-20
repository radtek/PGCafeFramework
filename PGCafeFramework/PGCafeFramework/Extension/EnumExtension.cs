using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// Enum's Extension
    /// </summary>
    public static class EnumExtension {

        #region Description

        /// <summary> Get <see cref="DescriptionAttribute"/>'s description of enum, if no description, return <see cref="Enum.ToString()"/> </summary>
        /// <param name="value"> source to get description. </param>
        /// <returns> description </returns>
        public static string Description( this Enum value ) {
            if ( value == null ) throw new ArgumentNullException( nameof( value ) );

            FieldInfo fieldInfo = value.GetType().GetField( value.ToString() );
            DescriptionAttribute[] attributes = ( DescriptionAttribute[] ) fieldInfo.GetCustomAttributes( typeof( DescriptionAttribute ), false );

            return attributes?.FirstOrDefault()?.Description ?? value.ToString();
        } // public static string Description( this Enum value )
        

        /// <summary>
        /// Try parse string to enum with specify enum type, return default value if parse failed.
        /// Compare with string and enum's <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <typeparam name="T"> Type of Result Enum </typeparam>
        /// <param name="source"></param>
        /// <param name="defaultValue"> return this value if parse failed. </param>
        /// <param name="IgnoreCase"> Ignore case when compare with description. </param>
        public static T ToEnumByDescription<T>( this string source, T defaultValue = default( T ), bool IgnoreCase = false )
            where T : struct {
            if ( !typeof( T ).IsEnum ) throw new ArgumentException( $"Type {nameof( T )} should be Enum" );
            if ( source.IsNullOrWhiteSpace() ) return defaultValue;

            foreach ( T enumItem in Enum.GetValues( typeof( T ) ) )
                if ( string.Compare( ( enumItem as Enum ).Description(), source.Trim(), IgnoreCase ) == 0 )
                    return enumItem;
            
            return defaultValue;
        } // public static T ToEnumByDescription<T>( this string source, T defaultValue = default( T ), bool IgnoreCase = false )
        

        /// <summary>
        /// Try parse string to enum with specify enum type, return default value if parse failed.
        /// Compare with string and enum's <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="EnumType"> Enum type to convert from string by description</param>
        /// <param name="IgnoreCase"> Ignore case when compare with description. </param>
        public static Enum ToEnumByDescription( this string source, Type EnumType, bool IgnoreCase = false ) {
            if ( !EnumType.IsEnum ) throw new ArgumentException( $"Type {nameof( EnumType )} should be Enum" );
            if ( source.IsNullOrWhiteSpace() ) return null;

            foreach ( Enum enumItem in Enum.GetValues( EnumType ) )
                if ( string.Compare( ( enumItem as Enum ).Description(), source.Trim(), IgnoreCase ) == 0 )
                    return enumItem;

            return null;
        } // public static T ToEnumByDescription( this string source, Type EnumType, bool IgnoreCase = false )

        #endregion
        
        #region StringValue

        /// <summary> Get <see cref="EnumStringValueAttribute"/>'s Value of enum, if no StringValue, return <see cref="Enum.ToString()"/> </summary>
        /// <param name="value"> source to get StringValue. </param>
        /// <param name="Key"> Specific the key of <see cref="EnumStringValueAttribute"/> to get specific string value or pass null to get first string value of attribute. </param>
        /// <returns> StringValue </returns>
        private static IEnumerable<EnumStringValueAttribute> GetStringValueAttributes( this Enum value, string Key = null ) {
            var fieldInfo = value.GetType().GetField( value.ToString() );
            var attributes = ( EnumStringValueAttribute[] ) fieldInfo.GetCustomAttributes( typeof( EnumStringValueAttribute ), false );

            return attributes?.Where( item => Key == null || item.Key == Key );
        } // private static IEnumerable<EnumStringValueAttribute> GetStringValueAttributes( this Enum value, string Key = null )

        /// <summary> Get <see cref="EnumStringValueAttribute"/>'s Value of enum, if no StringValue, return <see cref="Enum.ToString()"/> </summary>
        /// <param name="value"> source to get StringValue. </param>
        /// <param name="Key"> Specific the key of <see cref="EnumStringValueAttribute"/> to get specific string value or pass null to get first string value of attribute. </param>
        /// <returns> StringValue </returns>
        public static string StringValue( this Enum value, string Key = null ) {
            if ( value == null ) throw new ArgumentNullException( nameof( value ) );

            var attributes = GetStringValueAttributes( value, Key );
            return attributes?.FirstOrDefault()?.Value ?? value.ToString();
        } // public static string StringValue( this Enum value, string Key = null )
        

        /// <summary>
        /// Try parse string to enum with specify enum type, return default value if parse failed.
        /// Compare with string and enum's <see cref="EnumStringValueAttribute"/>.
        /// </summary>
        /// <typeparam name="T"> Type of Result Enum </typeparam>
        /// <param name="source"></param>
        /// <param name="defaultValue"> return this value if parse failed. </param>
        /// <param name="IgnoreCase"> Ignore case when compare with StringValue. </param>
        /// <param name="Key"> Specific the key of <see cref="EnumStringValueAttribute"/> to convert by specific string value or pass null to convert by any string value. </param>
        public static T ToEnumByStringValue<T>( this string source, T defaultValue = default( T ), bool IgnoreCase = false, string Key = null )
            where T : struct {
            if ( !typeof( T ).IsEnum ) throw new ArgumentException( $"Type {nameof( T )} should be Enum" );
            if ( source.IsNullOrWhiteSpace() ) return defaultValue;

            foreach ( T enumItem in Enum.GetValues( typeof( T ) ) ){
                var attributes = GetStringValueAttributes( ( enumItem as Enum ), Key );
                var stringValues = attributes?.Where( item => Key == null || item.Key == Key ).Select( item => item.Value );
                foreach ( var stringValue in stringValues ){
                    if ( string.Compare( stringValue, source, IgnoreCase ) == 0 )
                        return enumItem;
                } // foreach
            } // foreach
            
            return defaultValue;
        } // public static T ToEnumByStringValue<T>( this string source, T defaultValue = default( T ), bool IgnoreCase = false, string Key = null )
        

        /// <summary>
        /// Try parse string to enum with specify enum type, return default value if parse failed.
        /// Compare with string and enum's <see cref="EnumStringValueAttribute"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="EnumType"> Enum type to convert from string by StringValue. </param>
        /// <param name="IgnoreCase"> Ignore case when compare with StringValue. </param>
        /// <param name="Key"> Specific the key of <see cref="EnumStringValueAttribute"/> to convert by specific string value or pass null to convert by any string value. </param>
        public static Enum ToEnumByStringValue( this string source, Type EnumType, bool IgnoreCase = false, string Key = null ) {
            if ( !EnumType.IsEnum ) throw new ArgumentException( $"Type {nameof( EnumType )} should be Enum" );
            if ( source.IsNullOrWhiteSpace() ) return null;
            
            foreach ( Enum enumItem in Enum.GetValues( EnumType ) ){
                var attributes = GetStringValueAttributes( ( enumItem as Enum ), Key );
                var stringValues = attributes?.Where( item => Key == null || item.Key == Key ).Select( item => item.Value );
                foreach ( var stringValue in stringValues ){
                    if ( string.Compare( stringValue, source, IgnoreCase ) == 0 )
                        return enumItem;
                } // foreach
            } // foreach

            return null;
        } // public static T ToEnumByStringValue( this string source, Type EnumType, bool IgnoreCase = false, string Key = null )

        #endregion

    } // public static class EnumExtension
} // namespace PGCafe
