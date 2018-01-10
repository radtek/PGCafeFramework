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
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false )]
    public class EnumStringValueAttribute : Attribute {

        /// <summary> Specific column name, if null, get the field's name to instead it. </summary>
        public string Value { get; set; }

        /// <summary> Set the field to be a DB Column, to use extension in PGLibrary.Database. </summary>
        /// <param name="Value"> Specify column name, if null, use the field's name to instead it </param>
        public EnumStringValueAttribute( string Value = null ) {
            this.Value = Value;
        } // public EnumStringValueAttribute( string Value = null )
        
    } // public class EnumStringValueAttribute : Attribute

} // namespace PGCafe.Object
