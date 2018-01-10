#pragma warning disable CS1591
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PGCafe {

    public static class PGWeb {

        public static string GetString( string Url, Encoding Encoding = null ) {
            var request = WebRequest.Create( Url );

            using ( var response = request.GetResponse() )
            using ( var stream = response.GetResponseStream() )
            using ( var reader = new StreamReader( stream, Encoding ?? Encoding.Default ) )
                return reader.ReadToEnd();
        } // public static string GetString( string Url, Encoding Encoding = null )
        
        public static byte[] GetBytes( string Url ) {
            var request = WebRequest.Create( Url );

            using ( var response = request.GetResponse() )
            using ( var stream = response.GetResponseStream() )
            using ( var memoryStream = new MemoryStream() ) {
                stream.CopyTo( memoryStream );
                return memoryStream.ToArray();
            } // using
        } // public static byte[] GetBytes( string Url )

    } // public static class PGWeb

} // namespace PGCafe
