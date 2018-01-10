using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {

    /// <summary> Provide has access or not of value to be set and get. </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class HasAccess<T> {

        #region Property

        /// <summary> The value. </summary>
        private T mValue;

        /// <summary>Value in box</summary>
        public T Value { 
            get {
                HasGetted = true;
                return mValue;
            } // get
            set {
                HasSetted = true;
                mValue = value;
            } // set
        } // public T Value

        
        /// <summary> Has the value been set. </summary>
        public bool HasSetted { get; private set; }
        
        /// <summary> Has the value been get. </summary>
        public bool HasGetted { get; private set; }

        #endregion

        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="HasAccess{T}"/> class. </summary>
        public HasAccess() {}

        /// <summary> Initializes a new instance of the <see cref="HasAccess{T}"/> class with initial value. ( this won't set HasSetted ) </summary>
        /// <param name="Value">The value.</param>
        public HasAccess( T Value ) {
            this.Value = Value;
        } // public HasAccess( T Value )

        #endregion

        #region implicit operator

        /// <summary>
        /// Performs an implicit conversion from <see cref="T"/> to <see cref="HasAccess{T}"/>.( this won't set HasSetted )
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator HasAccess<T>( T Value ) {
            return new HasAccess<T>( Value );
        } // public static implicit operator HasAccess<T>( T Value )

        /// <summary>
        /// Performs an implicit conversion from <see cref="HasAccess{T}"/> to <see cref="T"/>. ( this will set HasGetted )
        /// </summary>
        /// <param name="Object">The <see cref="HasAccess{T}"/> object.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T( HasAccess<T> Object ) {
            return Object.Value;
        } // public static implicit operator T( HasAccess<T> Object )

        #endregion

    } // public class HasAccess<T>

} // namespace PGCafe.Object
