using Newtonsoft.Json;
using System;
using System.Drawing;

namespace PGCafe.Object {

    /// <summary> Line object contains two point. </summary>
    public struct Line {

        #region Instance & Constructor

        /// <summary> X of Point1 </summary>
        public float X1 { get; set; }

        /// <summary> Y of Point1 </summary>
        public float Y1 { get; set; }

        /// <summary> X of Point2 </summary>
        public float X2 { get; set; }

        /// <summary> Y of Point2 </summary>
        public float Y2 { get; set; }


        /// <summary> Initializes a new instance of the <see cref="Line"/> struct. </summary>
        /// <param name="X1"> X of Point1 </param>
        /// <param name="Y1"> Y of Point1 </param>
        /// <param name="X2"> X of Point2 </param>
        /// <param name="Y2"> Y of Point2 </param>
        [JsonConstructor]
        public Line( float X1, float Y1, float X2, float Y2 ) {
            this.X1 = X1;  this.Y1 = Y1;
            this.X2 = X2;  this.Y2 = Y2;
        } // public Line( float X1, float Y1, float X2, float Y2 )
        

        /// <summary> Initializes a new instance of the <see cref="Line"/> struct. </summary>
        /// <param name="Point1"> Point1 </param>
        /// <param name="Point2"> Point1 </param>
        public Line( PointF Point1, PointF Point2 ) {
            this.X1 = Point1.X;  this.Y1 = Point1.Y;
            this.X2 = Point2.X;  this.Y2 = Point2.Y;
        } // public Line( PointF Point1, PointF Point2 )

        #endregion

        #region Non field property

        /// <summary> Point1 </summary>
        public PointF Point1 {
            get { return new PointF( X1, Y1 ); }
            set { X1 = value.X;  Y1 = value.Y; }
        } // public PointF Point1
        
        /// <summary> Point2 </summary>
        public PointF Point2 {
            get { return new PointF( X2, Y2 ); }
            set { X2 = value.X;  Y2 = value.Y; }
        } // public PointF Point2
        
        /// <summary> Rect contains whole line, the line's endpoints should be Rect's TopLeft and BottomRight </summary>
        public RectangleF ContainRect {
            get { return new RectangleF( Math.Min( X1, X2 ), Math.Min( Y1, Y2 ), Math.Abs( X2 - X1 ), Math.Abs( Y2 - Y1 ) ); }
            set { X1 = value.Left;  X2 = value.Right;  Y1 = value.Top;  Y2 = value.Bottom; }
        } // public RectangleF ContainRect

        /// <summary> Length of line </summary>
        public float Length => Math.Sqrt( Math.Pow( X1 - X2, 2 ) + Math.Pow( Y1 - Y2, 2 ) ).ToType<float>();
        
        /// <summary> Determine the line is horizontal or not. </summary>
        public bool IsHorizontal => this.Y1 == this.Y2;
        
        /// <summary> Determine the line is vertical or not. </summary>
        public bool IsVertical => this.X1 == this.X2;

        #endregion

    } // public struct Line


    /// <summary>
    /// Horizontal Line object contains left point and Line width.
    /// </summary>
    public struct HLine {

        #region Instance & Constructor

        /// <summary> X of left point </summary>
        public float X { get; set; }

        /// <summary> Y of left point </summary>
        public float Y { get; set; }

        /// <summary> Line's width </summary>
        public float Width { get; set; }


        /// <summary> Initializes a new instance of the <see cref="HLine"/> struct. </summary>
        /// <param name="X"> X of left point </param>
        /// <param name="Y"> Y of left point </param>
        /// <param name="Width"> Line's width </param>
        [JsonConstructor]
        public HLine( float X, float Y, float Width ) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
        } // public HLine( float X, float Y, float Width )


        /// <summary> Initializes a new instance of the <see cref="HLine"/> struct. </summary>
        /// <param name="Point"> Left point of Line </param>
        /// <param name="Width"> Line's width </param>
        public HLine( PointF Point, float Width ) {
            this.X = Point.X;
            this.Y = Point.Y;
            this.Width = Width;
        } // public HLine( PointF Point, float Width )

        #endregion

        #region Non field property

        /// <summary> Left value of Line </summary>
        public float Left {
            get { return X; }
            set { X = value; }
        } // public float Left

        /// <summary> Right value of Line </summary>
        public float Right {
            get { return X + Width; }
            set { X = value - Width; }
        } // public float Right

        /// <summary> Left point of Line </summary>
        public PointF LeftPoint {
            get { return new PointF( X, Y ); }
            set { X = value.X; Y = value.Y; }
        } // public PointF LeftPoint

        /// <summary> Right point of Line </summary>
        public PointF RightPoint {
            get { return new PointF( X + Width, Y ); }
            set { X = value.X - Width; Y = value.Y; }
        } // public PointF RightPoint

        #endregion

        #region operator        

        /// <summary> Performs an implicit conversion from <see cref="HLine"/> to <see cref="Line"/>. </summary>
        /// <param name="HLine">The HLine.</param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator Line( HLine HLine ) {
            return new Line( HLine.X, HLine.Y, HLine.X + HLine.Width, HLine.Y );
        } // public static implicit operator Line( HLine HLine )

        #endregion

    } // public struct HLine


    /// <summary>
    /// Vertical Line object contains top point and Line height.
    /// </summary>
    public struct VLine {

        #region Instance & Constructor

        /// <summary> X of Top point </summary>
        public float X { get; set; }

        /// <summary> Y of Top point </summary>
        public float Y { get; set; }

        /// <summary> Line's height </summary>
        public float Height { get; set; }


        /// <summary> Initializes a new instance of the <see cref="VLine"/> struct. </summary>
        /// <param name="X"> X of Top point </param>
        /// <param name="Y"> Y of Top point </param>
        /// <param name="Height"> Line's height </param>
        [JsonConstructor]
        public VLine( float X, float Y, float Height ) {
            this.X = X;
            this.Y = Y;
            this.Height = Height;
        } // public VLine( float X, float Y, float Height )


        /// <summary> Initializes a new instance of the <see cref="VLine"/> struct. </summary>
        /// <param name="Point"> Top point of Line </param>
        /// <param name="Height"> Line's height </param>
        public VLine( PointF Point, float Height ) {
            this.X = Point.X;
            this.Y = Point.Y;
            this.Height = Height;
        } // public VLine( PointF Point, float Height )

        #endregion

        #region Non field property

        /// <summary> Top value of Line </summary>
        public float Top {
            get { return Y; }
            set { Y = value; }
        } // public float Top

        /// <summary> Bottom value of Line </summary>
        public float Bottom {
            get { return Y + Height; }
            set { Y = value - Height; }
        } // public float Bottom

        /// <summary> Top point of Line </summary>
        public PointF TopPoint {
            get { return new PointF( X, Y ); }
            set { X = value.X; Y = value.Y; }
        } // public PointF TopPoint

        /// <summary> Bottom point of Line </summary>
        public PointF BottomPoint {
            get { return new PointF( X, Y + Height ); }
            set { X = value.X; Y = value.Y - Height; }
        } // public PointF BottomPoint

        #endregion

        #region operator        

        /// <summary> Performs an implicit conversion from <see cref="VLine"/> to <see cref="Line"/>. </summary>
        /// <param name="VLine">The VLine.</param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator Line( VLine VLine ) {
            return new Line( VLine.X, VLine.Y, VLine.X, VLine.Y + VLine.Height );
        } // public static implicit operator Line( VLine VLine )

        #endregion

    } // public struct VLine

} // namespace PGCafe.Object
