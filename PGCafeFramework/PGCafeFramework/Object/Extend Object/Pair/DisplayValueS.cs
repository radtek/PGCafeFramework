using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> The Display and Value pair </summary>
    /// <typeparam name="TDisplay"> Type of Display </typeparam>
    /// <typeparam name="TValue"> Type of Value </typeparam>
    public struct DisplayValueS<TDisplay,TValue> {

        /// <summary> Key </summary>
        public TDisplay Display { get; set; }

        /// <summary> Value </summary>
        public TValue Value { get; set; }
        
        /// <summary> Create Key and Value pair </summary>
        [JsonConstructor]
        public DisplayValueS( TDisplay Display, TValue Value ) {
            this.Display = Display;  this.Value = Value;
        } // public DisplayValueS( TDisplay Display, TValue Value )

    } // public struct DisplayValueS<TDisplay,TValue>
    
    /// <summary> Provide static method of KeyValueS </summary>
    public static class DisplayValueS {

        /// <summary> Create DisplayValueS object </summary>
        /// <typeparam name="TDisplay"> type of Display </typeparam>
        /// <typeparam name="TValue"> type of Value </typeparam>
        /// <param name="Display"> value of Display </param>
        /// <param name="Value"> value of Value</param>
        public static DisplayValueS<TDisplay,TValue> Create<TDisplay,TValue>( TDisplay Display, TValue Value ) {
            return new DisplayValueS<TDisplay, TValue>( Display, Value );
        } // public static DisplayValueS<TDisplay,TValue> Create<TDisplay,TValue>( TDisplay Display, TValue Value )

    } // public static class KeyValue

} // namespace PGCafe.Object
