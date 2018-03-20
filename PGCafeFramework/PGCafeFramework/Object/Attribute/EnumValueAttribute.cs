#pragma warning disable CS1591
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace PGCafe.Object {

    /// <summary>
    /// Set the string value to Enum field
    /// * get string value of Enum with <see cref="EnumExtension.StringValue"/>
    /// * set Enum value of string with <see cref="EnumExtension.ToEnumByStringValue"/>
    /// </summary>
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public class EnumStringValueAttribute : Attribute {

        /// <summary> Get or Set the key of this string value.( specific the key when use multiple <see cref="EnumStringValueAttribute"/> ) </summary>
        public string Key { get; set; }

        /// <summary> Specific value to represent this enum field. </summary>
        public string Value { get; set; }

        /// <summary> Set the string value to represent this enum field. </summary>
        /// <param name="Value"> Specific value to represent this enum field. </param>
        public EnumStringValueAttribute( string Value ) {
            this.Value = Value;
        } // public EnumStringValueAttribute( string Value )
        
    } // public class EnumStringValueAttribute : Attribute

} // namespace PGCafe.Object
