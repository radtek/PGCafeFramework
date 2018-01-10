using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PGCafe.Object {

    /// <summary> Provide meticulous horizontal and vertical alignment. </summary>
    public class PGAlignment {

        #region Const

        /// <summary> Left alignment's value of horizontal alignment </summary>
        public const double LeftValue = -1;

        /// <summary> Right alignment's value of horizontal alignment </summary>
        public const double RightValue = 1;

        /// <summary> Center alignment's value of horizontal alignment </summary>
        public const double CenterValue = ( LeftValue + RightValue ) / 2;

        /// <summary> Top alignment's value of vertical alignment </summary>
        public const double TopValue = -1;

        /// <summary> Bottom alignment's value of vertical alignment </summary>
        public const double BottomValue = 1;

        /// <summary> Middle alignment's value of vertical alignment </summary>
        public const double MiddleValue = ( TopValue + BottomValue ) / 2;
        
        /// <summary> ExtendLeft alignment's value of horizontal alignment. ( ExtendLeft usually used to get out of [Left Bounds] by [Width] ) </summary>
        public const double ExtendLeftValue = -2;

        /// <summary> ExtendRight alignment's value of horizontal alignment. ( ExtendRight usually used to get out of [Right Bounds] by [Width] ) </summary>
        public const double ExtendRightValue = 2;

        /// <summary> ExtendTop alignment's value of horizontal alignment. ( ExtendTop usually used to get out of [Top Bounds] by [Height] ) </summary>
        public const double ExtendTopValue = -2;

        /// <summary> ExtendBottom alignment's value of horizontal alignment. ( ExtendBottom usually used to get out of [Bottom Bounds] by [Height] ) </summary>
        public const double ExtendBottomValue = 2;

        #endregion

        #region Default Member

        /// <summary> Alignment at TopLeft </summary>
        public readonly static PGAlignment TopLeft = new PGAlignment( TopValue, LeftValue );

        /// <summary> Alignment at MiddleLeft </summary>
        public readonly static PGAlignment MiddleLeft = new PGAlignment( MiddleValue, LeftValue );

        /// <summary> Alignment at BottomLeft </summary>
        public readonly static PGAlignment BottomLeft = new PGAlignment( BottomValue, LeftValue );

        /// <summary> Alignment at TopCenter </summary>
        public readonly static PGAlignment TopCenter = new PGAlignment( TopValue, MiddleValue );

        /// <summary> Alignment at MiddleCenter </summary>
        public readonly static PGAlignment MiddleCenter = new PGAlignment( MiddleValue, MiddleValue );

        /// <summary> Alignment at BottomCenter </summary>
        public readonly static PGAlignment BottomCenter = new PGAlignment( BottomValue, MiddleValue );

        /// <summary> Alignment at TopRight </summary>
        public readonly static PGAlignment TopRight = new PGAlignment( TopValue, RightValue );

        /// <summary> Alignment at MiddleRight </summary>
        public readonly static PGAlignment MiddleRight = new PGAlignment( MiddleValue, RightValue );

        /// <summary> Alignment at BottomRight </summary>
        public readonly static PGAlignment BottomRight = new PGAlignment( BottomValue, RightValue );

        /// <summary> Alignment at ExtendTopLeft </summary>
        public readonly static PGAlignment ExtendTopLeft = new PGAlignment( ExtendTopValue, ExtendLeftValue );

        /// <summary> Alignment at ExtendMiddleLeft </summary>
        public readonly static PGAlignment ExtendMiddleLeft = new PGAlignment( MiddleValue, ExtendLeftValue );

        /// <summary> Alignment at ExtendBottomLeft </summary>
        public readonly static PGAlignment ExtendBottomLeft = new PGAlignment( ExtendBottomValue, ExtendLeftValue );

        /// <summary> Alignment at ExtendTopCenter </summary>
        public readonly static PGAlignment ExtendTopCenter = new PGAlignment( ExtendTopValue, MiddleValue );

        /// <summary> Alignment at ExtendBottomCenter </summary>
        public readonly static PGAlignment ExtendBottomCenter = new PGAlignment( ExtendBottomValue, MiddleValue );

        /// <summary> Alignment at ExtendTopRight </summary>
        public readonly static PGAlignment ExtendTopRight = new PGAlignment( ExtendTopValue, ExtendRightValue );

        /// <summary> Alignment at ExtendMiddleRight </summary>
        public readonly static PGAlignment ExtendMiddleRight = new PGAlignment( MiddleValue, ExtendRightValue );

        /// <summary> Alignment at <see cref="ExtendBottomRight"/> </summary>
        public readonly static PGAlignment ExtendBottomRight = new PGAlignment( ExtendBottomValue, ExtendRightValue );

        #endregion
        
        #region Instance & Constructor

        /// <summary> Horizontal alignment value </summary>
        public double Horizontal { get; set; }

        /// <summary> Vertical alignment value </summary>
        public double Vertical { get; set; }

        /// <summary> Initializes a new instance of the <see cref="PGAlignment"/> class. </summary>
        /// <param name="Vertical">The vertical alignment value.</param>
        /// <param name="Horizontal">The horizontal alignment value.</param>
        public PGAlignment( double Vertical, double Horizontal ) {
            this.Horizontal = Horizontal;  this.Vertical = Vertical;
        } // public PGAlignment( double Vertical, double Horizontal )
        
        /// <summary> Get a instance of the <see cref="PGAlignment"/> class by <see cref="StringAlignment"/> type. </summary>
        /// <param name="Vertical">The vertical alignment value with <see cref="StringAlignment"/> type.</param>
        /// <param name="Horizontal">The horizontal alignment value with <see cref="StringAlignment"/> type.</param>
        public static PGAlignment FromStringAlignment( StringAlignment Vertical, StringAlignment Horizontal ) {

            if ( Vertical == StringAlignment.Near ) {
                if ( Horizontal == StringAlignment.Near ) return PGAlignment.TopLeft;
                else if ( Horizontal == StringAlignment.Center ) return PGAlignment.TopCenter;
                else if ( Horizontal == StringAlignment.Far ) return PGAlignment.TopRight;
            } // if
            else if ( Vertical == StringAlignment.Center ) {
                if ( Horizontal == StringAlignment.Near ) return PGAlignment.MiddleLeft;
                else if ( Horizontal == StringAlignment.Center ) return PGAlignment.MiddleCenter;
                else if ( Horizontal == StringAlignment.Far ) return PGAlignment.MiddleRight;
            } // else if
            else if ( Vertical == StringAlignment.Far ) {
                if ( Horizontal == StringAlignment.Near ) return PGAlignment.BottomLeft;
                else if ( Horizontal == StringAlignment.Center ) return PGAlignment.BottomCenter;
                else if ( Horizontal == StringAlignment.Far ) return PGAlignment.BottomRight;
            } // else if

            throw new NotSupportedException();
        } // public static PGAlignment FromStringAlignment( StringAlignment Vertical, StringAlignment Horizontal )

        /// <summary> Get a instance of the <see cref="PGAlignment"/> class by <see cref="ContentAlignment"/> type. </summary>
        /// <param name="Alignment">The alignment value with <see cref="ContentAlignment"/> type.</param>
        public static PGAlignment FromContentAlignment( ContentAlignment Alignment ) {
            if ( Alignment == ContentAlignment.TopLeft )
                return PGAlignment.TopLeft;
            else if ( Alignment == ContentAlignment.TopCenter )
                return PGAlignment.TopCenter;
            else if ( Alignment == ContentAlignment.TopRight )
                return PGAlignment.TopRight;
            else if ( Alignment == ContentAlignment.MiddleLeft )
                return PGAlignment.MiddleLeft;
            else if ( Alignment == ContentAlignment.MiddleCenter )
                return PGAlignment.MiddleCenter;
            else if ( Alignment == ContentAlignment.MiddleRight )
                return PGAlignment.MiddleRight;
            else if ( Alignment == ContentAlignment.BottomLeft )
                return PGAlignment.BottomLeft;
            else if ( Alignment == ContentAlignment.BottomCenter )
                return PGAlignment.BottomCenter;
            else if ( Alignment == ContentAlignment.BottomRight )
                return PGAlignment.BottomRight;
            else
                throw new NotSupportedException();
        } // public static PGAlignment FromContentAlignment( ContentAlignment Alignment )

        #endregion

        #region Private Alignment

        /// <summary> Get alignment X with ExtendLeft. ( Horizontal should &lt; LeftValue when call this function ) </summary>
        /// <param name="Left"> Left value </param>
        /// <param name="ExtendWidth"> Extend Width value </param>
        /// <returns> alignment X with ExtendLeft </returns>
        private float AlignmentExtendLeft( float Left, float ExtendWidth ) {
            var horizontalPercent = ValueRange.GetPercent( ExtendLeftValue, LeftValue, Horizontal );
            var result = ValueRange.GetValue( Left - ExtendWidth, Left, horizontalPercent );
            return (float)result;
        } // private float AlignmentExtendLeft( float Left, float ExtendWidth )

        /// <summary> Get alignment X with ExtendRight. ( Horizontal should &gt; RightValue when call this function ) </summary>
        /// <param name="Right"> Right value </param>
        /// <param name="ExtendWidth"> Extend Width value </param>
        /// <returns> alignment X with ExtendRight </returns>
        private float AlignmentExtendRight( float Right, float ExtendWidth ) {
            var horizontalPercent = ValueRange.GetPercent( RightValue, ExtendRightValue, Horizontal );
            var result = ValueRange.GetValue( Right, Right + ExtendWidth, horizontalPercent );
            return (float)result;
        } // private float AlignmentExtendRight( float Right, float ExtendWidth )

        /// <summary> Get alignment Y with ExtendTop. ( Vertical should &lt; TopValue when call this function ) </summary>
        /// <param name="Top"> Top value </param>
        /// <param name="ExtendHeight"> Extend Height value </param>
        /// <returns> alignment Y with ExtendTop </returns>
        private float AlignmentExtendTop( float Top, float ExtendHeight ) {
            var verticalPercent = ValueRange.GetPercent( ExtendTopValue, TopValue, Vertical );
            var result = ValueRange.GetValue( Top - ExtendHeight, Top, verticalPercent );
            return (float)result;
        } // private float AlignmentExtendLeft( float Top, float ExtendHeight )
        
        /// <summary> Get alignment Y with ExtendBottom. ( Vertical should &gt; BottomValue when call this function ) </summary>
        /// <param name="Bottom"> Bottom value </param>
        /// <param name="ExtendHeight"> Extend Height value </param>
        /// <returns> alignment Y with ExtendBottom </returns>
        private float AlignmentExtendBottom( float Bottom, float ExtendHeight ) {
            var verticalPercent = ValueRange.GetPercent( BottomValue, ExtendBottomValue, Vertical );
            var result = ValueRange.GetValue( Bottom, Bottom + ExtendHeight, verticalPercent );
            return (float)result;
        } // private float AlignmentExtendBottom( float Bottom, float ExtendHeight )

        #endregion

        #region Public Alignment

        /// <summary>
        /// Get the X that aligns from Left to Right without extend.
        /// ( Horizontal will shrink to LeftValue and RightValue )
        /// </summary>
        /// <param name="Left">Left boundary value</param>
        /// <param name="Right">Right boundary value</param>
        /// <returns> value in boundary depands on alignment </returns>
        public float AlignmentX( float Left, float Right ) {
            var horizontalValue = ValueRange.InRange( LeftValue, RightValue, Horizontal );
            var horizontalPercent = ValueRange.GetPercent( LeftValue, RightValue, horizontalValue );
            var resultX = ValueRange.GetValue( Left, Right, horizontalPercent );
            return (float)resultX;
        } // public float AlignmentX( float Left, float Right )
        
        /// <summary>Get the X that aligns from Left to Right.</summary>
        /// <param name="Left">Left boundary value</param>
        /// <param name="Right">Right boundary value</param>
        /// <param name="ExtendWidth">Extend width when Horizontal is out of boundary</param>
        /// <returns> value depands on alignment </returns>
        public float AlignmentX( float Left, float Right, float ExtendWidth ) {
            if ( Horizontal < LeftValue )
                return AlignmentExtendLeft( Left, ExtendWidth );
            else if ( Horizontal > RightValue )
                return AlignmentExtendRight( Right, ExtendWidth );
            else
                return AlignmentX( Left, Right );
        } // public float AlignmentX( float Left, float Right, float ExtendWidth )
        
        /// <summary>
        /// Get the Y that aligns from Top to Bottom without extend.
        /// ( Vertical will shrink to TopValue and BottomValue )
        /// </summary>
        /// <param name="Top">Top boundary value</param>
        /// <param name="Bottom">Bottom boundary value</param>
        /// <returns> value in boundary depands on alignment </returns>
        public float AlignmentY( float Top, float Bottom ) {
            var verticalValue = ValueRange.InRange( TopValue, BottomValue, Vertical );
            var verticalPercent = ValueRange.GetPercent( TopValue, BottomValue, verticalValue );
            var result = ValueRange.GetValue( Top, Bottom, verticalPercent );
            return (float)result;
        } // public float AlignmentY( float Top, float Bottom )
        
        
        /// <summary>Get the Y that aligns from Top to Bottom.</summary>
        /// <param name="Top">Top boundary value</param>
        /// <param name="Bottom">Bottom boundary value</param>
        /// <param name="ExtendHeight">Extend height when Vertical is out of boundary</param>
        /// <returns> value depands on alignment </returns>
        public float AlignmentY( float Top, float Bottom, float ExtendHeight ) {
            if ( Vertical < TopValue )
                return AlignmentExtendTop( Top, ExtendHeight );
            else if ( Horizontal > RightValue )
                return AlignmentExtendBottom( Bottom, ExtendHeight );
            else
                return AlignmentY( Top, Bottom );
        } // public float AlignmentY( float Top, float Bottom, float ExtendHeight )

        #endregion

        #region Convert To

        /// <summary> Convert Horizontal to <see cref="StringAlignment"/>. </summary>
        /// <returns> Horizontal alignment value with <see cref="StringAlignment"/> type. </returns>
        public StringAlignment ToHorizontalStringAlignment() {
            // if is obviously, return corresponding alignment.
            if ( this.Horizontal <= PGAlignment.LeftValue )
                return StringAlignment.Near;
            else if ( this.Horizontal == PGAlignment.CenterValue )
                return StringAlignment.Center;
            else if ( this.Horizontal >= PGAlignment.RightValue )
                return StringAlignment.Far;
            
            // if is not obviously, check where is more closer.
            else if ( this.Horizontal <= ( PGAlignment.CenterValue + PGAlignment.LeftValue / 2 ) )
                return StringAlignment.Near;
            else if ( this.Horizontal >= ( PGAlignment.CenterValue + PGAlignment.RightValue / 2 ) )
                return StringAlignment.Far;
            else return StringAlignment.Center;
        } // public StringAlignment ToHorizontalStringAlignment()

        /// <summary> Convert Vertical to <see cref="StringAlignment"/>. </summary>
        /// <returns> Vertical alignment value with <see cref="StringAlignment"/> type. </returns>
        public StringAlignment ToVerticalStringAlignment() {
            // if is obviously, return corresponding alignment.
            if ( this.Horizontal <= PGAlignment.TopValue )
                return StringAlignment.Near;
            else if ( this.Horizontal == PGAlignment.MiddleValue )
                return StringAlignment.Center;
            else if ( this.Horizontal >= PGAlignment.BottomValue )
                return StringAlignment.Far;
            
            // if is not obviously, check where is more closer.
            else if ( this.Horizontal <= ( PGAlignment.MiddleValue + PGAlignment.TopValue / 2 ) )
                return StringAlignment.Near;
            else if ( this.Horizontal >= ( PGAlignment.MiddleValue + PGAlignment.BottomValue / 2 ) )
                return StringAlignment.Far;
            else return StringAlignment.Center;
        } // public StringAlignment ToVerticalStringAlignment()
        
        /// <summary> Convert to <see cref="ContentAlignment"/>. </summary>
        /// <returns> Alignment value with <see cref="ContentAlignment"/> type. </returns>
        public ContentAlignment ToContentAlignment() {
            // convert this to StringAlignment.
            var horizontal = this.ToHorizontalStringAlignment();
            var vertical = this.ToVerticalStringAlignment();

            // convert StringAlignment to ContentAlignment.
            if ( horizontal == StringAlignment.Near && vertical == StringAlignment.Near )
                return ContentAlignment.TopLeft;
            else if ( horizontal == StringAlignment.Near && vertical == StringAlignment.Center )
                return ContentAlignment.TopCenter;
            else if ( horizontal == StringAlignment.Near && vertical == StringAlignment.Far )
                return ContentAlignment.TopRight;
            else if ( horizontal == StringAlignment.Center && vertical == StringAlignment.Near )
                return ContentAlignment.MiddleLeft;
            else if ( horizontal == StringAlignment.Center && vertical == StringAlignment.Center )
                return ContentAlignment.MiddleCenter;
            else if ( horizontal == StringAlignment.Center && vertical == StringAlignment.Far )
                return ContentAlignment.MiddleRight;
            else if ( horizontal == StringAlignment.Far && vertical == StringAlignment.Near )
                return ContentAlignment.BottomLeft;
            else if ( horizontal == StringAlignment.Far && vertical == StringAlignment.Center )
                return ContentAlignment.BottomCenter;
            else if ( horizontal == StringAlignment.Far && vertical == StringAlignment.Far )
                return ContentAlignment.BottomRight;
            else throw new NotSupportedException();
        } // public ContentAlignment ToContentAlignment()
        
        #endregion

    } // public struct PGAlignment

} // namespace PGCafe.Object
