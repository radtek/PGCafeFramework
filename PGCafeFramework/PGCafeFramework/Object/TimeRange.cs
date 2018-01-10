using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    /// <summary> Provide Time relation type. ( Flag enum ) </summary>
    [Flags]
    public enum TimeRelation {

        #region Flag cell

        /// <summary> Part of A is to the left of B. ( A.End &lt; B.End and A.Start &lt;= B.Start ) </summary>
        Left = 0x1,

        /// <summary> Part of A is to the right of B. ( A.Start &gt; B.Start and A.End &gt;= B.End ) </summary>
        Right = 0x2,

        /// <summary> A is outside of B. ( not Overlap ) </summary>
        Outside = 0x4,
        
        /// <summary> A is overlap with B. </summary>
        Overlap = 0x8,

        /// <summary> A is continus of B. ( A.End == B.Start or A.Start == B.End )</summary>
        Continus = 0x10 | Outside,

        /// <summary> A has contains B. ( B is all in A )</summary>
        Contains = 0x20 | Overlap,

        /// <summary> A is inside of B. ( A is all in B )</summary>
        Inside = 0x40 | Overlap,

        #endregion

        #region Combine item

        /// <summary> A is to the left of B and not continus. </summary>
        OutsideLeft = Outside | Left,

        /// <summary> A is to the left of B and A.End == B.Start. </summary>
        ContinusLeft = Continus | Left,

        /// <summary> A is to the left of B and A is overlap with B. </summary>
        OverlapLeft = Overlap | Left,

        /// <summary> A has contains B and A.Start == B.Start. </summary>
        ContainsLeft = Contains | Left,

        /// <summary> A is inside of B and A.Start == B.Start. </summary>
        InsideLeft = Inside | Left,

        /// <summary> A is to the right of B. </summary>
        OutsideRight = Outside | Right,

        /// <summary> A is to the right of B and A.Start == B.End. </summary>
        ContinusRight = Continus | Right,

        /// <summary> A is to the left of B and A is overlap with B. </summary>
        OverlapRight = Overlap | Right,

        /// <summary> A has contains B and A.End == B.End. </summary>
        ContainsRight = Contains | Right,

        /// <summary> A is inside of B and A.End == B.End. </summary>
        InsideRight = Inside | Right,

        /// <summary> A is exact same with B. </summary>
        ExactSame = Contains | Overlap | Inside | Left | Right,

        #endregion

    } // public enum TimeRelation

    /// <summary> Represents a range of time, contains Start and End. </summary>
    public struct TimeRange {

        #region Property, Constructor, Setter

        /// <summary> Start time of range. </summary>
        public DateTime Start { get; private set; }

        /// <summary> End time of range. </summary>
        public DateTime End { get; private set; }

        /// <summary> Time span from Start to End. </summary>
        public TimeSpan Span { get { return End - Start; } }

        /// <summary> Initial <see cref="TimeRange"/> struct by start time and zero of time span. </summary>
        /// <param name="Start"> Start time of range </param>
        public TimeRange( DateTime Start ) {
            this.Start = Start;  this.End = Start;
        } // public TimeRange( DateTime Start )

        /// <summary> Initial <see cref="TimeRange"/> struct by start time and end time. </summary>
        /// <param name="Start"> Start time of range </param>
        /// <param name="End"> End time of range </param>
        /// <exception cref="ArgumentException"> Throw when end time &lt; start time </exception>
        public TimeRange( DateTime Start, DateTime End ) {
            if ( End < Start ) throw new ArgumentException( "End time must >= Start time" );
            this.Start = Start;  this.End = End;
        } // public TimeRange( DateTime Start, DateTime End )
        
        /// <summary> Initial <see cref="TimeRange"/> struct by start time and time span. </summary>
        /// <param name="Start"> Start time of range </param>
        /// <param name="TimeSpan"> Time span of range </param>
        public TimeRange( DateTime Start, TimeSpan TimeSpan ) {
            this.Start = Start;  this.End = Start.Add( TimeSpan );
        } // public TimeRange( DateTime Start, TimeSpan TimeSpan )

        /// <summary> Initial <see cref="TimeRange"/> struct by time span and end time. </summary>
        /// <param name="TimeSpan"> Time span of range </param>
        /// <param name="End"> End time of range </param>
        public TimeRange( TimeSpan TimeSpan, DateTime End ) {
            this.Start = End.Subtract( TimeSpan );  this.End = End;
        } // public TimeRange( TimeSpan TimeSpan, DateTime End )



        /// <summary> Initial <see cref="TimeRange"/> struct by start time's ticks and end time's ticks. </summary>
        /// <param name="StartTicks"> Start time's ticks of range </param>
        /// <param name="EndTicks"> End time's ticks of range </param>
        /// <exception cref="ArgumentException"> Throw when end time &lt; start time </exception>
        public TimeRange( long StartTicks, long EndTicks ) {
            if ( EndTicks < StartTicks ) throw new ArgumentException( "End time must >= Start time" );
            this.Start = new DateTime( StartTicks );  this.End = new DateTime( EndTicks );
        } // public TimeRange( DateTime Start, DateTime EndTicks )
        
        /// <summary> Initial <see cref="TimeRange"/> struct by start time's ticks and time span. </summary>
        /// <param name="StartTicks"> Start time's ticks of range </param>
        /// <param name="TimeSpan"> Time span of range </param>
        public TimeRange( long StartTicks, TimeSpan TimeSpan ) {
            this.Start = new DateTime( StartTicks );  this.End = new DateTime( StartTicks + TimeSpan.Ticks );
        } // public TimeRange( long Start, TimeSpan TimeSpan )

        /// <summary> Initial <see cref="TimeRange"/> struct by time span and end time's ticks. </summary>
        /// <param name="TimeSpan"> Time span of range </param>
        /// <param name="EndTicks"> End time's ticks of range </param>
        public TimeRange( TimeSpan TimeSpan, long EndTicks ) {
            this.Start = new DateTime( EndTicks - TimeSpan.Ticks );  this.End = new DateTime( EndTicks );
        } // public TimeRange( TimeSpan TimeSpan, long EndTicks )


        /// <summary> Set start time of this object. </summary>
        /// <param name="Start">The new start time.</param>
        public void SetStart( DateTime Start ) {
            this.Start = Start;
        } // public void SetStart( DateTime Start )
        
        /// <summary> Set end time of this object. </summary>
        /// <param name="End">The new end time.</param>
        public void SetEnd( DateTime End ) {
            this.End = End;
        } // public void SetEnd( DateTime End )

        #endregion

        #region Non category method

        /// <summary> Determine this TimeRange is time point or not. ( the time point is means Start == End ) </summary>
        /// <returns>
        ///   <c>true</c> if [is date time]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTimePoint() {
            return this.Start == this.End;
        } // public bool IsTimePoint()

        #endregion

        #region DateTime method

        /// <summary> Returns a value indicating whether a specified DateTime occurs within this TimeRange( include Start, exclude End ). </summary>
        /// <param name="Value"> Value of <see cref="DateTime"/> to seek.</param>
        /// <returns> true if the Value occurs within this TimeRange( include Start, exclude End ), otherwise false.</returns>
        public bool Contains( DateTime Value ) {
            return this.Start <= Value && Value < this.End;
        } // public bool Contains( DateTime Value )
        

        /// <summary> Determine the relation from this TimeRange to a specified DateTime. </summary>
        /// <param name="Value"> Value of <see cref="DateTime"/> to seek.</param>
        /// <returns> <see cref="TimeRelation"/> to Determine the relation from this TimeRange to a specified DateTime.</returns>
        public TimeRelation RelationTo( DateTime Value ) {
            if ( this.IsTimePoint() ) return this.Start.RelationTo( Value );

            // check relative and return it.
            if ( this.End < Value ) return TimeRelation.OutsideLeft;
            if ( this.End == Value ) return TimeRelation.ContinusLeft;

            if ( this.Start > Value ) return TimeRelation.OutsideRight;
            if ( this.Start == Value ) return TimeRelation.ContinusRight | TimeRelation.ContainsRight;

            // base-line : this.End > Value && this.Start < Value
            
            return TimeRelation.Contains;
        } // public TimeRelation RelationTo( DateTime Value )

        #endregion

        #region TimeRange method
        
        /// <summary> Returns a value indicating whether a specified TimeRange is all within this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is all within this TimeRange, otherwise false.</returns>
        public bool Contains( TimeRange Value ) {
            return this.Start <= Value.Start && this.End >= Value.End;
        } // public bool Contains( TimeRange Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRange is overlap with this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is overlap with this TimeRange, otherwise false.</returns>
        public bool Overlap( TimeRange Value ) {
            return this.Start < Value.End && this.End > Value.Start;
        } // public bool Overlap( TimeRange Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRange is contains all of this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is contains all of this TimeRange, otherwise false.</returns>
        public bool Inside( TimeRange Value ) {
            return Value.Contains( this );
        } // public bool Inside( TimeRange Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRange is continus with this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is continus with this TimeRange, otherwise false.</returns>
        public bool Continus( TimeRange Value ) {
            return this.Start == Value.End || this.End == Value.Start;
        } // public bool Continus( TimeRange Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRange is overlap or continus with this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is overlap or continus with this TimeRange, otherwise false.</returns>
        public bool OverlapOrContinus( TimeRange Value ) {
            return this.End >= Value.Start && this.Start <= Value.End;
        } // public bool OverlapOrContinus( TimeRange Value )
        
        /// <summary> Determine the relation from this TimeRange to a specified TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> <see cref="TimeRelation"/> to Determine the relation from this TimeRange to a specified TimeRange.</returns>
        public TimeRelation RelationTo( TimeRange Value ) {
            // if Value is time point, generate relative with TimeRange and DateTime.
            if ( Value.IsTimePoint() ) return this.RelationTo( Value.Start );

            // check relative and return it.
            if ( this.End < Value.Start ) return TimeRelation.OutsideLeft;
            if ( this.End == Value.Start ) return TimeRelation.ContinusLeft;

            if ( this.Start > Value.End ) return TimeRelation.OutsideRight;
            if ( this.Start == Value.End ) return TimeRelation.ContinusRight;

            // base-line : this.End > Value.Start && this.Start < Value.End
            
            if ( this.Start < Value.Start ) {
                if ( this.End < Value.End ) return TimeRelation.OverlapLeft;
                if ( this.End == Value.End ) return TimeRelation.ContainsRight;
                if ( this.End > Value.End ) return TimeRelation.Contains;
            } // if
            else if ( this.Start == Value.Start ) {
                if ( this.End < Value.End ) return TimeRelation.InsideLeft;
                if ( this.End == Value.End ) return TimeRelation.ExactSame;
                if ( this.End > Value.End ) return TimeRelation.ContainsLeft;
            } // else if
            else { // this.Start > O.Start
                if ( this.End < Value.End ) return TimeRelation.Inside;
                if ( this.End == Value.End ) return TimeRelation.InsideRight;
                if ( this.End > Value.End ) return TimeRelation.OverlapRight;
            } // else

            throw new NotSupportedException( 
$@"Undefine relative, should not happened.
this[{this.Start.Ticks} - {this.End.Ticks}] Value[{Value.Start.Ticks} - {Value.End.Ticks}]" );

        } // public TimeRelation RelationTo( TimeRange Value )

        
        /// <summary> Returns a TimeRange which is intersection of this TimeRange and another TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to intersect.</param>
        /// <returns> TimeRange which is intersection of this TimeRange and another TimeRange, null if no intersection. </returns>
        public TimeRange? Intersect( TimeRange Value ) {
            var newStart = Math.Max( this.Start.Ticks, Value.Start.Ticks );
            var newEnd = Math.Min( this.End.Ticks, Value.End.Ticks );

            // if no intersection, return null.
            if ( newEnd < newStart ) return null;

            // else return new TimeRange of intersection.
            else return new TimeRange( newStart, newEnd );
        } // public TimeRange? Intersect( TimeRange Value )
        
        
        /// <summary> Returns a TimeRegion which is union of this TimeRange and another TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to union.</param>
        /// <returns> TimeRegion which is union of this TimeRange and another TimeRange. </returns>
        public TimeRegion Union( TimeRange Value ) {
            // if has overlap or continus, union to one TimeRange.
            if ( this.OverlapOrContinus( Value ) ) {
                var newStart = Math.Min( this.Start.Ticks, Value.Start.Ticks );
                var newEnd = Math.Max( this.End.Ticks, Value.End.Ticks );

                return new TimeRange( newStart, newEnd );
            } // if

            // else, return TimeRegion contains both two TimeRange.
            return new TimeRegion( this, Value );
        } // public TimeRegion Union( TimeRange Value )
        
        
        /// <summary> Returns a TimeRegion which is the result of this TimeRange except another TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to be except.</param>
        /// <returns> TimeRegion which is the result of this TimeRange except another TimeRange. </returns>
        public TimeRegion Except( TimeRange Value ) {
            // result could has zero or one or two TimeRange, prepare tmp variable to save.
            TimeRange? timeRange1 = null;
            TimeRange? timeRange2 = null;
            
            // if this.Start is smaller than Value.Start, should have one TimeRange.
            if ( this.Start < Value.Start )
                timeRange1 = new TimeRange( this.Start.Ticks, Math.Min( this.End.Ticks, Value.Start.Ticks ) );
            
            // if this.End is bigger than Value.End, should have one TimeRange.
            if ( this.End > Value.End )
                timeRange2 = new TimeRange( Math.Max( this.Start.Ticks, Value.End.Ticks ), this.End.Ticks );

            // if has no first TimeRange, return second TimeRange or null.
            if ( timeRange1 == null ) return timeRange2 ?? null;

            // if has no second TimeRange, return first TimeRange or null.
            if ( timeRange2 == null ) return timeRange1 ?? null;

            // if has both TimeRange, return TimeRegion contains two TimeRange.
            return new TimeRegion( timeRange1.Value, timeRange2.Value );
        } // public TimeRegion Except( TimeRange Value )

        #endregion

        #region TimeRegion method
        
        /// <summary> Returns a value indicating whether a specified TimeRegion is all within this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to seek.</param>
        /// <returns> true if the Value is all within this TimeRange, otherwise false.</returns>
        public bool Contains( TimeRegion Value ) {
            return Value.Inside( this );
        } // public bool Contains( TimeRegion Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRegion has any overlap with this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to seek.</param>
        /// <returns> true if the Value has any overlap with this TimeRange, otherwise false.</returns>
        public bool Overlap( TimeRegion Value ) {
            return Value.Overlap( this );
        } // public bool Overlap( TimeRegion Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRegion is contains all of this TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to seek.</param>
        /// <returns> true if the Value is contains all of this TimeRange, otherwise false.</returns>
        public bool Inside( TimeRegion Value ) {
            return Value.Contains( this );
        } // public bool Inside( TimeRegion Value )

        
        /// <summary> Returns a TimeRegion which is intersection of this TimeRange and another TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to intersect.</param>
        /// <returns> TimeRegion which is intersection of this TimeRange and another TimeRegion. </returns>
        public TimeRegion Intersect( TimeRegion Value ) {
            return Value.Intersect( this );
        } // public TimeRegion Intersect( TimeRegion Value )
        
        /// <summary> Returns a TimeRegion which is union of this TimeRange and another TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to union.</param>
        /// <returns> TimeRegion which is union of this TimeRange and another TimeRegion. </returns>
        public TimeRegion Union( TimeRegion Value ) {
            return Value.Union( this );
        } // public TimeRegion Union( TimeRegion Value )
        
        /// <summary> Returns a TimeRegion which is the result of this TimeRange except another TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to be except.</param>
        /// <returns> TimeRegion which is the result of this TimeRange except another TimeRegion. </returns>
        public TimeRegion Except( TimeRegion Value ) {
            return new TimeRegion( this ).Except( Value );
        } // public TimeRegion Except( TimeRegion Value )

        #endregion

        #region ToString, implicit operator

        /// <summary> Convert this TimeRange to string with. </summary>
        /// <returns> string of this TimeRange show start to end. </returns>
        public override string ToString() {
            return $"{Start.ToString()}~{End.ToString()}";
        } // public override string ToString()

        /// <summary> Convert DateTime to TimeRange with StartTime and zero timespan. </summary>
        /// <param name="Start"> Start time of range </param>
        public static implicit operator TimeRange( DateTime Start ) {
            return new TimeRange( Start );
        } // public static implicit operator TimeRange( DateTime Start )

        #endregion

    } // public struct TimeRange

} // namespace PGCafe.Object
