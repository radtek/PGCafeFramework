using System;
using System.Collections.Generic;
using System.Linq;

namespace PGCafe.Object {

    /// <summary>
    /// List with two item. ( just inherit from List&lt;TupleS&lt;T1,T2&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    public class ListS<T1,T2> : List<TupleS<T1,T2>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        public void Add( T1 item1, T2 item2 ){
            base.Add( TupleS.Create( item1, item2 ) );
        } // public void Add( T1 item1, T2 item2 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2 ){
            return base.BinarySearch( TupleS.Create( item1, item2 ) );
        } // public void BinarySearch( T1 item1, T2 item2 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2 ){
            return base.Contains( TupleS.Create( item1, item2 ) );
        } // public void Contains( T1 item1, T2 item2 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2 ){
            return base.IndexOf( TupleS.Create( item1, item2 ) );
        } // public void IndexOf( T1 item1, T2 item2 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, int index ){
            return base.IndexOf( TupleS.Create( item1, item2 ), index );
        } // public void IndexOf( T1 item1, T2 item2, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2 ){
            base.Insert( index, TupleS.Create( item1, item2 ) );
        } // public void Insert( int index, T1 item1, T2 item2 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2 ){
            return base.LastIndexOf( TupleS.Create( item1, item2 ) );
        } // public void LastIndexOf( T1 item1, T2 item2 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2 ){
            return base.Remove( TupleS.Create( item1, item2 ) );
        } // public void Remove( T1 item1, T2 item2 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()

        #endregion

    } // public class ListS<T1,T2> : List<TupleS<T1,T2>>
    

    /// <summary>
    /// List with three item. ( just inherit from List&lt;TupleS&lt;T1,T2,T3&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    public class ListS<T1,T2,T3> : List<TupleS<T1,T2,T3>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2,T3>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        /// <param name="item3"> Third item of item to add. </param>
        public void Add( T1 item1, T2 item2, T3 item3 ){
            base.Add( TupleS.Create( item1, item2, item3 ) );
        } // public void Add( T1 item1, T2 item2, T3 item3 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2, T3 item3 ){
            return base.BinarySearch( TupleS.Create( item1, item2, item3 ) );
        } // public void BinarySearch( T1 item1, T2 item2, T3 item3 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2, T3 item3 ){
            return base.Contains( TupleS.Create( item1, item2, item3 ) );
        } // public void Contains( T1 item1, T2 item2, T3 item3 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3 ){
            return base.IndexOf( TupleS.Create( item1, item2, item3 ) );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, int index ){
            return base.IndexOf( TupleS.Create( item1, item2, item3 ), index );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2, item3 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2, T3 item3 ){
            base.Insert( index, TupleS.Create( item1, item2, item3 ) );
        } // public void Insert( int index, T1 item1, T2 item2, T3 item3 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3 ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3 ) );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2, item3 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <param name="item3"> Third item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2, T3 item3 ){
            return base.Remove( TupleS.Create( item1, item2, item3 ) );
        } // public void Remove( T1 item1, T2 item2, T3 item3 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()
        /// <summary>
        /// Get list of all item's Third item.
        /// </summary>
        /// <returns></returns>
        public List<T3> Item3List() {
            return this.Select( item => item.Item3 ).ToList();
        } // public List<T3> Item3List()

        #endregion

    } // public class ListS<T1,T2,T3> : List<TupleS<T1,T2,T3>>
    

    /// <summary>
    /// List with four item. ( just inherit from List&lt;TupleS&lt;T1,T2,T3,T4&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    public class ListS<T1,T2,T3,T4> : List<TupleS<T1,T2,T3,T4>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2,T3,T4>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        /// <param name="item3"> Third item of item to add. </param>
        /// <param name="item4"> Fourth item of item to add. </param>
        public void Add( T1 item1, T2 item2, T3 item3, T4 item4 ){
            base.Add( TupleS.Create( item1, item2, item3, item4 ) );
        } // public void Add( T1 item1, T2 item2, T3 item3, T4 item4 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4 ){
            return base.BinarySearch( TupleS.Create( item1, item2, item3, item4 ) );
        } // public void BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2, T3 item3, T4 item4 ){
            return base.Contains( TupleS.Create( item1, item2, item3, item4 ) );
        } // public void Contains( T1 item1, T2 item2, T3 item3, T4 item4 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4 ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4 ) );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4 ), index );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4 ){
            base.Insert( index, TupleS.Create( item1, item2, item3, item4 ) );
        } // public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4 ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4 ) );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2, item3, item4 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <param name="item3"> Third item of item to remove. </param>
        /// <param name="item4"> Fourth item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2, T3 item3, T4 item4 ){
            return base.Remove( TupleS.Create( item1, item2, item3, item4 ) );
        } // public void Remove( T1 item1, T2 item2, T3 item3, T4 item4 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()
        /// <summary>
        /// Get list of all item's Third item.
        /// </summary>
        /// <returns></returns>
        public List<T3> Item3List() {
            return this.Select( item => item.Item3 ).ToList();
        } // public List<T3> Item3List()
        /// <summary>
        /// Get list of all item's Fourth item.
        /// </summary>
        /// <returns></returns>
        public List<T4> Item4List() {
            return this.Select( item => item.Item4 ).ToList();
        } // public List<T4> Item4List()

        #endregion

    } // public class ListS<T1,T2,T3,T4> : List<TupleS<T1,T2,T3,T4>>
    

    /// <summary>
    /// List with five item. ( just inherit from List&lt;TupleS&lt;T1,T2,T3,T4,T5&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    public class ListS<T1,T2,T3,T4,T5> : List<TupleS<T1,T2,T3,T4,T5>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2,T3,T4,T5>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        /// <param name="item3"> Third item of item to add. </param>
        /// <param name="item4"> Fourth item of item to add. </param>
        /// <param name="item5"> Fifth item of item to add. </param>
        public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            base.Add( TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            return base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            return base.Contains( TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2, item3, item4, item5 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <param name="item3"> Third item of item to remove. </param>
        /// <param name="item4"> Fourth item of item to remove. </param>
        /// <param name="item5"> Fifth item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 ){
            return base.Remove( TupleS.Create( item1, item2, item3, item4, item5 ) );
        } // public void Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()
        /// <summary>
        /// Get list of all item's Third item.
        /// </summary>
        /// <returns></returns>
        public List<T3> Item3List() {
            return this.Select( item => item.Item3 ).ToList();
        } // public List<T3> Item3List()
        /// <summary>
        /// Get list of all item's Fourth item.
        /// </summary>
        /// <returns></returns>
        public List<T4> Item4List() {
            return this.Select( item => item.Item4 ).ToList();
        } // public List<T4> Item4List()
        /// <summary>
        /// Get list of all item's Fifth item.
        /// </summary>
        /// <returns></returns>
        public List<T5> Item5List() {
            return this.Select( item => item.Item5 ).ToList();
        } // public List<T5> Item5List()

        #endregion

    } // public class ListS<T1,T2,T3,T4,T5> : List<TupleS<T1,T2,T3,T4,T5>>
    

    /// <summary>
    /// List with six item. ( just inherit from List&lt;TupleS&lt;T1,T2,T3,T4,T5,T6&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    /// <typeparam name="T6"> type of Sixth item. </typeparam>
    public class ListS<T1,T2,T3,T4,T5,T6> : List<TupleS<T1,T2,T3,T4,T5,T6>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2,T3,T4,T5,T6>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        /// <param name="item3"> Third item of item to add. </param>
        /// <param name="item4"> Fourth item of item to add. </param>
        /// <param name="item5"> Fifth item of item to add. </param>
        /// <param name="item6"> Sixth item of item to add. </param>
        public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            base.Add( TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            return base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            return base.Contains( TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2, item3, item4, item5, item6 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <param name="item3"> Third item of item to remove. </param>
        /// <param name="item4"> Fourth item of item to remove. </param>
        /// <param name="item5"> Fifth item of item to remove. </param>
        /// <param name="item6"> Sixth item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 ){
            return base.Remove( TupleS.Create( item1, item2, item3, item4, item5, item6 ) );
        } // public void Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()
        /// <summary>
        /// Get list of all item's Third item.
        /// </summary>
        /// <returns></returns>
        public List<T3> Item3List() {
            return this.Select( item => item.Item3 ).ToList();
        } // public List<T3> Item3List()
        /// <summary>
        /// Get list of all item's Fourth item.
        /// </summary>
        /// <returns></returns>
        public List<T4> Item4List() {
            return this.Select( item => item.Item4 ).ToList();
        } // public List<T4> Item4List()
        /// <summary>
        /// Get list of all item's Fifth item.
        /// </summary>
        /// <returns></returns>
        public List<T5> Item5List() {
            return this.Select( item => item.Item5 ).ToList();
        } // public List<T5> Item5List()
        /// <summary>
        /// Get list of all item's Sixth item.
        /// </summary>
        /// <returns></returns>
        public List<T6> Item6List() {
            return this.Select( item => item.Item6 ).ToList();
        } // public List<T6> Item6List()

        #endregion

    } // public class ListS<T1,T2,T3,T4,T5,T6> : List<TupleS<T1,T2,T3,T4,T5,T6>>
    

    /// <summary>
    /// List with seven item. ( just inherit from List&lt;TupleS&lt;T1,T2,T3,T4,T5,T6,T7&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    /// <typeparam name="T6"> type of Sixth item. </typeparam>
    /// <typeparam name="T7"> type of Seventh item. </typeparam>
    public class ListS<T1,T2,T3,T4,T5,T6,T7> : List<TupleS<T1,T2,T3,T4,T5,T6,T7>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6,T7&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6,T7&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6,T7&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2,T3,T4,T5,T6,T7>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        /// <param name="item3"> Third item of item to add. </param>
        /// <param name="item4"> Fourth item of item to add. </param>
        /// <param name="item5"> Fifth item of item to add. </param>
        /// <param name="item6"> Sixth item of item to add. </param>
        /// <param name="item7"> Seventh item of item to add. </param>
        public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            base.Add( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            return base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            return base.Contains( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <param name="item3"> Third item of item to remove. </param>
        /// <param name="item4"> Fourth item of item to remove. </param>
        /// <param name="item5"> Fifth item of item to remove. </param>
        /// <param name="item6"> Sixth item of item to remove. </param>
        /// <param name="item7"> Seventh item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 ){
            return base.Remove( TupleS.Create( item1, item2, item3, item4, item5, item6, item7 ) );
        } // public void Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()
        /// <summary>
        /// Get list of all item's Third item.
        /// </summary>
        /// <returns></returns>
        public List<T3> Item3List() {
            return this.Select( item => item.Item3 ).ToList();
        } // public List<T3> Item3List()
        /// <summary>
        /// Get list of all item's Fourth item.
        /// </summary>
        /// <returns></returns>
        public List<T4> Item4List() {
            return this.Select( item => item.Item4 ).ToList();
        } // public List<T4> Item4List()
        /// <summary>
        /// Get list of all item's Fifth item.
        /// </summary>
        /// <returns></returns>
        public List<T5> Item5List() {
            return this.Select( item => item.Item5 ).ToList();
        } // public List<T5> Item5List()
        /// <summary>
        /// Get list of all item's Sixth item.
        /// </summary>
        /// <returns></returns>
        public List<T6> Item6List() {
            return this.Select( item => item.Item6 ).ToList();
        } // public List<T6> Item6List()
        /// <summary>
        /// Get list of all item's Seventh item.
        /// </summary>
        /// <returns></returns>
        public List<T7> Item7List() {
            return this.Select( item => item.Item7 ).ToList();
        } // public List<T7> Item7List()

        #endregion

    } // public class ListS<T1,T2,T3,T4,T5,T6,T7> : List<TupleS<T1,T2,T3,T4,T5,T6,T7>>
    

    /// <summary>
    /// List with eight item. ( just inherit from List&lt;TupleS&lt;T1,T2,T3,T4,T5,T6,T7,T8&gt;&gt; and provide some method to use. )
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    /// <typeparam name="T6"> type of Sixth item. </typeparam>
    /// <typeparam name="T7"> type of Seventh item. </typeparam>
    /// <typeparam name="T8"> type of Eighth item. </typeparam>
    public class ListS<T1,T2,T3,T4,T5,T6,T7,T8> : List<TupleS<T1,T2,T3,T4,T5,T6,T7,T8>> {
    
        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6,T7,T8&gt; class that is empty and has the default initial capacity.
        /// </summary>
        public ListS() : base() { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6,T7,T8&gt; class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"> The number of elements that new new list can initially store. </param>
        public ListS( int capacity ) : base( capacity ) { }

        /// <summary>
        /// Initializes a new instance of the List&lt;T1,T2,T3,T4,T5,T6,T7,T8&gt; class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"> The collection whose elements are copied to the new list. </param>
        public ListS( IEnumerable<TupleS<T1,T2,T3,T4,T5,T6,T7,T8>> collection ) : base( collection ) { }

        /// <summary>
        /// Add item to list.
        /// ( just call base.Add( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to add. </param>
        /// <param name="item2"> Second item of item to add. </param>
        /// <param name="item3"> Third item of item to add. </param>
        /// <param name="item4"> Fourth item of item to add. </param>
        /// <param name="item5"> Fifth item of item to add. </param>
        /// <param name="item6"> Sixth item of item to add. </param>
        /// <param name="item7"> Seventh item of item to add. </param>
        /// <param name="item8"> Eighth item of item to add. </param>
        public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            base.Add( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void Add( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        /// <summary>
        /// find item's index with binary search.
        /// ( just call base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="item8"> Eighth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            return base.BinarySearch( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void BinarySearch( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        /// <summary>
        /// find is list has item.
        /// ( just call base.Contains( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="item8"> Eighth item of item to find. </param>
        /// <returns> list has contains item or not. </returns>
        public bool Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            return base.Contains( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void Contains( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        /// <summary>
        /// find item's index in list.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="item8"> Eighth item of item to find. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        /// <summary>
        /// find item's index in list start with specific index.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="item8"> Eighth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index )

        /// <summary>
        /// find item's index in list start with specific index and specific item num.
        /// ( just call base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to find. </param>
        /// <param name="item2"> Second item of item to find. </param>
        /// <param name="item3"> Third item of item to find. </param>
        /// <param name="item4"> Fourth item of item to find. </param>
        /// <param name="item5"> Fifth item of item to find. </param>
        /// <param name="item6"> Sixth item of item to find. </param>
        /// <param name="item7"> Seventh item of item to find. </param>
        /// <param name="item8"> Eighth item of item to find. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index, int count ){
            return base.IndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index, count );
        } // public void IndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index, int count )

        /// <summary>
        /// insert item to list at index.
        /// ( just call base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="index"> insert at index. </param>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <param name="item8"> Eighth item of item to insert. </param>
        public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            base.Insert( index, TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void Insert( int index, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        /// <summary>
        /// find item's index in list from last.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <param name="item8"> Eighth item of item to insert. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        /// <summary>
        /// find item's index in list from last start with specific index.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <param name="item8"> Eighth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index )

        /// <summary>
        /// find item's index in list from last start with specific index and specific item num.
        /// ( just call base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index, count ) )
        /// </summary>
        /// <param name="item1"> First item of item to insert. </param>
        /// <param name="item2"> Second item of item to insert. </param>
        /// <param name="item3"> Third item of item to insert. </param>
        /// <param name="item4"> Fourth item of item to insert. </param>
        /// <param name="item5"> Fifth item of item to insert. </param>
        /// <param name="item6"> Sixth item of item to insert. </param>
        /// <param name="item7"> Seventh item of item to insert. </param>
        /// <param name="item8"> Eighth item of item to insert. </param>
        /// <param name="index"> find item start with index. </param>
        /// <param name="count"> find only count num of item. </param>
        /// <returns> index of item. </returns>
        public int LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index, int count ){
            return base.LastIndexOf( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ), index, count );
        } // public void LastIndexOf( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, int index, int count )

        /// <summary>
        /// remove first match item from list.
        /// ( just call base.Remove( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) ) )
        /// </summary>
        /// <param name="item1"> First item of item to remove. </param>
        /// <param name="item2"> Second item of item to remove. </param>
        /// <param name="item3"> Third item of item to remove. </param>
        /// <param name="item4"> Fourth item of item to remove. </param>
        /// <param name="item5"> Fifth item of item to remove. </param>
        /// <param name="item6"> Sixth item of item to remove. </param>
        /// <param name="item7"> Seventh item of item to remove. </param>
        /// <param name="item8"> Eighth item of item to remove. </param>
        /// <returns> has remove success or not. </returns>
        public bool Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 ){
            return base.Remove( TupleS.Create( item1, item2, item3, item4, item5, item6, item7, item8 ) );
        } // public void Remove( T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8 )

        
        
        #region GetItemList        

        /// <summary>
        /// Get list of all item's First item.
        /// </summary>
        /// <returns></returns>
        public List<T1> Item1List() {
            return this.Select( item => item.Item1 ).ToList();
        } // public List<T1> Item1List()
        /// <summary>
        /// Get list of all item's Second item.
        /// </summary>
        /// <returns></returns>
        public List<T2> Item2List() {
            return this.Select( item => item.Item2 ).ToList();
        } // public List<T2> Item2List()
        /// <summary>
        /// Get list of all item's Third item.
        /// </summary>
        /// <returns></returns>
        public List<T3> Item3List() {
            return this.Select( item => item.Item3 ).ToList();
        } // public List<T3> Item3List()
        /// <summary>
        /// Get list of all item's Fourth item.
        /// </summary>
        /// <returns></returns>
        public List<T4> Item4List() {
            return this.Select( item => item.Item4 ).ToList();
        } // public List<T4> Item4List()
        /// <summary>
        /// Get list of all item's Fifth item.
        /// </summary>
        /// <returns></returns>
        public List<T5> Item5List() {
            return this.Select( item => item.Item5 ).ToList();
        } // public List<T5> Item5List()
        /// <summary>
        /// Get list of all item's Sixth item.
        /// </summary>
        /// <returns></returns>
        public List<T6> Item6List() {
            return this.Select( item => item.Item6 ).ToList();
        } // public List<T6> Item6List()
        /// <summary>
        /// Get list of all item's Seventh item.
        /// </summary>
        /// <returns></returns>
        public List<T7> Item7List() {
            return this.Select( item => item.Item7 ).ToList();
        } // public List<T7> Item7List()
        /// <summary>
        /// Get list of all item's Eighth item.
        /// </summary>
        /// <returns></returns>
        public List<T8> Item8List() {
            return this.Select( item => item.Item8 ).ToList();
        } // public List<T8> Item8List()

        #endregion

    } // public class ListS<T1,T2,T3,T4,T5,T6,T7,T8> : List<TupleS<T1,T2,T3,T4,T5,T6,T7,T8>>
    



} // namespace PGCafe.Object
