using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace PGCafe {

    /// <summary> Provide zip static function </summary>
    public static class PGZip {

        #region GZip

        /// <summary> Zip data by GZip </summary>
        /// <param name="data">data with byte array.</param>
        /// <returns> zip data </returns>
        public static byte[] GZip( byte[] data ) {
            using ( var input = new MemoryStream( data ) )
            using ( var output = new MemoryStream() ) {
                using ( var gzipStream = new GZipStream( output, CompressionMode.Compress ) ) {
                    input.CopyTo( gzipStream );
                } // using

                return output.ToArray();
            } // using
        } // public static byte[] GZip( byte[] data )

        /// <summary> Zip data by GZip </summary>
        /// <param name="data">data with byte array.</param>
        /// <param name="Encoding">Use encoding to convert string to byte.</param>
        /// <returns> zip data </returns>
        public static byte[] GZip( string data, Encoding Encoding ) {
            using ( var input = new MemoryStream( Encoding.GetBytes( data ) ) )
            using ( var output = new MemoryStream() ) {
                using ( var gzipStream = new GZipStream( output, CompressionMode.Compress ) ) {
                    input.CopyTo( gzipStream );
                } // using

                return output.ToArray();
            } // using
        } // public static byte[] GZip( string data, Encoding Encoding )
        
        /// <summary> UnZip data by GZip </summary>
        /// <param name="data">data with byte array.</param>
        /// <returns> un-zip data </returns>
        public static byte[] UnGZip( byte[] data ) {
            using ( var input = new MemoryStream( data ) )
            using ( var output = new MemoryStream() ) {
                using ( var gzipStream = new GZipStream( input, CompressionMode.Decompress ) ) {
                    gzipStream.CopyTo( output );
                } // using

                return output.ToArray();
            } // using
        } // public static byte[] UnGZip( byte[] data )
        
        /// <summary> UnZip data by GZip </summary>
        /// <param name="data">data with string.</param>
        /// <param name="Encoding">Use encoding to convert byte to string.</param>
        /// <returns> un-zip data </returns>
        public static string UnGZip( byte[] data, Encoding Encoding ) {
            using ( var input = new MemoryStream( data ) )
            using ( var output = new MemoryStream() ) {
                using ( var gzipStream = new GZipStream( input, CompressionMode.Decompress ) ) {
                    gzipStream.CopyTo( output );
                } // using

                return Encoding.GetString( output.ToArray() );
            } // using
        } // public static string UnGZip( byte[] data, Encoding Encoding )

        #endregion

    } // public static class PGZip

} // namespace PGCafe
