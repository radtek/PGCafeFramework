using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {

    /// <summary> Provide access times of value to be set. </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class SetTimes<T> {

        #region Property

        /// <summary> The value. </summary>
        private T mValue;

        /// <summary>Value in box</summary>
        public T Value { 
            get { return mValue; }
            set {
                SetCount++;
                mValue = value;
            } // set
        } // public T Value

        
        /// <summary> Has the value been set. </summary>
        public bool HasSet { get { return SetCount > 0; } }
        
        /// <summary> The times of value been set. </summary>
        public uint SetCount { get; private set; } = 0;

        #endregion

        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="SetTimes{T}"/> class. </summary>
        public SetTimes() {}

        /// <summary> Initializes a new instance of the <see cref="SetTimes{T}"/> class with initial value. ( this won't count SetTimes ) </summary>
        /// <param name="Value">The value.</param>
        public SetTimes( T Value ) {
            this.Value = Value;
        } // public SetTimes( T Value )

        #endregion

        #region implicit operator

        /// <summary>
        /// Performs an implicit conversion from <see cref="T"/> to <see cref="SetTimes{T}"/>.( this won't count SetTimes )
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator SetTimes<T>( T Value ) {
            return new SetTimes<T>( Value );
        } // public static implicit operator SetTimes<T>( T Value )

        /// <summary>
        /// Performs an implicit conversion from <see cref="SetTimes{T}"/> to <see cref="T"/>.
        /// </summary>
        /// <param name="Object">The <see cref="SetTimes{T}"/> object.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T( SetTimes<T> Object ) {
            return Object.Value;
        } // public static implicit operator T( SetTimes<T> Object )

        #endregion

    } // public class SetTimes<T>

} // namespace PGCafe.Object
