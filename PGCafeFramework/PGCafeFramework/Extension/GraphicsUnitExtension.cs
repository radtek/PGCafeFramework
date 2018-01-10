using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using PGCafe.Object;

namespace PGCafe {
    /// <summary> Graphics's Extension </summary>
    public static class GraphicsUnitExtension {

        #region Convert

        /// <summary> Convert the value to Pixel, use GraphicsUnit and Dpi to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="Dpi">The Dpi of convert value.</param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static float ToPixel( this GraphicsUnit GraphicsUnit, float Dpi, float Value ) {
            switch ( GraphicsUnit ) {
                case GraphicsUnit.Pixel:
                    return Value;
                case GraphicsUnit.Inch:
                    return Value * Dpi;
                case GraphicsUnit.Millimeter:
                    return Value * 0.0393700787f * Dpi;
                case GraphicsUnit.Point:
                    return Value * Dpi / 72;
                case GraphicsUnit.Document:
                    return Value * Dpi / 300;
                case GraphicsUnit.Display:
                    return Value;
                default:
                    throw new NotSupportedException( $"{nameof( GraphicsUnitExtension.ToPixel )} not support convert from {GraphicsUnit.ToString()} to Pixel" );
            } // switch
        } // public static float ToPixel( this GraphicsUnit GraphicsUnit, int Dpi, float Value )

        /// <summary> Convert the value to Pixel, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="DpiX">The DpiX of convert XValue.</param>
        /// <param name="DpiY">The DpiX of convert YValue.</param>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static SizeF ToPixel( this GraphicsUnit GraphicsUnit, float DpiX, float DpiY, float XValue, float YValue ) {
            return new SizeF( GraphicsUnit.ToPixel( DpiX, XValue ), GraphicsUnit.ToPixel( DpiY, YValue ) );
        } // public static SizeF ToPixel( this GraphicsUnit GraphicsUnit, float DpiX, int DpiY, float XValue, float YValue )

        /// <summary> Convert the value to Pixel, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="DpiX">The DpiX of convert Size.</param>
        /// <param name="DpiY">The DpiX of convert Size.</param>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static SizeF ToPixel( this GraphicsUnit GraphicsUnit, float DpiX, float DpiY, SizeF Size ) {
            return new SizeF( GraphicsUnit.ToPixel( DpiX, Size.Width ), GraphicsUnit.ToPixel( DpiY, Size.Height ) );
        } // public static SizeF ToPixel( this GraphicsUnit GraphicsUnit, float DpiX, int DpiY, SizeF Size )

        /// <summary> Convert the value to Pixel, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="DpiX">The DpiX of convert Point.</param>
        /// <param name="DpiY">The DpiX of convert Point.</param>
        /// <param name="Point">The Point to convert.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static PointF ToPixel( this GraphicsUnit GraphicsUnit, float DpiX, float DpiY, PointF Point ) {
            return new PointF( GraphicsUnit.ToPixel( DpiX, Point.X ), GraphicsUnit.ToPixel( DpiY, Point.Y ) );
        } // public static PointF ToPixel( this GraphicsUnit GraphicsUnit, float DpiX, int DpiY, PointF Point )



        /// <summary> Convert the value from Pixel to GraphicsUnit, use DpiX to determine how to convert. </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="Dpi">The Dpi of convert value.</param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Value with GraphicsUnit convert from pixel</returns>
        public static float FromPixel( this GraphicsUnit GraphicsUnit, float Dpi, float Value ) {
            switch ( GraphicsUnit ) {
                case GraphicsUnit.Pixel:
                    return Value;
                case GraphicsUnit.Inch:
                    return Value / Dpi;
                case GraphicsUnit.Millimeter:
                    return Value / 0.0393700787f / Dpi;
                case GraphicsUnit.Point:
                    return Value * 72 / Dpi;
                case GraphicsUnit.Document:
                    return Value * 300 / Dpi;
                case GraphicsUnit.Display:
                    return Value;
                default:
                    throw new NotSupportedException( $"{nameof( GraphicsUnitExtension.FromPixel )} not support convert from Pixel to {GraphicsUnit.ToString()}" );
            } // switch
        } // public static float ConvertXFromPixel( float Value )

        /// <summary> Convert the value from Pixel, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="DpiX">The DpiX of convert XValue.</param>
        /// <param name="DpiY">The DpiX of convert YValue.</param>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static SizeF FromPixel( this GraphicsUnit GraphicsUnit, float DpiX, float DpiY, float XValue, float YValue ) {
            return new SizeF( GraphicsUnit.FromPixel( DpiX, XValue ), GraphicsUnit.FromPixel( DpiY, YValue ) );
        } // public static SizeF FromPixel( this GraphicsUnit GraphicsUnit, float DpiX, int DpiY, float XValue, float YValue )

        /// <summary> Convert the value from Pixel, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="DpiX">The DpiX of convert Size.</param>
        /// <param name="DpiY">The DpiX of convert Size.</param>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static SizeF FromPixel( this GraphicsUnit GraphicsUnit, float DpiX, float DpiY, SizeF Size ) {
            return new SizeF( GraphicsUnit.FromPixel( DpiX, Size.Width ), GraphicsUnit.FromPixel( DpiY, Size.Height ) );
        } // public static SizeF FromPixel( this GraphicsUnit GraphicsUnit, float DpiX, int DpiY, SizeF Size )

        /// <summary> Convert the value from Pixel, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="DpiX">The DpiX of convert Size.</param>
        /// <param name="DpiY">The DpiX of convert Size.</param>
        /// <param name="Point">The Point to convert.</param>
        /// <returns>Pixel convert from value with GraphicsUnit</returns>
        public static PointF FromPixel( this GraphicsUnit GraphicsUnit, float DpiX, float DpiY, PointF Point ) {
            return new PointF( GraphicsUnit.FromPixel( DpiX, Point.X ), GraphicsUnit.FromPixel( DpiY, Point.Y ) );
        } // public static PointF FromPixel( this GraphicsUnit GraphicsUnit, float DpiX, int DpiY, PointF Point )

        

        /// <summary> Convert the value to OtherUnit, use GraphicsUnit and Dpi to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="OtherUnit">destination unit.</param>
        /// <param name="Dpi">The Dpi of convert value.</param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>OtherUnit convert from value with GraphicsUnit</returns>
        public static float ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float Dpi, float Value ) {
            return OtherUnit.FromPixel( Dpi, GraphicsUnit.ToPixel( Dpi, Value ) );
        } // public static float ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float Dpi, float Value )

        /// <summary> Convert the value to OtherUnit, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="OtherUnit">destination unit.</param>
        /// <param name="DpiX">The DpiX of convert XValue.</param>
        /// <param name="DpiY">The DpiX of convert YValue.</param>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>OtherUnit convert from value with GraphicsUnit</returns>
        public static SizeF ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float DpiX, float DpiY, float XValue, float YValue ) {
            return OtherUnit.FromPixel( DpiX, DpiY, GraphicsUnit.ToPixel( DpiX, DpiY, XValue, YValue ) );
        } // public static SizeF ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float DpiX, int DpiY, float XValue, float YValue )

        /// <summary> Convert the value to OtherUnit, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="OtherUnit">destination unit.</param>
        /// <param name="DpiX">The DpiX of convert Size.</param>
        /// <param name="DpiY">The DpiX of convert Size.</param>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>OtherUnit convert from value with GraphicsUnit</returns>
        public static SizeF ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float DpiX, float DpiY, SizeF Size ) {
            return OtherUnit.FromPixel( DpiX, DpiY, GraphicsUnit.ToPixel( DpiX, DpiY, Size ) );
        } // public static SizeF ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float DpiX, int DpiY, SizeF Size )

        /// <summary> Convert the value to OtherUnit, use GraphicsUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="GraphicsUnit">source.</param>
        /// <param name="OtherUnit">destination unit.</param>
        /// <param name="DpiX">The DpiX of convert Point.</param>
        /// <param name="DpiY">The DpiX of convert Point.</param>
        /// <param name="Point">The Point to convert.</param>
        /// <returns>OtherUnit convert from value with GraphicsUnit</returns>
        public static PointF ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float DpiX, float DpiY, PointF Point ) {
            return OtherUnit.FromPixel( DpiX, DpiY, GraphicsUnit.ToPixel( DpiX, DpiY, Point ) );
        } // public static PointF ToOtherUnit( this GraphicsUnit GraphicsUnit, GraphicsUnit OtherUnit, float DpiX, int DpiY, PointF Point )

        #endregion

    } // public static class GraphicsUnitExtension


} // namespace PGCafe
