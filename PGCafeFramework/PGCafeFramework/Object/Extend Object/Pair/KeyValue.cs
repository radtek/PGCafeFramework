using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> The Key and Value pair </summary>
        /// <typeparam name="TKey"> type of Key </typeparam>
        /// <typeparam name="TValue"> type of Value </typeparam>
    public class KeyValue<TKey,TValue> {

        /// <summary> Key </summary>
        public TKey Key { get; set; }

        /// <summary> Value </summary>
        public TValue Value { get; set; }
        
        /// <summary> Create Key and Value pair </summary>
        [JsonConstructor]
        public KeyValue( TKey Key, TValue Value ) {
            this.Key = Key;  this.Value = Value;
        } // public KeyValue( TKey Key, TValue Value )

    } // public class KeyValue<TKey,TValue>

    /// <summary> Provide static method of KeyValue </summary>
    public static class KeyValue {

        /// <summary> name of KeyValue.Key </summary>
        public static string Key { get { return nameof( Key ); } }

        /// <summary> name of KeyValue.Key </summary>
        public static string Value { get { return nameof( Value ); } }

        /// <summary> Create KeyValue object </summary>
        /// <typeparam name="TKey"> type of Key </typeparam>
        /// <typeparam name="TValue"> type of Value </typeparam>
        /// <param name="Key"> value of Key </param>
        /// <param name="Value"> value of Value</param>
        public static KeyValue<TKey,TValue> Create<TKey,TValue>( TKey Key, TValue Value ) {
            return new KeyValue<TKey, TValue>( Key, Value );
        } // public static KeyValue<TKey,TValue> Create<TKey,TValue>( TKey Key, TValue Value )

    } // public static class KeyValue

} // namespace PGCafe.Object
