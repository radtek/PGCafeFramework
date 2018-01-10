using System;

namespace PGCafe.Object {
    /// <summary> Provide success and exception property for return value. </summary>
    public class EmptyResult {

        #region Property

        /// <summary> excute success or not. </summary>
        public bool Success { get; private set; }

        /// <summary> Exception occur, usually has value when Success is false. </summary>
        public Exception Exception { get; private set; }

        #endregion

        #region Constructor

        /// <summary> Create instance by success and exception. </summary>
        /// <param name="Success"> success or not. </param>
        /// <param name="Exception"> exception which occur. </param>
        public EmptyResult( bool Success, Exception Exception ) {
            this.Success = Success;
            this.Exception = Exception;
        } // public Result( bool Success, Exception Exception )

        /// <summary> Create instance by success. </summary>
        /// <param name="Success"> success or not. </param>
        public EmptyResult( bool Success ) : this( Success, null ) { }

        /// <summary> Create instance by exception and set success to false. </summary>
        /// <param name="Exception"> exception which occur. </param>
        public EmptyResult( Exception Exception ) : this( false, Exception ) { }

        #endregion
        
        /// <summary> Convert this object to string, and show more detail. </summary>
        /// <returns> string for more detail. </returns>
        public override string ToString() {
            return
$@"{this.GetType().Name} - 
Success:{Success.ToString()}
Exception:{(Exception == null ? "null" : Exception.ToString())}";
        } // public override string ToString()

        #region Imlicit operator

        /// <summary> implicit by Success property. </summary>
        /// <param name="Success"> success or not </param>
        public static implicit operator EmptyResult( bool Success ) {
            return new EmptyResult( Success );
        } // public static implicit operator EmptyResult( bool Success )


        /// <summary> implicit by Exception property. </summary>
        /// <param name="Exception"> exception which occur </param>
        public static implicit operator EmptyResult( Exception Exception ) {
            return new EmptyResult( Exception );
        } // public static implicit operator EmptyResult( Exception Exception )

        #endregion

    } // public class EmptyResult

} // namespace PGCafe.Object
