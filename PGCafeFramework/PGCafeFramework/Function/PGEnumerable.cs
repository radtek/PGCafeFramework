using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {

    /// <summary> Exnumerable's Function </summary>
    public static class PGEnumerable {

        #region Enumrate

        /// <summary> Get list object with [From], [To], [Step], the Type T must have operator =, &lt;=, + </summary>
        /// <typeparam name="T"> T of result. ( etc. int, double... number ) </typeparam>
        /// <param name="From"> From object.( result will include this ) </param>
        /// <param name="To"> To object.( if the To = From + Step*x, then result will include this ) </param>
        /// <param name="Step"> the step between every object.</param>
        /// <returns></returns>
        public static IEnumerable<T> Enumerate<T>( T From, T To, T Step ) {
            for ( dynamic cur = From ; cur <= To ; cur = cur + Step )
                yield return cur;
        } // public static IEnumerable<T> Enumerate<T>( T From, T To, T Step )
        
        
        /// <summary> Get list object with [From], [To], [StepFunc], the Type T must have operator =, &lt;= </summary>
        /// <typeparam name="T"> T of result. ( etc. int, double... number ) </typeparam>
        /// <param name="From"> From object.( result will include this ) </param>
        /// <param name="To"> To object.( if the To = From + Step*x, then result will include this ) </param>
        /// <param name="StepFunc"> the step function.</param>
        /// <returns></returns>
        public static IEnumerable<T> Enumerate<T>( T From, T To, Func<T,T> StepFunc ) {
            for ( dynamic cur = From ; cur <= To ; cur = StepFunc( cur ) )
                yield return cur;
        } // public static IEnumerable<T> Enumerate<T>( T From, T To, Func<T,T> StepFunc )
        
        
        /// <summary> Get list object with [Seed], [StopFunc], [StepFunc], the Type T must have operator = </summary>
        /// <typeparam name="T"> T of result. ( etc. int, double... number ) </typeparam>
        /// <param name="From"> First object.( result will include this ) </param>
        /// <param name="Next"> Stop Function, enumrate will stop until this function return false. </param>
        /// <param name="To"> the step function.</param>
        /// <returns></returns>
        public static IEnumerable<T> Enumerate<T>( T From, Func<T,T> Next, Func<T,bool> To ) {
            for ( T cur = From ; To( cur ) ; cur = Next( cur ) )
                yield return cur;
        } // public static IEnumerable<T> Enumerate<T>( T From, Func<T,bool> Next, Func<T,T> To )

        #endregion
        
        /// <summary> Create Empty IEnumerable with type T, this method is use when the T is Anonymous Type. </summary>
        /// <typeparam name="T"> type of object </typeparam>
        /// <param name="TTypeObject"> the object of type, this object will not add to IEnumerable. </param>
        public static IEnumerable<T> Empty<T>( T TTypeObject ) {
            return new T[0];
        } // public static IEnumerable<T> Empty<T>( T TTypeObject )

        /// <summary> Create null IEnumerable with type T, this method is use when the T is Anonymous Type. </summary>
        /// <typeparam name="T"> type of object </typeparam>
        /// <param name="TTypeObject"> the object of type, this object will not add to IEnumerable. </param>
        public static IEnumerable<T> Null<T>( T TTypeObject ) {
            return null;
        } // public static IEnumerable<T> Null<T>( T TTypeObject )

    } // public static class PGEnumerable
} // namespace PGCafe
