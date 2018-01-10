using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {

    /// <summary> Provide access times of value to be set and get. </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class GetTimes<T> {

        #region Property

        /// <summary> The value. </summary>
        private T mValue;

        /// <summary>Value in box</summary>
        public T Value { 
            get {
                GetCount++;
                return mValue;
            } // get
            set { mValue = value; } // set
        } // public T Value
        
        
        /// <summary> Has the value been get. </summary>
        public bool HasGet { get { return GetCount > 0; } }
        
        /// <summary> The times of value been get. </summary>
        public uint GetCount { get; private set; } = 0;

        #endregion

        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="GetTimes{T}"/> class. </summary>
        /// <param name="Value">The value.</param>
        public GetTimes() {}

        /// <summary> Initializes a new instance of the <see cref="GetTimes{T}"/> class with initial value. </summary>
        /// <param name="Value">The value.</param>
        public GetTimes( T Value ) {
            this.Value = Value;
        } // public GetTimes( T Value )

        #endregion

        #region implicit operator

        /// <summary>
        /// Performs an implicit conversion from <see cref="T"/> to <see cref="GetTimes{T}"/>.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator GetTimes<T>( T Value ) {
            return new GetTimes<T>( Value );
        } // public static implicit operator GetTimes<T>( T Value )

        /// <summary>
        /// Performs an implicit conversion from <see cref="GetTimes{T}"/> to <see cref="T"/>. ( this will count GetTimes )
        /// </summary>
        /// <param name="Object">The <see cref="GetTimes{T}"/> object.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T( GetTimes<T> Object ) {
            return Object.Value;
        } // public static implicit operator T( GetTimes<T> Object )

        #endregion

    } // public class GetTimes<T>

} // namespace PGCafe.Object
