using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGCafe;

namespace PGCafe.Object.EqualityComparer {

    /// <summary> EqualityComparer's static method. </summary>
    public static class EqualityComparer {
        
        /// <summary> Create an EqualityComparer&lt;T,TKeygrt;. </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="KeySelector"> Key Selector lambda. </param>
        public static EqualityComparer<T,TKey> Create<T,TKey>( Func<T,TKey> KeySelector ) {
            return new EqualityComparer<T,TKey>( KeySelector );
        } // public statis EqualityComparer<T,TKey> Create<T,TKey>( Func<T,TKey> KeySelector )
        
        /// <summary> Create an EqualityComparer&lt;Tgrt;. </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Comparer"> Comparer lambda. </param>
        /// <param name="HashGetter"> HashGetter of T. </param>
        public static EqualityComparer<T> Create<T>( Func<T,T,bool> Comparer, Func<T,int> HashGetter ) {
            return new EqualityComparer<T>( Comparer, HashGetter );
        } // public statis EqualityComparer<T> Create<T>( Func<T,T,bool> Comparer, Func<T,int> HashGetter )
        
        /// <summary> Create an EqualityComparer&lt;Tgrt;. </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Comparer"> Comparer lambda. </param>
        public static EqualityComparer<T> Create<T>( Func<T,T,bool> Comparer ) {
            return new EqualityComparer<T>( Comparer );
        } // public statis EqualityComparer<T> Create<T>( Func<T,T,bool> Comparer )

        #region Static Comparer

        /// <summary> Instance provide ignore case compare. </summary>
        public static EqualityComparer<string> IgnoreCaseComparer = EqualityComparer.Create<string>( ( item1, item2 ) => item1.EqualsIgnoreCase( item2 ) );

        #endregion

    } // public static class EqualityComparer

    /// <summary> Class of IEqualityComparer&lt;T,TKey&gt; </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class EqualityComparer<T,TKey> : IEqualityComparer<T> {
        
        /// <summary> Key Selector. </summary>
        protected readonly Func<T, TKey> mKeySelector;

        /// <summary> Create instance of IEqualityComparer&lt;T,TKey&gt; </summary>
        /// <param name="KeySelector"></param>
        public EqualityComparer( Func<T,TKey> KeySelector ) {
            mKeySelector = KeySelector;
        } // public EqualityComparer( Func<T,TKey> KeySelector )

        /// <summary> Equals method of Type T's Key </summary>
        /// <param name="x"> first item. </param>
        /// <param name="y"> second item. </param>
        /// <returns></returns>
        public bool Equals( T x, T y ) {
            return this.mKeySelector( x ).Equals( this.mKeySelector( y ) );
        } // public bool Equals( T x, T y )

        /// <summary> Get the hash code of T's Key. </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode( T obj ) {
            return this.mKeySelector( obj ).GetHashCode();
        } // public int GetHashCode( T obj )

    } // public class EqualityComparer<T> : IEqualityComparer<T>

    
    /// <summary> Class of IEqualityComparer&lt;T&gt; </summary>
    /// <typeparam name="T"></typeparam>
    public class EqualityComparer<T> : IEqualityComparer<T> {
        /// <summary> Comparer of T </summary>
        protected readonly Func<T,T,bool> mComparer;
        /// <summary> Get hashcode of T </summary>
        protected readonly Func<T,int> mGetHash;
        
        /// <summary> Create instance of IEqualityComparer&lt;T,TKey&gt; </summary>
        /// <param name="Comparer"></param>
        /// <param name="HashGetter"></param>
        public EqualityComparer( Func<T,T,bool> Comparer, Func<T,int> HashGetter ) {
            mComparer = Comparer;
            mGetHash = HashGetter;
        } // public EqualityComparer( Func<T,bool> Comparer, Func<T,int> HashGetter )
        
        /// <summary> Create instance of IEqualityComparer&lt;T,TKey&gt; </summary>
        /// <param name="Comparer"></param>
        public EqualityComparer( Func<T,T,bool> Comparer ) :
            this( Comparer, item => 0 ) {
        } // public EqualityComparer( Func<T,bool> Comparator )
        
        /// <summary> Equals method of Type T </summary>
        /// <param name="x"> first item. </param>
        /// <param name="y"> second item. </param>
        /// <returns></returns>
        public bool Equals( T x, T y ) {
            return mComparer( x, y );
        } // public bool Equals( T x, T y )
        
        /// <summary> Get the hash code of T. </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode( T obj ) {
            return mGetHash( obj );
        } // public int GetHashCode( T obj )

    } // public class EqualityComparer<T> : IEqualityComparer<T>


    /// <summary> Use EqualityComparer.Create to replace the linq extension with equality comparer. </summary>
    public static class EqualityComparerExtension {

        #region Create EqualityComparer by anonymous type

        /// <summary> Create CreateIEqualityComparer by Type T and compare function of T, the source can be null or any other value. </summary>
        /// <typeparam name="T"> type to create IEqualityComparer </typeparam>
        /// <param name="source"> source </param>
        /// <param name="Comparer"> comprer func to create IEqualityComparer. </param>
        /// <returns> T of IEqualityComparer </returns>
        public static IEqualityComparer<T> CreateComparer<T>( this T source, Func<T, T, bool> Comparer ) {
            return new EqualityComparer<T>( Comparer );
        } // public static IEqualityComparer<T> CreateComparer<T>( this T source, Func<T, T, bool> Comparer )


        /// <summary> Create CreateIEqualityComparer by Type T and KeySelector of T, the source can be null or any other value </summary>
        /// <typeparam name="T"> type to create IEqualityComparer </typeparam>
        /// <typeparam name="TKey"> Key of T to create IEqualityComparer </typeparam>
        /// <param name="source"> source </param>
        /// <param name="KeySelector"> function to select key in T. </param>
        /// <returns> T of IEqualityComparer </returns>
        public static IEqualityComparer<T> CreateComparer<T, TKey>( this T source, Func<T, TKey> KeySelector ) {
            return new EqualityComparer<T, TKey>( KeySelector );
        } // public static IEqualityComparer<T> CreateComparer<T>( this T source, Func<T, TKey> KeySelector )

        #endregion

        #region IEqualityComparer Linq Extension

        /// <summary> Determines whether a sequence contains a specified element by using a specified KeySelector. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> A sequence in which to locate a value. </param>
        /// <param name="value"> The value to locate in the sequence. </param>
        /// <param name="KeySelector"> A function to extract the key for each element. </param>
        /// <returns> true if the source sequence contains an element that has the specified value; otherwise, false. </returns>
        public static bool Contains<T, TKey>( this IEnumerable<T> source, T value, Func<T, TKey> KeySelector ) {
            return source.Contains( value, new EqualityComparer<T, TKey>( KeySelector ) );
        } // public static bool Contains<T,TKey>( this IEnumerable<T> source, T value, Func<T,TKey> KeySelector )
        
        /// <summary> Determines whether a sequence contains a specified element by using a specified KeySelector. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <param name="source"> A sequence in which to locate a value. </param>
        /// <param name="value"> The value to locate in the sequence. </param>
        /// <param name="Comparer"> A function to compare values. </param>
        /// <returns> true if the source sequence contains an element that has the specified value; otherwise, false. </returns>
        public static bool Contains<T>( this IEnumerable<T> source, T value, Func<T, T, bool> Comparer ) {
            return source.Contains( value, new EqualityComparer<T>( Comparer ) );
        } // public static bool Contains<T>( this IEnumerable<T> source, T value, Func<T,T,bool> Comparer )



        /// <summary> Returns distinct elements from a sequence by using a specified IEqualityComparer&lt;T&gt; to compare values. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> The sequence to remove duplicate elements from. </param>
        /// <param name="KeySelector"> A function to extract the key for each element. </param>
        /// <returns> An IEnumerable&lt;T&gt;that contains distinct elements from the source sequence. </returns>
        public static IEnumerable<T> Distinct<T, TKey>( this IEnumerable<T> source, Func<T, TKey> KeySelector ) {
            return source.Distinct( new EqualityComparer<T, TKey>( KeySelector ) );
        } // public static IEnumerable<T> Distinct<T,TKey>( this IEnumerable<T> source, Func<T,TKey> KeySelector )
        
        /// <summary> Returns distinct elements from a sequence by using a specified IEqualityComparer&lt;T&gt; to compare values. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <param name="source"> The sequence to remove duplicate elements from. </param>
        /// <param name="Comparer"> A function to compare values. </param>
        /// <returns> An IEnumerable&lt;T&gt;that contains distinct elements from the source sequence. </returns>
        public static IEnumerable<T> Distinct<T>( this IEnumerable<T> source, Func<T, T, bool> Comparer ) {
            return source.Distinct( new EqualityComparer<T>( Comparer ) );
        } // public static IEnumerable<T> Distinct<T>( this IEnumerable<T> source, Func<T,T,bool> Comparer )



        /// <summary> Produces the set difference of two sequences by using the specified IEqualityComparer&lt;T&gt; to compare values. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose elements that are not also in second will be returned. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence. </param>
        /// <param name="KeySelector"> A function to extract the key for each element. </param>
        /// <returns> A sequence that contains the set difference of the elements of two sequences. </returns>
        public static IEnumerable<T> Except<T, TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> KeySelector ) {
            return source.Except( second, new EqualityComparer<T, TKey>( KeySelector ) );
        } // public static IEnumerable<T> Except<T,TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,TKey> KeySelector )
        
        /// <summary> Produces the set difference of two sequences by using the specified IEqualityComparer&lt;T&gt; to compare values. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose elements that are not also in second will be returned. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence. </param>
        /// <param name="Comparer"> A function to compare values. </param>
        /// <returns> A sequence that contains the set difference of the elements of two sequences. </returns>
        public static IEnumerable<T> Except<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, bool> Comparer ) {
            return source.Except( second, new EqualityComparer<T>( Comparer ) );
        } // public static IEnumerable<T> Except<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,T,bool> Comparer )
        


        /// <summary> Produces the set intersection of two sequences by using the specified IEqualityComparer&lt;T&gt; to compare values. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose distinct elements that also appear in second will be returned. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; whose distinct elements that also appear in the first sequence will be returned. </param>
        /// <param name="KeySelector"> A function to extract the key for each element. </param>
        /// <returns> A sequence that contains the elements that form the set intersection of two sequences. </returns>
        public static IEnumerable<T> Intersect<T, TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> KeySelector ) {
            return source.Intersect( second, new EqualityComparer<T, TKey>( KeySelector ) );
        } // public static IEnumerable<T> Intersect<T,TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,TKey> KeySelector )
        
        /// <summary> Produces the set intersection of two sequences by using the specified IEqualityComparer&lt;T&gt; to compare values. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose distinct elements that also appear in second will be returned. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; whose distinct elements that also appear in the first sequence will be returned. </param>
        /// <param name="Comparer"> A function to compare values. </param>
        /// <returns> A sequence that contains the elements that form the set intersection of two sequences. </returns>
        public static IEnumerable<T> Intersect<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, bool> Comparer ) {
            return source.Intersect( second, new EqualityComparer<T>( Comparer ) );
        } // public static IEnumerable<T> Intersect<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,T,bool> Comparer )



        /// <summary> Determines whether two sequences are equal by comparing their elements by using a specified IEqualityComparer&lt;T&gt;. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> A sequence in which to locate a value. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; to compare to the first sequence. </param>
        /// <param name="KeySelector"> A function to extract the key for each element. </param>
        /// <returns> true if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, false. </returns>
        public static bool SequenceEqual<T, TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> KeySelector ) {
            return source.SequenceEqual( second, new EqualityComparer<T, TKey>( KeySelector ) );
        } // public static bool SequenceEqual<T,TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,TKey> KeySelector )
        
        /// <summary> Determines whether two sequences are equal by comparing their elements by using a specified IEqualityComparer&lt;T&gt;. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <param name="source"> A sequence in which to locate a value. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; to compare to the first sequence. </param>
        /// <param name="Comparer"> A function to compare values. </param>
        /// <returns> true if the two source sequences are of equal length and their corresponding elements compare equal according to comparer; otherwise, false. </returns>
        public static bool SequenceEqual<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, bool> Comparer ) {
            return source.SequenceEqual( second, new EqualityComparer<T>( Comparer ) );
        } // public static bool SequenceEqual<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,T,bool> Comparer )



        /// <summary> Creates a Dictionary&lt;TKey, TValue&gt; from an IEnumerable&lt;T&gt; according to a specified key selector function and key comparer. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; to create a Dictionary&lt;TKey, TValue&gt; from. </param>
        /// <param name="KeySelector"> A function to extract a key from each element. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> A Dictionary&lt;TKey, TValue&gt; that contains keys and values. </returns>
        public static Dictionary<TKey, T> ToDictionary<T, TKey>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.ToDictionary( KeySelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static Dictionary<TKey,T> ToDictionary<T,TKey>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<TKey,TKey,bool> KeyComparer )
        
        /// <summary> Creates a Dictionary&lt;TKey, TValue&gt; from an IEnumerable&lt;T&gt; according to a specified key selector function, a comparer, and an element selector function. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <typeparam name="TElement"> The type of the value returned by elementSelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; to create a Dictionary&lt;TKey, TValue&gt; from. </param>
        /// <param name="KeySelector"> A function to extract a key from each element. </param>
        /// <param name="ElementSelector"> A transform function to produce a result element value from each element. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> A Dictionary&lt;TKey, TValue&gt; that contains keys and values. </returns>
        public static Dictionary<TKey, TElement> ToDictionary<T, TKey, TElement>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<T, TElement> ElementSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.ToDictionary( KeySelector, ElementSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static Dictionary<TKey,TElement> ToDictionary<T,TKey,TElement>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<T,TElement> ElementSelector, Func<TKey,TKey,bool> KeyComparer )


        
        /// <summary> Creates a Lookup&lt;TKey, TElement&gt; from an IEnumerable&lt;T&gt; according to a specified key selector function and key comparer. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> The IEnumerable&lt;T&gt; to create a Lookup&lt;TKey, TElement&gt; from. </param>
        /// <param name="KeySelector"> A function to extract a key from each element. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> A Lookup&lt;TKey, TElement&gt; that contains values of type TElement selected from the input sequence. </returns>
        public static ILookup<TKey, T> ToLookup<T, TKey>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.ToLookup( KeySelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static ILookup<TKey,T> ToLookup<T,TKey>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<TKey,TKey,bool> KeyComparer )

        /// <summary> Creates a Lookup&lt;TKey, TElement&gt; from an IEnumerable&lt;T&gt; according to a specified key selector function, a comparer and an element selector function. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <typeparam name="TElement"> The type of the value returned by elementSelector. </typeparam>
        /// <param name="source"> The IEnumerable&lt;T&gt; to create a Lookup&lt;TKey, TElement&gt; from. </param>
        /// <param name="KeySelector"> A function to extract a key from each element. </param>
        /// <param name="ElementSelector"> A transform function to produce a result element value from each element. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> A Lookup&lt;TKey, TElement&gt; that contains values of type TElement selected from the input sequence. </returns>
        public static ILookup<TKey, TElement> ToLookup<T, TKey, TElement>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<T, TElement> ElementSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.ToLookup( KeySelector, ElementSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static ILookup<TKey,TElement> ToLookup<T,TKey,TElement>( this IEnumerable<T> source, Func<T, TKey> KeySelector, Func<T,TElement> ElementSelector, Func<TKey,TKey,bool> KeyComparer )



        /// <summary> Produces the set union of two sequences by using a specified IEqualityComparer&lt;T&gt;. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose distinct elements form the first set for the union. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; whose distinct elements form the second set for the union. </param>
        /// <param name="KeySelector"> A function to extract the key for each element. </param>
        /// <returns> An IEnumerable&lt;T&gt; that contains the elements from both input sequences, excluding duplicates. </returns>
        public static IEnumerable<T> Union<T, TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> KeySelector ) {
            return source.Union( second, new EqualityComparer<T, TKey>( KeySelector ) );
        } // public static IEnumerable<T> Union<T, TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> KeySelector )
        
        /// <summary> Produces the set union of two sequences by using a specified IEqualityComparer&lt;T&gt;. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose distinct elements form the first set for the union. </param>
        /// <param name="second"> An IEnumerable&lt;T&gt; whose distinct elements form the second set for the union. </param>
        /// <param name="Comparer"> A function to compare values. </param>
        /// <returns> An IEnumerable&lt;T&gt; that contains the elements from both input sequences, excluding duplicates. </returns>
        public static IEnumerable<T> Union<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, bool> Comparer ) {
            return source.Union( second, new EqualityComparer<T>( Comparer ) );
        } // public static IEnumerable<T> Union<T>( this IEnumerable<T> source, IEnumerable<T> second, Func<T,T,bool> Comparer )



        /// <summary> Groups the elements of a sequence according to a specified key selector function and compares the keys by using a specified comparer. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose elements to group. </param>
        /// <param name="keySelector"> A function to extract the key for each element. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each IGrouping&lt;TKey, TElement&gt; object contains a collection of objects and a key. </returns>
        public static IEnumerable<IGrouping<TKey,T>> GroupBy<T,TKey>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.GroupBy( keySelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static IEnumerable<IGrouping<TKey,T>> GroupBy<T,TKey>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<T, T, bool> KeyComparer )

        /// <summary> Groups the elements of a sequence according to a key selector function. The keys are compared by using a comparer and each group's elements are projected by using a specified function. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <typeparam name="TElement"> The type of the elements in the IGrouping&lt;TKey, TElement&gt;. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose elements to group. </param>
        /// <param name="keySelector"> A function to extract the key for each element. </param>
        /// <param name="elementSelector"> A function to map each source element to an element in an IGrouping&lt;TKey, TElement&gt;. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> An IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TElement)) in Visual Basic where each IGrouping&lt;TKey, TElement&gt; object contains a collection of objects of type TElement and a key. </returns>
        public static IEnumerable<IGrouping<TKey,TElement>> GroupBy<T,TKey,TElement>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<T,TElement> elementSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.GroupBy( keySelector, elementSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static IEnumerable<IGrouping<TKey,TElement>> GroupBy<T,TKey,TElement>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<T,TElement> elementSelector, Func<TKey, TKey, bool> KeyComparer )

        /// <summary> Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key.The keys are compared by using a specified comparer. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <typeparam name="TResult"> The type of the result value returned by resultSelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose elements to group. </param>
        /// <param name="keySelector"> A function to extract the key for each element. </param>
        /// <param name="resultSelector"> A function to create a result value from each group. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> A collection of elements of type TResult where each element represents a projection over a group and its key. </returns>
        public static IEnumerable<TResult> GroupBy<T,TKey,TResult>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<TKey,IEnumerable<T>,TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.GroupBy( keySelector, resultSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static IEnumerable<TResult> GroupBy<T,TKey,TResult>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<TKey,IEnumerable<T>,TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer )

        /// <summary> Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key.Key values are compared by using a specified comparer, and the elements of each group are projected by using a specified function. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by KeySelector. </typeparam>
        /// <typeparam name="TElement"> The type of the elements in the IGrouping&lt;TKey, TElement&gt;. </typeparam>
        /// <typeparam name="TResult"> The type of the result value returned by resultSelector. </typeparam>
        /// <param name="source"> An IEnumerable&lt;T&gt; whose elements to group. </param>
        /// <param name="keySelector"> A function to extract the key for each element. </param>
        /// <param name="elementSelector"> A function to map each source element to an element in an IGrouping&lt;TKey, TElement&gt;. </param>
        /// <param name="resultSelector"> A function to create a result value from each group. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> A collection of elements of type TResult where each element represents a projection over a group and its key. </returns>
        public static IEnumerable<TResult> GroupBy<T,TKey,TElement,TResult>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<T,TElement> elementSelector, Func<TKey,IEnumerable<TElement>,TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.GroupBy( keySelector, elementSelector, resultSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static IEnumerable<TResult> GroupBy<T,TKey,TElement,TResult>( this IEnumerable<T> source, Func<T,TKey> keySelector, Func<T,TElement> elementSelector, Func<TKey,IEnumerable<TElement>,TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer )
        


        /// <summary> Correlates the elements of two sequences based on matching keys. A specified IEqualityComparer&lt;T&gt; is used to compare keys. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TInner"> The type of the elements of the second sequence. </typeparam>
        /// <typeparam name="TKey"> The type of the keys returned by the key selector functions. </typeparam>
        /// <typeparam name="TResult"> The type of the result elements. </typeparam>
        /// <param name="source"> The first sequence to join. </param>
        /// <param name="inner"> The sequence to join to the first sequence. </param>
        /// <param name="outerKeySelector"> A function to extract the join key from each element of the first sequence. </param>
        /// <param name="innerKeySelector"> A function to extract the join key from each element of the second sequence. </param>
        /// <param name="resultSelector"> A function to create a result element from two matching elements. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> An IEnumerable&lt;T&gt; that has elements of type TResult that are obtained by performing an inner join on two sequences. </returns>
        public static IEnumerable<TResult> Join<T, TInner, TKey, TResult>( this IEnumerable<T> source, IEnumerable<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, TInner, TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.Join( inner, outerKeySelector, innerKeySelector, resultSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static IEnumerable<TResult> Join<T, TInner, TKey, TResult>( this IEnumerable<T> source, IEnumerable<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, TInner, TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer )
        

        
        /// <summary> Correlates the elements of two sequences based on key equality and groups the results. A specified IEqualityComparer&lt;T&gt; is used to compare keys. </summary>
        /// <typeparam name="T"> The type of the elements of source. </typeparam>
        /// <typeparam name="TInner"> The type of the elements of the second sequence. </typeparam>
        /// <typeparam name="TKey"> The type of the keys returned by the key selector functions. </typeparam>
        /// <typeparam name="TResult"> The type of the result elements. </typeparam>
        /// <param name="source"> The first sequence to join. </param>
        /// <param name="inner"> The sequence to join to the first sequence. </param>
        /// <param name="outerKeySelector"> A function to extract the join key from each element of the first sequence. </param>
        /// <param name="innerKeySelector"> A function to extract the join key from each element of the second sequence. </param>
        /// <param name="resultSelector"> A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence. </param>
        /// <param name="KeyComparer"> A function to compare keys. </param>
        /// <returns> An IEnumerable&lt;T&gt; that contains elements of type TResult that are obtained by performing a grouped join on two sequences. </returns>
        public static IEnumerable<TResult> GroupJoin<T, TInner, TKey, TResult>( this IEnumerable<T> source, IEnumerable<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer ) {
            return source.GroupJoin( inner, outerKeySelector, innerKeySelector, resultSelector, new EqualityComparer<TKey>( KeyComparer ) );
        } // public static IEnumerable<TResult> GroupJoin<T, TInner, TKey, TResult>( this IEnumerable<T> source, IEnumerable<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector, Func<TKey, TKey, bool> KeyComparer )
        
        #endregion

    } // public static class EqualityComparerExtension
    
} // namespace PGCafe.Object.EqualityComparer
