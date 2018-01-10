using System;
using System.Drawing;

namespace PGCafe.Object {

    /// <summary> 
    /// Line with value range.
    /// Setting value range to line, and get the point on line by value.
    /// </summary>
    public struct ValueLine {

        #region Instance & Constructor

        /// <summary> X of Point1 </summary>
        public float X1 { get; set; }

        /// <summary> Y of Point1 </summary>
        public float Y1 { get; set; }

        /// <summary> X of Point2 </summary>
        public float X2 { get; set; }

        /// <summary> Y of Point2 </summary>
        public float Y2 { get; set; }

        /// <summary> Value of Point1 </summary>
        public double Value1 { get; set; }

        /// <summary> Value of Point2 </summary>
        public double Value2 { get; set; }


        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="X1"> X of Point1 </param>
        /// <param name="Y1"> Y of Point1 </param>
        /// <param name="X2"> X of Point2 </param>
        /// <param name="Y2"> Y of Point2 </param>
        /// <param name="Value1"> Value of Point1 </param>
        /// <param name="Value2"> Value of Point2 </param>
        public ValueLine( float X1, float Y1, float X2, float Y2, double Value1, double Value2 ) {
            this.X1 = X1;  this.Y1 = Y1;
            this.X2 = X2;  this.Y2 = Y2;
            this.Value1 = Value1;  this.Value2 = Value2;
        } // public ValueLine( float X1, float Y1, float X2, float Y2, double Value1, double Value2 )


        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="X1"> X of Point1 </param>
        /// <param name="Y1"> Y of Point1 </param>
        /// <param name="X2"> X of Point2 </param>
        /// <param name="Y2"> Y of Point2 </param>
        /// <param name="ValueRange"> Value range of line </param>
        public ValueLine( float X1, float Y1, float X2, float Y2, ValueRange ValueRange ) {
            this.X1 = X1;  this.Y1 = Y1;
            this.X2 = X2;  this.Y2 = Y2;
            this.Value1 = ValueRange.From;  this.Value2 = ValueRange.To;
        } // public ValueLine( float X1, float Y1, float X2, float Y2, ValueRange ValueRange )
        

        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="Point1"> Point1 </param>
        /// <param name="Point2"> Point1 </param>
        /// <param name="Value1"> Value of Point1 </param>
        /// <param name="Value2"> Value of Point2 </param>
        public ValueLine( PointF Point1, PointF Point2, double Value1, double Value2 ) {
            this.X1 = Point1.X;  this.Y1 = Point1.Y;
            this.X2 = Point2.X;  this.Y2 = Point2.Y;
            this.Value1 = Value1;  this.Value2 = Value2;
        } // public ValueLine( PointF Point1, PointF Point2, double Value1, double Value2 )
        

        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="Point1"> Point1 </param>
        /// <param name="Point2"> Point1 </param>
        /// <param name="ValueRange"> Value range of line </param>
        public ValueLine( PointF Point1, PointF Point2, ValueRange ValueRange ) {
            this.X1 = Point1.X;  this.Y1 = Point1.Y;
            this.X2 = Point2.X;  this.Y2 = Point2.Y;
            this.Value1 = ValueRange.From;  this.Value2 = ValueRange.To;
        } // public ValueLine( PointF Point1, PointF Point2, ValueRange ValueRange )
        

        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="Line"> Line </param>
        /// <param name="Value1"> Value of Point1 </param>
        /// <param name="Value2"> Value of Point2 </param>
        public ValueLine( Line Line, double Value1, double Value2 ) {
            this.X1 = Line.X1;  this.Y1 = Line.Y1;
            this.X2 = Line.X2;  this.Y2 = Line.Y2;
            this.Value1 = Value1;  this.Value2 = Value2;
        } // public ValueLine( Line Line, double Value1, double Value2 )
        

        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="Line"> Line </param>
        /// <param name="ValueRange"> Value range of line </param>
        public ValueLine( Line Line, ValueRange ValueRange ) {
            this.X1 = Line.X1;  this.Y1 = Line.Y1;
            this.X2 = Line.X2;  this.Y2 = Line.Y2;
            this.Value1 = ValueRange.From;  this.Value2 = ValueRange.To;
        } // public ValueLine( Line Line, ValueRange ValueRange )


        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="HLine"> HLine to initial ValueLine's Point1 and Point2 </param>
        /// <param name="Value1"> Value of Point1 </param>
        /// <param name="Value2"> Value of Point2 </param>
        public ValueLine( HLine HLine, double Value1, double Value2 ) {
            this.X1 = HLine.X;
            this.Y1 = HLine.Y;
            this.X2 = HLine.X + HLine.Width;
            this.Y2 = HLine.Y;
            this.Value1 = Value1;
            this.Value2 = Value2;
        } // public ValueLine( HLine HLine, double Value1, double Value2 )


        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="HLine"> HLine to initial ValueLine's Point1 and Point2 </param>
        /// <param name="ValueRange"> Value range of line </param>
        public ValueLine( HLine HLine, ValueRange ValueRange ) {
            this.X1 = HLine.X;
            this.Y1 = HLine.Y;
            this.X2 = HLine.X + HLine.Width;
            this.Y2 = HLine.Y;
            this.Value1 = ValueRange.From;
            this.Value2 = ValueRange.To;
        } // public ValueLine( HLine HLine, ValueRange ValueRange )


        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="VLine"> VLine to initial ValueLine's Point1 and Point2 </param>
        /// <param name="Value1"> Value of Point1 </param>
        /// <param name="Value2"> Value of Point2 </param>
        public ValueLine( VLine VLine, double Value1, double Value2 ) {
            this.X1 = VLine.X;
            this.Y1 = VLine.Y;
            this.X2 = VLine.X;
            this.Y2 = VLine.Y + VLine.Height;
            this.Value1 = Value1;
            this.Value2 = Value2;
        } // public ValueLine( VLine VLine, double Value1, double Value2 )


        /// <summary> Initializes a new instance of the <see cref="ValueLine"/> struct. </summary>
        /// <param name="VLine"> VLine to initial ValueLine's Point1 and Point2 </param>
        /// <param name="ValueRange"> Value range of line </param>
        public ValueLine( VLine VLine, ValueRange ValueRange ) {
            this.X1 = VLine.X;
            this.Y1 = VLine.Y;
            this.X2 = VLine.X;
            this.Y2 = VLine.Y + VLine.Height;
            this.Value1 = ValueRange.From;
            this.Value2 = ValueRange.To;
        } // public ValueLine( VLine VLine, ValueRange ValueRange )

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
        
        /// <summary> Line without ValurRange </summary>
        public Line Line {
            get { return new Line( X1, Y1, X2, Y2 ); }
            set { X1 = value.X1;  X2 = value.X2;  Y1 = value.Y1;  Y2 = value.Y2; }
        } // public Line Line
        
        /// <summary> Rect contains whole line, the line's endpoints should be Rect's TopLeft and BottomRight </summary>
        public RectangleF ContainRect {
            get { return new RectangleF( Math.Min( X1, X2 ), Math.Min( Y1, Y2 ), Math.Abs( X2 - X1 ), Math.Abs( Y2 - Y1 ) ); }
            set { X1 = value.Left;  X2 = value.Right;  Y1 = value.Top;  Y2 = value.Bottom; }
        } // public RectangleF ContainRect
        
        /// <summary> Value range of line </summary>
        public ValueRange ValueRange {
            get { return new ValueRange( Value1, Value2 ); }
            set { Value1 = value.From;  Value2 = value.To; }
        } // public ValueRange ValueRange

        /// <summary> Length of line </summary>
        public float Length => Math.Sqrt( Math.Pow( X1 - X2, 2 ) + Math.Pow( Y1 - Y2, 2 ) ).ToType<float>();
        
        /// <summary> Determine the line is horizontal or not. </summary>
        public bool IsHorizontal => this.Y1 == this.Y2;
        
        /// <summary> Determine the line is vertical or not. </summary>
        public bool IsVertical => this.X1 == this.X2;

        #endregion

        #region implicit operator

        /// <summary> Performs an implicit conversion from <see cref="HValueLine"/> to <see cref="ValueLine"/>. </summary>
        /// <param name="HValueLine">The HValueLine.</param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator ValueLine( HValueLine HValueLine ) {
            return new ValueLine( HValueLine.X, HValueLine.Y, HValueLine.X + HValueLine.Width, HValueLine.Y, HValueLine.LeftValue, HValueLine.RightValue );
        } // public static implicit operator ValueLine( HValueLine HValueLine )

        /// <summary> Performs an implicit conversion from <see cref="VValueLine"/> to <see cref="ValueLine"/>. </summary>
        /// <param name="VValueLine">The VValueLine.</param>
        /// <returns> The result of the conversion. </returns>
        public static implicit operator ValueLine( VValueLine VValueLine ) {
            return new ValueLine( VValueLine.X, VValueLine.Y, VValueLine.X, VValueLine.Y + VValueLine.Height, VValueLine.TopValue, VValueLine.BottomValue );
        } // public static implicit operator ValueLine( VValueLine VValueLine )

        #endregion

        #region GetPoint

        /// <summary> Get the point on line by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on line </returns>
        public PointF GetPoint( double Value ) {
            return new PointF() {
                X = (float)ValueRange.GetValue( X1, X2, ValueRange.GetPercent( Value1, Value2, Value ) ),
                Y = (float)ValueRange.GetValue( Y1, Y2, ValueRange.GetPercent( Value1, Value2, Value ) ),
            };
        } // public PointF GetPoint( double Value )

        #endregion

    } // public struct ValueLine


    /// <summary> 
    /// Horizontal Line with value range.
    /// Setting value range to line, and get the point on line by value.
    /// </summary>
    public struct HValueLine {

        #region Instance & Constructor

        /// <summary> X of left point </summary>
        public float X { get; set; }

        /// <summary> Y of left point </summary>
        public float Y { get; set; }

        /// <summary> Line's width </summary>
        public float Width { get; set; }

        /// <summary> Value of Left Point </summary>
        public double LeftValue { get; set; }

        /// <summary> Value of Right Point </summary>
        public double RightValue { get; set; }


        /// <summary> Initializes a new instance of the <see cref="HValueLine"/> struct. </summary>
        /// <param name="X"> X of left point </param>
        /// <param name="Y"> Y of left point </param>
        /// <param name="Width"> Line's width </param>
        /// <param name="LeftValue"> Value of left point </param>
        /// <param name="RightValue"> Value of right point </param>
        public HValueLine( float X, float Y, float Width, double LeftValue, double RightValue ) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.LeftValue = LeftValue;
            this.RightValue = RightValue;
        } // public HValueLine( float X, float Y, float Width, double LeftValue, double RightValue )


        /// <summary> Initializes a new instance of the <see cref="HValueLine"/> struct. </summary>
        /// <param name="X"> X of left point </param>
        /// <param name="Y"> Y of left point </param>
        /// <param name="Width"> Line's width </param>
        /// <param name="ValueRange"> Value range of line </param>
        public HValueLine( float X, float Y, float Width, ValueRange ValueRange ) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.LeftValue = ValueRange.From;
            this.RightValue = ValueRange.To;
        } // public HValueLine( float X, float Y, float Width, ValueRange ValueRange )


        /// <summary> Initializes a new instance of the <see cref="HValueLine"/> struct. </summary>
        /// <param name="Point"> Left point of Line </param>
        /// <param name="Width"> Line's width </param>
        /// <param name="LeftValue"> Value of left point </param>
        /// <param name="RightValue"> Value of right point </param>
        public HValueLine( PointF Point, float Width, double LeftValue, double RightValue ) {
            this.X = Point.X;
            this.Y = Point.Y;
            this.Width = Width;
            this.LeftValue = LeftValue;
            this.RightValue = RightValue;
        } // public HValueLine( PointF Point, float Width, double LeftValue, double RightValue )


        /// <summary> Initializes a new instance of the <see cref="HValueLine"/> struct. </summary>
        /// <param name="Point"> Left point of Line </param>
        /// <param name="Width"> Line's width </param>
        /// <param name="ValueRange"> Value range of line </param>
        public HValueLine( PointF Point, float Width, ValueRange ValueRange ) {
            this.X = Point.X;
            this.Y = Point.Y;
            this.Width = Width;
            this.LeftValue = ValueRange.From;
            this.RightValue = ValueRange.To;
        } // public HValueLine( PointF Point, float Width, ValueRange ValueRange )


        /// <summary> Initializes a new instance of the <see cref="HValueLine"/> struct. </summary>
        /// <param name="HLine"> HLine of HValueLine's left point and width </param>
        /// <param name="LeftValue"> Value of left point </param>
        /// <param name="RightValue"> Value of right point </param>
        public HValueLine( HLine HLine, double LeftValue, double RightValue ) {
            this.X = HLine.X;
            this.Y = HLine.Y;
            this.Width = HLine.Width;
            this.LeftValue = LeftValue;
            this.RightValue = RightValue;
        } // public HValueLine( HLine HLine, double LeftValue, double RightValue )


        /// <summary> Initializes a new instance of the <see cref="HValueLine"/> struct. </summary>
        /// <param name="HLine"> HLine of HValueLine's left point and width </param>
        /// <param name="ValueRange"> Value range of line </param>
        public HValueLine( HLine HLine, ValueRange ValueRange ) {
            this.X = HLine.X;
            this.Y = HLine.Y;
            this.Width = HLine.Width;
            this.LeftValue = ValueRange.From;
            this.RightValue = ValueRange.To;
        } // public HValueLine( HLine HLine, ValueRange ValueRange )

        #endregion

        #region Non field property

        /// <summary> Left point of Line </summary>
        public PointF Left {
            get { return new PointF( X, Y ); }
            set { X = value.X; Y = value.Y; }
        } // public PointF Left

        /// <summary> Right point of Line </summary>
        public PointF Right {
            get { return new PointF( X + Width, Y ); }
            set { X = value.X - Width; Y = value.Y; }
        } // public PointF Right

        /// <summary> Line without value </summary>
        public Line Line {
            get { return new Line( X, Y, X + Width, Y ); }
        } // public Line Line

        /// <summary> HLine without value </summary>
        public HLine HLine {
            get { return new HLine( X, Y, Width ); }
            set { this.X = value.X; this.Y = value.Y; this.Width = value.Width; }
        } // public HLine HLine

        /// <summary> Value range of line </summary>
        public ValueRange ValueRange {
            get { return new ValueRange( LeftValue, RightValue ); }
            set { LeftValue = value.From; RightValue = value.To; }
        } // public ValueRange ValueRange

        #endregion

        #region GetX, GetPoint

        /// <summary> Get the X on line by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> X value on line </returns>
        public float GetX( double Value ) {
            return (float)ValueRange.GetValue( X, X + Width, ValueRange.GetPercent( LeftValue, RightValue, Value ) );
        } // public float GetX( double Value )

        /// <summary> Get the point on line by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on line </returns>
        public PointF GetPoint( double Value ) {
            return new PointF( this.GetX( Value ), Y );
        } // public PointF GetPoint( double Value )

        #endregion

    } // public struct HValueLine


    /// <summary> 
    /// Vertical Line with value range.
    /// Setting value range to line, and get the point on line by value.
    /// </summary>
    public struct VValueLine {

        #region Instance & Constructor

        /// <summary> X of top point </summary>
        public float X { get; set; }

        /// <summary> Y of top point </summary>
        public float Y { get; set; }

        /// <summary> Line's height </summary>
        public float Height { get; set; }

        /// <summary> Value of Top Point </summary>
        public double TopValue { get; set; }

        /// <summary> Value of Bottom Point </summary>
        public double BottomValue { get; set; }


        /// <summary> Initializes a new instance of the <see cref="VValueLine"/> struct. </summary>
        /// <param name="X"> X of top point </param>
        /// <param name="Y"> Y of top point </param>
        /// <param name="Height"> Line's height </param>
        /// <param name="TopValue"> Value of top point </param>
        /// <param name="BottomValue"> Value of bottom point </param>
        public VValueLine( float X, float Y, float Height, double TopValue, double BottomValue ) {
            this.X = X;
            this.Y = Y;
            this.Height = Height;
            this.TopValue = TopValue;
            this.BottomValue = BottomValue;
        } // public VValueLine( float X, float Y, float Height, double TopValue, double BottomValue )


        /// <summary> Initializes a new instance of the <see cref="VValueLine"/> struct. </summary>
        /// <param name="X"> X of top point </param>
        /// <param name="Y"> Y of top point </param>
        /// <param name="Height"> Line's height </param>
        /// <param name="ValueRange"> Value range of line </param>
        public VValueLine( float X, float Y, float Height, ValueRange ValueRange ) {
            this.X = X;
            this.Y = Y;
            this.Height = Height;
            this.TopValue = ValueRange.From;
            this.BottomValue = ValueRange.To;
        } // public VValueLine( float X, float Y, float Height, ValueRange ValueRange )


        /// <summary> Initializes a new instance of the <see cref="VValueLine"/> struct. </summary>
        /// <param name="Point"> Top point of Line </param>
        /// <param name="Height"> Line's height </param>
        /// <param name="TopValue"> Value of top point </param>
        /// <param name="BottomValue"> Value of bottom point </param>
        public VValueLine( PointF Point, float Height, double TopValue, double BottomValue ) {
            this.X = Point.X;
            this.Y = Point.Y;
            this.Height = Height;
            this.TopValue = TopValue;
            this.BottomValue = BottomValue;
        } // public VValueLine( PointF Point, float Height, double TopValue, double BottomValue )


        /// <summary> Initializes a new instance of the <see cref="VValueLine"/> struct. </summary>
        /// <param name="Point"> Top point of Line </param>
        /// <param name="Height"> Line's height </param>
        /// <param name="ValueRange"> Value range of line </param>
        public VValueLine( PointF Point, float Height, ValueRange ValueRange ) {
            this.X = Point.X;
            this.Y = Point.Y;
            this.Height = Height;
            this.TopValue = ValueRange.From;
            this.BottomValue = ValueRange.To;
        } // public VValueLine( PointF Point, float Height, ValueRange ValueRange )


        /// <summary> Initializes a new instance of the <see cref="VValueLine"/> struct. </summary>
        /// <param name="VLine"> VLine of VValueLine's top point and height </param>
        /// <param name="TopValue"> Value of top point </param>
        /// <param name="BottomValue"> Value of bottom point </param>
        public VValueLine( VLine VLine, double TopValue, double BottomValue ) {
            this.X = VLine.X;
            this.Y = VLine.Y;
            this.Height = VLine.Height;
            this.TopValue = TopValue;
            this.BottomValue = BottomValue;
        } // public VValueLine( VLine VLine, double TopValue, double BottomValue )


        /// <summary> Initializes a new instance of the <see cref="VValueLine"/> struct. </summary>
        /// <param name="VLine"> VLine of VValueLine's top point and height </param>
        /// <param name="ValueRange"> Value range of line </param>
        public VValueLine( VLine VLine, ValueRange ValueRange ) {
            this.X = VLine.X;
            this.Y = VLine.Y;
            this.Height = VLine.Height;
            this.TopValue = ValueRange.From;
            this.BottomValue = ValueRange.To;
        } // public VValueLine( VLine VLine, ValueRange ValueRange )

        #endregion

        #region Non field property

        /// <summary> Top point of Line </summary>
        public PointF Top {
            get { return new PointF( X, Y ); }
            set { X = value.X; Y = value.Y; }
        } // public PointF Top

        /// <summary> Bottom point of Line </summary>
        public PointF Bottom {
            get { return new PointF( X + Height, Y ); }
            set { X = value.X; Y = value.Y - Height; }
        } // public PointF Bottom

        /// <summary> Line without value </summary>
        public Line Line {
            get { return new Line( X, Y, X, Y + Height ); }
        } // public Line Line

        /// <summary> VLine without value </summary>
        public VLine VLine {
            get { return new VLine( X, Y, Height ); }
            set { this.X = value.X; this.Y = value.Y; this.Height = value.Height; }
        } // public VLine VLine

        /// <summary> Value range of line </summary>
        public ValueRange ValueRange {
            get { return new ValueRange( TopValue, BottomValue ); }
            set { TopValue = value.From; BottomValue = value.To; }
        } // public ValueRange ValueRange

        #endregion

        #region GetY, GetPoint

        /// <summary> Get the Y on line by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Y value on line </returns>
        public float GetY( double Value ) {
            return (float)ValueRange.GetValue( Y, Y + Height, ValueRange.GetPercent( TopValue, BottomValue, Value ) );
        } // public float GetY( double Value )

        /// <summary> Get the point on line by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on line </returns>
        public PointF GetPoint( double Value ) {
            return new PointF( X, this.GetY( Value ) );
        } // public PointF GetPoint( double Value )

        #endregion

    } // public struct VValueLine

} // namespace PGCafe.Object
