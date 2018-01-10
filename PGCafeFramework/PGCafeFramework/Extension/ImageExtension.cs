using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PGCafe.Object;

namespace PGCafe {
    /// <summary> Image's Extension </summary>
    public static class ImageExtension {

        /// <summary> Set bitmap's resolution and return it. </summary>
        /// <param name="source"> soure </param>
        /// <param name="GraphicsProperty"> <see cref="GraphicsProperty"/> with resolution. </param>
        /// <returns> source </returns>
        public static Bitmap SetResolution( this Bitmap source, GraphicsProperty GraphicsProperty ) {
            source.SetResolution( GraphicsProperty.DpiX, GraphicsProperty.DpiY );
            return source;
        } // public static Bitmap SetResolution( this Bitmap source, GraphicsProperty GraphicsProperty )


        /// <summary> Create <see cref="Graphics"/> object with bitmap, and use <see cref="GraphicsProperty"/> to initial it. </summary>
        /// <param name="source"> soure </param>
        /// <param name="GraphicsProperty"> <see cref="GraphicsProperty"/> with resolution. </param>
        /// <returns> <see cref="Graphics"/> of bitmap </returns>
        public static Graphics CreateGraphics( this Image source, GraphicsProperty GraphicsProperty ) {
            var result = Graphics.FromImage( source );
            result.SetProperty( GraphicsProperty );
            return result;
        } // public static Graphics CreateGraphics( this Image source, GraphicsProperty GraphicsProperty )

    } // public static class ImageExtension
} // namespace PGCafe
