using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    /// <summary>
    /// Char's Extension.
    /// </summary>
    public static class CharExtension {
        
        /// <summary> Repeat char n times. </summary>
        /// <param name="source"> char to repeat. </param>
        /// <param name="count"> repeat times. </param>
        /// <returns> Repeat char n times. </returns>
        public static string Repeat( this char source, int count ){
            return new string( source, count );
        } // public static string Repeat( this char source, int count )
        
        /// <summary>
        /// Check the char is in the list of char, this just call linq's extension method => .Contains( ... ).
        /// </summary>
        /// <param name="source"> char to be search </param>
        /// <param name="chars"> check is in the char list. </param>
        /// <returns> return true if is in list, otherwise return false. </returns>
        public static bool IsIn( this char source, params char[] chars ){
            return chars.Contains( source );
        } // public static bool IsIn( this char source, params char[] chars )
        
        /// <summary>
        /// Check the char is in the list of char, this just call linq's extension method => .Contains( ... ).
        /// </summary>
        /// <param name="source"> char to be search </param>
        /// <param name="chars"> check is in the char list. </param>
        /// <returns> return true if is in list, otherwise return false. </returns>
        public static bool IsIn( this char source, IEnumerable<char> chars ){
            return chars.Contains( source );
        } // public static bool IsIn( this char source, IEnumerable<char> chars )
        
    } // public static class CharExtension

} // namespace PGCafe
