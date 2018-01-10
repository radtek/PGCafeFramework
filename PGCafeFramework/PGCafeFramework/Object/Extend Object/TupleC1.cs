using System;
using System.Collections.Generic;
using System.Linq;

namespace PGCafe.Object {

    /// <summary> TupleC static function </summary> 
    public static class TupleC {

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        public static TupleC<T1,T2> Create<T1,T2>( T1 Item1, T2 Item2 ) {
            return new TupleC<T1,T2>( Item1, Item2 );
        } // public static TupleC<T1,T2> Create<T1,T2>( T1 Item1, T2 Item2 )

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <typeparam name="T3"> type of Third item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        public static TupleC<T1,T2,T3> Create<T1,T2,T3>( T1 Item1, T2 Item2, T3 Item3 ) {
            return new TupleC<T1,T2,T3>( Item1, Item2, Item3 );
        } // public static TupleC<T1,T2,T3> Create<T1,T2,T3>( T1 Item1, T2 Item2, T3 Item3 )

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <typeparam name="T3"> type of Third item. </typeparam>
        /// <typeparam name="T4"> type of Fourth item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        public static TupleC<T1,T2,T3,T4> Create<T1,T2,T3,T4>( T1 Item1, T2 Item2, T3 Item3, T4 Item4 ) {
            return new TupleC<T1,T2,T3,T4>( Item1, Item2, Item3, Item4 );
        } // public static TupleC<T1,T2,T3,T4> Create<T1,T2,T3,T4>( T1 Item1, T2 Item2, T3 Item3, T4 Item4 )

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <typeparam name="T3"> type of Third item. </typeparam>
        /// <typeparam name="T4"> type of Fourth item. </typeparam>
        /// <typeparam name="T5"> type of Fifth item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        public static TupleC<T1,T2,T3,T4,T5> Create<T1,T2,T3,T4,T5>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5 ) {
            return new TupleC<T1,T2,T3,T4,T5>( Item1, Item2, Item3, Item4, Item5 );
        } // public static TupleC<T1,T2,T3,T4,T5> Create<T1,T2,T3,T4,T5>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5 )

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <typeparam name="T3"> type of Third item. </typeparam>
        /// <typeparam name="T4"> type of Fourth item. </typeparam>
        /// <typeparam name="T5"> type of Fifth item. </typeparam>
        /// <typeparam name="T6"> type of Sixth item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        /// <param name="Item6"> Sixth item </param>
        public static TupleC<T1,T2,T3,T4,T5,T6> Create<T1,T2,T3,T4,T5,T6>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6 ) {
            return new TupleC<T1,T2,T3,T4,T5,T6>( Item1, Item2, Item3, Item4, Item5, Item6 );
        } // public static TupleC<T1,T2,T3,T4,T5,T6> Create<T1,T2,T3,T4,T5,T6>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6 )

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <typeparam name="T3"> type of Third item. </typeparam>
        /// <typeparam name="T4"> type of Fourth item. </typeparam>
        /// <typeparam name="T5"> type of Fifth item. </typeparam>
        /// <typeparam name="T6"> type of Sixth item. </typeparam>
        /// <typeparam name="T7"> type of Seventh item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        /// <param name="Item6"> Sixth item </param>
        /// <param name="Item7"> Seventh item </param>
        public static TupleC<T1,T2,T3,T4,T5,T6,T7> Create<T1,T2,T3,T4,T5,T6,T7>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7 ) {
            return new TupleC<T1,T2,T3,T4,T5,T6,T7>( Item1, Item2, Item3, Item4, Item5, Item6, Item7 );
        } // public static TupleC<T1,T2,T3,T4,T5,T6,T7> Create<T1,T2,T3,T4,T5,T6,T7>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7 )

        /// <summary> Create TupleC with specify item. </summary>
        /// <typeparam name="T1"> type of First item. </typeparam>
        /// <typeparam name="T2"> type of Second item. </typeparam>
        /// <typeparam name="T3"> type of Third item. </typeparam>
        /// <typeparam name="T4"> type of Fourth item. </typeparam>
        /// <typeparam name="T5"> type of Fifth item. </typeparam>
        /// <typeparam name="T6"> type of Sixth item. </typeparam>
        /// <typeparam name="T7"> type of Seventh item. </typeparam>
        /// <typeparam name="T8"> type of Eighth item. </typeparam>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        /// <param name="Item6"> Sixth item </param>
        /// <param name="Item7"> Seventh item </param>
        /// <param name="Item8"> Eighth item </param>
        public static TupleC<T1,T2,T3,T4,T5,T6,T7,T8> Create<T1,T2,T3,T4,T5,T6,T7,T8>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7, T8 Item8 ) {
            return new TupleC<T1,T2,T3,T4,T5,T6,T7,T8>( Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8 );
        } // public static TupleC<T1,T2,T3,T4,T5,T6,T7,T8> Create<T1,T2,T3,T4,T5,T6,T7,T8>( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7, T8 Item8 )

     } // public static class TupleC

    /// <summary>
    /// Tuple with two item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    public class TupleC<T1,T2> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }

        /// <summary> Create Class And Writeable Tuple by two Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        public TupleC( T1 Item1, T2 Item2 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
        } // public TupleC( T1 Item1, T2 Item2 )
    } // public class TupleC<T1,T2>


    /// <summary>
    /// Tuple with three item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    public class TupleC<T1,T2,T3> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;
        private readonly T3 mItem3;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }
        /// <summary> Item3 </summary>
        public T3 Item3 { get { return this.mItem3; } }

        /// <summary> Create Class And Writeable Tuple by three Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        public TupleC( T1 Item1, T2 Item2, T3 Item3 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
            this.mItem3 = Item3;
        } // public TupleC( T1 Item1, T2 Item2, T3 Item3 )
    } // public class TupleC<T1,T2>


    /// <summary>
    /// Tuple with four item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    public class TupleC<T1,T2,T3,T4> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;
        private readonly T3 mItem3;
        private readonly T4 mItem4;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }
        /// <summary> Item3 </summary>
        public T3 Item3 { get { return this.mItem3; } }
        /// <summary> Item4 </summary>
        public T4 Item4 { get { return this.mItem4; } }

        /// <summary> Create Class And Writeable Tuple by four Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
            this.mItem3 = Item3;
            this.mItem4 = Item4;
        } // public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4 )
    } // public class TupleC<T1,T2>


    /// <summary>
    /// Tuple with five item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    public class TupleC<T1,T2,T3,T4,T5> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;
        private readonly T3 mItem3;
        private readonly T4 mItem4;
        private readonly T5 mItem5;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }
        /// <summary> Item3 </summary>
        public T3 Item3 { get { return this.mItem3; } }
        /// <summary> Item4 </summary>
        public T4 Item4 { get { return this.mItem4; } }
        /// <summary> Item5 </summary>
        public T5 Item5 { get { return this.mItem5; } }

        /// <summary> Create Class And Writeable Tuple by five Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
            this.mItem3 = Item3;
            this.mItem4 = Item4;
            this.mItem5 = Item5;
        } // public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5 )
    } // public class TupleC<T1,T2>


    /// <summary>
    /// Tuple with six item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    /// <typeparam name="T6"> type of Sixth item. </typeparam>
    public class TupleC<T1,T2,T3,T4,T5,T6> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;
        private readonly T3 mItem3;
        private readonly T4 mItem4;
        private readonly T5 mItem5;
        private readonly T6 mItem6;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }
        /// <summary> Item3 </summary>
        public T3 Item3 { get { return this.mItem3; } }
        /// <summary> Item4 </summary>
        public T4 Item4 { get { return this.mItem4; } }
        /// <summary> Item5 </summary>
        public T5 Item5 { get { return this.mItem5; } }
        /// <summary> Item6 </summary>
        public T6 Item6 { get { return this.mItem6; } }

        /// <summary> Create Class And Writeable Tuple by six Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        /// <param name="Item6"> Sixth item </param>
        public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
            this.mItem3 = Item3;
            this.mItem4 = Item4;
            this.mItem5 = Item5;
            this.mItem6 = Item6;
        } // public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6 )
    } // public class TupleC<T1,T2>


    /// <summary>
    /// Tuple with seven item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    /// <typeparam name="T6"> type of Sixth item. </typeparam>
    /// <typeparam name="T7"> type of Seventh item. </typeparam>
    public class TupleC<T1,T2,T3,T4,T5,T6,T7> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;
        private readonly T3 mItem3;
        private readonly T4 mItem4;
        private readonly T5 mItem5;
        private readonly T6 mItem6;
        private readonly T7 mItem7;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }
        /// <summary> Item3 </summary>
        public T3 Item3 { get { return this.mItem3; } }
        /// <summary> Item4 </summary>
        public T4 Item4 { get { return this.mItem4; } }
        /// <summary> Item5 </summary>
        public T5 Item5 { get { return this.mItem5; } }
        /// <summary> Item6 </summary>
        public T6 Item6 { get { return this.mItem6; } }
        /// <summary> Item7 </summary>
        public T7 Item7 { get { return this.mItem7; } }

        /// <summary> Create Class And Writeable Tuple by seven Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        /// <param name="Item6"> Sixth item </param>
        /// <param name="Item7"> Seventh item </param>
        public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
            this.mItem3 = Item3;
            this.mItem4 = Item4;
            this.mItem5 = Item5;
            this.mItem6 = Item6;
            this.mItem7 = Item7;
        } // public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7 )
    } // public class TupleC<T1,T2>


    /// <summary>
    /// Tuple with eight item ( class Type, and item is writeable
    /// </summary>
    /// <typeparam name="T1"> type of First item. </typeparam>
    /// <typeparam name="T2"> type of Second item. </typeparam>
    /// <typeparam name="T3"> type of Third item. </typeparam>
    /// <typeparam name="T4"> type of Fourth item. </typeparam>
    /// <typeparam name="T5"> type of Fifth item. </typeparam>
    /// <typeparam name="T6"> type of Sixth item. </typeparam>
    /// <typeparam name="T7"> type of Seventh item. </typeparam>
    /// <typeparam name="T8"> type of Eighth item. </typeparam>
    public class TupleC<T1,T2,T3,T4,T5,T6,T7,T8> {
        private readonly T1 mItem1;
        private readonly T2 mItem2;
        private readonly T3 mItem3;
        private readonly T4 mItem4;
        private readonly T5 mItem5;
        private readonly T6 mItem6;
        private readonly T7 mItem7;
        private readonly T8 mItem8;

        /// <summary> Item1 </summary>
        public T1 Item1 { get { return this.mItem1; } }
        /// <summary> Item2 </summary>
        public T2 Item2 { get { return this.mItem2; } }
        /// <summary> Item3 </summary>
        public T3 Item3 { get { return this.mItem3; } }
        /// <summary> Item4 </summary>
        public T4 Item4 { get { return this.mItem4; } }
        /// <summary> Item5 </summary>
        public T5 Item5 { get { return this.mItem5; } }
        /// <summary> Item6 </summary>
        public T6 Item6 { get { return this.mItem6; } }
        /// <summary> Item7 </summary>
        public T7 Item7 { get { return this.mItem7; } }
        /// <summary> Item8 </summary>
        public T8 Item8 { get { return this.mItem8; } }

        /// <summary> Create Class And Writeable Tuple by eight Item. </summary>
        /// <param name="Item1"> First item </param>
        /// <param name="Item2"> Second item </param>
        /// <param name="Item3"> Third item </param>
        /// <param name="Item4"> Fourth item </param>
        /// <param name="Item5"> Fifth item </param>
        /// <param name="Item6"> Sixth item </param>
        /// <param name="Item7"> Seventh item </param>
        /// <param name="Item8"> Eighth item </param>
        public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7, T8 Item8 ){
            this.mItem1 = Item1;
            this.mItem2 = Item2;
            this.mItem3 = Item3;
            this.mItem4 = Item4;
            this.mItem5 = Item5;
            this.mItem6 = Item6;
            this.mItem7 = Item7;
            this.mItem8 = Item8;
        } // public TupleC( T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7, T8 Item8 )
    } // public class TupleC<T1,T2>




} // namespace PGCafe.Object
