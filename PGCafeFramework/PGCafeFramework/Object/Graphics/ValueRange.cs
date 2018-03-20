using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> Provide some calculate between two value. </summary>
    public struct ValueRange {

        #region Property & Constructor

        private double mFromValue, mToValue;

        /// <summary> first Value </summary>
        public double From {
            get { return mFromValue; }
            set { mFromValue = value;  ResetExtermeValue(); }
        } // public double From

        /// <summary> second Value </summary>
        public double To {
            get { return mToValue; }
            set { mToValue = value;  ResetExtermeValue(); }
        } // public double To
        
        /// <summary> Length between Value1 and Value2 </summary>
        public double Length { get { return Math.Abs( From - To ); } }
                
        /// <summary> Mininum value in Value1 and Value2 </summary>
        public double Min { get; private set; }
        
        /// <summary> Maxnum value in Value1 and Value2 </summary>
        public double Max { get; private set; }
        
        /// <summary> Middle value between Value1 and Value2 </summary>
        public double Middle { get { return ( Min + Max ) / 2; } }


        /// <summary>
        /// Initializes a new instance of the <see cref="ValueRange"/> struct.
        /// </summary>
        /// <param name="From">The value form.</param>
        /// <param name="To">The value to.</param>
        [JsonConstructor]
        public ValueRange( double From, double To ) {
            this.mFromValue = From;  this.mToValue = To;
            this.Min = 0;  this.Max = 0;
            ResetExtermeValue();
        } // public ValueRange( double From, double To )


        private void ResetExtermeValue() {
            this.Min = Math.Min( mFromValue, mToValue );
            this.Max = Math.Max( mFromValue, mToValue );
        } // private void ResetExtermeValue()

        #endregion

        #region Instance method
                
        /// <summary> Calculate percent by value between value range. </summary>
        /// <param name="Value"> The value to calculate. </param>
        /// <returns> percent of value between value range. </returns>
        public double GetPercent( double Value ) {
            if ( To == From ) return 0;
            else return ( Value - From ) / ( To - From );
        } // public double GetPercent( double Value )

        /// <summary> Calculate the Value by assign Precent in Value Range. </summary>
        /// <param name="Percent">The percent to calculate.</param>
        /// <returns> value by percent between value range. </returns>
        public double GetValue( double Percent ) {
            return From + ( ( To - From ) * Percent );
        } // public double GetValue( double Percent )

        /// <summary> Get value in value region, if [Value] is out of range, return the bound value. </summary>
        /// <param name="Value">The value to check is in range.</param>
        /// <returns> value in range or bound value if [Value] out of range. </returns>
        public double InRange( double Value ) {
            if ( From == To ) return From;
            else if ( Value < this.Min ) return this.Min;
            else if ( Value > this.Max ) return this.Max;
            else return Value;
        } // public double InRange( double Value )

        #endregion

        #region Static method
                
        /// <summary> Calculate percent by value between value range. </summary>
        /// <param name="From"> The value from. </param>
        /// <param name="To"> The value to. </param>
        /// <param name="Value"> The value to calculate. </param>
        /// <returns> percent of value between value range. </returns>
        public static double GetPercent( double From, double To, double Value ) {
            if ( To == From ) return 0;
            else return ( Value - From ) / ( To - From );
        } // public static double GetPercent( double From, double To, double Value )

        /// <summary> Calculate the Value by assign Precent in Value Range. </summary>
        /// <param name="From"> The value from. </param>
        /// <param name="To"> The value to. </param>
        /// <param name="Percent">The percent to calculate.</param>
        /// <returns> value by percent between value range. </returns>
        public static double GetValue( double From, double To, double Percent ) {
            return From + ( ( To - From ) * Percent );
        } // public static double GetValue( double From, double To, double Percent )

        /// <summary> Get value in value region, if [Value] is out of range, return the bound value. </summary>
        /// <param name="From"> The value from. </param>
        /// <param name="To"> The value to. </param>
        /// <param name="Value">The value to check is in range.</param>
        /// <returns> value in range or bound value if [Value] out of range. </returns>
        public static double InRange( double From, double To, double Value ) {
            if ( From == To ) return From;

            var min = Math.Min( From, To );
            var max = Math.Max( From, To );

            if ( Value < min ) return min;
            else if ( Value > max ) return max;
            else return Value;
        } // public static double InRange( double From, double To, double Value )

        #endregion

    } // public struct ValueRange
} // namespace PGCafe.Object
