using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    /// <summary>
    /// Number's Extension.
    /// </summary>
    public static class NumberExtension {

        /// <summary> Determines whether the float value is integer. </summary>
        /// <param name="source">The source.</param>
        /// <param name="AllowErrorDigit">The allow error digit count.</param>
        /// <returns>
        ///   <c>true</c> if the the float value is integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger( this float source, int AllowErrorDigit = 2 ){
            return Math.Abs( source % 1 ) <= ( float.Epsilon * Math.Pow( 10, AllowErrorDigit ) );
        } // public static bool IsInteger( this float source, int AllowErrorDigit = 2 )
        
        /// <summary> Determines whether the double value is integer. </summary>
        /// <param name="source">The source.</param>
        /// <param name="AllowErrorDigit">The allow error digit count.</param>
        /// <returns>
        ///   <c>true</c> if the the double value is integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger( this double source, int AllowErrorDigit = 2 ){
            return Math.Abs( source % 1 ) <= ( double.Epsilon * Math.Pow( 10, AllowErrorDigit ) );
        } // public static bool IsInteger( this double source, int AllowErrorDigit = 2 )
        
        /// <summary> Determines whether the float value is integer. </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c> if the the float value is integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger( this decimal source ){
            return source % 1 == 0;
        } // public static bool IsInteger( this decimal source )

    } // public static class NumberExtension
} // namespace PGCafe
