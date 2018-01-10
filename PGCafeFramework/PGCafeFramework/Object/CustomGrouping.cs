using System.Collections.Generic;
using System.Linq;

namespace PGCafe.Object {

    /// <summary>
    /// Static method of ListGrouping
    /// </summary>
    public static class ListGrouping {
        
        /// <summary>
        /// Create a new instance of the <see cref="ListGrouping{TKey, TElement}"/> class.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="Elements">The elements.</param>
        public static ListGrouping<TKey, TElement> Create<TKey, TElement>( TKey Key, IEnumerable<TElement> Elements ) {
            return new ListGrouping<TKey, TElement>( Key, Elements );
        } // public static ListGrouping<TKey, TElement> Create<TKey, TElement>( TKey Key, IEnumerable<TElement> Elements )

    } // public static class ListGrouping

    /// <summary> Provide list group object inherit from List and IGrouping </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <seealso cref="System.Collections.Generic.List{TElement}" />
    /// <seealso cref="System.Linq.IGrouping{TKey, TElement}" />
    public class ListGrouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement> {

        /// <summary>
        /// get the key of <see cref="T:System.Linq.IGrouping`2" />。
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListGrouping{TKey, TElement}"/> class.
        /// </summary>
        public ListGrouping() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListGrouping{TKey, TElement}"/> class.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="Elements">The elements.</param>
        public ListGrouping( TKey Key, IEnumerable<TElement> Elements ){
            this.Key = Key;
            this.AddRange( Elements );
        } // public ListGrouping( TKey Key, IEnumerable<TElement> Elements )

    } // public class ListGrouping<TKey,TElement> : List<TElement>, IGrouping<TKey,TElement>

} // namespace PGCafe.Object
