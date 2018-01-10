using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {

    /// <summary> Provide more method of Math. </summary>
    public static class PGMath {

        /// <summary>
        /// Calculate Standard value of value list.
        /// </summary>
        /// <param name="values"> value list to calculate. </param>
        /// <returns> Standard value </returns>
        public static double Stdandard( IEnumerable<int> values ) {
            // 標準差為 根號( 平方的平均 - 平均的平方 )
            int count = values.Count();
            double pow2_avg = values.Select( item => Math.Pow( item, 2 ) ).Sum() / count;
            double avg_pow2 = Math.Pow( values.Average(), 2 );
            double sd_pow2 = pow2_avg - avg_pow2;
            double sd = Math.Sqrt( sd_pow2 );
            return sd;
        } // public static double Stdandard( IEnumerable<int> values )


        /// <summary>
        /// Calculate Standard value of value list.
        /// </summary>
        /// <param name="values"> value list to calculate. </param>
        /// <returns> Standard value </returns>
        public static double Stdandard( IEnumerable<float> values ) {
            // 標準差為 根號( 平方的平均 - 平均的平方 )
            int count = values.Count();
            double pow2_avg = values.Select( item => Math.Pow( item, 2 ) ).Sum() / count;
            double avg_pow2 = Math.Pow( values.Average(), 2 );
            double sd_pow2 = pow2_avg - avg_pow2;
            double sd = Math.Sqrt( sd_pow2 );
            return sd;
        } // public static double Stdandard( IEnumerable<float> values )


        /// <summary>
        /// Calculate Standard value of value list.
        /// </summary>
        /// <param name="values"> value list to calculate. </param>
        /// <returns> Standard value </returns>
        public static double Stdandard( IEnumerable<double> values ) {
            // 標準差為 根號( 平方的平均 - 平均的平方 )
            int count = values.Count();
            double pow2_avg = values.Select( item => Math.Pow( item, 2 ) ).Sum() / count;
            double avg_pow2 = Math.Pow( values.Sum() / count, 2 );
            double sd_pow2 = pow2_avg - avg_pow2;
            double sd = Math.Sqrt( sd_pow2 );
            return sd;
        } // public static double Stdandard( IEnumerable<double> values )



        private static DataTable mCalculateDT = null;

        /// <summary>
        /// Calculate formula with string type.( support base operator +, -, *, /, (, )... )
        /// * Use DataTable's Compute method to calculate, for more support infomation see the DataTable's Compute in MSDN.
        /// * for more support, try use free library "nCalc".
        /// </summary>
        /// <param name="Formula"> formula to be calculate. </param>
        public static double? Calculate( string Formula ) {
            mCalculateDT = mCalculateDT ?? new DataTable();
            return mCalculateDT.Compute( Formula, "" ).ToType<double?>();
        } // public static double? Calculate( string Formula )

        #region Min, Max

        #region Min - 2 Values

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static int Min( int value1, int value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static decimal Min( decimal value1, decimal value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static double Min( double value1, double value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static float Min( float value1, float value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>                                                                               
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static ulong Min( ulong value1, ulong value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static long Min( long value1, long value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static uint Min( uint value1, uint value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static ushort Min( ushort value1, ushort value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static short Min( short value1, short value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static byte Min( byte value1, byte value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static sbyte Min( sbyte value1, sbyte value2 ) => Math.Min( value1, value2 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime Min( DateTime value1, DateTime value2 ) => new DateTime( Math.Min( value1.Ticks, value2.Ticks ) );

        #endregion

        #region Min - 3 Values

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static int Min( int value1, int value2, int value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static decimal Min( decimal value1, decimal value2, decimal value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static double Min( double value1, double value2, double value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static float Min( float value1, float value2, float value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static ulong Min( ulong value1, ulong value2, ulong value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static long Min( long value1, long value2, long value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static uint Min( uint value1, uint value2, uint value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static ushort Min( ushort value1, ushort value2, ushort value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static short Min( short value1, short value2, short value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static byte Min( byte value1, byte value2, byte value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static sbyte Min( sbyte value1, sbyte value2, sbyte value3 ) => Math.Min( Math.Min( value1, value2 ), value3 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime Min( DateTime value1, DateTime value2, DateTime value3 ) => new DateTime( Math.Min( Math.Min( value1.Ticks, value2.Ticks ), value3.Ticks ) );
        
        #endregion

        #region Min - 4 Values

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static int Min( int value1, int value2, int value3, int value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static decimal Min( decimal value1, decimal value2, decimal value3, decimal value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static double Min( double value1, double value2, double value3, double value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static float Min( float value1, float value2, float value3, float value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static ulong Min( ulong value1, ulong value2, ulong value3, ulong value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static long Min( long value1, long value2, long value3, long value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static uint Min( uint value1, uint value2, uint value3, uint value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static ushort Min( ushort value1, ushort value2, ushort value3, ushort value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static short Min( short value1, short value2, short value3, short value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static byte Min( byte value1, byte value2, byte value3, byte value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static sbyte Min( sbyte value1, sbyte value2, sbyte value3, sbyte value4 ) => Math.Min( Math.Min( Math.Min( value1, value2 ), value3 ), value4 );
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime Min( DateTime value1, DateTime value2, DateTime value3, DateTime value4 ) => new DateTime( Math.Min( Math.Min( Math.Min( value1.Ticks, value2.Ticks ), value3.Ticks ), value4.Ticks ) );
        
        #endregion

        #region Min - multiple Values

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static int Min( params int[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static decimal Min( params decimal[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static double Min( params double[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static float Min( params float[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static ulong Min( params ulong[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static long Min( params long[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static uint Min( params uint[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static ushort Min( params ushort[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static short Min( params short[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static byte Min( params byte[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static sbyte Min( params sbyte[] values ) => values.Min();

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime Min( params DateTime[] values ) => values.Min();

        #endregion
        
        #region Min - 2 Values - Nullable

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Byte? Min( Byte? value1, Byte? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Byte? Min( Byte? value1, Byte? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static UInt16? Min( UInt16? value1, UInt16? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static UInt16? Min( UInt16? value1, UInt16? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static UInt32? Min( UInt32? value1, UInt32? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static UInt32? Min( UInt32? value1, UInt32? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static UInt64? Min( UInt64? value1, UInt64? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static UInt64? Min( UInt64? value1, UInt64? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static SByte? Min( SByte? value1, SByte? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static SByte? Min( SByte? value1, SByte? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Int16? Min( Int16? value1, Int16? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Int16? Min( Int16? value1, Int16? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Int32? Min( Int32? value1, Int32? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Int32? Min( Int32? value1, Int32? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Int64? Min( Int64? value1, Int64? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Int64? Min( Int64? value1, Int64? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Single? Min( Single? value1, Single? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Single? Min( Single? value1, Single? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Double? Min( Double? value1, Double? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Double? Min( Double? value1, Double? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static Decimal? Min( Decimal? value1, Decimal? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Min( value1.Value, value2.Value );
        } // public static Decimal? Min( Decimal? value1, Decimal? value2 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime? Min( DateTime? value1, DateTime? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return PGMath.Min( value1.Value, value2.Value );
        } // public static DateTime? Min( DateTime? value1, DateTime? value2 )

        #endregion
        
        #region Min - 3 Values - Nullable

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Byte? Min( Byte? value1, Byte? value2, Byte? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Byte? Min( Byte? value1, Byte? value2, Byte? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static UInt16? Min( UInt16? value1, UInt16? value2, UInt16? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static UInt16? Min( UInt16? value1, UInt16? value2, UInt16? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static UInt32? Min( UInt32? value1, UInt32? value2, UInt32? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static UInt32? Min( UInt32? value1, UInt32? value2, UInt32? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static UInt64? Min( UInt64? value1, UInt64? value2, UInt64? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static UInt64? Min( UInt64? value1, UInt64? value2, UInt64? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static SByte? Min( SByte? value1, SByte? value2, SByte? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static SByte? Min( SByte? value1, SByte? value2, SByte? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Int16? Min( Int16? value1, Int16? value2, Int16? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Int16? Min( Int16? value1, Int16? value2, Int16? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Int32? Min( Int32? value1, Int32? value2, Int32? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Int32? Min( Int32? value1, Int32? value2, Int32? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Int64? Min( Int64? value1, Int64? value2, Int64? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Int64? Min( Int64? value1, Int64? value2, Int64? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Single? Min( Single? value1, Single? value2, Single? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Single? Min( Single? value1, Single? value2, Single? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Double? Min( Double? value1, Double? value2, Double? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Double? Min( Double? value1, Double? value2, Double? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static Decimal? Min( Decimal? value1, Decimal? value2, Decimal? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static Decimal? Min( Decimal? value1, Decimal? value2, Decimal? value3 )

            /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime? Min( DateTime? value1, DateTime? value2, DateTime? value3 ){
            return PGMath.Min( PGMath.Min( value1, value2 ), value3 );
        } // public static DateTime? Min( DateTime? value1, DateTime? value2, DateTime? value3 )

        #endregion
        
        #region Min - 4 Values - Nullable

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Byte? Min( Byte? value1, Byte? value2, Byte? value3, Byte? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Byte? Min( Byte? value1, Byte? value2, Byte? value3, Byte? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static UInt16? Min( UInt16? value1, UInt16? value2, UInt16? value3, UInt16? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static UInt16? Min( UInt16? value1, UInt16? value2, UInt16? value3, UInt16? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static UInt32? Min( UInt32? value1, UInt32? value2, UInt32? value3, UInt32? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static UInt32? Min( UInt32? value1, UInt32? value2, UInt32? value3, UInt32? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static UInt64? Min( UInt64? value1, UInt64? value2, UInt64? value3, UInt64? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static UInt64? Min( UInt64? value1, UInt64? value2, UInt64? value3, UInt64? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static SByte? Min( SByte? value1, SByte? value2, SByte? value3, SByte? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static SByte? Min( SByte? value1, SByte? value2, SByte? value3, SByte? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Int16? Min( Int16? value1, Int16? value2, Int16? value3, Int16? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Int16? Min( Int16? value1, Int16? value2, Int16? value3, Int16? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Int32? Min( Int32? value1, Int32? value2, Int32? value3, Int32? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Int32? Min( Int32? value1, Int32? value2, Int32? value3, Int32? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Int64? Min( Int64? value1, Int64? value2, Int64? value3, Int64? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Int64? Min( Int64? value1, Int64? value2, Int64? value3, Int64? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Single? Min( Single? value1, Single? value2, Single? value3, Single? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Single? Min( Single? value1, Single? value2, Single? value3, Single? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Double? Min( Double? value1, Double? value2, Double? value3, Double? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Double? Min( Double? value1, Double? value2, Double? value3, Double? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static Decimal? Min( Decimal? value1, Decimal? value2, Decimal? value3, Decimal? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static Decimal? Min( Decimal? value1, Decimal? value2, Decimal? value3, Decimal? value4 )

        /// <summary> Get the minimum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime? Min( DateTime? value1, DateTime? value2, DateTime? value3, DateTime? value4 ){
            return PGMath.Min( PGMath.Min( PGMath.Min( value1, value2 ), value3 ), value4 );
        } // public static DateTime? Min( DateTime? value1, DateTime? value2, DateTime? value3, DateTime? value4 )

        #endregion

        #region Min - multiple Values - Nullable

        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Byte? Min( params Byte?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static UInt16? Min( params UInt16?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static UInt32? Min( params UInt32?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static UInt64? Min( params UInt64?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static SByte? Min( params SByte?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Int16? Min( params Int16?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Int32? Min( params Int32?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Int64? Min( params Int64?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Single? Min( params Single?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Double? Min( params Double?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static Decimal? Min( params Decimal?[] values ) => values.Min();
        
        /// <summary> Get the minimum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The minimum value. </returns>
        public static DateTime? Min( params DateTime?[] values ) => values.Min();
        
        #endregion
        

        #region Max - 2 Values

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static int Max( int value1, int value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static decimal Max( decimal value1, decimal value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static double Max( double value1, double value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static float Max( float value1, float value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>                                                                               
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static ulong Max( ulong value1, ulong value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static long Max( long value1, long value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static uint Max( uint value1, uint value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static ushort Max( ushort value1, ushort value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static short Max( short value1, short value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static byte Max( byte value1, byte value2 ) => Math.Max( value1, value2 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static sbyte Max( sbyte value1, sbyte value2 ) => Math.Max( value1, value2 );
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime Max( DateTime value1, DateTime value2 ) => new DateTime( Math.Max( value1.Ticks, value2.Ticks ) );
        
        #endregion
        
        #region Max - 3 Values

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static int Max( int value1, int value2, int value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static decimal Max( decimal value1, decimal value2, decimal value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static double Max( double value1, double value2, double value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static float Max( float value1, float value2, float value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static ulong Max( ulong value1, ulong value2, ulong value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static long Max( long value1, long value2, long value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static uint Max( uint value1, uint value2, uint value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static ushort Max( ushort value1, ushort value2, ushort value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static short Max( short value1, short value2, short value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static byte Max( byte value1, byte value2, byte value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static sbyte Max( sbyte value1, sbyte value2, sbyte value3 ) => Math.Max( Math.Max( value1, value2 ), value3 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime Max( DateTime value1, DateTime value2, DateTime value3 ) => new DateTime( Math.Max( Math.Max( value1.Ticks, value2.Ticks ), value3.Ticks ) );
        

        #endregion

        #region Max - 4 Values

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static int Max( int value1, int value2, int value3, int value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static decimal Max( decimal value1, decimal value2, decimal value3, decimal value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static double Max( double value1, double value2, double value3, double value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static float Max( float value1, float value2, float value3, float value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static ulong Max( ulong value1, ulong value2, ulong value3, ulong value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static long Max( long value1, long value2, long value3, long value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static uint Max( uint value1, uint value2, uint value3, uint value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static ushort Max( ushort value1, ushort value2, ushort value3, ushort value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static short Max( short value1, short value2, short value3, short value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static byte Max( byte value1, byte value2, byte value3, byte value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static sbyte Max( sbyte value1, sbyte value2, sbyte value3, sbyte value4 ) => Math.Max( Math.Max( Math.Max( value1, value2 ), value3 ), value4 );
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime Max( DateTime value1, DateTime value2, DateTime value3, DateTime value4 ) => new DateTime( Math.Max( Math.Max( Math.Max( value1.Ticks, value2.Ticks ), value3.Ticks ), value4.Ticks ) );
        
        #endregion

        #region Max - multiple Values

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static int Max( params int[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static decimal Max( params decimal[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static double Max( params double[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static float Max( params float[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static ulong Max( params ulong[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static long Max( params long[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static uint Max( params uint[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static ushort Max( params ushort[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static short Max( params short[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static byte Max( params byte[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static sbyte Max( params sbyte[] values ) => values.Max();

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime Max( params DateTime[] values ) => values.Max();

        #endregion
        
        #region Max - 2 Values - Nullable

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Byte? Max( Byte? value1, Byte? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Byte? Max( Byte? value1, Byte? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static UInt16? Max( UInt16? value1, UInt16? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static UInt16? Max( UInt16? value1, UInt16? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static UInt32? Max( UInt32? value1, UInt32? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static UInt32? Max( UInt32? value1, UInt32? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static UInt64? Max( UInt64? value1, UInt64? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static UInt64? Max( UInt64? value1, UInt64? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static SByte? Max( SByte? value1, SByte? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static SByte? Max( SByte? value1, SByte? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Int16? Max( Int16? value1, Int16? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Int16? Max( Int16? value1, Int16? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Int32? Max( Int32? value1, Int32? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Int32? Max( Int32? value1, Int32? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Int64? Max( Int64? value1, Int64? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Int64? Max( Int64? value1, Int64? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Single? Max( Single? value1, Single? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Single? Max( Single? value1, Single? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Double? Max( Double? value1, Double? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Double? Max( Double? value1, Double? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static Decimal? Max( Decimal? value1, Decimal? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return Math.Max( value1.Value, value2.Value );
        } // public static Decimal? Max( Decimal? value1, Decimal? value2 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime? Max( DateTime? value1, DateTime? value2 ){
            if ( value1 == null ) return value2;
            if ( value2 == null ) return value1;
            return PGMath.Max( value1.Value, value2.Value );
        } // public static DateTime? Max( DateTime? value1, DateTime? value2 )

        #endregion
        
        #region Max - 3 Values - Nullable

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Byte? Max( Byte? value1, Byte? value2, Byte? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Byte? Max( Byte? value1, Byte? value2, Byte? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static UInt16? Max( UInt16? value1, UInt16? value2, UInt16? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static UInt16? Max( UInt16? value1, UInt16? value2, UInt16? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static UInt32? Max( UInt32? value1, UInt32? value2, UInt32? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static UInt32? Max( UInt32? value1, UInt32? value2, UInt32? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static UInt64? Max( UInt64? value1, UInt64? value2, UInt64? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static UInt64? Max( UInt64? value1, UInt64? value2, UInt64? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static SByte? Max( SByte? value1, SByte? value2, SByte? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static SByte? Max( SByte? value1, SByte? value2, SByte? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Int16? Max( Int16? value1, Int16? value2, Int16? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Int16? Max( Int16? value1, Int16? value2, Int16? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Int32? Max( Int32? value1, Int32? value2, Int32? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Int32? Max( Int32? value1, Int32? value2, Int32? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Int64? Max( Int64? value1, Int64? value2, Int64? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Int64? Max( Int64? value1, Int64? value2, Int64? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Single? Max( Single? value1, Single? value2, Single? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Single? Max( Single? value1, Single? value2, Single? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Double? Max( Double? value1, Double? value2, Double? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Double? Max( Double? value1, Double? value2, Double? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static Decimal? Max( Decimal? value1, Decimal? value2, Decimal? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static Decimal? Max( Decimal? value1, Decimal? value2, Decimal? value3 )

            /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime? Max( DateTime? value1, DateTime? value2, DateTime? value3 ){
            return PGMath.Max( PGMath.Max( value1, value2 ), value3 );
        } // public static DateTime? Max( DateTime? value1, DateTime? value2, DateTime? value3 )

        #endregion
        
        #region Max - 4 Values - Nullable

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Byte? Max( Byte? value1, Byte? value2, Byte? value3, Byte? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Byte? Max( Byte? value1, Byte? value2, Byte? value3, Byte? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static UInt16? Max( UInt16? value1, UInt16? value2, UInt16? value3, UInt16? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static UInt16? Max( UInt16? value1, UInt16? value2, UInt16? value3, UInt16? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static UInt32? Max( UInt32? value1, UInt32? value2, UInt32? value3, UInt32? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static UInt32? Max( UInt32? value1, UInt32? value2, UInt32? value3, UInt32? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static UInt64? Max( UInt64? value1, UInt64? value2, UInt64? value3, UInt64? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static UInt64? Max( UInt64? value1, UInt64? value2, UInt64? value3, UInt64? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static SByte? Max( SByte? value1, SByte? value2, SByte? value3, SByte? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static SByte? Max( SByte? value1, SByte? value2, SByte? value3, SByte? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Int16? Max( Int16? value1, Int16? value2, Int16? value3, Int16? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Int16? Max( Int16? value1, Int16? value2, Int16? value3, Int16? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Int32? Max( Int32? value1, Int32? value2, Int32? value3, Int32? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Int32? Max( Int32? value1, Int32? value2, Int32? value3, Int32? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Int64? Max( Int64? value1, Int64? value2, Int64? value3, Int64? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Int64? Max( Int64? value1, Int64? value2, Int64? value3, Int64? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Single? Max( Single? value1, Single? value2, Single? value3, Single? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Single? Max( Single? value1, Single? value2, Single? value3, Single? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Double? Max( Double? value1, Double? value2, Double? value3, Double? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Double? Max( Double? value1, Double? value2, Double? value3, Double? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static Decimal? Max( Decimal? value1, Decimal? value2, Decimal? value3, Decimal? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static Decimal? Max( Decimal? value1, Decimal? value2, Decimal? value3, Decimal? value4 )

        /// <summary> Get the maximum value. </summary>
        /// <param name="value1">The value1.</param> <param name="value2">The value2.</param> <param name="value3">The value3.</param> <param name="value4">The value4.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime? Max( DateTime? value1, DateTime? value2, DateTime? value3, DateTime? value4 ){
            return PGMath.Max( PGMath.Max( PGMath.Max( value1, value2 ), value3 ), value4 );
        } // public static DateTime? Max( DateTime? value1, DateTime? value2, DateTime? value3, DateTime? value4 )

        #endregion

        #region Max - multiple Values - Nullable

        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Byte? Max( params Byte?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static UInt16? Max( params UInt16?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static UInt32? Max( params UInt32?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static UInt64? Max( params UInt64?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static SByte? Max( params SByte?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Int16? Max( params Int16?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Int32? Max( params Int32?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Int64? Max( params Int64?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Single? Max( params Single?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Double? Max( params Double?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static Decimal? Max( params Decimal?[] values ) => values.Max();
        
        /// <summary> Get the maximum value. </summary>
        /// <param name="values">values to search.</param>
        /// <returns> The maximum value. </returns>
        public static DateTime? Max( params DateTime?[] values ) => values.Max();
        
        #endregion

        #endregion

        #region ToRadians, ToAngle

        /// <summary> Convert angle to radians </summary>
        /// <param name="Angle">The angle.</param>
        /// <returns> Radians convert from angle. </returns>
        public static double ToRadians( double Angle ) {
            return Angle * Math.PI / 180;
        } // public static double ToRadians( double Angle )

        /// <summary> Convert angle to radians </summary>
        /// <param name="Angle">The angle.</param>
        /// <returns> Radians convert from angle. </returns>
        public static float ToRadians( float Angle ) {
            return (float)( Angle * Math.PI / 180 );
        } // public static float ToRadians( float Angle )

        /// <summary> Convert radians to angle </summary>
        /// <param name="Radians">The radians.</param>
        /// <returns> Angle convert from radians. </returns>
        public static double ToAngle( double Radians ) {
            return Radians * 180 / Math.PI;
        } // public static double ToAngle( double Radians )

        /// <summary> Convert radians to angle </summary>
        /// <param name="Radians">The radians.</param>
        /// <returns> Angle convert from radians. </returns>
        public static float ToAngle( float Radians ) {
            return (float)( Radians * 180 / Math.PI );
        } // public static double ToAngle( float Radians )

        #endregion

        #region Unit Conversion

        /// <summary> Convert value to other unit. </summary>
        /// <param name="Value">Value to convert.</param>
        /// <param name="FromUnit">From unit.</param>
        /// <param name="ToUnit">To unit.</param>
        /// <param name="Dpi">Dpi of value use.</param>
        public static float UnitConvertion( float Value, GraphicsUnit FromUnit, GraphicsUnit ToUnit, float Dpi ){
            return FromUnit.ToOtherUnit( ToUnit, Dpi, Value );
        } // public static float UnitConvertion( double Value, GraphicsUnit FromUnit, GraphicsUnit ToUnit, float Dpi )

        #endregion

        /// <summary> Count the true values of boolean </summary>
        /// <param name="values">The values of boolean.</param>
        /// <returns> count of true values of boolean </returns>
        public static int Truth( params bool[] values ){
            return values.Count(b => b);
        } // public static int Truth( params bool[] values )

    } // class PGMath
} // namespace PGCafe