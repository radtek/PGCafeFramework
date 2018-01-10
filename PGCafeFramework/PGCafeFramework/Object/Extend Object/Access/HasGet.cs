using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {

    /// <summary> Provide has access or not of value to be set and get. </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class HasGet<T> {

        #region Property

        /// <summary> The value. </summary>
        private T mValue;

        /// <summary>Value in box</summary>
        public T Value { 
            get {
                HasGetted = true;
                return mValue;
            } // get
            set { mValue = value; } // set
        } // public T Value
        
        /// <summary> Has the value been get. </summary>
        public bool HasGetted { get; private set; }

        #endregion

        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="HasGet{T}"/> class. </summary>
        public HasGet() {}

        /// <summary> Initializes a new instance of the <see cref="HasGet{T}"/> class with initial value. </summary>
        /// <param name="Value">The value.</param>
        public HasGet( T Value ) {
            this.Value = Value;
        } // public HasGet( T Value )

        #endregion

        #region implicit operator

        /// <summary>
        /// Performs an implicit conversion from <see cref="T"/> to <see cref="HasGet{T}"/>.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator HasGet<T>( T Value ) {
            return new HasGet<T>( Value );
        } // public static implicit operator HasGet<T>( T Value )

        /// <summary>
        /// Performs an implicit conversion from <see cref="HasGet{T}"/> to <see cref="T"/>. ( this will set HasGetted )
        /// </summary>
        /// <param name="Object">The <see cref="HasGet{T}"/> object.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T( HasGet<T> Object ) {
            return Object.Value;
        } // public static implicit operator T( HasGet<T> Object )

        #endregion

    } // public class HasGet<T>

} // namespace PGCafe.Object
