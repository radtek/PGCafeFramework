using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// Point and PointF's Extension.
    /// </summary>
    public static class PointExtension {

        #region PGAlignment - Point
        
        /// <summary>Get the X that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <returns> X value aligns the base point </returns>
        public static float AlignmentX( this Point Base, PGAlignment Alignmentor, float Width ) {
            return Alignmentor.AlignmentX( Base.X - Width, Base.X + Width, Width );
        } // public static float AlignmentX( this Point Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the Y that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> Y value aligns the base point </returns>
        public static float AlignmentY( this Point Base, PGAlignment Alignmentor, float Height ) {
            return Alignmentor.AlignmentY( Base.Y - Height, Base.Y + Height, Height );
        } // public static float AlignmentY( this Point Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the Point that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> Point aligns the base point </returns>
        public static PointF AlignmentPoint( this Point Base, PGAlignment Alignmentor, float Width, float Height ) {
            return new PointF( Alignmentor.AlignmentX( Base.X, Width, Width ), Alignmentor.AlignmentY( Base.Y, Height, Height ) );
        } // public static PointF AlignmentPoint( this Point Base, PGAlignment Alignmentor, float Width, float Height )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <returns> <see cref="HLine"/> depands on alignment </returns>
        public static HLine AlignmentHLine( this Point Base, PGAlignment Alignmentor, float Width ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            return new HLine( X, Base.Y, Width );
        } // public static HLine AlignmentHLine( this Point Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the base point with extend height</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <param name="ExtendHeight">Height of alignment</param>
        /// <returns> <see cref="HLine"/> depands on alignment </returns>
        public static HLine AlignmentHLine( this Point Base, PGAlignment Alignmentor, float Width, float ExtendHeight ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            return new HLine( X, Alignmentor.AlignmentY( Base.Y, ExtendHeight, ExtendHeight ), Width );
        } // public static HLine AlignmentHLine( this Point Base, PGAlignment Alignmentor, float Width, float ExtendHeight )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <returns> <see cref="VLine"/> depands on alignment </returns>
        public static VLine AlignmentVLine( this Point Base, PGAlignment Alignmentor, float Height ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new VLine( Base.X, Y, Height );
        } // public static VLine AlignmentVLine( this Point Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the base point with extend width</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <param name="ExtendWidth">Width of alignment</param>
        /// <returns> <see cref="VLine"/> depands on alignment </returns>
        public static VLine AlignmentVLine( this Point Base, PGAlignment Alignmentor, float Height, float ExtendWidth ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new VLine( Alignmentor.AlignmentX( Base.X, ExtendWidth, ExtendWidth ), Y, Height );
        } // public static VLine AlignmentVLine( this Point Base, PGAlignment Alignmentor, float Height, float ExtendWidth )
        
        /// <summary>Get the <see cref="RectangleF"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="RectangleF"/></param>
        /// <param name="Height">Height of <see cref="RectangleF"/></param>
        /// <returns> <see cref="RectangleF"/> depands on alignment </returns>
        public static RectangleF AlignmentRectangle( this Point Base, PGAlignment Alignmentor, float Width, float Height ) {
            var left = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            var top = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new RectangleF( left, top, Width, Height );
        } // public static RectangleF AlignmentRectangle( this Point Base, PGAlignment Alignmentor, float Width, float Height )

        #endregion

        #region PGAlignment - PointF
        
        /// <summary>Get the X that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <returns> X value aligns the base point </returns>
        public static float AlignmentX( this PointF Base, PGAlignment Alignmentor, float Width ) {
            return Alignmentor.AlignmentX( Base.X - Width, Base.X + Width, Width );
        } // public static float AlignmentX( this PointF Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the Y that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> Y value aligns the base point </returns>
        public static float AlignmentY( this PointF Base, PGAlignment Alignmentor, float Height ) {
            return Alignmentor.AlignmentY( Base.Y - Height, Base.Y + Height, Height );
        } // public static float AlignmentY( this PointF Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="PointF"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of alignment</param>
        /// <param name="Height">Height of alignment</param>
        /// <returns> <see cref="PointF"/> aligns the base point </returns>
        public static PointF AlignmentPoint( this PointF Base, PGAlignment Alignmentor, float Width, float Height ) {
            return new PointF(
                Alignmentor.AlignmentX( Base.X - Width, Base.X + Width, Width ),
                Alignmentor.AlignmentY( Base.Y - Height, Base.Y + Height, Height ) );
        } // public static PointF AlignmentPoint( this PointF Base, PGAlignment Alignmentor, float Width, float Height )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <returns> <see cref="HLine"/> depands on alignment </returns>
        public static HLine AlignmentHLine( this PointF Base, PGAlignment Alignmentor, float Width ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            return new HLine( X, Base.Y, Width );
        } // public static HLine AlignmentHLine( this PointF Base, PGAlignment Alignmentor, float Width )
        
        /// <summary>Get the <see cref="HLine"/> that aligns the base point with extend height</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="HLine"/></param>
        /// <param name="ExtendHeight">Height of alignment</param>
        /// <returns> <see cref="HLine"/> depands on alignment </returns>
        public static HLine AlignmentHLine( this PointF Base, PGAlignment Alignmentor, float Width, float ExtendHeight ) {
            var X = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            return new HLine( X, Alignmentor.AlignmentY( Base.Y, ExtendHeight, ExtendHeight ), Width );
        } // public static HLine AlignmentHLine( this PointF Base, PGAlignment Alignmentor, float Width, float ExtendHeight )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <returns> <see cref="VLine"/> depands on alignment </returns>
        public static VLine AlignmentVLine( this PointF Base, PGAlignment Alignmentor, float Height ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new VLine( Base.X, Y, Height );
        } // public static VLine AlignmentVLine( this PointF Base, PGAlignment Alignmentor, float Height )
        
        /// <summary>Get the <see cref="VLine"/> that aligns the base point with extend width</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Height">Height of <see cref="VLine"/></param>
        /// <param name="ExtendWidth">Width of alignment</param>
        /// <returns> <see cref="VLine"/> depands on alignment </returns>
        public static VLine AlignmentVLine( this PointF Base, PGAlignment Alignmentor, float Height, float ExtendWidth ) {
            var Y = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new VLine( Alignmentor.AlignmentX( Base.X, ExtendWidth, ExtendWidth ), Y, Height );
        } // public static VLine AlignmentVLine( this PointF Base, PGAlignment Alignmentor, float Height, float ExtendWidth )
        
        /// <summary>Get the <see cref="RectangleF"/> that aligns the base point</summary>
        /// <param name="Base">Base point</param>
        /// <param name="Alignmentor">The alignment value to calculate</param>
        /// <param name="Width">Width of <see cref="RectangleF"/></param>
        /// <param name="Height">Height of <see cref="RectangleF"/></param>
        /// <returns> <see cref="RectangleF"/> depands on alignment </returns>
        public static RectangleF AlignmentRectangle( this PointF Base, PGAlignment Alignmentor, float Width, float Height ) {
            var left = Alignmentor.AlignmentX( Base.X - Width, Base.X, Width );
            var top = Alignmentor.AlignmentY( Base.Y - Height, Base.Y, Height );
            return new RectangleF( left, top, Width, Height );
        } // public static RectangleF AlignmentRectangle( this PointF Base, PGAlignment Alignmentor, float Width, float Height )

        #endregion
        
        #region Convert To

        /// <summary> Convert to <see cref="Point"/> with Round X, Y property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Point"/> with Round X, Y property.</returns>
        public static Point Round( this PointF source ) {
            return new Point() {
                X = (int)Math.Round( source.X ),
                Y = (int)Math.Round( source.Y ),
            };
        } // public static Point Round( this PointF source )

        /// <summary> Convert to <see cref="Point"/> with Floor X, Y property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Point"/> with Floor X, Y property.</returns>
        public static Point Floor( this PointF source ) {
            return new Point() {
                X = (int)Math.Floor( source.X ),
                Y = (int)Math.Floor( source.Y ),
            };
        } // public static Point Round( this PointF source )

        /// <summary> Convert to <see cref="Point"/> with Ceiling X, Y property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Point"/> with Ceiling X, Y property.</returns>
        public static Point Ceiling( this PointF source ) {
            return new Point() {
                X = (int)Math.Ceiling( source.X ),
                Y = (int)Math.Ceiling( source.Y ),
            };
        } // public static Point Ceiling( this PointF source )

        #endregion

        #region Mirror
        
        /// <summary> Return new point that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror point.</param>
        /// <returns>new point that mirror by center point</returns>
        public static Point Mirror( this Point source, Point Center ) {
            return new Point( source.X.Mirror( Center.X ), source.Y.Mirror( Center.Y ) );
        } // public static Point Mirror( this Point source, Point Center )
        
        /// <summary> Return new point that mirror by center point. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center point to calculate mirror point.</param>
        /// <returns>new point that mirror by center point</returns>
        public static PointF Mirror( this PointF source, PointF Center ) {
            return new PointF( source.X.Mirror( Center.X ), source.Y.Mirror( Center.Y ) );
        } // public static PointF Mirror( this PointF source, PointF Center )
        
        /// <summary> Return new point that mirror by center HLine. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center HLine to calculate mirror point.</param>
        /// <returns>new point that mirror by center HLine</returns>
        public static PointF Mirror( this PointF source, HLine Center ) {
            return new PointF( source.X, source.Y.Mirror( Center.Y ) );
        } // public static PointF Mirror( this PointF source, HLine Center )
        
        /// <summary> Return new point that mirror by center VLine. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center VLine to calculate mirror point.</param>
        /// <returns>new point that mirror by center VLine</returns>
        public static PointF Mirror( this PointF source, VLine Center ) {
            return new PointF( source.X.Mirror( Center.X ), source.Y );
        } // public static PointF Mirror( this PointF source, VLine Center )

        #endregion

        #region Rotate

        /// <summary> Rotate the point by specify center and angle. </summary>
        /// <param name="source">The source.</param>
        /// <param name="center">Center point of rotation.</param>
        /// <param name="angle">The angle to rotate.</param>
        /// <returns>Point which rotate by specify center and angle.</returns>
        public static PointF Rotate( this PointF source, PointF center, float angle ) {
            // get radians, cos, sin.
            var radians = PGMath.ToRadians( angle );
            var cosTheta = Math.Cos( radians );
            var sinTheta = Math.Sin( radians );

            // calculate rotate point.
            var newX = cosTheta * ( source.X - center.X ) - sinTheta * ( source.Y - center.Y ) + center.X;
            var newY = sinTheta * ( source.X - center.X ) + cosTheta * ( source.Y - center.Y ) + center.Y;

            // return it.
            return new PointF( (float)newX, (float)newY );
        } // public static PointF Rotate( this PointF source, PointF center, float angle )

        /// <summary> Rotate the point by specify center and radians. </summary>
        /// <param name="source">The source.</param>
        /// <param name="center">Center point of rotation.</param>
        /// <param name="radians">The radians to rotate.</param>
        /// <returns>Point which rotate by specify center and radians.</returns>
        public static PointF RotateByRadians( this PointF source, PointF center, float radians ) {
            // get cos, sin.
            var cosTheta = Math.Cos( radians );
            var sinTheta = Math.Sin( radians );

            // calculate rotate point.
            var newX = cosTheta * ( source.X - center.X ) - sinTheta * ( source.Y - center.Y ) + center.X;
            var newY = sinTheta * ( source.X - center.X ) + cosTheta * ( source.Y - center.Y ) + center.Y;

            // return it.
            return new PointF( (float)newX, (float)newY );
        } // public static PointF RotateByRadians( this PointF source, PointF center, float radians )

        #endregion

    } // public static class PointExtension

} // namespace PGCafe
