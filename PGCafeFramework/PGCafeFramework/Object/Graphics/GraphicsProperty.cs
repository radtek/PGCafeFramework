using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    
    /// <summary> Graphics's property. ( not include clip relative property ) </summary>
    public class GraphicsProperty {

        #region Property

        /// <summary> Gets or sets the CompositingMode with <see cref="Graphics"/> </summary>
        public CompositingMode CompositingMode { get; set; }

        /// <summary> Gets or sets the CompositingQuality mode with <see cref="Graphics"/> </summary>
        public CompositingQuality CompositingQuality { get; set; }

        /// <summary> Gets or sets the DpiX mode with <see cref="Graphics"/> </summary>
        public float DpiX { get; set; }

        /// <summary> Gets or sets the DpiY mode with <see cref="Graphics"/> </summary>
        public float DpiY { get; set; }

        /// <summary> Gets or sets the InterpolationMode mode with <see cref="Graphics"/> </summary>
        public InterpolationMode InterpolationMode { get; set; }

        /// <summary> Gets or sets the PageScale mode with <see cref="Graphics"/> </summary>
        public float PageScale { get; set; }

        /// <summary> Gets or sets the PageUnit mode with <see cref="Graphics"/> </summary>
        public GraphicsUnit PageUnit { get; set; }

        /// <summary> Gets or sets the PixelOffsetMode mode with <see cref="Graphics"/> </summary>
        public PixelOffsetMode PixelOffsetMode { get; set; }

        /// <summary> Gets or sets the RenderingOrigin mode with <see cref="Graphics"/> </summary>
        public Point RenderingOrigin { get; set; }

        /// <summary> Gets or sets the SmoothingMode mode with <see cref="Graphics"/> </summary>
        public SmoothingMode SmoothingMode { get; set; }

        /// <summary> Gets or sets the TextContrast mode with <see cref="Graphics"/> </summary>
        public int TextContrast { get; set; }

        /// <summary> Gets or sets the TextRenderingHint mode with <see cref="Graphics"/> </summary>
        public TextRenderingHint TextRenderingHint { get; set; }

        /// <summary> Gets or sets the Transform mode with <see cref="Graphics"/> </summary>
        public Matrix Transform { get; set; }

        #endregion

        #region Constructor

        private static GraphicsProperty mDefault = null;

        /// <summary> 取得預設的 GraphicsProperty 物件副本. </summary>
        public static GraphicsProperty Default {
            get {
                if ( mDefault == null ) {
                    mDefault = Graphics.FromImage( new Bitmap( 1, 1 ) ).GetProperty();
                } // if

                return (GraphicsProperty)mDefault.MemberwiseClone();
            } // get
        } // public static GraphicsProperty Default

        /// <summary> Initializes a new instance of the <see cref="GraphicsProperty"/> class. </summary>
        internal GraphicsProperty() { }

        #endregion

        #region Convert

        /// <summary> Convert the value to Pixel, use PageUnit and DpiX to determine how to convert </summary>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public float ConvertXToPixel( float Value ) {
            return PageUnit.ToPixel( this.DpiX, Value );
        } // public float ConvertXToPixel( float Value )

        /// <summary> Convert the value to Pixel, use PageUnit and DpiY to determine how to convert </summary>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public float ConvertYToPixel( float Value ) {
            return PageUnit.ToPixel( this.DpiY, Value );
        } // public float ConvertYToPixel( float Value )

        /// <summary> Convert the value to Pixel, use PageUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public SizeF ConvertToPixel( float XValue, float YValue ) {
            return PageUnit.ToPixel( this.DpiX, this.DpiY, XValue, YValue );
        } // public SizeF ConvertYToPixel( float XValue, float YValue )

        /// <summary> Convert the value to Pixel, use PageUnit, DpiX, DpiY to determine how to convert </summary>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>Pixel convert from value with PageUnit</returns>
        public SizeF ConvertToPixel( SizeF Size ) {
            return PageUnit.ToPixel( this.DpiX, this.DpiY, Size );
        } // public SizeF ConvertYToPixel( SizeF Size )

        

        /// <summary> Convert the value from Pixel to PageUnit, use DpiX to determine how to convert. </summary>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Value with PageUnit convert from pixel</returns>
        public float ConvertXFromPixel( float Value ) {
            return PageUnit.FromPixel( this.DpiX, Value );
        } // public float ConvertXFromPixel( float Value )
        
        /// <summary> Convert the value from Pixel to PageUnit, use DpiY to determine how to convert. </summary>
        /// <param name="Value">The value to convert.</param>
        /// <returns>Value with PageUnit convert from pixel</returns>
        public float ConvertYFromPixel( float Value ) {
            return PageUnit.FromPixel( this.DpiY, Value );
        } // public float ConvertYFromPixel( float Value )

        /// <summary> Convert the value from Pixel to PageUnit, use DpiX, DpiY to determine how to convert </summary>
        /// <param name="XValue">The X value convert use DpiX.</param>
        /// <param name="YValue">The Y value convert use DpiY.</param>
        /// <returns>SizeF with PageUnit convert from pixel</returns>
        public SizeF ConvertFromPixel( float XValue, float YValue ) {
            return PageUnit.FromPixel( this.DpiX, this.DpiY, XValue, YValue );
        } // public SizeF ConvertFromPixel( float XValue, float YValue )
        
        /// <summary> Convert the value from Pixel to PageUnit, use DpiX, DpiY to determine how to convert </summary>
        /// <param name="Size">The Size to convert.</param>
        /// <returns>SizeF with PageUnit convert from pixel</returns>
        public SizeF ConvertFromPixel( SizeF Size ) {
            return PageUnit.FromPixel( this.DpiX, this.DpiY, Size );
        } // public SizeF ConvertFromPixel( SizeF Size )

        #endregion

    } // public class GraphicsProperty

} // namespace PGCafe.Object
