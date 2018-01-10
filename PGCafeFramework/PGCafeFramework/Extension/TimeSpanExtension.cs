using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    /// <summary>
    /// TimeSpan's extension.
    /// </summary>
    public static class TimeSpanExtension {

        #region TimeSpan

        /// <summary> get new <see cref="TimeSpan"/> with add days to source. </summary>
        /// <param name="source"> source </param>
        /// <param name="day"> day to add. </param>
        /// <returns> new <see cref="TimeSpan"/> with add days to source. </returns>
        public static TimeSpan AddDays( this TimeSpan source, int day ) {
            return source.Add( new TimeSpan( day, 0, 0, 0 ) );
        } // public static TimeSpan AddHour( this TimeSpan source, int day )
        
        /// <summary> get new <see cref="TimeSpan"/> with add hours to source. </summary>
        /// <param name="source"> source </param>
        /// <param name="hour"> hour to add. </param>
        /// <returns> new <see cref="TimeSpan"/> with add hours to source. </returns>
        public static TimeSpan AddHours( this TimeSpan source, int hour ) {
            return source.Add( new TimeSpan( hour, 0, 0 ) );
        } // public static TimeSpan AddHour( this TimeSpan source, int hour )
        
        /// <summary> get new <see cref="TimeSpan"/> with add minutes to source. </summary>
        /// <param name="source"> source </param>
        /// <param name="minute"> minute to add. </param>
        /// <returns> new <see cref="TimeSpan"/> with add minutes to source. </returns>
        public static TimeSpan AddMinutes( this TimeSpan source, int minute ) {
            return source.Add( new TimeSpan( 0, minute, 0 ) );
        } // public static TimeSpan AddHour( this TimeSpan source, int minute )
        
        /// <summary> get new <see cref="TimeSpan"/> with add secondssecond to source. </summary>
        /// <param name="source"> source </param>
        /// <param name="second"> second to add. </param>
        /// <returns> new <see cref="TimeSpan"/> with add s to source. </returns>
        public static TimeSpan AddSeconds( this TimeSpan source, int second ) {
            return source.Add( new TimeSpan( 0, 0, second ) );
        } // public static TimeSpan AddHour( this TimeSpan source, int second )
        
        /// <summary> get new <see cref="TimeSpan"/> with add millisecondsmillisecond to source. </summary>
        /// <param name="source"> source </param>
        /// <param name="millisecond"> millisecond to add. </param>
        /// <returns> new <see cref="TimeSpan"/> with add milliseconds to source. </returns>
        public static TimeSpan AddMilliseconds( this TimeSpan source, int millisecond ) {
            return source.Add( new TimeSpan( 0, 0, 0, 0, millisecond ) );
        } // public static TimeSpan AddHour( this TimeSpan source, int millisecond )
        
        /// <summary> Convert to <see cref="DateTime"/> with ticks. </summary>
        /// <param name="source"> source </param>
        /// <returns> <see cref="DateTime"/> with <see cref="TimeSpan"/>'s Ticks. </returns>
        public static DateTime ToDateTime( this TimeSpan source ) {
            return new DateTime( source.Ticks );
        } // public static DateTime ToDateTime( this TimeSpan source )

        #endregion

        #region Set

        /// <summary>
        /// replace TimeSpan's Hour to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Hour"> new value => Hour. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan SetHour( this TimeSpan source, int Hour ) {
            return source.AddHours( -source.Hours + Hour );
        } // public static TimeSpan SetHour( this TimeSpan source, int Hour )

        /// <summary>
        /// replace TimeSpan's Minute to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Minute"> new value => Minute. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan SetMinute( this TimeSpan source, int Minute ) {
            return source.AddMinutes( -source.Minutes + Minute );
        } // public static TimeSpan SetMinute( this TimeSpan source, int Minute )

        /// <summary>
        /// replace TimeSpan's Second to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Second"> new value => Second. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan SetSecond( this TimeSpan source, int Second ) {
            return source.AddSeconds( -source.Seconds + Second );
        } // public static TimeSpan SetSecond( this TimeSpan source, int Second )

        /// <summary>
        /// replace TimeSpan's Millisecond to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Millisecond"> new value => Millisecond. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan SetMillisecond( this TimeSpan source, int Millisecond ) {
            return source.AddMilliseconds( -source.Milliseconds + Millisecond );
        } // public static TimeSpan SetMillisecond( this TimeSpan source, int Millisecond )

        #endregion

        #region ReserveTo

        /// <summary>
        /// reset TimeSpan's all column except day to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ReserveToDay( this TimeSpan source ) {
            return new TimeSpan( source.Days, 0, 0, 0 );
        } // public static TimeSpan ReserveToDay( this TimeSpan source )


        /// <summary>
        /// reset TimeSpan's all column except day, hour to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ReserveToHour( this TimeSpan source ) {
            return new TimeSpan( source.Days, source.Hours, 0, 0 );
        } // public static TimeSpan ReserveToHour( this TimeSpan source )


        /// <summary>
        /// reset TimeSpan's all column except day, hour, minute to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ReserveToMinute( this TimeSpan source ) {
            return new TimeSpan( source.Days, source.Hours, source.Minutes, 0 );
        } // public static TimeSpan ReserveToMinute( this TimeSpan source )


        /// <summary>
        /// reset TimeSpan's all column except day, hour, minute, second to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ReserveToSecond( this TimeSpan source ) {
            return new TimeSpan( source.Days, source.Hours, source.Minutes, source.Seconds );
        } // public static TimeSpan ReserveToSecond( this TimeSpan source )

        #endregion
        
        #region ClearTo

        /// <summary>
        /// reset TimeSpan's all column except hour, minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ClearToDay( this TimeSpan source ) {
            return new TimeSpan( 0, source.Hours, source.Minutes, source.Seconds, source.Milliseconds );
        } // public static TimeSpan ClearToDay( this TimeSpan source )


        /// <summary>
        /// reset TimeSpan's all column except minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ClearToHour( this TimeSpan source ) {
            return new TimeSpan( 0, 0, source.Minutes, source.Seconds, source.Milliseconds );
        } // public static TimeSpan ClearToHour( this TimeSpan source )


        /// <summary>
        /// reset TimeSpan's all column except second, millisecond to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ClearToMinute( this TimeSpan source ) {
            return new TimeSpan( 0, 0, 0, source.Seconds, source.Milliseconds );
        } // public static TimeSpan ClearToMinute( this TimeSpan source )


        /// <summary>
        /// reset TimeSpan's all column except millisecond to min value.
        /// </summary>
        /// <param name="source"> TimeSpan of reserve column. </param>
        /// <returns> the TimeSpan object. </returns>
        public static TimeSpan ClearToSecond( this TimeSpan source ) {
            return new TimeSpan( 0, 0, 0, 0, source.Milliseconds );
        } // public static TimeSpan ClearToSecond( this TimeSpan source )

        #endregion
        
    } // public static class TimeSpanExtension
} // namespace PGCafe
