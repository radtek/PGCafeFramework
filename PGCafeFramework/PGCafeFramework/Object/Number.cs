#pragma warning disable CS1587, CS1591
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGCafe.Object {
    public struct Number {
        private const int cEachTokenBits = 7;
        private const double cCarryNumber = 10e6; // should be pow 10 with [cEachTokenBits]
        private double[] mTokens;
        private int TokenCount { get { return mTokens.Length; } }

        public Number( char[] number ) {
            /// split number string to token by token-length = cEachTokenBits
            
            // get token count.
            int tokenCount = Math.Ceiling( number.Length / cEachTokenBits.ToType<double>() ).ToType<int>();

            // create token by string to double.
            mTokens = new double[tokenCount];
            for ( int i = 0 ; i < mTokens.Length ; i++ ) {

                // get start index.
                var startIndex = number.Length - ( i + 1 ) * cEachTokenBits;
                var length = cEachTokenBits;
                
                if ( startIndex < 0 ) {
                    startIndex = 0;
                    length = number.Length - i * cEachTokenBits;
                } // if

                mTokens[i] = new string( number, startIndex, length ).ToType<double>();
            } // for
        } // public Number( char[] number )

        public Number( string number ) : this( number.ToCharArray() ) {
        } // public Number( string number )

        private Number( double[] tokens ) {
            mTokens = tokens;
        } // public Number( IEnumerable<double> tokens )


        public static Number operator +( Number left, Number right ) {
            if ( left.TokenCount > right.TokenCount ) return Plus( ref left, ref right );
            else return Plus( ref right, ref left );
        } // public class Number operator +( Number left, Number right )

        private static Number Plus( ref Number longNumber, ref Number shortNumber ) {            
            var newNumberTokens = new double[longNumber.TokenCount+1];
            int carry = 0;
            int i = 0;
            for ( i = 0 ; i < shortNumber.TokenCount ; i++ ) {
                double newToken = shortNumber.mTokens[i] + longNumber.mTokens[i] + carry;
                carry = (int)( newToken / cCarryNumber );
                newNumberTokens[i] = ( newToken - cCarryNumber * carry );
            } // for

            while ( i < longNumber.TokenCount && carry != 0 ) {
                double newToken = longNumber.mTokens[i] + carry;
                carry = (int)( newToken / cCarryNumber );
                newNumberTokens[i] = ( newToken - cCarryNumber * carry );
                i++;
            } // while

            while ( i < longNumber.TokenCount ) {
                newNumberTokens[i] = ( longNumber.mTokens[i] );
                i++;
            } // while

            if ( newNumberTokens[newNumberTokens.Length-1] == 0 ) return new Number( newNumberTokens.SkipLast( 1 ).ToArray() );
            else return new Number( newNumberTokens );
        } // private static Number Plus( ref Number longNumber, ref Number shortNumber )


        public override string ToString() {
            return string.Join( "", mTokens.Reverse().Select( item => item.ToString() ) );
        }


    } // public struct Number
} // namespace PGCafe.Object
