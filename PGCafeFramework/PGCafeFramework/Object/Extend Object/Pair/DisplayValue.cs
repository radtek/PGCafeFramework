using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> The Display and Value pair </summary>
        /// <typeparam name="TDisplay"> type of Display </typeparam>
        /// <typeparam name="TValue"> type of Value </typeparam>
    public class DisplayValue<TDisplay,TValue> {

        /// <summary> Display </summary>
        public TDisplay Display { get; set; }

        /// <summary> Value </summary>
        public TValue Value { get; set; }
        
        /// <summary> Create Display and Value pair </summary>
        public DisplayValue( TDisplay Display, TValue Value ) {
            this.Display = Display;  this.Value = Value;
        } // public DisplayValue( TDisplay Display, TValue Value )

    } // public class DisplayValue<TDisplay,TValue>

    /// <summary> Provide static method of KeyValue </summary>
    public static class DisplayValue {

        /// <summary> name of DisplayValue.Display </summary>
        public static string Display { get { return nameof( Display ); } }

        /// <summary> name of DisplayValue.Display </summary>
        public static string Value { get { return nameof( Value ); } }

        /// <summary> Create KeyValue object </summary>
        /// <typeparam name="TDisplay"> type of Display </typeparam>
        /// <typeparam name="TValue"> type of Value </typeparam>
        /// <param name="Display"> value of Display </param>
        /// <param name="Value"> value of Value</param>
        public static DisplayValue<TDisplay,TValue> Create<TDisplay,TValue>( TDisplay Display, TValue Value ) {
            return new DisplayValue<TDisplay, TValue>( Display, Value );
        } // public static DisplayValue<TDisplay,TValue> Create<TDisplay,TValue>( TDisplay Display, TValue Value )

    } // public static class DisplayValue

} // namespace PGCafe.Object
