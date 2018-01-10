using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    
    /// <summary> Represents multiple range of time, and they should be in order and not overlap or continus for each other in list. </summary>
    public class TimeRegion : IEnumerable<TimeRange> {

        #region Constructor & Property

        /// <summary> list of TimeRange </summary>
        private List<TimeRange> mTimeRanges = new List<TimeRange>();
        
        /// <summary> First start time of this TimeRegion. </summary>
        public DateTime? Start { get { return mTimeRanges.Count > 0 ? (DateTime?)mTimeRanges.First().Start : null; } }

        /// <summary> Latest end time of this TimeRegion. </summary>
        public DateTime? End { get { return mTimeRanges.Count > 0 ? (DateTime?)mTimeRanges.Last().End : null; } }
        
        /// <summary> How many part of TimeRange in this TimeRegion. </summary>
        public int Count { get { return mTimeRanges.Count; } }

        /// <summary> Initial <see cref="TimeRegion"/>. </summary>
        public TimeRegion() {
        } // public TimeRegion()

        /// <summary> Initial <see cref="TimeRegion"/> by <see cref="TimeRange"/> list. </summary>
        /// <param name="TimeRangeList"> TimeRange list. </param>
        public TimeRegion( params TimeRange[] TimeRangeList ) {
            this.AddRange( TimeRangeList );
        } // public TimeRegion( params TimeRange[] TimeRangeList )
        
        /// <summary> Initial <see cref="TimeRegion"/> by <see cref="TimeRange"/> list. </summary>
        /// <param name="TimeRangeList"> TimeRange list. </param>
        public TimeRegion( IEnumerable<TimeRange> TimeRangeList )
            : this( TimeRangeList.ToArray() ){
        } // public TimeRegion( IEnumerable<TimeRange> TimeRangeList )

        /// <summary> Initial <see cref="TimeRegion"/> by <see cref="TimeRegion"/> list. </summary>
        /// <param name="TimeRegionList"> TimeRegion list. </param>
        public TimeRegion( params TimeRegion[] TimeRegionList ) {
            this.AddRange( TimeRegionList );
        } // public TimeRegion( params TimeRegion[] TimeRegionList )
        
        /// <summary> Initial <see cref="TimeRegion"/> by <see cref="TimeRegion"/> list. </summary>
        /// <param name="TimeRegionList"> TimeRegion list. </param>
        public TimeRegion( IEnumerable<TimeRegion> TimeRegionList )
            : this( TimeRegionList.ToArray() ){
        } // public TimeRegion( IEnumerable<TimeRegion> TimeRegionList )

        #endregion

        #region Add
        
        /// <summary> Combine new TimeRange to this TimeRegion. </summary>
        /// <param name="NewTimeRange">New time range to add.</param>
        public void Add( TimeRange NewTimeRange ) {
            // if no any item in list, just add it.
            if ( this.Count == 0 ) {
                mTimeRanges.Add( NewTimeRange );
                return ;
            } // if

            // find first overlap Index, and last overlap Index.
            var firstOverlapIndex = -1;
            var lastOverlapIndex = -1;
            for ( int i = 0 ; i < this.Count ; i++ ) {

                // if current item has overlap with NewTimeRange, record it.
                if ( mTimeRanges[i].OverlapOrContinus( NewTimeRange ) ) {

                    // if hasn't first overlap, record current index to first overlap index.
                    if ( firstOverlapIndex == -1 ) {
                        firstOverlapIndex = i;
                        lastOverlapIndex = i; // need record last overlap index. ( maybe first and last is same index )
                    } // if

                    // if had first overlap index already, record current index to last overlap index, and check next.
                    // ( if next also has overlap, record last overlap index to next index.
                    else lastOverlapIndex = i;
                } // if

                // if current item isn't overlap with NewTimeRange, and also has last overlap index,
                // means remain item in list won't overlap with NewTimeRange, break for.
                else if ( lastOverlapIndex != -1 ) break;

                // because timerange in list is in order,
                // so if NewTimeRange's end time < item in list's start time, and no any overlap or continus,
                // means NewTimeRange should insert in here.
                else if ( mTimeRanges[i].Start > NewTimeRange.End ) {
                    mTimeRanges.Insert( i, NewTimeRange );
                    break;
                } // else if

                // if current item is last item, and no overlap, add NewTimeRange to last.
                else if ( i == this.Count - 1 ) {
                    mTimeRanges.Add( NewTimeRange );
                } // else if
            } // for

            // if has first overlap Index, must have last overlap index, otherwise, both == -1.
            // if has overlap, remove all overlap or continus item, and inesrt Union timerange.
            if ( firstOverlapIndex != -1 ) {
                var newStartTicks = Math.Min( mTimeRanges[firstOverlapIndex].Start.Ticks, NewTimeRange.Start.Ticks );
                var newEndTicks = Math.Max( mTimeRanges[lastOverlapIndex].End.Ticks, NewTimeRange.End.Ticks );

                // remove all overlap or continus item in list.
                mTimeRanges.RemoveRange( firstOverlapIndex, lastOverlapIndex - firstOverlapIndex + 1 );

                // add union time range.
                mTimeRanges.Insert( firstOverlapIndex, new TimeRange( newStartTicks, newEndTicks ) );
            } // if

        } // public void Add( TimeRange TimeRange )
        
        /// <summary> Combine new TimeRanges to this TimeRegion. </summary>
        /// <param name="TimeRangeList">New time range list to add.</param>
        public void AddRange( params TimeRange[] TimeRangeList ) {
            foreach ( var item in TimeRangeList ) this.Add( item );
        } // public void AddRange( params TimeRange[] TimeRangeList )
        
        /// <summary> Combine new TimeRanges to this TimeRegion. </summary>
        /// <param name="TimeRangeList">New time range list to add.</param>
        public void AddRange( IEnumerable<TimeRange> TimeRangeList ) {
            foreach ( var item in TimeRangeList ) this.Add( item );
        } // public void AddRange( IEnumerable<TimeRange> TimeRangeList )
        
        /// <summary> Combine new TimeRegion to this TimeRegion. </summary>
        /// <param name="TimeRegion">New time range to add.</param>
        public void Add( TimeRegion TimeRegion ) {
            this.AddRange( TimeRegion.Cast<TimeRange>().ToArray() );
        } // public void Add( TimeRegion TimeRegion )
        
        /// <summary> Combine new TimeRegions to this TimeRegion. </summary>
        /// <param name="TimeRegionList">New time region list to add.</param>
        public void AddRange( params TimeRegion[] TimeRegionList ) {
            foreach ( var item in TimeRegionList ) this.Add( item );
        } // public void AddRange( params TimeRegion[] TimeRegionList )
        
        /// <summary> Combine new TimeRegions to this TimeRegion. </summary>
        /// <param name="TimeRegionList">New time region list to add.</param>
        public void AddRange( IEnumerable<TimeRegion> TimeRegionList ) {
            foreach ( var item in TimeRegionList ) this.Add( item );
        } // public void AddRange( IEnumerable<TimeRegion> TimeRegionList )

        #endregion

        #region Remove

        /// <summary> Remove specify TimeRange from this TimeRegion. </summary>
        /// <param name="TimeRange">Specify time range to remove.</param>
        public void Remove( TimeRange TimeRange ) {
            // find first overlap Index, and last overlap Index.
            var firstOverlapIndex = -1;
            var lastOverlapIndex = -1;
            for ( int i = 0 ; i < this.Count ; i++ ) {

                // if current item has overlap with TimeRange, record it.
                if ( mTimeRanges[i].Overlap( TimeRange ) ) {

                    // if hasn't first overlap, record current index to first overlap index.
                    if ( firstOverlapIndex == -1 ) {
                        firstOverlapIndex = i;
                        lastOverlapIndex = i; // need record last overlap index. ( maybe first and last is same index )
                    } // if

                    // if had first overlap index already, record current index to last overlap index, and check next.
                    // ( if next also has overlap, record last overlap index to next index.
                    else lastOverlapIndex = i;
                } // if

                // if current item isn't overlap with TimeRange, and also has last overlap index,
                // means remain item in list won't overlap with TimeRange, break for.
                else if ( lastOverlapIndex != -1 ) break;

                // because timerange in list is in order,
                // so if TimeRange's end time < item in list's start time, and no any overlap,
                // means don't remove any time range.
                else if ( mTimeRanges[i].Start > TimeRange.End )
                    break;
            } // for

            // if has first overlap Index, must have last overlap index, otherwise, both == -1.
            // if has overlap, remove all overlap time range.
            if ( firstOverlapIndex != -1 ) {
                // insert first complement from first overlap item, and last complement from last overlap item.
                // and remove all time range from first to last.

                // reserve first overlap start time and last overlap end time.
                var firstOverlapStart = mTimeRanges[firstOverlapIndex].Start;
                var lastOverlapEnd = mTimeRanges[lastOverlapIndex].End;

                // remove all time range from first to last
                mTimeRanges.RemoveRange( firstOverlapIndex, lastOverlapIndex - firstOverlapIndex + 1 );

                // find and insert last complement. ( insert into firstOverlapIndex )
                if ( lastOverlapEnd > TimeRange.End )
                    mTimeRanges.Insert( firstOverlapIndex, new TimeRange( TimeRange.End, lastOverlapEnd ) );

                // find and insert first complement. ( insert into firstOverlapIndex )
                if ( firstOverlapStart < TimeRange.Start )
                    mTimeRanges.Insert( firstOverlapIndex, new TimeRange( firstOverlapStart, TimeRange.Start ) );
            } // if

        } // public void Remove( TimeRange TimeRange )
        
        /// <summary> Remove specify TimeRanges from this TimeRegion. </summary>
        /// <param name="TimeRangeList">Specify time range list to remove.</param>
        public void RemoveRange( params TimeRange[] TimeRangeList ) {
            foreach ( var item in TimeRangeList ) this.Remove( item );
        } // public void RemoveRange( params TimeRange[] TimeRangeList )
        
        /// <summary> Remove specify TimeRanges from this TimeRegion. </summary>
        /// <param name="TimeRangeList">Specify time range list to remove.</param>
        public void RemoveRange( IEnumerable<TimeRange> TimeRangeList ) {
            foreach ( var item in TimeRangeList ) this.Remove( item );
        } // public void RemoveRange( IEnumerable<TimeRange> TimeRangeList )

        /// <summary> Remove specify TimeRegion from this TimeRegion. </summary>
        /// <param name="TimeRegion">Specify time region to remove.</param>
        public void Remove( TimeRegion TimeRegion ) {
            this.RemoveRange( TimeRegion.Cast<TimeRange>().ToArray() );
        } // public void Remove( TimeRegion TimeRegion )
        
        /// <summary> Remove specify TimeRegions from this TimeRegion. </summary>
        /// <param name="TimeRegionList">Specify time region list to remove.</param>
        public void RemoveRange( params TimeRegion[] TimeRegionList ) {
            foreach ( var item in TimeRegionList ) this.Remove( item );
        } // public void RemoveRange( params TimeRegion[] TimeRegionList )
        
        /// <summary> Remove specify TimeRegions from this TimeRegion. </summary>
        /// <param name="TimeRegionList">Specify time region list to remove.</param>
        public void RemoveRange( IEnumerable<TimeRegion> TimeRegionList ) {
            foreach ( var item in TimeRegionList ) this.Remove( item );
        } // public void RemoveRange( IEnumerable<TimeRegion> TimeRegionList )

        #endregion

        #region DateTime method
        
        /// <summary> Returns a value indicating whether a specified DateTime occurs within this TimRegion( include Start, exclude End for every range ). </summary>
        /// <param name="Value"> Value of <see cref="DateTime"/> to seek.</param>
        /// <returns> true if the Value occurs within this TimRegion( include Start, exclude End for every range ), otherwise false.</returns>
        public bool Contains( DateTime Value ) {
            return this.TakeWhile( item => item.Start <= Value ).Any( item => item.Contains( Value ) );
        } // public bool Contains( DateTime Value )

        #endregion

        #region TimeRange method
        
        /// <summary> Returns a value indicating whether a specified TimeRange is all within this TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is all within this TimeRegion, otherwise false.</returns>
        public bool Contains( TimeRange Value ) {
            return this.TakeWhile( item => item.Start <= Value.Start ).Any( item => item.Contains( Value ) );
        } // public bool Contains( TimeRange Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRange is overlap with this TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is overlap with this TimeRegion, otherwise false.</returns>
        public bool Overlap( TimeRange Value ) {
            return this.TakeWhile( item => item.Start < Value.End ).Any( item => item.Contains( Value ) );
        } // public bool Overlap( TimeRange Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRange is contains all of this TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to seek.</param>
        /// <returns> true if the Value is contains all of this TimeRegion, otherwise false.</returns>
        public bool Inside( TimeRange Value ) {
            return this.Start <= Value.Start && this.End >= Value.End;
        } // public bool Inside( TimeRange Value )

        
        /// <summary> Returns a new TimeRegion which is intersection of this TimeRegion and another TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to intersect.</param>
        /// <returns> TimeRegion which is intersection of this TimeRegion and another TimeRange, null if no intersection. </returns>
        public TimeRegion Intersect( TimeRange Value ) {
            return new TimeRegion( this
                .SkipWhile( item => item.End < Value.Start )
                .TakeWhile( item => item.Start < Value.End )
                .Select( item => item.Intersect( Value ) )
                .Where( item => item != null )
                .Cast<TimeRange>() );
        } // public TimeRegion Intersect( TimeRange Value )
        
        /// <summary> Returns a new TimeRegion which is union of this TimeRegion and another TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to union.</param>
        /// <returns> TimeRegion which is union of this TimeRegion and another TimeRange. </returns>
        public TimeRegion Union( TimeRange Value ) {
            return new TimeRegion( this.Concat( Value ) );
        } // public TimeRegion Union( TimeRange Value )
        
        /// <summary> Returns a new TimeRegion which is the result of this TimeRegion except another TimeRange. </summary>
        /// <param name="Value"> Value of <see cref="TimeRange"/> to be except.</param>
        /// <returns> TimeRegion which is the result of this TimeRegion except another TimeRange. </returns>
        public TimeRegion Except( TimeRange Value ) {
            var result = new TimeRegion( this );
            result.Remove( Value );
            return result;
        } // public TimeRegion Except( TimeRange Value )

        #endregion

        #region TimeRegion method
        
        /// <summary> Returns a value indicating whether a specified TimeRegion is all within this TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to seek.</param>
        /// <returns> true if the Value is all within this TimeRegion, otherwise false.</returns>
        public bool Contains( TimeRegion Value ) {
            return Value.All( item => this.Contains( item ) );
        } // public bool Contains( TimeRegion Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRegion is overlap with this TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to seek.</param>
        /// <returns> true if the Value is overlap with this TimeRegion, otherwise false.</returns>
        public bool Overlap( TimeRegion Value ) {
            return this.Any( item1 => Value.Any( item2 => item1.Overlap( item2 ) ) );
        } // public bool Overlap( TimeRegion Value )
        
        /// <summary> Returns a value indicating whether a specified TimeRegion is contains all of this TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to seek.</param>
        /// <returns> true if the Value is contains all of this TimeRegion, otherwise false.</returns>
        public bool Inside( TimeRegion Value ) {
            return this.All( item => Value.Contains( item ) );
        } // public bool Inside( TimeRegion Value )

        
        /// <summary> Returns a new TimeRegion which is intersection of this TimeRegion and another TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to intersect.</param>
        /// <returns> TimeRegion which is intersection of this TimeRegion and another TimeRegion, null if no intersection. </returns>
        public TimeRegion Intersect( TimeRegion Value ) {
            return new TimeRegion( this.SelectMany( item => Value.Intersect( item ) ) );
        } // public TimeRegion Intersect( TimeRegion Value )
        
        /// <summary> Returns a new TimeRegion which is union of this TimeRegion and another TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to union.</param>
        /// <returns> TimeRegion which is union of this TimeRegion and another TimeRegion. </returns>
        public TimeRegion Union( TimeRegion Value ) {
            return new TimeRegion( this.Concat( Value ) );
        } // public TimeRegion Union( TimeRegion Value )
        
        /// <summary> Returns a new TimeRegion which is the result of this TimeRegion except another TimeRegion. </summary>
        /// <param name="Value"> Value of <see cref="TimeRegion"/> to be except.</param>
        /// <returns> TimeRegion which is the result of this TimeRegion except another TimeRegion. </returns>
        public TimeRegion Except( TimeRegion Value ) {
            var result = new TimeRegion( this );
            result.Remove( Value );
            return result;
        } // public TimeRegion Except( TimeRegion Value )

        #endregion

        #region Other: GetContainsTimeRange, ToString, Clone, implicit operator

        /// <summary> Get TimeRange that contains this TimeRegion. </summary>
        /// <returns> TimeRange has contains this TimeRegion, null if no item in this TimeRegion. </returns>
        public TimeRange? GetContainsTimeRange() {
            if ( this.Any() ) return new TimeRange( this.Start.Value, this.End.Value );
            else return null;
        } // public TimeRange? GetContainsTimeRange()
        
        /// <summary> Convert this TimeRegion to string with. </summary>
        /// <returns> string of this TimeRegion show each part of TimeRange. </returns>
        public override string ToString() {
            return string.Join( ", ", this );
        } // public override string ToString()
        
        /// <summary> Clone this object to new one. </summary>
        /// <returns> New TimeRegion has same time region with this.</returns>
        public TimeRegion Clone() {
            return new TimeRegion( this );
        } // public TimeRegion Clone()

        /// <summary> Convert TimeRange to TimeRegion. </summary>
        /// <param name="Value"> Value of time range </param>
        public static implicit operator TimeRegion( TimeRange Value ) {
            return new TimeRegion( Value );
        } // public static implicit operator TimeRegion( TimeRange Value )

        #endregion

        #region Implement
        
        /// <summary> Get Enumerator of this object. </summary>
        /// <returns> Enumerator of this object. </returns>
        public IEnumerator<TimeRange> GetEnumerator() {
            return mTimeRanges.GetEnumerator();
        } // public IEnumerator<TimeRange> GetEnumerator()
        
        /// <summary> Get Enumerator of this object. </summary>
        /// <returns> Enumerator of this object. </returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return mTimeRanges.GetEnumerator();
        } // IEnumerator IEnumerable.GetEnumerator()

        #endregion

    } // public class TimeRegion : IEnumerable<TimeRange>

} // namespace PGCafe.Object
