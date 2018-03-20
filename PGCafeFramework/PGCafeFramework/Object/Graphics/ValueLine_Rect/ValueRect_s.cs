using Newtonsoft.Json;
using System.Drawing;

namespace PGCafe.Object {
    
    /// <summary> 
    /// Rect with value range.
    /// Setting value range to rect, and get the point on rect by value.
    /// </summary>
    public struct ValueRect {

        #region Property & Constructor
        
        /// <summary> X of TopLeft point </summary>
        public float X { get; set; }

        /// <summary> Y of TopLeft point </summary>
        public float Y { get; set; }

        /// <summary> Width of Rect </summary>
        public float Width { get; set; }

        /// <summary> Height of Rect </summary>
        public float Height { get; set; }

        /// <summary> Value of Left </summary>
        public double LeftValue { get; set; }

        /// <summary> Value of Right </summary>
        public double RightValue { get; set; }

        /// <summary> Value of Top </summary>
        public double TopValue { get; set; }

        /// <summary> Value of Bottom </summary>
        public double BottomValue { get; set; }

        /// <summary> Initializes a new instance of the <see cref="ValueRect"/> struct. </summary>
        /// <param name="X"> X of TopLeft point </param>
        /// <param name="Y"> Y of TopLeft point </param>
        /// <param name="Width">Width of Rect.</param>
        /// <param name="Height">Height of Rect.</param>
        /// <param name="LeftValue">Value of Left.</param>
        /// <param name="RightValue">Value of Right.</param>
        /// <param name="TopValue">Value of Top.</param>
        /// <param name="BottomValue">Value of Bottom.</param>
        [JsonConstructor]
        public ValueRect( float X, float Y, float Width, float Height, double LeftValue, double RightValue, double TopValue, double BottomValue ) {
            this.X = X;  this.Y = Y;  this.Width = Width;  this.Height = Height;
            this.LeftValue = LeftValue;  this.RightValue = RightValue;
            this.TopValue = TopValue;  this.BottomValue = BottomValue;
        } // public ValueRect( float X, float Y, float Width, float Height, double LeftValue, double RightValue, double TopValue, double BottomValue )

        /// <summary> Initializes a new instance of the <see cref="ValueRect"/> struct. </summary>
        /// <param name="X"> X of TopLeft point </param>
        /// <param name="Y"> Y of TopLeft point </param>
        /// <param name="Width">Width of Rect.</param>
        /// <param name="Height">Height of Rect.</param>
        /// <param name="XValueRange">Value of Left &amp; Right.</param>
        /// <param name="YValueRange">Value of Top &amp; Bottom.</param>
        public ValueRect( float X, float Y, float Width, float Height, ValueRange XValueRange, ValueRange YValueRange ) {
            this.X = X;  this.Y = Y;  this.Width = Width;  this.Height = Height;
            this.LeftValue = XValueRange.From;  this.RightValue = XValueRange.To;
            this.TopValue = YValueRange.From;  this.BottomValue = YValueRange.To;
        } // public ValueRect( float X, float Y, float Width, float Height, ValueRange XValueRange, ValueRange YValueRange )

        /// <summary> Initializes a new instance of the <see cref="ValueRect"/> struct. </summary>
        /// <param name="TopLeft"> TopLeft point </param>
        /// <param name="Size">Size of Rect.</param>
        /// <param name="LeftValue">Value of Left.</param>
        /// <param name="RightValue">Value of Right.</param>
        /// <param name="TopValue">Value of Top.</param>
        /// <param name="BottomValue">Value of Bottom.</param>
        public ValueRect( Point TopLeft, SizeF Size, double LeftValue, double RightValue, double TopValue, double BottomValue ) {
            this.X = TopLeft.X;  this.Y = TopLeft.Y;  this.Width = Size.Width;  this.Height = Size.Height;
            this.LeftValue = LeftValue;  this.RightValue = RightValue;
            this.TopValue = TopValue;  this.BottomValue = BottomValue;
        } // public ValueRect( Point TopLeft, SizeF Size, double LeftValue, double RightValue, double TopValue, double BottomValue )

        /// <summary> Initializes a new instance of the <see cref="ValueRect"/> struct. </summary>
        /// <param name="TopLeft"> TopLeft point </param>
        /// <param name="Size">Size of Rect.</param>
        /// <param name="XValueRange">Value of Left &amp; Right.</param>
        /// <param name="YValueRange">Value of Top &amp; Bottom.</param>
        public ValueRect( Point TopLeft, SizeF Size, ValueRange XValueRange, ValueRange YValueRange ) {
            this.X = TopLeft.X;  this.Y = TopLeft.Y;  this.Width = Size.Width;  this.Height = Size.Height;
            this.LeftValue = XValueRange.From;  this.RightValue = XValueRange.To;
            this.TopValue = YValueRange.From;  this.BottomValue = YValueRange.To;
        } // public ValueRect( Point TopLeft, SizeF Size, ValueRange XValueRange, ValueRange YValueRange )

        /// <summary> Initializes a new instance of the <see cref="ValueRect"/> struct. </summary>
        /// <param name="Rect"> Rectangle </param>
        /// <param name="LeftValue">Value of Left.</param>
        /// <param name="RightValue">Value of Right.</param>
        /// <param name="TopValue">Value of Top.</param>
        /// <param name="BottomValue">Value of Bottom.</param>
        public ValueRect( RectangleF Rect, double LeftValue, double RightValue, double TopValue, double BottomValue ) {
            this.X = Rect.X;  this.Y = Rect.Y;  this.Width = Rect.Width;  this.Height = Rect.Height;
            this.LeftValue = LeftValue;  this.RightValue = RightValue;
            this.TopValue = TopValue;  this.BottomValue = BottomValue;
        } // public ValueRect( RectangleF Rect, double LeftValue, double RightValue, double TopValue, double BottomValue )

        /// <summary> Initializes a new instance of the <see cref="ValueRect"/> struct. </summary>
        /// <param name="Rect"> Rectangle </param>
        /// <param name="XValueRange">Value of Left &amp; Right.</param>
        /// <param name="YValueRange">Value of Top &amp; Bottom.</param>
        public ValueRect( RectangleF Rect, ValueRange XValueRange, ValueRange YValueRange ) {
            this.X = Rect.X;  this.Y = Rect.Y;  this.Width = Rect.Width;  this.Height = Rect.Height;
            this.LeftValue = XValueRange.From;  this.RightValue = XValueRange.To;
            this.TopValue = YValueRange.From;  this.BottomValue = YValueRange.To;
        } // public ValueRect( RectangleF Rect, ValueRange XValueRange, ValueRange YValueRange )

        #endregion

        #region Not field property

        /// <summary> Rect </summary>
        public RectangleF Rect {
            get { return new RectangleF( this.X, this.Y, this.Width, this.Height ); }
            set { this.X = value.X;  this.Y = value.Y;  this.Width = value.Width;  this.Height = value.Height; }
        } // public RectangleF Rect

        /// <summary> Location </summary>
        public PointF TopLeft {
            get { return new PointF( this.X, this.Y ); }
            set { this.X = value.X;  this.Y = value.Y; }
        } // public PointF TopLeft

        /// <summary> Size </summary>
        public SizeF Size {
            get { return new SizeF( this.Width, this.Height ); }
            set { this.Width = value.Width;  this.Height = Height; }
        } // public SizeF Size

        /// <summary> TopRight Point </summary>
        public PointF TopRight {
            get { return new PointF( this.X + this.Width, this.Y ); }
            set { this.X = value.X - this.Width;  this.Y = value.Y; }
        } // public PointF TopRight

        /// <summary> BottomLeft Point </summary>
        public PointF BottomLeft {
            get { return new PointF( this.X, this.Y + this.Height ); }
            set { this.X = value.X;  this.Y = value.Y - this.Height; }
        } // public PointF BottomLeft

        /// <summary> BottomRight Point </summary>
        public PointF BottomRight {
            get { return new PointF( this.X + this.Width, this.Y + this.Height ); }
            set { this.X = value.X - this.Width;  this.Y = value.Y - this.Height; }
        } // public PointF BottomRight
        
        /// <summary> Value range of horizontal range </summary>
        public ValueRange XValueRange {
            get { return new ValueRange( LeftValue, RightValue ); }
            set { this.LeftValue = value.From;  this.RightValue = value.To; }
        } // public ValueRange XValueRange
        
        /// <summary> Value range of vertical range </summary>
        public ValueRange YValueRange {
            get { return new ValueRange( TopValue, BottomValue ); }
            set { this.TopValue = value.From;  this.BottomValue = value.To; }
        } // public ValueRange YValueRange

        #endregion
        
        #region GetPoint
        
        /// <summary> Get the X point on rect by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on rect </returns>
        public float GetPointX( double Value ) {
            return (float)ValueRange.GetValue( X, X + Width, ValueRange.GetPercent( LeftValue, RightValue, Value ) );
        } // public float GetPointX( double Value )
        
        /// <summary> Get the Y point on rect by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on rect </returns>
        public float GetPointY( double Value ) {
            return (float)ValueRange.GetValue( Y, Y + Height, ValueRange.GetPercent( TopValue, BottomValue, Value ) );
        } // public float GetPointY( double Value )
        
        /// <summary> Get the point on rect by value </summary>
        /// <param name="XValue">The XValue.</param>
        /// <param name="YValue">The YValue.</param>
        /// <returns> Point on rect </returns>
        public PointF GetPoint( double XValue, double YValue ) {
            return new PointF( GetPointX( XValue ), GetPointY( YValue ) );
        } // public PointF GetPoint( double XValue, double YValue )

        #endregion

    } // public struct ValueRect
    
    /// <summary> 
    /// Rect with horizontal value range.
    /// Setting value range to rect, and get the point on rect by value.
    /// </summary>
    public struct HValueRect {

        #region Property & Constructor
        
        /// <summary> X of TopLeft point </summary>
        public float X { get; set; }

        /// <summary> Y of TopLeft point </summary>
        public float Y { get; set; }

        /// <summary> Width of Rect </summary>
        public float Width { get; set; }

        /// <summary> Height of Rect </summary>
        public float Height { get; set; }

        /// <summary> Value of Left </summary>
        public double LeftValue { get; set; }

        /// <summary> Value of Right </summary>
        public double RightValue { get; set; }

        /// <summary> Initializes a new instance of the <see cref="HValueRect"/> struct. </summary>
        /// <param name="X"> X of TopLeft point </param>
        /// <param name="Y"> Y of TopLeft point </param>
        /// <param name="Width">Width of Rect.</param>
        /// <param name="Height">Height of Rect.</param>
        /// <param name="LeftValue">Value of Left.</param>
        /// <param name="RightValue">Value of Right.</param>
        [JsonConstructor]
        public HValueRect( float X, float Y, float Width, float Height, double LeftValue, double RightValue ) {
            this.X = X;  this.Y = Y;  this.Width = Width;  this.Height = Height;
            this.LeftValue = LeftValue;  this.RightValue = RightValue;
        } // public HValueRect( float X, float Y, float Width, float Height, double LeftValue, double RightValue )

        /// <summary> Initializes a new instance of the <see cref="HValueRect"/> struct. </summary>
        /// <param name="X"> X of TopLeft point </param>
        /// <param name="Y"> Y of TopLeft point </param>
        /// <param name="Width">Width of Rect.</param>
        /// <param name="Height">Height of Rect.</param>
        /// <param name="ValueRange">Value of Left &amp; Right.</param>
        public HValueRect( float X, float Y, float Width, float Height, ValueRange ValueRange ) {
            this.X = X;  this.Y = Y;  this.Width = Width;  this.Height = Height;
            this.LeftValue = ValueRange.From;  this.RightValue = ValueRange.To;
        } // public HValueRect( float X, float Y, float Width, float Height, ValueRange ValueRange )

        /// <summary> Initializes a new instance of the <see cref="HValueRect"/> struct. </summary>
        /// <param name="TopLeft"> TopLeft point </param>
        /// <param name="Size">Size of Rect.</param>
        /// <param name="LeftValue">Value of Left.</param>
        /// <param name="RightValue">Value of Right.</param>
        public HValueRect( Point TopLeft, SizeF Size, double LeftValue, double RightValue ) {
            this.X = TopLeft.X;  this.Y = TopLeft.Y;  this.Width = Size.Width;  this.Height = Size.Height;
            this.LeftValue = LeftValue;  this.RightValue = RightValue;
        } // public HValueRect( Point TopLeft, SizeF Size, double LeftValue, double RightValue )

        /// <summary> Initializes a new instance of the <see cref="HValueRect"/> struct. </summary>
        /// <param name="TopLeft"> TopLeft point </param>
        /// <param name="Size">Size of Rect.</param>
        /// <param name="ValueRange">Value of Left &amp; Right.</param>
        public HValueRect( Point TopLeft, SizeF Size, ValueRange ValueRange ) {
            this.X = TopLeft.X;  this.Y = TopLeft.Y;  this.Width = Size.Width;  this.Height = Size.Height;
            this.LeftValue = ValueRange.From;  this.RightValue = ValueRange.To;
        } // public HValueRect( Point TopLeft, SizeF Size, ValueRange ValueRange )

        /// <summary> Initializes a new instance of the <see cref="HValueRect"/> struct. </summary>
        /// <param name="Rect"> Rectangle </param>
        /// <param name="LeftValue">Value of Left.</param>
        /// <param name="RightValue">Value of Right.</param>
        public HValueRect( RectangleF Rect, double LeftValue, double RightValue ) {
            this.X = Rect.X;  this.Y = Rect.Y;  this.Width = Rect.Width;  this.Height = Rect.Height;
            this.LeftValue = LeftValue;  this.RightValue = RightValue;
        } // public HValueRect( RectangleF Rect, double LeftValue, double RightValue )

        /// <summary> Initializes a new instance of the <see cref="HValueRect"/> struct. </summary>
        /// <param name="Rect"> Rectangle </param>
        /// <param name="ValueRange">Value of Left &amp; Right.</param>
        public HValueRect( RectangleF Rect, ValueRange ValueRange ) {
            this.X = Rect.X;  this.Y = Rect.Y;  this.Width = Rect.Width;  this.Height = Rect.Height;
            this.LeftValue = ValueRange.From;  this.RightValue = ValueRange.To;
        } // public HValueRect( RectangleF Rect, ValueRange ValueRange )

        #endregion

        #region Not field property

        /// <summary> Rect </summary>
        public RectangleF Rect {
            get { return new RectangleF( this.X, this.Y, this.Width, this.Height ); }
            set { this.X = value.X;  this.Y = value.Y;  this.Width = value.Width;  this.Height = value.Height; }
        } // public RectangleF Rect

        /// <summary> Size </summary>
        public SizeF Size {
            get { return new SizeF( this.Width, this.Height ); }
            set { this.Width = value.Width;  this.Height = value.Height; }
        } // public SizeF Size

        /// <summary> TopLeft Point </summary>
        public PointF TopLeft {
            get { return new PointF( this.X, this.Y ); }
            set { this.X = value.X;  this.Y = value.Y; }
        } // public PointF TopLeft

        /// <summary> TopRight Point </summary>
        public PointF TopRight {
            get { return new PointF( this.X + this.Width, this.Y ); }
            set { this.X = value.X - this.Width;  this.Y = value.Y; }
        } // public PointF TopRight

        /// <summary> BottomLeft Point </summary>
        public PointF BottomLeft {
            get { return new PointF( this.X, this.Y + this.Height ); }
            set { this.X = value.X;  this.Y = value.Y - this.Height; }
        } // public PointF BottomLeft

        /// <summary> BottomRight Point </summary>
        public PointF BottomRight {
            get { return new PointF( this.X + this.Width, this.Y + this.Height ); }
            set { this.X = value.X - this.Width;  this.Y = value.Y - this.Height; }
        } // public PointF BottomRight
        
        /// <summary> Value range of horizontal range </summary>
        public ValueRange ValueRange {
            get { return new ValueRange( LeftValue, RightValue ); }
            set { this.LeftValue = value.From;  this.RightValue = value.To; }
        } // public ValueRange ValueRange

        #endregion
        
        #region GetPoint, GetVLine
        
        /// <summary> Get the X point on rect by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on rect </returns>
        public float GetPointX( double Value ) {
            return (float)ValueRange.GetValue( X, X + Width, ValueRange.GetPercent( LeftValue, RightValue, Value ) );
        } // public float GetPointX( double Value )
        
        /// <summary> Get the point on rect by value </summary>
        /// <param name="XValue">The XValue.</param>
        /// <param name="Y">The Y of point.</param>
        /// <returns> Point on rect </returns>
        public PointF GetPoint( double XValue, float Y ) {
            return new PointF( GetPointX( XValue ), Y );
        } // public PointF GetPoint( double XValue, float Y )
        
        /// <summary> Get the VLine on rect by value of X </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> VLine on rect </returns>
        public VLine GetVLine( double Value ) {
            return new VLine( GetPointX( Value ), this.Y, this.Height );
        } // public VLine GetVLine( double Value )

        #endregion

    } // public struct HValueRect
    
    /// <summary> 
    /// Rect with vertical value range.
    /// Setting value range to rect, and get the point on rect by value.
    /// </summary>
    public struct VValueRect {

        #region Property & Constructor
        
        /// <summary> X of TopLeft point </summary>
        public float X { get; set; }

        /// <summary> Y of TopLeft point </summary>
        public float Y { get; set; }

        /// <summary> Width of Rect </summary>
        public float Width { get; set; }

        /// <summary> Height of Rect </summary>
        public float Height { get; set; }

        /// <summary> Value of Top </summary>
        public double TopValue { get; set; }

        /// <summary> Value of Bottom </summary>
        public double BottomValue { get; set; }
        [JsonConstructor]

        /// <summary> Initializes a new instance of the <see cref="VValueRect"/> struct. </summary>
        /// <param name="X"> X of TopLeft point </param>
        /// <param name="Y"> Y of TopLeft point </param>
        /// <param name="Width">Width of Rect.</param>
        /// <param name="Height">Height of Rect.</param>
        /// <param name="TopValue">Value of Top.</param>
        /// <param name="BottomValue">Value of Bottom.</param>
        public VValueRect( float X, float Y, float Width, float Height, double TopValue, double BottomValue ) {
            this.X = X;  this.Y = Y;  this.Width = Width;  this.Height = Height;
            this.TopValue = TopValue;  this.BottomValue = BottomValue;
        } // public VValueRect( float X, float Y, float Width, float Height, double TopValue, double BottomValue )

        /// <summary> Initializes a new instance of the <see cref="VValueRect"/> struct. </summary>
        /// <param name="X"> X of TopLeft point </param>
        /// <param name="Y"> Y of TopLeft point </param>
        /// <param name="Width">Width of Rect.</param>
        /// <param name="Height">Height of Rect.</param>
        /// <param name="ValueRange">Value of Top &amp; Bottom.</param>
        public VValueRect( float X, float Y, float Width, float Height, ValueRange ValueRange ) {
            this.X = X;  this.Y = Y;  this.Width = Width;  this.Height = Height;
            this.TopValue = ValueRange.From;  this.BottomValue = ValueRange.To;
        } // public VValueRect( float X, float Y, float Width, float Height, ValueRange ValueRange )

        /// <summary> Initializes a new instance of the <see cref="VValueRect"/> struct. </summary>
        /// <param name="TopLeft"> TopLeft point </param>
        /// <param name="Size">Size of Rect.</param>
        /// <param name="TopValue">Value of Top.</param>
        /// <param name="BottomValue">Value of Bottom.</param>
        public VValueRect( Point TopLeft, SizeF Size, double TopValue, double BottomValue ) {
            this.X = TopLeft.X;  this.Y = TopLeft.Y;  this.Width = Size.Width;  this.Height = Size.Height;
            this.TopValue = TopValue;  this.BottomValue = BottomValue;
        } // public VValueRect( Point TopLeft, SizeF Size, double TopValue, double BottomValue )

        /// <summary> Initializes a new instance of the <see cref="VValueRect"/> struct. </summary>
        /// <param name="TopLeft"> TopLeft point </param>
        /// <param name="Size">Size of Rect.</param>
        /// <param name="ValueRange">Value of Top &amp; Bottom.</param>
        public VValueRect( Point TopLeft, SizeF Size, ValueRange ValueRange ) {
            this.X = TopLeft.X;  this.Y = TopLeft.Y;  this.Width = Size.Width;  this.Height = Size.Height;
            this.TopValue = ValueRange.From;  this.BottomValue = ValueRange.To;
        } // public VValueRect( Point TopLeft, SizeF Size, ValueRange ValueRange )

        /// <summary> Initializes a new instance of the <see cref="VValueRect"/> struct. </summary>
        /// <param name="Rect"> Rectangle </param>
        /// <param name="TopValue">Value of Top.</param>
        /// <param name="BottomValue">Value of Bottom.</param>
        public VValueRect( RectangleF Rect, double TopValue, double BottomValue ) {
            this.X = Rect.X;  this.Y = Rect.Y;  this.Width = Rect.Width;  this.Height = Rect.Height;
            this.TopValue = TopValue;  this.BottomValue = BottomValue;
        } // public VValueRect( RectangleF Rect, double TopValue, double BottomValue )

        /// <summary> Initializes a new instance of the <see cref="VValueRect"/> struct. </summary>
        /// <param name="Rect"> Rectangle </param>
        /// <param name="ValueRange">Value of Top &amp; Bottom.</param>
        public VValueRect( RectangleF Rect, ValueRange ValueRange ) {
            this.X = Rect.X;  this.Y = Rect.Y;  this.Width = Rect.Width;  this.Height = Rect.Height;
            this.TopValue = ValueRange.From;  this.BottomValue = ValueRange.To;
        } // public VValueRect( RectangleF Rect, ValueRange ValueRange )

        #endregion

        #region Not field property

        /// <summary> Rect </summary>
        public RectangleF Rect {
            get { return new RectangleF( this.X, this.Y, this.Width, this.Height ); }
            set { this.X = value.X;  this.Y = value.Y;  this.Width = value.Width;  this.Height = value.Height; }
        } // public RectangleF Rect

        /// <summary> Size </summary>
        public SizeF Size {
            get { return new SizeF( this.Width, this.Height ); }
            set { this.Width = value.Width;  this.Height = Height; }
        } // public SizeF Size

        /// <summary> TopLeft Point </summary>
        public PointF TopLeft {
            get { return new PointF( this.X, this.Y ); }
            set { this.X = value.X;  this.Y = value.Y; }
        } // public PointF TopLeft

        /// <summary> TopRight Point </summary>
        public PointF TopRight {
            get { return new PointF( this.X + this.Width, this.Y ); }
            set { this.X = value.X - this.Width;  this.Y = value.Y; }
        } // public PointF TopRight

        /// <summary> BottomLeft Point </summary>
        public PointF BottomLeft {
            get { return new PointF( this.X, this.Y + this.Height ); }
            set { this.X = value.X;  this.Y = value.Y - this.Height; }
        } // public PointF BottomLeft

        /// <summary> BottomRight Point </summary>
        public PointF BottomRight {
            get { return new PointF( this.X + this.Width, this.Y + this.Height ); }
            set { this.X = value.X - this.Width;  this.Y = value.Y - this.Height; }
        } // public PointF BottomRight
        
        /// <summary> Value range of vertical range </summary>
        public ValueRange ValueRange {
            get { return new ValueRange( TopValue, BottomValue ); }
            set { this.TopValue = value.From;  this.BottomValue = value.To; }
        } // public ValueRange ValueRange

        #endregion
        
        #region GetPoint
        
        /// <summary> Get the X point on rect by value </summary>
        /// <param name="Value">The Value.</param>
        /// <returns> Point on rect </returns>
        public float GetPointY( double Value ) {
            return (float)Object.ValueRange.GetValue( Y, Y + Height, Object.ValueRange.GetPercent( TopValue, BottomValue, Value ) );
        } // public float GetPointY( double Value )
        
        /// <summary> Get the point on rect by value </summary>
        /// <param name="X">The X of point.</param>
        /// <param name="YValue">The YValue.</param>
        /// <returns> Point on rect </returns>
        public PointF GetPoint( float X, double YValue ) {            
            return new PointF( X, GetPointY( YValue ) );
        } // public PointF GetPoint( float X, double YValue )

        #endregion

    } // public struct VValueRect

} // namespace PGCafe.Object
