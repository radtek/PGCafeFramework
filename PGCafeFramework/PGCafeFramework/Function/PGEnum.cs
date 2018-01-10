using System;
using System.Collections.Generic;
using System.Linq;
using PGCafe.Object;

namespace PGCafe {

    /// <summary> Provide more function for Enum. </summary>
    public static class PGEnum {

        /// <summary> Get Enum's values with IEnumerable. </summary>
        /// <typeparam name="TEnum"> type of enum </typeparam>
        /// <returns> IEnumerable of TEnum </returns>
        public static IEnumerable<TEnum> Enumerable<TEnum>() {
            // get enum value and use cast to get IEnumerable.
            return Enum.GetValues( typeof( TEnum ) ).Cast<TEnum>();
        } // public static IEnumerable<TEnum> Enumerable<TEnum>()

        /// <summary> Get the list of KeyValue with Key = Description, Value = Enum's Value </summary>
        /// <typeparam name="TEnum"> type of enum </typeparam>
        public static List<DisplayValue<string,TEnum>> GetDisplayValueWithDescription<TEnum>() {
            // if not enum type, throw exception.
            if ( !typeof( TEnum ).IsEnum ) throw new ArgumentException( "The type of TEnum is not Enum" );

            // get enum value and description.
            return Enum.GetValues( typeof( TEnum ) ).Cast<Enum>()
                .Select( item => DisplayValue.Create( item.Description(), item.CastTo<TEnum>() ) )
                .ToList();                
        } // public static List<DisplayValue<string,TEnum>> GetDisplayValueWithDescription<TEnum>()
        

        /// <summary> Get the list of KeyValue with Key = Enum's Name, Value = Enum's Value </summary>
        /// <typeparam name="TEnum"> type of enum </typeparam>
        public static List<DisplayValue<string,TEnum>> GetDisplayValueWithName<TEnum>() {
            // if not enum type, throw exception.
            if ( !typeof( TEnum ).IsEnum ) throw new ArgumentException( "The type of TEnum is not Enum" );

            // get enum value and description.
            return Enum.GetValues( typeof( TEnum ) ).Cast<Enum>()
                .Select( item => DisplayValue.Create( item.ToString(), item.CastTo<TEnum>() ) )
                .ToList();                
        } // public static List<DisplayValue<string,TEnum>> GetDisplayValueWithName<TEnum>()

    } // public static class PGEnum

} // namespace PGCafe
