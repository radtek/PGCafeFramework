using System;
using System.Collections.Generic;
using System.Linq;
using PGCafe.Object.EqualityComparer;

namespace PGCafe {
    /// <summary> Generic's Extension </summary>
    public static class GenericExtension {
        
        /// <summary> Check the object of T is in the list, this just call <see cref="System.Linq.Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/> </summary>
        /// <param name="source"> source </param>
        /// <param name="items"> item list to check is the object in. </param>
        /// <returns> return true if is in list, otherwise return false. </returns>
        public static bool IsIn<T>( this T source, params T[] items ){
            return items.Contains( source );
        } // public static bool IsIn( this T source, params T[] items )
        
        /// <summary> Check the object of T is in the list, this just call <see cref="System.Linq.Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/> </summary>
        /// <param name="source"> source </param>
        /// <param name="items"> item list to check is the object in. </param>
        /// <returns> return true if is in list, otherwise return false. </returns>
        public static bool IsIn<T>( this T source, IEnumerable<T> items ){
            return items.Contains( source );
        } // public static bool IsIn<T>( source T dis, IEnumerable<T> items )
                
        /// <summary> Check the object of T is in the list, this just call <see cref="System.Linq.Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/> </summary>
        /// <param name="source"> source </param>
        /// <param name="items"> item list to check is the object in. </param>
        /// <param name="comparer"> use the comparer to comparer string. </param>
        /// <returns> return true if is in list, otherwise return false. </returns>
        public static bool IsIn<T>( this T source, IEnumerable<T> items, IEqualityComparer<T> comparer ){
            return items.Contains( source, comparer );
        } // public static bool IsIn<T>( this T source, IEnumerable<T> items, IEqualityComparer<T> comparer )
                
        /// <summary> Check the object of T is in the list, this just call <see cref="System.Linq.Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/> </summary>
        /// <param name="source"> source </param>
        /// <param name="items"> item list to check is the object in. </param>
        /// <param name="comparer"> use the comparer to comparer string. </param>
        /// <returns> return true if is in list, otherwise return false. </returns>
        public static bool IsIn<T>( this T source, IEnumerable<T> items, Func<T,T,bool> comparer ){
            return items.Contains( source, EqualityComparer.Create( comparer ) );
        } // public static bool IsIn<T>( this T source, IEnumerable<T> items, Func<T,T,bool> comparer )

    } // public static class GenericExtension
} // namespace PGCafe
