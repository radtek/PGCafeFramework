using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> Collect multiple exception and throw it at once. </summary>
    public class MultipleException : Exception {
        [JsonProperty]
        private Exception[] mItems;

        /// <summary> Exceptions be collected. </summary>
        public ReadOnlyCollection<Exception> Items { get { return Array.AsReadOnly( mItems ); } }

        /// <summary> Create MultipleException without initial. </summary>
        public MultipleException(){
        } // public MultipleException()

        /// <summary> Create MultipleException and with base message. </summary>
        /// <param name="message"> error meesage. </param>
        /// <param name="otherExceptions"> otehr exceptions be collected. </param>
        public MultipleException( string message, IEnumerable<Exception> otherExceptions )
            : base( message ){
            if ( otherExceptions == null ) this.mItems = new Exception[] { };
            else this.mItems = otherExceptions.ToArray();
        } // public MultipleException( string message, IEnumerable<Exception> otherExceptions )

        /// <summary> Create MultipleException and with base message. </summary>
        /// <param name="message"> error meesage. </param>
        /// <param name="innerException"> the reason of this exception occur. </param>
        /// <param name="otherExceptions"> otehr exceptions be collected. </param>
        public MultipleException( string message, Exception innerException, IEnumerable<Exception> otherExceptions )
            : base( message, innerException ){
            if ( otherExceptions == null ) this.mItems = new Exception[] { };
            else this.mItems = otherExceptions.ToArray();
        } // public MultipleException( string message, Exception innerException, IEnumerable<Exception> otherExceptions )

        /// <summary> Combine all exception's ToString and use {Enter} with separator </summary>
        public override string ToString() {
            return string.Join( Environment.NewLine, Items.Select( item => item.ToString() ) );
        } // public override string ToString()

    } // public class MultipleException : Exception
} // namespace PGCafe.Object
