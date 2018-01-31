using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PGCafe {
    /// <summary>
    /// String's Extension.
    /// </summary>
    public static class StringExtension {

        #region SubstringEX

        /// <summary>
        /// Substring start with [from] parameter to [to] parameter.
        /// Pass zero or one of [from] parameter and zero or one of [to] parameter to sub the string.
        /// Will include [from]/[to] token if use [fromString]/[toString] parameter.
        /// Without [from] parameter will sub string from the start, without [to] parameter will sub string to the end.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="fromString">sub string from by string token.</param>
        /// <param name="fromIndex">sub string from by index.</param>
        /// <param name="toString">sub string to by string token.</param>
        /// <param name="toIndex">sub string to by index.</param>
        /// <param name="toLength">sub string to by length.</param>
        /// <param name="comparisionType">Type of the string comparision. ( only use with [fronString] and [toString] parameter )</param>
        /// <returns>
        /// return sub string start with [from] parameter to [to] parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// pass more than one from token or pass more than one to token.
        /// </exception>
        public static string SubstringEX( this string source,
            string fromString = null, int? fromIndex = null,
            string toString = null, int? toIndex = null, int? toLength = null,
            StringComparison comparisionType = StringComparison.CurrentCulture ){

            if ( source == null )
                return null;

            /// check argument error.
            if ( fromString != null && fromIndex != null )
                throw new ArgumentException( $"below argument's can only have one value: {nameof( fromString )}, {nameof( fromIndex )}" );
            
            if ( PGMath.Truth( toString != null, toIndex != null, toLength != null ) > 1 )
                throw new ArgumentException( $"below argument's can only have one value: {nameof( toString )}, {nameof( toIndex )}, {nameof( toLength )}" );

            /// get from index.
            int from_startIndex;
            int from_endIndex;
            if ( fromString != null ){
                from_startIndex = source.IndexOf( fromString, comparisionType );
                if ( from_startIndex == -1 )
                    return null;

                from_endIndex = from_startIndex + fromString.Length;
            } // if
            else if ( fromIndex != null ){
                from_startIndex = from_endIndex = fromIndex.Value;
                if ( from_startIndex < 0 )
                    from_startIndex = from_endIndex = 0;
                else if ( from_startIndex > source.Length )
                    from_startIndex = from_endIndex = source.Length;
            } // else if
            else {
                from_startIndex = from_endIndex = 0;
            } // else
            

            /// get to index.
            int to_startIndex;
            int to_endIndex;
            if ( toString != null ){
                to_startIndex = source.IndexOf( toString, from_endIndex, comparisionType );
                if ( to_startIndex == -1 )
                    return null;

                to_endIndex = to_startIndex + toString.Length;
            } // if
            else if ( toIndex != null ){
                to_startIndex = to_endIndex = toIndex.Value;
                if ( to_startIndex < from_startIndex )
                    return "";
                else if ( to_startIndex > source.Length )
                    to_startIndex = to_endIndex = source.Length;
            } // else if
            else if ( toLength != null ){
                to_startIndex = to_endIndex = from_startIndex + toLength.Value;
                if ( to_startIndex < from_startIndex )
                    return "";
                else if ( to_startIndex > source.Length )
                    to_startIndex = to_endIndex = source.Length;
            } // else if
            else
                to_startIndex = to_endIndex = source.Length;


            /// sub string and return result.
            return source.Substring( from_startIndex, to_endIndex - from_startIndex );
        } // public static string SubstringEX( this string source, ... )
        
        /// <summary>
        /// Substring start with [from] parameter to [to] parameter.
        /// Pass zero or one of [from] parameter and zero or one of [to] parameter to sub the string.
        /// Will not include [from]/[to] token if use [fromString]/[toString] parameter.
        /// Without [from] parameter will sub string from the start, without [to] parameter will sub string to the end.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="fromString">sub string from by string token.</param>
        /// <param name="fromIndex">sub string from by index.</param>
        /// <param name="toString">sub string to by string token.</param>
        /// <param name="toIndex">sub string to by index.</param>
        /// <param name="toLength">sub string to by length.</param>
        /// <param name="comparisionType">Type of the string comparision. ( only use with [fronString] and [toString] parameter )</param>
        /// <returns>
        /// return sub string start with [from] parameter to [to] parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// pass more than one from token or pass more than one to token.
        /// </exception>
        public static string SubstringShrinkEX( this string source,
            string fromString = null, int? fromIndex = null,
            string toString = null, int? toIndex = null, int? toLength = null,
            StringComparison comparisionType = StringComparison.CurrentCulture ){

            if ( source == null )
                return null;

            /// check argument error.
            if ( fromString != null && fromIndex != null )
                throw new ArgumentException( $"below argument's can only have one value: {nameof( fromString )}, {nameof( fromIndex )}" );
            
            if ( PGMath.Truth( toString != null, toIndex != null, toLength != null ) > 1 )
                throw new ArgumentException( $"below argument's can only have one value: {nameof( toString )}, {nameof( toIndex )}, {nameof( toLength )}" );

            /// get from index.
            int from_startIndex;
            int from_endIndex;
            if ( fromString != null ){
                from_startIndex = source.IndexOf( fromString, comparisionType );
                if ( from_startIndex == -1 )
                    return null;

                from_endIndex = from_startIndex + fromString.Length;
            } // if
            else if ( fromIndex != null ){
                from_startIndex = from_endIndex = fromIndex.Value;
                if ( from_startIndex < 0 )
                    from_startIndex = from_endIndex = 0;
                else if ( from_startIndex > source.Length )
                    from_startIndex = from_endIndex = source.Length;
            } // else if
            else {
                from_startIndex = from_endIndex = 0;
            } // else
            

            /// get to index.
            int to_startIndex;
            int to_endIndex;
            if ( toString != null ){
                to_startIndex = source.IndexOf( toString, from_endIndex, comparisionType );
                if ( to_startIndex == -1 )
                    return null;

                to_endIndex = to_startIndex + toString.Length;
            } // if
            else if ( toIndex != null ){
                to_startIndex = to_endIndex = toIndex.Value;
                if ( to_startIndex < from_endIndex )
                    return "";
                else if ( to_startIndex > source.Length )
                    to_startIndex = to_endIndex = source.Length;
            } // else if
            else if ( toLength != null ){
                to_startIndex = to_endIndex = from_endIndex + toLength.Value;
                if ( to_startIndex < from_endIndex )
                    return "";
                else if ( to_startIndex > source.Length )
                    to_startIndex = to_endIndex = source.Length;
            } // else if
            else
                to_startIndex = to_endIndex = source.Length;


            /// sub string and return result.
            return source.Substring( from_endIndex, to_startIndex - from_endIndex );
        } // public static string SubstringShrinkEX( this string source, ... )

        #endregion

        #region Substring, SubstringShrink

        /// <summary>
        /// Substring start with string token. ( include token [from] )
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="from"> search token in source. </param>
        /// <returns> return sub string from index of [from] token. </returns>
        public static string Substring( this string source, string from ){
            // search index of token [from], if no found, return default value.
            int fromIndex = source.IndexOf( from );
            if ( fromIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex );
        } // public static string Substring( this string source, string from )


        /// <summary>
        /// Substring between string. ( include token [from] and [to] )
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="from"> search token in source, substring start with this token. </param>
        /// <param name="to"> search token in source, substring to this token. </param>
        /// <returns> return sub string from index of [from] token to index of [to] token. </returns>
        public static string Substring( this string source, string from, string to ){
            // search index of token [from] and token [to], if no found, return default value.
            int fromIndex = source.IndexOf( from );
            if ( fromIndex == -1 ) return null;

            int toIndex = source.IndexOf( to, fromIndex + from.Length );
            if ( toIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex, toIndex - fromIndex + to.Length );
        } // public static string Substring( this string source, string from, string to )


        /// <summary>
        /// Substring start with index and end with string. ( include token [to] )
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="fromIndex"> substring start with [fromIndex]. </param>
        /// <param name="to"> search token in source, substring to this token. </param>
        /// <returns> return sub string from index of [from] token to index of [to] token. </returns>
        public static string Substring( this string source, int fromIndex, string to ){
            // search index of token [to], if no found, return default value.
            int toIndex = source.IndexOf( to, fromIndex );
            if ( toIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex, toIndex - fromIndex + to.Length );
        } // public static string Substring( this string source, int fromIndex, string to )


        /// <summary>
        /// Substring start with string and end with index. ( include token [from] )
        /// </summary>
        /// <param name="source"> source. </param>
        /// <param name="from"> search token in source, substring start with this token. </param>
        /// <param name="toIndex"> substring to [toIndex]. </param>
        /// <returns> return sub string from index of [from] token to index of [to] token. </returns>
        public static string Substring( this string source, string from, int toIndex ){
            // search index of token [from], if no found, return default value.
            int fromIndex = source.IndexOf( from );
            if ( fromIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex, toIndex );
        } // public static string Substring( this string source, string from, int toIndex )


        /// <summary>
        /// Substring start with string token. ( not include token [from] )
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="from"> search token in source. </param>
        /// <returns> return sub string from index of [from] token. </returns>
        public static string SubstringShrink( this string source, string from ){
            // search index of token [from], if no found, return default value.
            int fromIndex = source.IndexOf( from );
            if ( fromIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex + from.Length );
        } // public static string SubstringShrink( this string source, string from )


        /// <summary>
        /// Substring between string. ( not include token [from] and [to] )
        /// </summary>
        /// <param name="source"> source. </param>
        /// <param name="from"> search token in source, substring start with this token. </param>
        /// <param name="to"> search token in source, search after [from] token, substring to this token. </param>
        /// <returns> return sub string from index of [from] token to index of [to] token. </returns>
        public static string SubstringShrink( this string source, string from, string to ){
            // search index of token [from] and token [to], if no found, return default value.
            int fromIndex = source.IndexOf( from );
            if ( fromIndex == -1 ) return null;

            int toIndex = source.IndexOf( to, fromIndex + from.Length );
            if ( toIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex + from.Length, toIndex - fromIndex - from.Length );
        } // public static string SubstringShrink( this string source, int from, string to )


        /// <summary>
        /// Substring start with index and end with string. ( not include token [to] )
        /// </summary>
        /// <param name="source"> source. </param>
        /// <param name="fromIndex"> substring start with [fromIndex]. </param>
        /// <param name="to"> search token in source start from [fromIndex], substring to this token. </param>
        /// <returns> return sub string from index of [from] token to index of [to] token. </returns>
        public static string SubstringShrink( this string source, int fromIndex, string to ){
            // search index of token [to], if no found, return default value.
            int toIndex = source.IndexOf( to, fromIndex );
            if ( toIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex, toIndex - fromIndex );
        } // public static string SubstringShrink( this string source, int fromIndex, string to )


        /// <summary>
        /// Substring start with string and end with index. ( not include token [from] )
        /// </summary>
        /// <param name="source"> source. </param>
        /// <param name="from"> search token in source, substring start with this token. </param>
        /// <param name="toIndex"> substring to [toIndex]. </param>
        public static string SubstringShrink( this string source, string from, int toIndex ){
            // search index of token [from], if no found, return default value.
            int fromIndex = source.IndexOf( from );
            if ( fromIndex == -1 ) return null;
            
            // else return sub string.
            return source.Substring( fromIndex + from.Length, toIndex - fromIndex - from.Length );
        } // public static string SubstringShrink( this string source, int from, int toIndex )

        #endregion

        #region SubstringAll(Shrink), SubstringMulti(Shrink)

        /// <summary>
        /// Substring between two string and get all values between those token.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="from"> search token in source, substring start with this token. </param>
        /// <param name="to"> search token in source, search after [from] token, substring to this token. </param>
        public static IEnumerable<string> SubstringAll( this string source, string from, string to ) {
            int startIndex = 0;
            while ( true ) {
                // search index of [from] and [to], if no found, break loop.
                int fromIndex = source.IndexOf( from, startIndex );
                if ( fromIndex == -1 ) break ;

                int toIndex = source.IndexOf( to, fromIndex + from.Length );
                if ( toIndex == -1 ) break ;

                // if found the token, sub string it and yield return it.
                yield return source.Substring( fromIndex, toIndex + to.Length - fromIndex );

                // set start index at last of [to] token.
                startIndex = toIndex + to.Length;
            } // while
        } // public static IEnumerable<string> SubstringAll( this string source, string from, string to )
        

        /// <summary>
        /// Substring between two string and get all values between those token. ( not include token [from] and [to] )
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="from"> search token in source, substring start with this token. </param>
        /// <param name="to"> search token in source, search after [from] token, substring to this token. </param>
        public static IEnumerable<string> SubstringAllShrink( this string source, string from, string to ) {
            int startIndex = 0;
            while ( true ) {
                // search index of [from] and [to], if no found, break loop.
                int fromIndex = source.IndexOf( from, startIndex );
                if ( fromIndex == -1 ) break ;

                int toIndex = source.IndexOf( to, fromIndex + from.Length );
                if ( toIndex == -1 ) break ;

                // if found the token, sub string it and yield return it.
                yield return source.Substring( fromIndex + from.Length, toIndex - fromIndex - from.Length );

                // set start index at last of [to] token.
                startIndex = toIndex + to.Length;
            } // while
        } // public static IEnumerable<string> SubstringAllShrink( this string source, string from, string to )
        
        #endregion

        #region IndexOfButNot

        /// <summary>
        /// find the index of char and this char should not be a part of string.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="find"> target char to find. </param>
        /// <param name="notValue"> the char should not include in this string. </param>
        /// <param name="startIndex"> find start with this index. </param>
        /// <returns> index of char in source string. </returns>
        public static int IndexOfButNot( this string source, char find, string notValue, int startIndex = 0 ){
            while ( true ){
                // find first index of char.
                int index = source.IndexOf( find, startIndex );
                if ( index == -1 ) return -1;

                // count notValue min start index.
                int notValueMinIndex = index - ( notValue.Length - 1 );
                if ( notValueMinIndex < startIndex ) return index;

                // try to find [notValue] in the range start with minIndex to index of char.
                // if has not found [notValue], return the index of char.
                int notIndex = source.IndexOf( notValue, notValueMinIndex, index - notValueMinIndex + 1 );
                if ( notIndex == -1 ) return index;

                // else, find next char index and check again.
                startIndex = index + 1;
                if ( startIndex > source.Length ) return -1;
            } // while
        } // public static string IndexOfButNot( this string source, char find, string notValue, int startIndex = 0 )
        

        /// <summary>
        /// find the index of string and this string should not be a part of string.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="find"> target string to find. </param>
        /// <param name="notValue"> the string should not include in this string. </param>
        /// <param name="startIndex"> find start with this index. </param>
        /// <returns> index of string in source string. </returns>
        public static int IndexOfButNot( this string source, string find, string notValue, int startIndex = 0 ){
            while ( true ){
                // find first index of string.
                int index = source.IndexOf( find, startIndex );
                if ( index == -1 ) return -1;

                // count notValue min start index.
                int notValueMinIndex = index - ( notValue.Length - 1 );
                if ( notValueMinIndex < startIndex ) return index;

                // try to find [notValue] in the range start with minIndex to index of string.
                // if has not found [notValue], return the index of char.
                int notIndex = source.IndexOf( notValue, notValueMinIndex, index - notValueMinIndex + 1 );
                if ( notIndex == -1 ) return index;

                // else, find next string index and check again.
                startIndex = index + 1;
                if ( startIndex > source.Length ) return -1;
            } // while
        } // public static string IndexOfButNot( this string source, string find, string notValue, int startIndex = 0 )

        #endregion

        #region StartWith

        /// <summary>
        /// Check is the string starts with any string in list.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="strs"> check is starts with in string list. </param>
        /// <returns> return true if is starts with any string in list, or return false. </returns>
        public static bool StartsWith( this string source, params string[] strs ){
            return strs.Any( item => source.StartsWith( item ) );
        } // public static bool StartWith( this string source, params string[] strs )

        #endregion

        #region Replace, NullIfEmpty

        /// <summary>
        /// Replace specify position and count string to other string.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="startIndex"> replace from startIndex. </param>
        /// <param name="replaceTo"> replace to this string. </param>
        /// <returns> after Replace string. </returns>
        public static string Replace( this string source, int startIndex, string replaceTo ){
            return source.Remove( startIndex, source.Length - startIndex ).Insert( startIndex, replaceTo );
        } // public static string Replace( this string source, int startIndex, string replaceTo )


        /// <summary>
        /// Replace specify position and count string to other string.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="startIndex"> replace from startIndex. </param>
        /// <param name="count"> replace char count. </param>
        /// <param name="replaceTo"> replace to this string. </param>
        /// <returns> after Replace string. </returns>
        public static string Replace( this string source, int startIndex, int count, string replaceTo ){
            return source.Remove( startIndex, count ).Insert( startIndex, replaceTo );
        } // public static string Replace( this string source, int startIndex, int count, string replaceTo )


        /// <summary>
        /// Get null value if the source is Empty string.
        /// </summary>
        /// <param name="source"> source </param>
        public static string NullIfEmpty( this string source ) {
            if ( source == string.Empty ) return null;
            else return source;
        } // public static string NullIfEmpty( this string source )
        

        /// <summary>
        /// Get null value if the source is Empty or whitespace string.
        /// </summary>
        /// <param name="source"> source </param>
        public static string NullIfWhiteSpace( this string source ) {
            if ( source.IsNullOrWhiteSpace() ) return null;
            else return source;
        } // public static string NullIfWhiteSpace( this string source )


        /// <summary> Get empty string if the source is null. </summary>
        /// <param name="source"> source </param>
        public static string EmptyIfNull( this string source ) {
            return source ?? string.Empty;
        } // public static string EmptyIfNull( this string source )

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat the source string [count] times.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="count"> repeat times. </param>
        /// <returns> Repeat the source string [count] times. </returns>
        public static string Repeat( this string source, int count ){
            if ( !string.IsNullOrEmpty( source ) || count <= 0 ){
                StringBuilder builder = new StringBuilder( source.Length * count );
                for( int i = 0; i < count; i++ ) builder.Append( source );
                return builder.ToString();
            } // if

            return string.Empty;
        } // public static string Repeat( this string source, int count )

        #endregion

        #region Split

        /// <summary>
        /// Split string use regex to group each token, return the group of regex except whole string.
        /// if no match return null,
        /// if no group in regexFormat return the match string.
        /// if has groups match return all of match group's value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="regexFormat"> format with regex. </param>
        /// <param name="options"> regex's options. </param>
        public static string[] SplitToken( this string source, string regexFormat, RegexOptions options = RegexOptions.None ) {
            var match = Regex.Match( source, regexFormat, options );
            if ( !match.Success ) return null;
            if ( match.Groups.Count == 1 ) return new string[] { match.Groups[0].Value };
            
            return match.Groups.Cast<Group>().Skip( 1 ).Select( item => item.Value ).ToArray();
        } // public static string[] SplitToken( this string source, string regexFormat, RegexOptions options = RegexOptions.None )

        /// <summary>
        /// Split string use regex to group each token, return the group of regex except whole string.
        /// if no match return null,
        /// if no group in regexFormat return the match string.
        /// if has groups match return all of match group's value.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="pattern"> format with regex. </param>
        /// <param name="Type"> determine how to reverse found word. </param>
        public static string[] SplitReversePattern( this string source, string pattern, SplitReversePatternType Type ) {
            var regexPattern = $"({Regex.Escape( pattern )})"; // set pattern with () to reverse pattern with Regex.Split.
            var entries = Regex.Split( source, regexPattern );

            if ( Type == SplitReversePatternType.ReversePatternWithEntry )
                return entries;
            else if ( Type == SplitReversePatternType.ReversePatternAttachFront ) { // attach pattern to Front entry.
                var result = new List<string>();
                for ( int i = 0 ; i < entries.Length ; i++ ) {
                    if ( i % 2 == 0 ) result.Add( entries[i] ); // for each not pattern entry, add it to list.
                    else result[result.Count-1] += entries[i]; // for each pattern entry, set it to last entry in list.( should be not pattern entry )
                } // for

                return result.ToArray();
            } // else if
            else if ( Type == SplitReversePatternType.ReversePatternAttachBack ) { // attach pattern to Back entry.
                var result = new List<string>();
                for ( int i = 0 ; i < entries.Length ; i++ ) {
                    if ( i % 2 == 1 ) result.Add( entries[i] ); // for each pattern entry, add it to list.
                    else if ( result.Count != 0 ) result[result.Count-1] += entries[i]; // for each not pattern entry, set it to last entry in list.( should be pattern entry )
                    else result.Add( entries[i] ); // but if there's no [pattern entry] in list, just add it to list.
                } // for

                return result.ToArray();
            } // else if

            throw new NotSupportedException( "The Type is out of enum range to support" );
        } // public static string[] SplitReversePattern( this string source, string pattern, SplitReversePatternType Type )

        #endregion

        #region Equals, Comparer

        /// <summary> Check the string is same with other string without case sensitive. </summary>
        /// <param name="source"> source </param>
        /// <param name="other"> other string to comparer. </param>
        public static bool EqualsIgnoreCase( this string source, string other ) {
            return string.Compare( source, other, true ) == 0;
        } // public static bool EqualsIgnoreCase( this string source, string other )
        
        /// <summary> Comparer the string to other string without case sensitive. </summary>
        /// <param name="source"> source </param>
        /// <param name="other"> other string to comparer. </param>
        public static int ComparerToIgnoreCase( this string source, string other ) {
            return string.Compare( source, other, true );
        } // public static int ComparerToIgnoreCase( this string source, string other )

        #endregion

        #region Regex: IsMatch

        /// <summary> Indicates whether the specified regular expression finds a match in the specified input string. </summary>
        /// <param name="source">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>
        ///   <c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMatch( this string source, string pattern ){
            return Regex.IsMatch( source, pattern );
        } // public static bool IsMatch( this string source, string pattern )

        /// <summary> Indicates whether the specified regular expression finds a match in the specified input string, using the specified matching options. </summary>
        /// <param name="source">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <returns>
        ///   <c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMatch( this string source, string pattern, RegexOptions options ){
            return Regex.IsMatch( source, pattern, options );
        } // public static bool IsMatch( this string source, string pattern, RegexOptions options )

        #endregion

        #region Prefix, Suffix, Fix

        /// <summary> Add prefix if the source is not null or empty, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="prefix">Prefix string to add.</param>
        /// <returns> return source with prefix if source is not null or empty, otherwise return source. </returns>
        public static string PrefixIfNotNullOrEmpty( this string source, string prefix ){
            if ( source.IsNullOrEmpty() )
                return source;
            else return prefix + source;
        } // public static string PrefixIfNotNullOrEmpty( this string source, string prefix )
        
        /// <summary> Add prefix if the source is not null or white space, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="prefix">Prefix string to add.</param>
        /// <returns> return source with prefix if source is not null or white space, otherwise return source. </returns>
        public static string PrefixIfNotNullOrWhiteSpace( this string source, string prefix ){
            if ( source.IsNullOrWhiteSpace() )
                return source;
            else return prefix + source;
        } // public static string PrefixIfNotNullOrWhiteSpace( this string source, string prefix )
        
        /// <summary> Add suffix if the source is not null or empty, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="suffix">Suffix string to add.</param>
        /// <returns> return source with suffix if source is not null or empty, otherwise return source. </returns>
        public static string SuffixIfNotNullOrEmpty( this string source, string suffix ){
            if ( source.IsNullOrEmpty() )
                return source;
            else return source + suffix;
        } // public static string SuffixIfNotNullOrEmpty( this string source, string suffix )
        
        /// <summary> Add suffix if the source is not null or white space, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="suffix">Suffix string to add.</param>
        /// <returns> return source with suffix if source is not null or white space, otherwise return source. </returns>
        public static string SuffixIfNotNullOrWhiteSpace( this string source, string suffix ){
            if ( source.IsNullOrWhiteSpace() )
                return source;
            else return source + suffix;
        } // public static string SuffixIfNotNullOrWhiteSpace( this string source, string suffix )
        
        /// <summary> Add prefix and suffix if the source is not null or empty, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="prefix">Prefix string to add.</param>
        /// <param name="suffix">Suffix string to add.</param>
        /// <returns> return source with prefix and suffix if source is not null or empty, otherwise return source. </returns>
        public static string FixIfNotNullOrEmpty( this string source, string prefix, string suffix ){
            if ( source.IsNullOrEmpty() )
                return source;
            else return prefix + source + suffix;
        } // public static string FixIfNotNullOrEmpty( this string source, string prefix, string suffix )
        
        /// <summary> Add prefix and suffix if the source is not null or white space, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="prefix">Prefix string to add.</param>
        /// <param name="suffix">Suffix string to add.</param>
        /// <returns> return source with prefix and suffix if source is not null or white space, otherwise return source. </returns>
        public static string FixIfNotNullOrWhiteSpace( this string source, string prefix, string suffix ){
            if ( source.IsNullOrWhiteSpace() )
                return source;
            else return prefix + source + suffix;
        } // public static string FixIfNotNullOrWhiteSpace( this string source, string prefix, string suffix )

        /// <summary> Use default value replace source is null or empty, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="defaultValue">The default value to use when source is null or empty.</param>
        /// <returns> return default value if source is null or empty, otherwise just return source </returns>
        public static string DefaultIfNullOrEmpty( this string source, string defaultValue ){
            if ( !source.IsNullOrEmpty() )
                return source;
            else return defaultValue;
        } // public static string DefaultIfNullOrEmpty( this string source, string defaultValue )
        
        /// <summary> Use default value replace source is null or white space, otherwise just return source. </summary>
        /// <param name="source">source.</param>
        /// <param name="defaultValue">The default value to use when source is null or white space.</param>
        /// <returns> return default value if source is null or white space, otherwise just return source </returns>
        public static string DefaultIfNullOrWhiteSpace( this string source, string defaultValue ){
            if ( !source.IsNullOrWhiteSpace() )
                return source;
            else return defaultValue;
        } // public static string DefaultIfNullOrWhiteSpace( this string source, string defaultValue )

        #endregion

    } // public static class StringExtension


    /// <summary> how to reverse pattern when split string. </summary>
    public enum SplitReversePatternType {
        /// <summary> reverser only pattern. </summary>
        ReversePatternWithEntry,
        /// <summary> reverser pattern and the string before pattern from pre-pattern to cur-pattern. </summary>
        ReversePatternAttachFront,
        /// <summary> reverser pattern and the string after pattern from cur-pattern to next-pattern. </summary>
        ReversePatternAttachBack,
    } // public enum SplitReversePatternType


} // namespace PGCafe
