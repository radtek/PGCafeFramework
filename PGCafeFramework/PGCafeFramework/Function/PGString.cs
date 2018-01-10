using System.Linq;
using PGCafe;

namespace PGCafe {

    /// <summary> Exnumerable's Function </summary>
    public static class PGString {
        
        /// <summary> return first not null or empty string. </summary>
        /// <param name="sources"> sources </param>
        public static string FirstNotNullOrEmpty( params string[] sources ) {
            return sources.FirstOrDefault( item => !item.IsNullOrEmpty() );
        } // public static string FirstNotNullOrEmpty( params string[] sources )
        
        /// <summary> return first not null or whitespace string. </summary>
        /// <param name="sources"> sources </param>
        public static string FirstNotNullOrWhiteSpace( params string[] sources ) {
            return sources.FirstOrDefault( item => !item.IsNullOrWhiteSpace() );
        } // public static string FirstNotNullOrWhiteSpace( params string[] sources )

    } // public static class PGString
} // namespace PGCafe
