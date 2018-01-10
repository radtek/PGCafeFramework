using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// Rectangle and RectangleF 's Extension.
    /// </summary>
    public static class RectangleExtension {
        
        #region PGAlignment - Rectangle
        
        /// <summary>Get the X that aligns the <see cref="Rectangle"/></summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> X value aligns the <see cref="Rectangle"/> </returns>
        public static float AlignmentX( this Rectangle Base, PGAlignment Alignmentor ) {
            return Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width );
        } // public static float AlignmentX( this Rectangle Base, PGAlignment Alignmentor )
        
        /// <summary>Get the X that aligns the <see cref="Rectangle"/> with extend width</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="ExtendWidth">Extend width of alignment</param>
        /// <returns> X value aligns the <see cref="Rectangle"/> </returns>
        public static float AlignmentX( this Rectangle Base, PGAlignment Alignmentor, float ExtendWidth ) {
            return Alignmentor.AlignmentX( Base.Left, Base.Right, ExtendWidth );
        } // public static float AlignmentX( this Rectangle Base, PGAlignment Alignmentor, float ExtendWidth )
        
        /// <summary>Get the Y that aligns the <see cref="Rectangle"/></summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> Y value aligns the <see cref="Rectangle"/> </returns>
        public static float AlignmentY( this Rectangle Base, PGAlignment Alignmentor ) {
            return Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height );
        } // public static float AlignmentY( this Rectangle Base, PGAlignment Alignmentor )
        
        /// <summary>Get the Y that aligns the <see cref="Rectangle"/> with extend height</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="ExtendHeight">Extend height of alignment</param>
        /// <returns> Y value aligns the <see cref="Rectangle"/> </returns>
        public static float AlignmentY( this Rectangle Base, PGAlignment Alignmentor, float ExtendHeight ) {
            return Alignmentor.AlignmentY( Base.Top, Base.Bottom, ExtendHeight );
        } // public static float AlignmentY( this Rectangle Base, PGAlignment Alignmentor, float ExtendHeight )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the <see cref="Rectangle"/></summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> <see cref="PointF"/> aligns the <see cref="Rectangle"/> </returns>
        public static PointF AlignmentPoint( this Rectangle Base, PGAlignment Alignmentor ) {
            return new PointF() {
                X = Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width ),
                Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height ),
            };
        } // public static PointF AlignmentPoint( this Rectangle Base, PGAlignment Alignmentor )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the <see cref="Rectangle"/> and Width and Height</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> <see cref="PointF"/> aligns the <see cref="Rectangle"/> </returns>
        public static PointF AlignmentPoint( this Rectangle Base, PGAlignment Alignmentor, float Width, float Height ) {
            return new PointF() {
                X = Alignmentor.AlignmentX( Base.Left, Base.Right, Width ),
                Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, Height ),
            };
        } // public static PointF AlignmentPoint( this Rectangle Base, PGAlignment Alignmentor, float Width, float Height )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the <see cref="Rectangle"/>.</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <returns> <see cref="HLine"/> aligns the <see cref="Rectangle"/> </returns>
        public static HLine AlignmentHLine( this Rectangle Base, PGAlignment Alignmentor, float Width ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height );
            return new HLine( X, Y, Width );
        } // public static HLine AlignmentHLine( this Rectangle Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the <see cref="Rectangle"/> with extend height.</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <param name="ExtendHeight">Extend height of alignment</param>
        /// <returns> <see cref="HLine"/> aligns the <see cref="Rectangle"/> </returns>
        public static HLine AlignmentHLine( this Rectangle Base, PGAlignment Alignmentor, float Width, float ExtendHeight ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, ExtendHeight );
            return new HLine( X, Y, Width );
        } // public static HLine AlignmentHLine( this Rectangle Base, PGAlignment Alignmentor, float Width, float ExtendHeight )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the <see cref="Rectangle"/>.</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <returns> <see cref="VLine"/> aligns the <see cref="Rectangle"/> </returns>
        public static VLine AlignmentVLine( this Rectangle Base, PGAlignment Alignmentor, float Height ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new VLine( X, Y, Height );
        } // public static VLine AlignmentVLine( this Rectangle Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the <see cref="Rectangle"/>.</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <param name="ExtendWidth">Extend width of alignment</param>
        /// <returns> <see cref="VLine"/> aligns the <see cref="Rectangle"/> </returns>
        public static VLine AlignmentVLine( this Rectangle Base, PGAlignment Alignmentor, float Height, float ExtendWidth ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right, ExtendWidth );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new VLine( X, Y, Height );
        } // public static VLine AlignmentVLine( this Rectangle Base, PGAlignment Alignmentor, float Height, float ExtendWidth )
        
        /// <summary>Get the <see cref="Rectangle"/> that aligns the <see cref="Rectangle"/>.</summary>
        /// <param name="Base">Base <see cref="Rectangle"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="Rectangle"/></param>
        /// <param name="Height">Height of <see cref="Rectangle"/></param>
        /// <returns> <see cref="Rectangle"/> aligns the <see cref="Rectangle"/> </returns>
        public static RectangleF AlignmentRectangle( this Rectangle Base, PGAlignment Alignmentor, float Width, float Height ) {
            var left = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var top = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new RectangleF( left, top, Width, Height );
        } // public static RectangleF AlignmentRectangle( this Rectangle Base, PGAlignment Alignmentor, float Width, float Height )

        #endregion
        
        #region PGAlignment - RectangleF
        
        /// <summary>Get the X that aligns the <see cref="RectangleF"/></summary>
        /// <param name="Base">Base Rectangle</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> X value aligns the <see cref="RectangleF"/> </returns>
        public static float AlignmentX( this RectangleF Base, PGAlignment Alignmentor ) {
            return Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width );
        } // public static float AlignmentX( this RectangleF Base, PGAlignment Alignmentor )
        
        /// <summary>Get the X that aligns the <see cref="RectangleF"/> with extend width</summary>
        /// <param name="Base">Base Rectangle</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="ExtendWidth">Extend width of alignment</param>
        /// <returns> X value aligns the <see cref="RectangleF"/> </returns>
        public static float AlignmentX( this RectangleF Base, PGAlignment Alignmentor, float ExtendWidth ) {
            return Alignmentor.AlignmentX( Base.Left, Base.Right, ExtendWidth );
        } // public static float AlignmentX( this RectangleF Base, PGAlignment Alignmentor, float ExtendWidth )
        
        /// <summary>Get the Y that aligns the <see cref="RectangleF"/></summary>
        /// <param name="Base">Base Rectangle</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> Y value aligns the <see cref="RectangleF"/> </returns>
        public static float AlignmentY( this RectangleF Base, PGAlignment Alignmentor ) {
            return Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height );
        } // public static float AlignmentY( this RectangleF Base, PGAlignment Alignmentor )
        
        /// <summary>Get the Y that aligns the <see cref="RectangleF"/> with extend height</summary>
        /// <param name="Base">Base Rectangle</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="ExtendHeight">Extend height of alignment</param>
        /// <returns> Y value aligns the <see cref="RectangleF"/> </returns>
        public static float AlignmentY( this RectangleF Base, PGAlignment Alignmentor, float ExtendHeight ) {
            return Alignmentor.AlignmentY( Base.Top, Base.Bottom, ExtendHeight );
        } // public static float AlignmentY( this RectangleF Base, PGAlignment Alignmentor, float ExtendHeight )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the <see cref="RectangleF"/></summary>
        /// <param name="Base">Base <see cref="RectangleF"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <returns> <see cref="PointF"/> aligns the <see cref="RectangleF"/> </returns>
        public static PointF AlignmentPoint( this RectangleF Base, PGAlignment Alignmentor ) {
            return new PointF() {
                X = Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width ),
                Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height ),
            };
        } // public static PointF AlignmentPoint( this RectangleF Base, PGAlignment Alignmentor )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the <see cref="RectangleF"/> and Width and Height</summary>
        /// <param name="Base">Base Rectangle</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> <see cref="PointF"/> aligns the <see cref="RectangleF"/> </returns>
        public static PointF AlignmentPoint( this RectangleF Base, PGAlignment Alignmentor, float Width, float Height ) {
            return new PointF() {
                X = Alignmentor.AlignmentX( Base.Left, Base.Right, Width ),
                Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, Height ),
            };
        } // public static PointF AlignmentPoint( this RectangleF Base, PGAlignment Alignmentor, float Width, float Height )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the <see cref="RectangleF"/>.</summary>
        /// <param name="Base">Base Rectangle</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <returns> <see cref="HLine"/> aligns the <see cref="RectangleF"/> </returns>
        public static HLine AlignmentHLine( this RectangleF Base, PGAlignment Alignmentor, float Width ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, Base.Height );
            return new HLine( X, Y, Width );
        } // public static HLine AlignmentHLine( this RectangleF Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the <see cref="RectangleF"/> with extend height.</summary>
        /// <param name="Base">Base <see cref="RectangleF"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <param name="ExtendHeight">Extend height of alignment</param>
        /// <returns> <see cref="HLine"/> aligns the <see cref="RectangleF"/> </returns>
        public static HLine AlignmentHLine( this RectangleF Base, PGAlignment Alignmentor, float Width, float ExtendHeight ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom, ExtendHeight );
            return new HLine( X, Y, Width );
        } // public static HLine AlignmentHLine( this RectangleF Base, PGAlignment Alignmentor, float Width, float ExtendHeight )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the <see cref="RectangleF"/>.</summary>
        /// <param name="Base">Base <see cref="RectangleF"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <returns> <see cref="VLine"/> aligns the <see cref="RectangleF"/> </returns>
        public static VLine AlignmentVLine( this RectangleF Base, PGAlignment Alignmentor, float Height ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right, Base.Width );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new VLine( X, Y, Height );
        } // public static VLine AlignmentVLine( this RectangleF Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the <see cref="RectangleF"/>.</summary>
        /// <param name="Base">Base <see cref="RectangleF"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <param name="ExtendWidth">Extend width of alignment</param>
        /// <returns> <see cref="VLine"/> aligns the <see cref="RectangleF"/> </returns>
        public static VLine AlignmentVLine( this RectangleF Base, PGAlignment Alignmentor, float Height, float ExtendWidth ) {
            var X = Alignmentor.AlignmentX( Base.Left, Base.Right, ExtendWidth );
            var Y = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new VLine( X, Y, Height );
        } // public static VLine AlignmentVLine( this RectangleF Base, PGAlignment Alignmentor, float Height, float ExtendWidth )
        
        /// <summary>Get the <see cref="RectangleF"/> that aligns the <see cref="RectangleF"/>.</summary>
        /// <param name="Base">Base <see cref="RectangleF"/></param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="RectangleF"/></param>
        /// <param name="Height">Height of <see cref="RectangleF"/></param>
        /// <returns> <see cref="RectangleF"/> aligns the <see cref="RectangleF"/> </returns>
        public static RectangleF AlignmentRectangle( this RectangleF Base, PGAlignment Alignmentor, float Width, float Height ) {
            var left = Alignmentor.AlignmentX( Base.Left, Base.Right - Width, Width );
            var top = Alignmentor.AlignmentY( Base.Top, Base.Bottom - Height, Height );
            return new RectangleF( left, top, Width, Height );
        } // public static RectangleF AlignmentRectangle( this RectangleF Base, PGAlignment Alignmentor, float Width, float Height )

        #endregion

        #region Convert To

        /// <summary> Convert to <see cref="Rectangle"/> with Round X, Y, Width, Height property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Rectangle"/> with Round X, Y, Width, Height property.</returns>
        public static Rectangle Round( this RectangleF source ) {
            return new Rectangle() {
                X = (int)Math.Round( source.X ),
                Y = (int)Math.Round( source.Y ),
                Width = (int)Math.Round( source.Width ),
                Height = (int)Math.Round( source.Height ),
            };
        } // public static Rectangle Round( this RectangleF source )

        /// <summary> Convert to <see cref="Rectangle"/> with Floor X, Y, Width, Height property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Rectangle"/> with Floor X, Y, Width, Height property.</returns>
        public static Rectangle Floor( this RectangleF source ) {
            return new Rectangle() {
                X = (int)Math.Floor( source.X ),
                Y = (int)Math.Floor( source.Y ),
                Width = (int)Math.Floor( source.Width ),
                Height = (int)Math.Floor( source.Height ),
            };
        } // public static Rectangle Round( this RectangleF source )

        /// <summary> Convert to <see cref="Rectangle"/> with Ceiling X, Y, Width, Height property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Rectangle"/> with Ceiling X, Y, Width, Height property.</returns>
        public static Rectangle Ceiling( this RectangleF source ) {
            return new Rectangle() {
                X = (int)Math.Ceiling( source.X ),
                Y = (int)Math.Ceiling( source.Y ),
                Width = (int)Math.Ceiling( source.Width ),
                Height = (int)Math.Ceiling( source.Height ),
            };
        } // public static Rectangle Ceiling( this RectangleF source )

        #endregion
        
        #region Mirror
        
        /// <summary> Return new rectangle that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror rectangle.</param>
        /// <returns>new rectangle that mirror by center point</returns>
        public static Rectangle Mirror( this Rectangle source, Point Center ) {
            return new Rectangle() {
                X = source.Right.Mirror( Center.X ),
                Y = source.Bottom.Mirror( Center.Y ),
                Width = source.Width,
                Height = source.Height,
            };
        } // public static Rectangle Mirror( this Rectangle source, Point Center )
        
        /// <summary> Return new rectangle that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror rectangle.</param>
        /// <returns>new rectangle that mirror by center point</returns>
        public static RectangleF Mirror( this RectangleF source, PointF Center ) {
            return new RectangleF() {
                X = source.Right.Mirror( Center.X ),
                Y = source.Bottom.Mirror( Center.Y ),
                Width = source.Width,
                Height = source.Height,
            };
        } // public static RectangleF Mirror( this RectangleF source, PointF Center )
        
        #endregion

    } // public static class RectangleExtension

} // namespace PGCafe
