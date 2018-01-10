using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    /// <summary>
    /// Change static method to non static method.
    /// </summary>
    public static class StaticExtension {
        
        #region Char Extension

        /// <summary> Indicates whether the specified Unicode character is categorized as a control character. </summary>
        /// <param name="source">source</param>
        public static bool IsControl( this char source ) {
            return Char.IsControl( source );
        } // public static bool IsControl( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a decimal digit. </summary>
        /// <param name="source">source</param>
        public static bool IsDigit( this char source ) {
            return Char.IsDigit( source );
        } // public static bool IsDigit( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a Unicode letter. </summary>
        /// <param name="source">source</param>
        public static bool IsLetter( this char source ) {
            return Char.IsLetter( source );
        } // public static bool IsLetter( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a letter or a decimal digit. </summary>
        /// <param name="source">source</param>
        public static bool IsLetterOrDigit( this char source ) {
            return Char.IsLetterOrDigit( source );
        } // public static bool IsLetterOrDigit( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a lowercase letter. </summary>
        /// <param name="source">source</param>
        public static bool IsLower( this char source ) {
            return Char.IsLower( source );
        } // public static bool IsLower( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a number. </summary>
        /// <param name="source">source</param>
        public static bool IsNumber( this char source ) {
            return Char.IsNumber( source );
        } // public static bool IsNumber( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a punctuation mark. </summary>
        /// <param name="source">source</param>
        public static bool IsPunctuation( this char source ) {
            return Char.IsPunctuation( source );
        } // public static bool IsPunctuation( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a separator character. </summary>
        /// <param name="source">source</param>
        public static bool IsSeparator( this char source ) {
            return Char.IsSeparator( source );
        } // public static bool IsSeparator( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as a symbol character. </summary>
        /// <param name="source">source</param>
        public static bool IsSymbol( this char source ) {
            return Char.IsSymbol( source );
        } // public static bool IsSymbol( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as an uppercase letter. </summary>
        /// <param name="source">source</param>
        public static bool IsUpper( this char source ) {
            return Char.IsUpper( source );
        } // public static bool IsUpper( this char source )

        /// <summary> Indicates whether the specified Unicode character is categorized as white space. </summary>
        /// <param name="source">source</param>
        public static bool IsWhiteSpace( this char source ) {
            return Char.IsWhiteSpace( source );
        } // public static bool IsWhiteSpace( this char source )

        /// <summary> Converts the value of a Unicode character to its lowercase equivalent. </summary>
        /// <param name="source">source</param>
        public static char ToLower( this char source ) {
            return Char.ToLower( source );
        } // public static char ToLower( this char source )

        /// <summary> Converts the value of a Unicode character to its uppercase equivalent. </summary>
        /// <param name="source">source</param>
        public static char ToUpper( this char source ) {
            return Char.ToUpper( source );
        } // public static char ToUpper( this char source )

        #endregion
        
        #region String Extension

        /// <summary>
        /// check the string is null or empty. ( same with static method string.IsNullOrEmpty( ... ) )
        /// </summary>
        /// <param name="dis"> string object to check. </param>
        /// <returns> return true if string is null or empty, else return false.</returns>
        public static bool IsNullOrEmpty( this string dis ){
            return string.IsNullOrEmpty( dis );
        } // public static bool IsNullOrEmpty( this string dis )
        
        /// <summary>
        /// check the string is null or whitespace. ( same with static method string.IsNullOrWhiteSpace( ... ) )
        /// </summary>
        /// <param name="dis"> string object to check. </param>
        /// <returns> return true if string is null or whitespace, else return false.</returns>
        public static bool IsNullOrWhiteSpace( this string dis ){
            return string.IsNullOrWhiteSpace( dis );
        } // public static bool IsNullOrWhiteSpace( this string dis )

        #endregion

        #region Double Extension

        /// <summary> Returns a value that indicates whether the specified value is not a number (double.NaN). </summary>
        /// <param name="source">source</param>
        public static bool IsNaN( this double source ) {
            return double.IsNaN( source );
        } // public static bool IsNaN( this double source )
        
        /// <summary> Returns a value indicating whether the specified number evaluates to negative or positive infinity. </summary>
        /// <param name="source">source</param>
        public static bool IsInfinity( this double source ) {
            return double.IsInfinity( source );
        } // public static bool IsInfinity( this double source )
        
        /// <summary> Returns a value indicating whether the specified number evaluates to positive infinity. </summary>
        /// <param name="source">source</param>
        public static bool IsPositiveInfinity( this double source ) {
            return double.IsPositiveInfinity( source );
        } // public static bool IsPositiveInfinity( this double source )
        
        /// <summary> Returns a value indicating whether the specified number evaluates to negative infinity. </summary>
        /// <param name="source">source</param>
        public static bool IsNegativeInfinity( this double source ) {
            return double.IsNegativeInfinity( source );
        } // public static bool IsNegativeInfinity( this double source )

        #endregion

    } // public static class StaticExtension
} // namespace PGCafe
