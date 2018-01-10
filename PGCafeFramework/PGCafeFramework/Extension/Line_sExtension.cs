using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// HLine's Extension.
    /// </summary>
    public static class LineExtension {
        
        #region Alignment - HLine
        
        /// <summary>Get the X that aligns the HLine</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> X value aligns the HLine </returns>
        public static float AlignmentX( this HLine Base, PGAlignment Alignmentor ) {
            return Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width );
        } // public static float AlignmentX( this HLine Base, PGAlignment Alignmentor )
        
        /// <summary>Get the X that aligns the HLine with extend width</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="ExtendWidth">Extend width of alignment</param>
        /// <returns> X value aligns the HLine </returns>
        public static float AlignmentX( this HLine Base, PGAlignment Alignmentor, float ExtendWidth ) {
            return Alignmentor.AlignmentX( Base.Left, Base.Right, ExtendWidth );
        } // public static float AlignmentX( this HLine Base, PGAlignment Alignmentor, float ExtendWidth )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the HLine</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> <see cref="PointF"/> aligns the HLine </returns>
        public static PointF AlignmentPoint( this HLine Base, PGAlignment Alignmentor ) {
            return new PointF( Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width ), Base.Y );
        } // public static PointF AlignmentPoint( this HLine Base, PGAlignment Alignmentor )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the HLine and Height</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> <see cref="PointF"/> aligns the HLine </returns>
        public static PointF AlignmentPoint( this HLine Base, PGAlignment Alignmentor, float Height ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new PointF( Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width ), Y );
        } // public static PointF AlignmentPoint( this HLine Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the HLine and Height with extend width</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of alignment</param>
        /// <param name="ExtendWidth">Extend width of alignment</param>
        /// <returns> <see cref="PointF"/> aligns the HLine </returns>
        public static PointF AlignmentPoint( this HLine Base, PGAlignment Alignmentor, float Height, float ExtendWidth ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new PointF( Alignmentor.AlignmentX( Base.Left, Base.Right, ExtendWidth ), Y );
        } // public static PointF AlignmentPoint( this HLine Base, PGAlignment Alignmentor, float Height, float ExtendWidth )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the HLine.</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <returns> <see cref="VLine"/> aligns the HLine </returns>
        public static VLine AlignmentVLine( this HLine Base, PGAlignment Alignmentor, float Height ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new VLine( Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width ), Y, Height );
        } // public static VLine AlignmentVLine( this HLine Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="RectangleF"/> that aligns the HLine.</summary>
        /// <param name="Base">Base HLine</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="RectangleF"/></param>
        /// <param name="Height">Height of <see cref="RectangleF"/></param>
        /// <returns> <see cref="RectangleF"/> aligns the HLine </returns>
        public static RectangleF AlignmentRectangle( this HLine Base, PGAlignment Alignmentor, float Width, float Height ) {
            var left = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var top = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new RectangleF( left, top, Width, Height );
        } // public static RectangleF AlignmentRectangle( this HLine Base, PGAlignment Alignmentor, float Width, float Height )
        
        #endregion
        
        #region Alignment - VLine
        
        /// <summary>Get the Y that aligns the <see cref="VLine"/></summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> Y value aligns the <see cref="VLine"/> </returns>
        public static float AlignmentY( this VLine Base, PGAlignment Alignmentor ) {
            return Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height );
        } // public static float AlignmentY( this VLine Base, PGAlignment Alignmentor )
        
        /// <summary>Get the Y that aligns the <see cref="VLine"/> with extend height</summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="ExtendHeight">Extend height of alignment</param>
        /// <returns> Y value aligns the <see cref="VLine"/> </returns>
        public static float AlignmentY( this VLine Base, PGAlignment Alignmentor, float ExtendHeight ) {
            return Alignmentor.AlignmentY( Base.Top, Base.Bottom, ExtendHeight );
        } // public static float AlignmentY( this VLine Base, PGAlignment Alignmentor, float ExtendHeight )
        
        /// <summary>Get the Point that aligns the <see cref="VLine"/></summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> Point aligns the <see cref="VLine"/> </returns>
        public static PointF AlignmentPoint( this VLine Base, PGAlignment Alignmentor ) {
            return new PointF( Base.X, Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height ) );
        } // public static PointF AlignmentPoint( this VLine Base, PGAlignment Alignmentor )
        
        /// <summary>Get the Point that aligns the <see cref="VLine"/> and Width</summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <returns> Point aligns the <see cref="VLine"/> </returns>
        public static PointF AlignmentPoint( this VLine Base, PGAlignment Alignmentor, float Width ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X + Width, Width );
            return new PointF( X, Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height ) );
        } // public static PointF AlignmentPoint( this VLine Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the Point that aligns the <see cref="VLine"/> and Width with extend height</summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <param name="ExtendHeight">Extend height of alignment</param>
        /// <returns> Point aligns the <see cref="VLine"/> </returns>
        public static PointF AlignmentPoint( this VLine Base, PGAlignment Alignmentor, float Width, float ExtendHeight ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X + Width, Width );
            return new PointF( X, Alignmentor.AlignmentY( Base.Top, Base.Bottom, ExtendHeight ) );
        } // public static PointF AlignmentPoint( this VLine Base, PGAlignment Alignmentor, float Width, float ExtendHeight )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the <see cref="VLine"/>.</summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <returns> <see cref="HLine"/> aligns the <see cref="VLine"/> </returns>
        public static HLine AlignmentHLine( this VLine Base, PGAlignment Alignmentor, float Width ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            return new HLine( X, Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height ), Width );
        } // public static HLine AlignmentHLine( this VLine Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the Rectangle that aligns the <see cref="VLine"/>.</summary>
        /// <param name="Base">Base <see cref="VLine"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of Rectangle</param>
        /// <param name="Height">Height of Rectangle</param>
        /// <returns> Rectangle aligns the <see cref="VLine"/> </returns>
        public static RectangleF AlignmentRectangle( this VLine Base, PGAlignment Alignmentor, float Width, float Height ) {
            var left = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            var top = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new RectangleF( left, top, Height, Width );
        } // public static RectangleF AlignmentRectangle( this VLine Base, PGAlignment Alignmentor, float Width, float Height )

        #endregion
        
        #region Mirror
        
        /// <summary> Return new HLine that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror HLine.</param>
        /// <returns>new HLine that mirror by center point</returns>
        public static HLine Mirror( this HLine source, PointF Center ) {
            return new HLine() {
                X = source.Right.Mirror( Center.X ),
                Y = source.Y.Mirror( Center.Y ),
                Width = source.Width,
            };
        } // public static VLine Mirror( this HLine source, PointF Center )
        
        /// <summary> Return new VLine that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror VLine.</param>
        /// <returns>new VLine that mirror by center point</returns>
        public static VLine Mirror( this VLine source, PointF Center ) {
            return new VLine() {
                X = source.X.Mirror( Center.X ),
                Y = source.Bottom.Mirror( Center.Y ),
                Height = source.Height,
            };
        } // public static VLine Mirror( this VLine source, PointF Center )
        
        /// <summary> Return new Line that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror Line.</param>
        /// <returns>new Line that mirror by center point</returns>
        public static Line Mirror( this Line source, PointF Center ) {
            return new Line() {
                Point1 = source.Point1.Mirror( Center ),
                Point2 = source.Point2.Mirror( Center ),
            };
        } // public static Line Mirror( this Line source, PointF Center )
        
        #endregion

    } // public static class LineExtension

} // namespace PGCafe
