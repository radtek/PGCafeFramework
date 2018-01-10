
using System;

namespace PGCafe {
    /// <summary>
    /// Number's Extension.
    /// </summary>
    public static class NumberExtension_T4 {


    #region Mirror

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Byte Mirror( this Byte source, Byte Center ){
            return (Byte)( Center + ( Center - source ) );
        } // public static Byte Mirror( this Byte source, Byte Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static UInt16 Mirror( this UInt16 source, UInt16 Center ){
            return (UInt16)( Center + ( Center - source ) );
        } // public static UInt16 Mirror( this UInt16 source, UInt16 Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static UInt32 Mirror( this UInt32 source, UInt32 Center ){
            return ( Center + ( Center - source ) );
        } // public static UInt32 Mirror( this UInt32 source, UInt32 Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static UInt64 Mirror( this UInt64 source, UInt64 Center ){
            return ( Center + ( Center - source ) );
        } // public static UInt64 Mirror( this UInt64 source, UInt64 Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static SByte Mirror( this SByte source, SByte Center ){
            return (SByte)( Center + ( Center - source ) );
        } // public static SByte Mirror( this SByte source, SByte Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Int16 Mirror( this Int16 source, Int16 Center ){
            return (Int16)( Center + ( Center - source ) );
        } // public static Int16 Mirror( this Int16 source, Int16 Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Int32 Mirror( this Int32 source, Int32 Center ){
            return ( Center + ( Center - source ) );
        } // public static Int32 Mirror( this Int32 source, Int32 Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Int64 Mirror( this Int64 source, Int64 Center ){
            return ( Center + ( Center - source ) );
        } // public static Int64 Mirror( this Int64 source, Int64 Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Single Mirror( this Single source, Single Center ){
            return ( Center + ( Center - source ) );
        } // public static Single Mirror( this Single source, Single Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Double Mirror( this Double source, Double Center ){
            return ( Center + ( Center - source ) );
        } // public static Double Mirror( this Double source, Double Center )

        /// <summary> Return new value that mirror by center value. </summary>
        /// <param name="source">The source.</param>
        /// <param name="Center">The Center value to calculate mirror value.</param>
        /// <returns>new value that mirror by center value</returns>
        public static Decimal Mirror( this Decimal source, Decimal Center ){
            return ( Center + ( Center - source ) );
        } // public static Decimal Mirror( this Decimal source, Decimal Center )

    #endregion
        

    #region Abs

        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static SByte Abs( this SByte source ){
            return Math.Abs( source );
        } // public static SByte Abs( this SByte source )
        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static Int16 Abs( this Int16 source ){
            return Math.Abs( source );
        } // public static Int16 Abs( this Int16 source )
        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static Int32 Abs( this Int32 source ){
            return Math.Abs( source );
        } // public static Int32 Abs( this Int32 source )
        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static Int64 Abs( this Int64 source ){
            return Math.Abs( source );
        } // public static Int64 Abs( this Int64 source )
        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static Single Abs( this Single source ){
            return Math.Abs( source );
        } // public static Single Abs( this Single source )
        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static Double Abs( this Double source ){
            return Math.Abs( source );
        } // public static Double Abs( this Double source )
        /// <summary> Return absolute value of source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>absolute value of source</returns>
        public static Decimal Abs( this Decimal source ){
            return Math.Abs( source );
        } // public static Decimal Abs( this Decimal source )
    #endregion

    #region Floor, Round, Ceiling

        /// <summary> Return max integer that smaller than or equal the source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>max integer that smaller than or equal the source/</returns>
        public static Single Floor( this Single source ){
            return (Single)Math.Floor( source );
        } // public static Single Floor( this Single source )

        /// <summary> Return min integer that bigger than or equal the source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>max min integer that bigger than or equal the source/</returns>
        public static Single Ceiling( this Single source ){
            return (Single)Math.Ceiling( source );
        } // public static Single Ceiling( this Single source )

        /// <summary> Rounds a value to the nearest integral value. </summary>
        /// <param name="source">The source.</param>
        /// <returns>Nearest integral value</returns>
        public static Single Round( this Single source ){
            return (Single)Math.Round( source );
        } // public static Single Round( this Single source )

        /// <summary> Rounds a value to a specified number of fractional digits. </summary>
        /// <param name="source">The source.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Single Round( this Single source, int decimals ){
            return (Single)Math.Round( source, decimals );
        } // public static Single Round( this Single source, int decimals )

        /// <summary> Rounds a value to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two numbers. </summary>
        /// <param name="source">The source.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Single Round( this Single source, int decimals, MidpointRounding mode ){
            return (Single)Math.Round( source, decimals, mode );
        } // public static Single Round( this Single source, int decimals, MidpointRounding mode )

        /// <summary> Rounds a  value to the nearest integer. A parameter specifies how to round the value if it is midway between two numbers. </summary>
        /// <param name="source">The source.</param>
        /// <param name="mode">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Single Round( this Single source, MidpointRounding mode ){
            return (Single)Math.Round( source, mode );
        } // public static Single Round( this Single source, MidpointRounding mode )



        /// <summary> Return max integer that smaller than or equal the source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>max integer that smaller than or equal the source/</returns>
        public static Double Floor( this Double source ){
            return Math.Floor( source );
        } // public static Double Floor( this Double source )

        /// <summary> Return min integer that bigger than or equal the source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>max min integer that bigger than or equal the source/</returns>
        public static Double Ceiling( this Double source ){
            return (Double)Math.Ceiling( source );
        } // public static Double Ceiling( this Double source )

        /// <summary> Rounds a value to the nearest integral value. </summary>
        /// <param name="source">The source.</param>
        /// <returns>Nearest integral value</returns>
        public static Double Round( this Double source ){
            return (Double)Math.Round( source );
        } // public static Double Round( this Double source )

        /// <summary> Rounds a value to a specified number of fractional digits. </summary>
        /// <param name="source">The source.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Double Round( this Double source, int decimals ){
            return (Double)Math.Round( source, decimals );
        } // public static Double Round( this Double source, int decimals )

        /// <summary> Rounds a value to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two numbers. </summary>
        /// <param name="source">The source.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Double Round( this Double source, int decimals, MidpointRounding mode ){
            return (Double)Math.Round( source, decimals, mode );
        } // public static Double Round( this Double source, int decimals, MidpointRounding mode )

        /// <summary> Rounds a  value to the nearest integer. A parameter specifies how to round the value if it is midway between two numbers. </summary>
        /// <param name="source">The source.</param>
        /// <param name="mode">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Double Round( this Double source, MidpointRounding mode ){
            return (Double)Math.Round( source, mode );
        } // public static Double Round( this Double source, MidpointRounding mode )



        /// <summary> Return max integer that smaller than or equal the source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>max integer that smaller than or equal the source/</returns>
        public static Decimal Floor( this Decimal source ){
            return Math.Floor( source );
        } // public static Decimal Floor( this Decimal source )

        /// <summary> Return min integer that bigger than or equal the source. </summary>
        /// <param name="source">The source.</param>
        /// <returns>max min integer that bigger than or equal the source/</returns>
        public static Decimal Ceiling( this Decimal source ){
            return (Decimal)Math.Ceiling( source );
        } // public static Decimal Ceiling( this Decimal source )

        /// <summary> Rounds a value to the nearest integral value. </summary>
        /// <param name="source">The source.</param>
        /// <returns>Nearest integral value</returns>
        public static Decimal Round( this Decimal source ){
            return (Decimal)Math.Round( source );
        } // public static Decimal Round( this Decimal source )

        /// <summary> Rounds a value to a specified number of fractional digits. </summary>
        /// <param name="source">The source.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Decimal Round( this Decimal source, int decimals ){
            return (Decimal)Math.Round( source, decimals );
        } // public static Decimal Round( this Decimal source, int decimals )

        /// <summary> Rounds a value to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two numbers. </summary>
        /// <param name="source">The source.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Decimal Round( this Decimal source, int decimals, MidpointRounding mode ){
            return (Decimal)Math.Round( source, decimals, mode );
        } // public static Decimal Round( this Decimal source, int decimals, MidpointRounding mode )

        /// <summary> Rounds a  value to the nearest integer. A parameter specifies how to round the value if it is midway between two numbers. </summary>
        /// <param name="source">The source.</param>
        /// <param name="mode">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>Specified number of fractional digits</returns>
        public static Decimal Round( this Decimal source, MidpointRounding mode ){
            return (Decimal)Math.Round( source, mode );
        } // public static Decimal Round( this Decimal source, MidpointRounding mode )


    #endregion


    } // public static class NumberExtension_T4

} // namespace PGCafe