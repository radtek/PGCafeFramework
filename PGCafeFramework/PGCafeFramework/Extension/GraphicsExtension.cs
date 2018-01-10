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
    public static class GraphicsExtension {

        #region GraphicsProperty Extension

        /// <summary> Get graphics's property. ( use to copy to other graphic ) </summary>
        /// <param name="source"> source </param>
        /// <returns> <see cref="GraphicsProperty"/> object </returns>
        public static GraphicsProperty GetProperty( this Graphics source ) =>
            new GraphicsProperty().CopyFrom( source );
        
        /// <summary> Get graphics's property. ( use to copy to other graphic ) </summary>
        /// <param name="source"> source </param>
        /// <param name="property"> property to copy to source. </param>
        /// <returns> <see cref="Graphics"/> of source </returns>
        public static Graphics SetProperty( this Graphics source, GraphicsProperty property )
            => source.CopyFrom( property );
        
        /// <summary> Set graphics's property from other graphics. ( not include clip relative property ) </summary>
        /// <param name="source"> source </param>
        /// <param name="propertyOfGraphics"> graphics with property to copy to source. </param>
        /// <returns> <see cref="Graphics"/> of source </returns>
        public static Graphics SetProperty( this Graphics source, Graphics propertyOfGraphics )
            => source.SetProperty( propertyOfGraphics.GetProperty() );

        #endregion

        #region Convert
        
        /// <summary> Convert the value to Pixel, use PageUnit and DpiX to determine how to convert </summary>
        /// <param name="source"> source </param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public static float ConvertXToPixel( this Graphics source, float Value ) {
            return source.PageUnit.ToPixel( source.DpiX, Value );
        } // public static float ConvertXToPixel( this Graphics source, float Value )

        /// <summary> Convert the value to Pixel, use PageUnit and DpiY to determine how to convert </summary>
        /// <param name="source"> source </param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public static float ConvertYToPixel( this Graphics source, float Value ) {
            return source.PageUnit.ToPixel( source.DpiY, Value );
        } // public static float ConvertYToPixel( this Graphics source, float Value )

        /// <summary> Convert the value to Pixel, use PageUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="source"> source </param>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public static SizeF ConvertToPixel( this Graphics source, float XValue, float YValue ) {
            return source.PageUnit.ToPixel( source.DpiX, source.DpiY, XValue, YValue );
        } // public static SizeF ConvertYToPixel( this Graphics source, float XValue, float YValue )

        /// <summary> Convert the value to Pixel, use PageUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="source"> source </param>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public static SizeF ConvertToPixel( this Graphics source, SizeF Size ) {
            return source.PageUnit.ToPixel( source.DpiX, source.DpiY, Size );
        } // public static SizeF ConvertYToPixel( this Graphics source, SizeF Size )

        

        /// <summary> Convert the value from Pixel to PageUnit, use DpiX to determine how to convert. </summary>
        /// <param name="source"> source </param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Value with PageUnit convert from pixel</returns>
        public static float ConvertXFromPixel( this Graphics source, float Value ) {
            return source.PageUnit.FromPixel( source.DpiX, Value );
        } // public static float ConvertXFromPixel( this Graphics source, float Value )
        
        /// <summary> Convert the value from Pixel to PageUnit, use DpiY to determine how to convert. </summary>
        /// <param name="source"> source </param>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Value with PageUnit convert from pixel</returns>
        public static float ConvertYFromPixel( this Graphics source, float Value ) {
            return source.PageUnit.FromPixel( source.DpiY, Value );
        } // public static float ConvertYFromPixel( this Graphics source, float Value )

        /// <summary> Convert the value from Pixel to PageUnit, use DpiX, DpiY to determine how to convert </summary>
        /// <param name="source"> source </param>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>SizeF with PageUnit convert from pixel</returns>
        public static SizeF ConvertFromPixel( this Graphics source, float XValue, float YValue ) {
            return source.PageUnit.FromPixel( source.DpiX, source.DpiY, XValue, YValue );
        } // public static SizeF ConvertFromPixel( this Graphics source, float XValue, float YValue )
        
        /// <summary> Convert the value from Pixel to PageUnit, use DpiX, DpiY to determine how to convert </summary>
        /// <param name="source"> source </param>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>SizeF with PageUnit convert from pixel</returns>
        public static SizeF ConvertFromPixel( this Graphics source, SizeF Size ) {
            return source.PageUnit.FromPixel( source.DpiX, source.DpiY, Size );
        } // public static SizeF ConvertFromPixel( this Graphics source, SizeF Size )

        #endregion

        #region Draw, Fill Extension

        /// <summary> Draw the line with <see cref="Line"/> </summary>
        /// <param name="source"> source </param>
        /// <param name="Pen"> Pen to use when drawing. </param>
        /// <param name="Line"> Location of line. </param>
        public static void DrawLine( this Graphics source, Pen Pen, Line Line ) {
            source.DrawLine( Pen, Line.Point1, Line.Point2 );
        } // public static void SetProperty( this Graphics source, Pen Pen, Line Line )
        
        /// <summary> Draw the circle center point and radius </summary>
        /// <param name="source"> source </param>
        /// <param name="Pen"> Pen to use when drawing. </param>
        /// <param name="Center"> Center of circle. </param>
        /// <param name="Radius"> Radius of circle. </param>
        public static void DrawCircle( this Graphics source, Pen Pen, PointF Center, float Radius ) {
            source.DrawEllipse( Pen, Center.X - Radius, Center.Y - Radius, Radius, Radius );
        } // public static void DrawCircle( this Graphics source, Pen Pen, PointF Center, float Radius )
        
        /// <summary> Fill the circle center point and radius </summary>
        /// <param name="source"> source </param>
        /// <param name="Brush"> Brush to use when drawing. </param>
        /// <param name="Center"> Center of circle. </param>
        /// <param name="Radius"> Radius of circle. </param>
        public static void FillCircle( this Graphics source, Brush Brush, PointF Center, float Radius ) {
            source.FillEllipse( Brush, Center.X - Radius, Center.Y - Radius, Radius*2, Radius*2 );
        } // public static void FillCircle( this Graphics source, Brush Brush, PointF Center, float Radius )

        /// <summary> Draw the Rectangle with <see cref="RectangleF"/> </summary>
        /// <param name="source"> source </param>
        /// <param name="Pen"> Pen to use when drawing. </param>
        /// <param name="Rectangle"> Rectangle to draw. </param>
        public static void DrawRectangle( this Graphics source, Pen Pen, RectangleF Rectangle ) {
            source.DrawRectangle( Pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height );
        } // public static void DrawRectangle( this Graphics source, Pen Pen, RectangleF Rectangle )

        #endregion

        #region Transform Extension

        /// <summary> Check is the graphics hasn't any transform. </summary>
        /// <param name="source">The source.</param>
        public static bool IsTransformClear( this Graphics source ) {
            return source.Transform.OffsetX == 0 && source.Transform.OffsetY == 0;
        } // public static bool IsTransformClear( this Graphics source )

        /// <summary> Rotate with angle to graphics's matrix. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">Center point to rotate.</param>
        /// <param name="angle">Angle to rotate.</param>
        public static void RotateTransform( this Graphics source, PointF Center, float angle ) {
            // move origin point to center.
            source.TranslateTransform( Center.X, Center.Y );

            // rotate by angle.
            source.RotateTransform( angle );

            // move origin point back.
            source.TranslateTransform( -Center.X, -Center.Y );
        } // public static void RotateTransform( this Graphics source, PointF Center, float angle )

        #endregion

    } // public static class GraphicsExtension


} // namespace PGCafe
