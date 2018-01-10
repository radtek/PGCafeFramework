using System;
using System.Collections.Generic;
using System.Linq;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// IEnumrable's Extension
    /// </summary>
    public static class IEnumerableExtension {
        
        #region ContinuousGroupBy( IEnumerable<IGrouping<...>> )

        /// <summary>
        /// group the source by key, but the condition of items in same group is not only when key is same,
        /// but also the item need to be continuous.
        /// EX: 1, 1, 2, 2, 1, 1 => will return three group by each two element.( group Key is 1, 2, 1 )
        /// Not return two group by each key 1, 2.
        /// </summary>
        /// <typeparam name="TSource"> type of source </typeparam>
        /// <typeparam name="TKey"> type of key </typeparam>
        /// <param name="source"> source </param>
        /// <param name="keySelector"> to get key with each item in source. </param>
        public static IEnumerable<IGrouping<TKey, TSource>> ContinuousGroupBy<TSource,TKey>(
            this IEnumerable<TSource> source, Func<TSource,TKey> keySelector ) {
            
            return source.ContinuousGroupBy( keySelector, item => item, EqualityComparer<TKey>.Default );
        } // public static IEnumerable<IGrouping<TKey, TSource>> ContinuousGroupBy<TSource,TKey>( ...
        

        /// <summary>
        /// group the source by key, but the condition of items in same group is not only when key is same,
        /// but also the item need to be continuous.
        /// EX: 1, 1, 2, 2, 1, 1 => will return three group by each two element.( group Key is 1, 2, 1 )
        /// Not return two group by each key 1, 2.
        /// </summary>
        /// <typeparam name="TSource"> type of source </typeparam>
        /// <typeparam name="TKey"> type of key </typeparam>
        /// <param name="source"> source </param>
        /// <param name="keySelector"> function to get key from source. </param>
        /// <param name="comparer"> key's comparer. </param>
        public static IEnumerable<IGrouping<TKey, TSource>> ContinuousGroupBy<TSource,TKey>(
            this IEnumerable<TSource> source, Func<TSource,TKey> keySelector, IEqualityComparer<TKey> comparer ) {
            
            return source.ContinuousGroupBy( keySelector, item => item, comparer );
        } // public static IEnumerable<IGrouping<TKey, TSource>> ContinuousGroupBy<TSource,TKey>( ...
        

        /// <summary>
        /// group the source by key, but the condition of items in same group is not only when key is same,
        /// but also the item need to be continuous.
        /// EX: 1, 1, 2, 2, 1, 1 => will return three group by each two element.( group Key is 1, 2, 1 )
        /// Not return two group by each key 1, 2.
        /// </summary>
        /// <typeparam name="TSource"> type of source </typeparam>
        /// <typeparam name="TKey"> type of key </typeparam>
        /// <typeparam name="TElement"> type of element </typeparam>
        /// <param name="source"> source </param>
        /// <param name="keySelector"> function to get key from source. </param>
        /// <param name="elementSelector"> function to get element from source. </param>
        public static IEnumerable<IGrouping<TKey, TElement>> ContinuousGroupBy<TSource,TKey,TElement>(
            this IEnumerable<TSource> source, Func<TSource,TKey> keySelector, Func<TSource, TElement> elementSelector ) {
            
            return source.ContinuousGroupBy( keySelector, elementSelector, EqualityComparer<TKey>.Default );
        } // public static IEnumerable<IGrouping<TKey, TElement>> ContinuousGroupBy<TSource,TKey>( ...


        /// <summary>
        /// group the source by key, but the condition of items in same group is not only when key is same,
        /// but also the item need to be continuous.
        /// EX: 1, 1, 2, 2, 1, 1 => will return three group by each two element.( group Key is 1, 2, 1 )
        /// Not return two group by each key 1, 2.
        /// </summary>
        /// <typeparam name="TSource"> type of source </typeparam>
        /// <typeparam name="TKey"> type of key </typeparam>
        /// <typeparam name="TElement"> type of element </typeparam>
        /// <param name="source"> source </param>
        /// <param name="keySelector"> to get key with each item in source. </param>
        /// <param name="elementSelector"> to get element with each item in source. </param>
        /// <param name="comparer"> to compare key is same or not. </param>
        public static IEnumerable<IGrouping<TKey, TElement>> ContinuousGroupBy<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer ) {

            ListGrouping<TKey,TElement> curGroup = null;
            foreach ( var item in source ) {
                TKey key = keySelector( item );
                
                if ( curGroup == null ) {
                    curGroup = new ListGrouping<TKey, TElement>();
                    curGroup.Key = key;
                } // if
                else if ( !comparer.Equals( key, curGroup.Key ) ) {
                    yield return curGroup;
                    curGroup = new ListGrouping<TKey, TElement>();
                    curGroup.Key = key;
                } // else if

                curGroup.Add( elementSelector( item ) );
            } // foreach
            
            if ( curGroup != null ) yield return curGroup;
        } // public static IEnumerable<IGrouping<TKey, TElement>> ContinuousGroupBy<TSource, TKey, TElement>( ...

        #endregion



        /// <summary> Skip items of count at last. </summary>
        /// <typeparam name="T"> type of item in source list </typeparam>
        /// <param name="source"> source </param>
        /// <param name="count"> number of item to skip. </param>
        public static IEnumerable<T> SkipLast<T>( this IEnumerable<T> source, int count ) {
            var all = source.ToArray();
            for ( int i = 0 ; i < all.Length - count ; i++ )
                yield return all[i];
        } // public static IEnumerable<T> SkipLast<T>( this IEnumerable<T> source, int count )

        /// <summary> Take items of count at last. </summary>
        /// <typeparam name="T"> type of item in source list </typeparam>
        /// <param name="source"> source </param>
        /// <param name="count"> number of item to take. </param>
        public static IEnumerable<T> TakeLast<T>( this IEnumerable<T> source, int count ) {
            var all = source.ToArray();
            for ( int i = all.Length - count ; i < all.Length ; i++ )
                yield return all[i];
        } // public static IEnumerable<T> TakeLast<T>( this IEnumerable<T> source, int count )
        
        /// <summary> Take items of count, if count is more than item's count, get item start from the first again. </summary>
        /// <typeparam name="T"> type of item in source list </typeparam>
        /// <param name="source"> source </param>
        /// <param name="count"> number of item to take in circle. </param>
        public static IEnumerable<T> TakeCircle<T>( this IEnumerable<T> source, int count ) {
            var tmp = new List<T>(); // tmp list to save source's item, use when circle return item, to avoid Enumerate again.
            foreach( var item in source ) {
                if ( --count == -1 ) yield break ;
                tmp.Add( item );
                yield return item;
            } // foreach

            // if no any item in source, break.
            if ( tmp.Count == 0 ) yield break ;

            // when start circle, return it from list.
            while ( true ) {
                foreach( var item in tmp ) {
                    if ( --count == -1 ) yield break ;
                    yield return item;
                } // foreach
            } // while
        } // public static IEnumerable<T> TakeCircle<T>( this IEnumerable<T> source, int count )

        
        /// <summary> return empty IEnumerable of TSource. </summary>
        /// <typeparam name="TSource"> type of item in source list. </typeparam>
        /// <param name="source"> source </param>
        /// <returns> empty IEnumerable of TSource. </returns>
        public static IEnumerable<TSource> Empty<TSource>( this IEnumerable<TSource> source ){
            return Enumerable.Empty<TSource>();
        } // public static IEnumerable<TSource> Empty<TSource>( this IEnumerable<TSource> source )
        

        /// <summary>
        /// check the list is null or empty.
        /// </summary>
        /// <typeparam name="TSource"> type of item in source list. </typeparam>
        /// <param name="source"> source </param>
        /// <returns> is list is null or empty. </returns>
        public static bool IsNullOrEmpty<TSource>( this IEnumerable<TSource> source ){
            return source == null || !source.Any();
        } // public static bool IsNullOrEmpty<TSource>( this IEnumerable<TSource> source )


        /// <summary> return Empty <see cref="IEnumerable{TSource}"/> if the source is null, otherwise return source. </summary>
        /// <typeparam name="TSource"> type of item in source list. </typeparam>
        /// <param name="source"> source </param>
        /// <returns> empty <see cref="IEnumerable{TSource}"/> if source is null. </returns>
        public static IEnumerable<TSource> EmptyIfNull<TSource>( this IEnumerable<TSource> source ){
            return source ?? Enumerable.Empty<TSource>();
        } // public static IEnumerable<TSource> EmptyIfNull<TSource>( this IEnumerable<TSource> source )


        /// <summary> return null if the source is empty, otherwise return source. </summary>
        /// <typeparam name="TSource"> type of item in source list. </typeparam>
        /// <param name="source"> source </param>
        /// <returns> null if the source is empty, otherwise return source. </returns>
        public static IEnumerable<TSource> NullIfEmpty<TSource>( this IEnumerable<TSource> source ){
            if ( source.Any() ) return source;
            else return null;
        } // public static IEnumerable<TSource> NullIfEmpty<TSource>( this IEnumerable<TSource> source )
        

        /// <summary> Concatenates two sequences </summary>
        /// <typeparam name="T"> The type of the elements of the input sequences. </typeparam>
        /// <param name="first"> The first sequence to concatenate </param>
        /// <param name="second"> The second sequence to concatenate </param>
        /// <returns> is list is null or empty. </returns>
        public static IEnumerable<T> Concat<T>( this IEnumerable<T> first, params T[] second ) {
            return first.Concat( second.CastTo<IEnumerable<T>>() );
        } // public static IEnumerable<T> Concat<T>( this IEnumerable<T> first, params T[] second )


        /// <summary> Evalueate <see cref="IEnumerable{T}"/> if it hasn't been evalueate. </summary>
        /// <typeparam name="T">Type of IEnumerable</typeparam>
        /// <param name="source">The source.</param>
        /// <returns> IEnumerable where has been evalueate. </returns>
        public static IEnumerable<T> Evaluate<T>( this IEnumerable<T> source ) {
            if ( source is ICollection<T> ) return source;
            else return source.ToArray();
        } // public static IEnumerable<T> Evaluate<T>( this IEnumerable<T> source )


        /// <summary> Determines whether the source list has contains any item in found list. </summary>
        /// <typeparam name="T">Type of IEnumerable</typeparam>
        /// <param name="source">The source list.</param>
        /// <param name="found">The found list.</param>
        /// <returns> <c>true</c> if source list has contains any item in found list; otherwise, <c>false</c>. </returns>
        public static bool ContainsAny<T>( this IEnumerable<T> source, IEnumerable<T> found ) {
            return source.Intersect( found ).Any();
        } // public static bool ContainsAny<T>( this IEnumerable<T> source, IEnumerable<T> found )

        
        /// <summary> Determines whether the source list has contains all item in found list. </summary>
        /// <typeparam name="T">Type of IEnumerable</typeparam>
        /// <param name="source">The source list.</param>
        /// <param name="found">The found list.</param>
        /// <returns> <c>true</c> if source list has contains all item in found list; otherwise, <c>false</c>. </returns>
        public static bool ContainsAll<T>( this IEnumerable<T> source, IEnumerable<T> found ) {
            var sourceList = source.Evaluate();
            return found.All( item => sourceList.Contains( item ) );
        } // public static bool ContainsAll<T>( this IEnumerable<T> source, IEnumerable<T> found )

        /// <summary> Find indexes of item in <see cref="IEnumerable{T}"/>. </summary>
        /// <typeparam name="T"> item's type </typeparam>
        /// <param name="source"> source </param>
        /// <param name="predicate"> function to match item. </param>
        public static IEnumerable<int> IndexOf<T>( this IEnumerable<T> source, Func<T,bool> predicate ) {
            int index = 0;
            foreach ( var item in source ){
                if ( predicate( item ) )
                    yield return index;

                index++;
            } // foreach
        } // public static IEnumerable<int> IndexOf<T>( this IEnumerable<T> source, Func<T,bool> predicate )
        
        /// <summary> Get value of index in <see cref="IEnumerable{T}"/>, throw exception if index is out of range. </summary>
        /// <typeparam name="T"> item's type </typeparam>
        /// <param name="source"> source </param>
        /// <param name="index"> get value at index. </param>
        public static T ValueOf<T>( this IEnumerable<T> source, int index ) {
            return source.Skip( index ).First();
        } // public static T ValueOf<T>( this IEnumerable<T> source, int index )
        
        /// <summary> Get value of index in <see cref="IEnumerable{T}"/>, return null if index is out of range. </summary>
        /// <typeparam name="T"> item's type </typeparam>
        /// <param name="source"> source </param>
        /// <param name="index"> get value at index. </param>
        public static T ValueOfOrDefault<T>( this IEnumerable<T> source, int index ) {
            return source.Skip( index ).FirstOrDefault();
        } // public static T ValueOfOrDefault<T>( this IEnumerable<T> source, int index )

        #region WithIndex

        /// <summary> Item contains Index field in list </summary>
        /// <typeparam name="T"> Item's type </typeparam>
        public struct IndexEntity<T> {
            /// <summary> item's Value </summary>
            public T Value;
            /// <summary> item's Index in list. </summary>
            public int Index;
        } // public struct IndexEntity<T>
        
        /// <summary> Add index to each item in list. </summary>
        /// <typeparam name="T"> item's type </typeparam>
        /// <param name="source"> source </param>
        /// <param name="from"> number of index begin. </param>
        /// <param name="increase"> number of index increase </param>
        public static IEnumerable<IndexEntity<T>> WithIndex<T>( this IEnumerable<T> source, int from = 0, int increase = 1 ) {
            int index = from;
            foreach ( var item in source ) {
                yield return new IndexEntity<T>() {
                    Value = item,
                    Index = index,
                };

                index += increase;
            } // foreach
        } // public static IEnumerable<IndexEntity<T>> WithIndex<T>( this IEnumerable<T> source, int from = 0, int increase = 1 )
        
        #endregion


        /// <summary> Merges two sequences using the specified predicate function.
        /// ( for each item to max length of sequences,
        /// pass default value of type if count is more than shorter sequences ) </summary>
        /// <typeparam name="TFirst"> Type of first list. </typeparam>
        /// <typeparam name="TSecond"> Type of second list. </typeparam>
        /// <typeparam name="TResult"> Type of result. </typeparam>
        /// <param name="source"> The first sequence to merge. </param>
        /// <param name="second"> The second sequence to merge. </param>
        /// <param name="resultSelector"> A function that specifies how to merge the elements from the two sequences. </param>
        /// <returns></returns>
        public static IEnumerable<TResult> ZipMax<TFirst, TSecond, TResult>( this IEnumerable<TFirst> source, IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector ) {

            using ( IEnumerator<TFirst> enumerator = source.GetEnumerator() ) {
                using ( IEnumerator<TSecond> enumerator2 = second.GetEnumerator() ) {
                    bool hasNext1 = enumerator.MoveNext(), hasNext2 = enumerator2.MoveNext();
                    while ( hasNext1 || hasNext2 ) {
                        TFirst curValue1 = hasNext1 ? enumerator.Current : default( TFirst );
                        TSecond curValue2 = hasNext2 ? enumerator2.Current : default( TSecond );
                        yield return resultSelector( curValue1, curValue2 );

                        hasNext1 = enumerator.MoveNext();
                        hasNext2 = enumerator2.MoveNext();
                    } // while
                } // using
            } // using
            yield break;
        } // public static IEnumerable<TResult> ZipMax<TFirst,TSecond,TResult>( this IEnumerable<TFirst> source, IEnumerable<TSecond> second, ... )

    } // public static class IEnumerableExtension

} // namespace PGCafe
