using Newtonsoft.Json;
using System;

namespace PGCafe.Object {
    /// <summary> Provide success and value and exception property for return value. </summary>
    public class SingleResult<T> : EmptyResult {

        #region Property

        /// <summary> Value of result, if is not success, value would be default( T ). </summary>
        public T Value { get; private set; }

        #endregion

        #region Constructor

        /// <summary> Create instance by success and exception and value. </summary>
        /// <param name="Success"> success or not. </param>
        /// <param name="Exception"> exception which occur. </param>
        /// <param name="Value"> value of result to return. </param>
        [JsonConstructor]
        public SingleResult( bool Success, Exception Exception, T Value ) : base( Success, Exception ) {
            this.Value = Value;
        } // public SingleResult( bool Success, Exception Exception, T Value )

        /// <summary> Create instance by success and exception in EmptyResult and value. </summary>
        /// <param name="EmptyResult"> success and exception. </param>
        /// <param name="Value"> value of result to return. </param>
        public SingleResult( EmptyResult EmptyResult, T Value ) : base( EmptyResult.Success, EmptyResult.Exception ) {
            this.Value = Value;
        } // public SingleResult( EmptyResult EmptyResult, T Value )

        /// <summary> Create instance by value and set success to true. </summary>
        /// <param name="Value"> value of result to return. </param>
        public SingleResult( T Value ) : this( true, null, Value ) { }

        /// <summary> Create instance by exception and set success to false. </summary>
        /// <param name="Exception"> exception which occur. </param>
        public SingleResult( Exception Exception ) : this( false, Exception, default( T ) ) { }

        /// <summary> Create instance by value and exception and set success to true. </summary>
        /// <param name="Value"> value of result to return. </param>
        /// <param name="Exception"> exception which occur. </param>
        public SingleResult( T Value, Exception Exception ) : this( true, Exception, Value ) { }

        #endregion

        /// <summary> Return value if is success, else return defaultValue. </summary>
        /// <param name="defaultValue">return default value if not success.</param>
        /// <returns> Return value if is success, else return defaultValue. </returns>
        public T Unwrap( T defaultValue = default( T ) ) {
            if ( this.Success ) return this.Value;
            else return defaultValue;
        } // public T Unwrap( T defaultValue = default( T ) )
        
        /// <summary> Convert this object to string, and show more detail. </summary>
        /// <returns> string for more detail. </returns>
        public override string ToString() {
            return
$@"{this.GetType().Name} - 
Success:{Success.ToString()}
Exception:{(Exception == null ? "null" : Exception.ToString())}
Value:{(Value?.ToString())}";
        } // public override string ToString()

        #region Imlicit operator

        /// <summary> implicit by Value property. </summary>
        /// <param name="Value"> value to return </param>
        public static implicit operator SingleResult<T>( T Value ) {
            return new SingleResult<T>( Value );
        } // public static implicit operator SingleResult<T>( T Value )

        /// <summary> implicit by Success property. </summary>
        /// <param name="Success"> success or not </param>
        public static implicit operator SingleResult<T>( bool Success ) {
            return new SingleResult<T>( Success, null, default( T ) );
        } // public static implicit operator SingleResult<T>(( bool Success )


        /// <summary> implicit by Exception property. </summary>
        /// <param name="Exception"> exception which occur </param>
        public static implicit operator SingleResult<T>( Exception Exception ) {
            return new SingleResult<T>( Exception );
        } // public static implicit operator SingleResult<T>( Exception Exception )

        #endregion

    } // public class SingleResult<T> : EmptyResult
} // namespace PGCafe.Object
