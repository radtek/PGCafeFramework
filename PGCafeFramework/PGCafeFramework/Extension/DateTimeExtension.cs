using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// DateTime relation extension.
    /// </summary>
    public static class DateTimeExtension {

        #region ReserveTo

        /// <summary>
        /// reset datetime's all column except year to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToYear( this DateTime source ) {
            return new DateTime( source.Year, 1, 1 );
        } // public static DateTime ReserveToYear( this DateTime source )


        /// <summary>
        /// reset datetime's all column except year, month to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToMonth( this DateTime source ) {
            return new DateTime( source.Year, source.Month, 1 );
        } // public static DateTime ReserveToMonth( this DateTime source )


        /// <summary>
        /// reset datetime's all column except year, month, day to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToDay( this DateTime source ) {
            return source.Date;
        } // public static DateTime ReserveToDay( this DateTime source )


        /// <summary>
        /// reset datetime's all column except year, month, day, hour to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToHour( this DateTime source ) {
            return new DateTime( source.Year, source.Month, source.Day, source.Hour, 0, 0 );
        } // public static DateTime ReserveToHour( this DateTime source )


        /// <summary>
        /// reset datetime's all column except year, month, day, hour, minute to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToMinute( this DateTime source ) {
            return new DateTime( source.Year, source.Month, source.Day, source.Hour, source.Minute, 0 );
        } // public static DateTime ReserveToMinute( this DateTime source )


        /// <summary>
        /// reset datetime's all column except year, month, day, hour, minute, second to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToSecond( this DateTime source ) {
            return new DateTime( source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second );
        } // public static DateTime ReserveToSecond( this DateTime source )


        /// <summary>
        /// reset datetime's all column except year, month, day, hour, minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ReserveToMillisecondSecond( this DateTime source ) {
            return new DateTime( source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second, source.Millisecond );
        } // public static DateTime ReserveToMillisecondSecond( this DateTime source )

        #endregion
        
        #region ClearTo

        /// <summary>
        /// reset datetime's all column except month, day, hour, minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ClearToYear( this DateTime source ) {
            return new DateTime( 1, source.Month, source.Day, source.Hour, source.Minute, source.Second, source.Millisecond );
        } // public static DateTime ClearToYear( this DateTime source )


        /// <summary>
        /// reset datetime's all column except day, hour, minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ClearToMonth( this DateTime source ) {
            return new DateTime( 1, 1, source.Day, source.Hour, source.Minute, source.Second, source.Millisecond );
        } // public static DateTime ClearToMonth( this DateTime source )


        /// <summary>
        /// reset datetime's all column except hour, minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ClearToDay( this DateTime source ) {
            return new DateTime( 1, 1, 1, source.Hour, source.Minute, source.Second, source.Millisecond );
        } // public static DateTime ClearToDay( this DateTime source )


        /// <summary>
        /// reset datetime's all column except minute, second, millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ClearToHour( this DateTime source ) {
            return new DateTime( 1, 1, 1, 0, source.Minute, source.Second, source.Millisecond );
        } // public static DateTime ClearToHour( this DateTime source )


        /// <summary>
        /// reset datetime's all column except second, millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ClearToMinute( this DateTime source ) {
            return new DateTime( 1, 1, 1, 0, 0, source.Second, source.Millisecond );
        } // public static DateTime ClearToMinute( this DateTime source )


        /// <summary>
        /// reset datetime's all column except millisecond to min value.
        /// </summary>
        /// <param name="source"> <see cref="DateTime"/> of reserve column. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime ClearToSecond( this DateTime source ) {
            return new DateTime( 1, 1, 1, 0, 0, 0, source.Millisecond );
        } // public static DateTime ClearToSecond( this DateTime source )

        #endregion

        #region NextDay, PreDay

        /// <summary>
        /// get the new <see cref="DateTime"/> with next day of week.( not include today )
        /// </summary>
        /// <param name="source"> base on what DateTime. </param>
        /// <param name="dayOfWeek"> calculate which next day of week. </param>
        /// <returns> new <see cref="DateTime"/> with next day of week </returns>
        public static DateTime NextDay( this DateTime source, DayOfWeek dayOfWeek ) {
            int daySpan = (int)dayOfWeek - (int)source.DayOfWeek;
            if ( daySpan <= 0 ) daySpan += 7;
            return new DateTime( source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second ).AddDays( daySpan );
        } // public static DateTime NextDay( this DateTime source, DayOfWeek dayOfWeek )


        /// <summary>
        /// get the new <see cref="DateTime"/> with pre day of week.( not include today )
        /// </summary>
        /// <param name="source"> base on what DateTime. </param>
        /// <param name="dayOfWeek"> calculate which pre day of week. </param>
        /// <returns> new <see cref="DateTime"/> with pre day of week </returns>
        public static DateTime PreDay( this DateTime source, DayOfWeek dayOfWeek ) {
            int daySpan = (int)dayOfWeek - (int)source.DayOfWeek;
            if ( daySpan >= 0 ) daySpan -= 7;
            return new DateTime( source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second ).AddDays( daySpan );
        } // public static DateTime PreDay( this DateTime source, DayOfWeek dayOfWeek )

        #endregion

        /// <summary> Add N weeks. </summary>
        /// <param name="source"> source to add spicify time. </param>
        /// <param name="weeks"> add weeks count. </param>
        /// <returns> result of <see cref="DateTime"/>. </returns>
        public static DateTime AddWeeks( this DateTime source, int weeks ) {
            return source.AddDays( weeks * 7 );
        } // public static DateTime AddWeeks( this DateTime source, int weeks )

        /// <summary>
        /// get time part of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime GetTime( this DateTime source ) {
            return DateTime.MinValue.Add( source.TimeOfDay );
        } // public static DateTime GetTime( this DateTime source )

        #region SetDate

        /// <summary>
        /// replace datetime's year, month, day to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="newDate"> new date to set. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetDate( this DateTime source, DateTime newDate ) {
            return new DateTime( newDate.Year, newDate.Month, newDate.Day, source.Hour, source.Minute, source.Second );
        } // public static DateTime SetDate( this DateTime source, DateTime newDate )

        /// <summary>
        /// replace datetime's year, month, day to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="year"> new value => year. </param>
        /// <param name="month"> new value => month. </param>
        /// <param name="day"> new value => day. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetDate( this DateTime source, int year, int month = 0, int day = 0 ) {
            return new DateTime( year, month, day, source.Hour, source.Minute, source.Second );
        } // public static DateTime SetDate( this DateTime source, int year, int month = 0, int day = 0 )

        /// <summary>
        /// replace datetime's year, month, day to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Year"> new value => Year. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetYear( this DateTime source, int Year ) {
            return source.AddYears( -source.Year + Year );
        } // public static DateTime SetYear( this DateTime source, int Year )

        /// <summary>
        /// replace datetime's Month, month, day to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Month"> new value => Month. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetMonth( this DateTime source, int Month ) {
            return source.AddMonths( -source.Month + Month );
        } // public static DateTime SetMonth( this DateTime source, int Month )

        /// <summary>
        /// replace datetime's Day, Day, day to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Day"> new value => Day. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetDay( this DateTime source, int Day ) {
            return source.AddDays( -source.Day + Day );
        } // public static DateTime SetDay( this DateTime source, int Day )

        #endregion

        #region SetTime

        /// <summary>
        /// replace datetime's year, month, day to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="newTime"> new time to set. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetTime( this DateTime source, DateTime newTime ) {
            return source.Date.Add( newTime.TimeOfDay );
        } // public static DateTime SetTime( this DateTime source, DateTime newTime )


        /// <summary>
        /// replace datetime's hour, minute, second, millisecond to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="hour"> new value => hour. </param>
        /// <param name="minute"> new value => minute. </param>
        /// <param name="second"> new value => second. </param>
        /// <param name="millisecond"> new value => millisecond. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetTime( this DateTime source, int hour, int minute = 0, int second = 0, int millisecond = 0 ) {
            return new DateTime( source.Year, source.Month, source.Day, hour, minute, second, millisecond );
        } // public static DateTime SetTime( this DateTime source, int hour, int minute = 0, int second = 0, int millisecond = 0 )
          

        /// <summary>
        /// replace datetime's Hour, Hour, Hour to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Hour"> new value => Hour. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetHour( this DateTime source, int Hour ) {
            return source.AddHours( -source.Hour + Hour );
        } // public static DateTime SetHour( this DateTime source, int Hour )

        /// <summary>
        /// replace datetime's Minute, Minute, Minute to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Minute"> new value => Minute. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetMinute( this DateTime source, int Minute ) {
            return source.AddMinutes( -source.Minute + Minute );
        } // public static DateTime SetMinute( this DateTime source, int Minute )

        /// <summary>
        /// replace datetime's Second, Second, Second to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Second"> new value => Second. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetSecond( this DateTime source, int Second ) {
            return source.AddSeconds( -source.Second + Second );
        } // public static DateTime SetSecond( this DateTime source, int Second )

        /// <summary>
        /// replace datetime's Millisecond, Millisecond, Millisecond to new value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="Millisecond"> new value => Millisecond. </param>
        /// <returns> the new <see cref="DateTime"/>. </returns>
        public static DateTime SetMillisecond( this DateTime source, int Millisecond ) {
            return source.AddMilliseconds( -source.Millisecond + Millisecond );
        } // public static DateTime SetMillisecond( this DateTime source, int Millisecond )

        #endregion

        #region Total Times

        /// <summary>
        /// get total weeks of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> total weeks of datetime </returns>
        public static double TotalWeeks( this DateTime source ) {
            return source.TotalDays() / 7;
        } // public static double TotalWeeks( this DateTime source )

        /// <summary>
        /// get total days of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> total days of datetime </returns>
        public static double TotalDays( this DateTime source ) {
            return ( source - DateTime.MinValue ).TotalDays;
        } // public static double TotalDays( this DateTime source )

        /// <summary>
        /// get total days of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> total days of datetime </returns>
        public static double TotalHours( this DateTime source ) {
            return ( source - DateTime.MinValue ).TotalHours;
        } // public static double TotalHours( this DateTime source )

        /// <summary>
        /// get total minutes of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> total minutes of datetime </returns>
        public static double TotalMinutes( this DateTime source ) {
            return ( source - DateTime.MinValue ).TotalMinutes;
        } // public static double TotalMinutes( this DateTime source )

        /// <summary>
        /// get total seconds of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> total seconds of datetime </returns>
        public static double TotalSeconds( this DateTime source ) {
            return ( source - DateTime.MinValue ).TotalSeconds;
        } // public static double TotalSeconds( this DateTime source )

        /// <summary>
        /// get total milliseconds of datetime.
        /// </summary>
        /// <param name="source"> source </param>
        /// <returns> total milliseconds of datetime </returns>
        public static double TotalMilliseconds( this DateTime source ) {
            return ( source - DateTime.MinValue ).TotalMilliseconds;
        } // public static double TotalMilliseconds( this DateTime source )

        #endregion

        #region RelationTo
        
        /// <summary> Determine the relation from this DateTime to a specified TimeRange. </summary>
        /// <param name="source"> source. </param>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> <see cref="TimeRelation"/> to Determine the relation from this DateTime to a specified TimeRange.</returns>
        public static TimeRelation RelationTo( this DateTime source, DateTime Value ) {
            // check relative and return it.
            if ( source < Value ) return TimeRelation.OutsideLeft;
            if ( source == Value ) return TimeRelation.ExactSame;
            if ( source > Value ) return TimeRelation.OutsideRight;

            throw new NotSupportedException( 
$@"Undefine relative, should not happened.
this[{source.Ticks}] Value[{source.Ticks}]" );

        } // public static TimeRelation RelationTo( this DateTime source, DateTime Value )

        
        /// <summary> Determine the relation from this DateTime to a specified TimeRange. </summary>
        /// <param name="source"> source. </param>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> <see cref="TimeRelation"/> to Determine the relation from this DateTime to a specified TimeRange.</returns>
        public static TimeRelation RelationTo( this DateTime source, TimeRange Value ) {
            // if Value is time point, generate relative with TimeRange and DateTime.
            if ( Value.IsTimePoint() ) return source.RelationTo( Value.Start );

            // check relative and return it.
            if ( source < Value.Start ) return TimeRelation.OutsideLeft;
            if ( source == Value.Start ) return TimeRelation.ContinusLeft | TimeRelation.InsideLeft;

            if ( source > Value.End ) return TimeRelation.OutsideRight;
            if ( source == Value.End ) return TimeRelation.ContinusRight;

            // base-line : source > Value.Start && source < Value.End
            
            return TimeRelation.Inside;
        } // public static TimeRelation RelationTo( this DateTime source, TimeRange Value )

        #endregion

        /// <summary> Enumrate date with step from [From] to [To] include [From] but exclude [To]. </summary>
        /// <param name="From"> From Time. </param>
        /// <param name="To"> To Time. </param>
        /// <param name="Step"> Interval of loop. </param>
        public static IEnumerable<DateTime> Enumerate( this DateTime From, DateTime To, TimeSpan Step ) {
            yield return From;
            while ( ( From = From.Add( Step ) ) < To ) 
                yield return From;
        } // public static IEnumerable<DateTime> Enumerate( this DateTime From, DateTime To, TimeSpan Step )


    } // public static class DateTimeExtension
} // namespace PGCafe
