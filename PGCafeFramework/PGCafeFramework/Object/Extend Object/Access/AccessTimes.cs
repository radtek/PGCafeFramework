﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {

    /// <summary> Provide access times of value to be set and get. </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class AccessTimes<T> {

        #region Property

        /// <summary> The value. </summary>
        private T mValue;

        /// <summary>Value in box</summary>
        public T Value { 
            get {
                GetCount++;
                return mValue;
            } // get
            set {
                SetCount++;
                mValue = value;
            } // set
        } // public T Value

        
        /// <summary> Has the value been set. </summary>
        public bool HasSet { get { return SetCount > 0; } }
        
        /// <summary> Has the value been get. </summary>
        public bool HasGet { get { return GetCount > 0; } }
        
        /// <summary> The times of value been set. </summary>
        public uint SetCount { get; private set; } = 0;
        
        /// <summary> The times of value been get. </summary>
        public uint GetCount { get; private set; } = 0;

        #endregion

        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="AccessTimes{T}"/> class. </summary>
        public AccessTimes() {}

        /// <summary> Initializes a new instance of the <see cref="AccessTimes{T}"/> class with initial value. ( this won't count SetTimes ) </summary>
        /// <param name="Value">The value.</param>
        public AccessTimes( T Value ) {
            this.Value = Value;
        } // public AccessTimes( T Value )

        #endregion

        #region implicit operator

        /// <summary>
        /// Performs an implicit conversion from <see cref="T"/> to <see cref="AccessTimes{T}"/>.( this won't count SetTimes )
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator AccessTimes<T>( T Value ) {
            return new AccessTimes<T>( Value );
        } // public static implicit operator AccessTimes<T>( T Value )

        /// <summary>
        /// Performs an implicit conversion from <see cref="AccessTimes{T}"/> to <see cref="T"/>. ( this will count GetTimes )
        /// </summary>
        /// <param name="Object">The <see cref="AccessTimes{T}"/> object.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T( AccessTimes<T> Object ) {
            return Object.Value;
        } // public static implicit operator T( AccessTimes<T> Object )

        #endregion

    } // public class AccessTimes<T>

} // namespace PGCafe.Object
