using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> The Key and Value pair </summary>
    /// <typeparam name="TKey"> Type of Key </typeparam>
    /// <typeparam name="TValue"> Type of Value </typeparam>
    public struct KeyValueS<TKey,TValue> {

        /// <summary> Key </summary>
        public TKey Key { get; set; }

        /// <summary> Value </summary>
        public TValue Value { get; set; }
        
        /// <summary> Create Key and Value pair </summary>
        [JsonConstructor]
        public KeyValueS( TKey Key, TValue Value ) {
            this.Key = Key;  this.Value = Value;
        } // public KeyValueS( TKey Key, TValue Value )

    } // public struct KeyValueS<TKey,TValue>
    
    /// <summary> Provide static method of KeyValueS </summary>
    public static class KeyValueS {

        /// <summary> Create KeyValueS object </summary>
        /// <typeparam name="TKey"> type of Key </typeparam>
        /// <typeparam name="TValue"> type of Value </typeparam>
        /// <param name="Key"> value of Key </param>
        /// <param name="Value"> value of Value</param>
        public static KeyValueS<TKey,TValue> Create<TKey,TValue>( TKey Key, TValue Value ) {
            return new KeyValueS<TKey, TValue>( Key, Value );
        } // public static KeyValueS<TKey,TValue> Create<TKey,TValue>( TKey Key, TValue Value )

    } // public static class KeyValue

} // namespace PGCafe.Object
