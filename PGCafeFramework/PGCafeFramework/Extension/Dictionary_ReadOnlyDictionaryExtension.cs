using System.Collections.Generic;
using PGCafe.Object.OldVersionUse;
using System;
using System.Collections.ObjectModel;

namespace PGCafe {
    /// <summary>
    /// DictionaryExtension's Extension.
    /// </summary>
    public static class DictionaryExtension {

        /// <summary> Get the value, if has no key, return the default value. </summary>
        /// <typeparam name="TKey"> Key's type of Dictionary </typeparam>
        /// <typeparam name="TValue"> Value's type of Dictionary </typeparam>
        /// <param name="source"> source </param>
        /// <param name="Key"> Key to find. </param>
        /// <param name="Default"> the value to return if has no key. </param>
        /// <returns> Value if conatins key, or Default </returns>
        public static TValue GetValue<TKey, TValue>( this Dictionary<TKey, TValue> source, TKey Key, TValue Default = default( TValue ) ) {
            if ( source.TryGetValue( Key, out TValue outValue ) )
                return outValue;
            else
                return Default;
        } // public static TValue GetValue<TKey,TValue>( this Dictionary<TKey,TValue> source, TKey Key, TValue Default = default( TValue ) )
        
        /// <summary> Get the value, if has no key, add the key with default value and return default value. </summary>
        /// <typeparam name="TKey"> Key's type of Dictionary </typeparam>
        /// <typeparam name="TValue"> Value's type of Dictionary </typeparam>
        /// <param name="source"> source </param>
        /// <param name="Key"> Key to find or set. </param>
        /// <param name="Default"> the value to set if has no contains key. </param>
        /// <returns> Value if conatins key, or Default </returns>
        public static TValue GetOrSet<TKey, TValue>( this Dictionary<TKey, TValue> source, TKey Key, TValue Default = default( TValue ) ) {
            if ( source.TryGetValue( Key, out TValue outValue ) )
                return outValue;
            else {
                source[Key] = Default;
                return Default;
            } // else
        } // public static TValue GetOrSet<TKey,TValue>( this Dictionary<TKey,TValue> source, TKey Key, TValue Default = default( TValue ) )
        

        /// <summary> Get the value, if has no key, return the default value. </summary>
        /// <typeparam name="TKey"> Key's type of Dictionary </typeparam>
        /// <typeparam name="TValue"> Value's type of Dictionary </typeparam>
        /// <param name="source"> source </param>
        /// <param name="Key"> Key to find. </param>
        /// <param name="Default"> the value to return if has no key. </param>
        /// <returns> Value if conatins key, or Default </returns>
        public static TValue GetValue<TKey,TValue>( this ReadOnlyDictionary<TKey,TValue> source, TKey Key, TValue Default = default( TValue ) ) {
            if ( source.TryGetValue( Key, out TValue outValue ) )
                return outValue;
            else
                return Default;
        } // public static TValue GetValue<TKey,TValue>( this ReadOnlyDictionary<TKey,TValue> source, TKey Key, TValue Default = default( TValue ) )
        

    } // public static class DictionaryExtension

} // namespace PGCafe
