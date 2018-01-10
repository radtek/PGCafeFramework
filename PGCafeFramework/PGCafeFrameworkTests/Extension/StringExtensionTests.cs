using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe.Tests {
    [TestClass()]
    public class StringExtensionTests {

        #region SubstringEX

        #region Base
        
        [TestMethod()]
        public void SubstringEX_null_source() {
            string result = ((string)null).SubstringEX(
                toLength: 5 );

            Assert.AreEqual( null, result );
        }
        
        [TestMethod()]
        public void SubstringEX_empty_source() {
            string result = "".SubstringEX(
                toLength: 5 );

            Assert.AreEqual( "", result );
        }
        
        [TestMethod()]
        [ExpectedException(typeof( ArgumentException ))]
        public void SubstringEX_two_from_argument_exception() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "Sub",
                fromIndex: 5 );
        }
        
        [TestMethod()]
        [ExpectedException(typeof( ArgumentException ))]
        public void SubstringEX_two_to_argument_exception() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toString: "Sub",
                toIndex: 5 );
        }
        
        [TestMethod()]
        [ExpectedException(typeof( ArgumentException ))]
        public void SubstringEX_three_to_argument_exception() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toString: "Sub",
                toIndex: 5,
                toLength: 5 );
        }

        #endregion

        #region FromString_ToString

        [TestMethod()]
        public void SubstringEX_FromString_ToString_general() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "Sub",
                toString: "EX" );

            Assert.AreEqual( "SubstringEX", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToString_repeat_string() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toString: "Sub" );

            Assert.AreEqual( "SubSubSub", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToString_not_found_from() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "aa",
                toString: "SubSub" );

            Assert.AreEqual( null, result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToString_not_found_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toString: "SubSub" );

            Assert.AreEqual( null, result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToString_not_found_from_and_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "aa",
                toString: "bb" );

            Assert.AreEqual( null, result );
        } // public void SubstringEX_FromString_ToString_GeneralTest()

        #endregion

        #region FromString_ToIndex

        [TestMethod()]
        public void SubstringEX_FromString_ToIndex_negative_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToIndex_index_before_from() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toIndex: 5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToIndex_index_after_from() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "Sub",
                toIndex: 11 );

            Assert.AreEqual( "SubstringEX", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToIndex_index_equal_from() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toIndex: 18 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToIndex_index_after_end_string() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toIndex: 100 );

            Assert.AreEqual( "SubSubSubstringEX test", result );
        }

        #endregion

        #region FromString_ToLength

        [TestMethod()]
        public void SubstringEX_FromString_ToLength_negative_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToLength_zero_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToLength_positive_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "Sub",
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_ToLength_length_more_than_source_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "SubSub",
                toLength: 100 );

            Assert.AreEqual( "SubSubSubstringEX test", result );
        }

        #endregion

        #region FromIndex_ToString

        [TestMethod()]
        public void SubstringEX_FromIndex_ToString_negative_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toString: "EX" );

            Assert.AreEqual( "SubstringEX", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToString_zero_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toString: "Sub" );

            Assert.AreEqual( "Sub", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToString_positive_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 2,
                toString: "Sub" );

            Assert.AreEqual( "bstringEX test, Sub", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToString_index_after_source_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toString: "SubSub" );

            Assert.AreEqual( null, result );
        }

        #endregion

        #region FromIndex_ToIndex

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_negative_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_negative_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_negative_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toIndex: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_negative_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toIndex: 100 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_zero_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_zero_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_zero_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toIndex: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_zero_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toIndex: 100 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_positive_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_positive_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_positive_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toIndex: 5 );

            Assert.AreEqual( "st", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_positive_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toIndex: 100 );

            Assert.AreEqual( "stringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_more_than_length_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_more_than_length_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_more_than_length_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toIndex: 5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToIndex_more_than_length_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toIndex: 100 );

            Assert.AreEqual( "", result );
        }

        #endregion

        #region FromIndex_ToLength

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_negative_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_negative_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_negative_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_negative_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5,
                toLength: 100 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_zero_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_zero_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_zero_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_zero_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0,
                toLength: 100 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_positive_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_positive_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_positive_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toLength: 5 );

            Assert.AreEqual( "strin", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_positive_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 3,
                toLength: 100 );

            Assert.AreEqual( "stringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_more_than_length_from_and_nagetive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_more_than_length_from_and_zero_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_more_than_length_from_and_positive_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toLength: 5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_ToLength_more_than_length_from_and_more_than_length_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100,
                toLength: 100 );

            Assert.AreEqual( "", result );
        }

        #endregion

        #region WithoutFrom_ToString

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToString_general() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toString: "EX" );

            Assert.AreEqual( "SubstringEX", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToString_not_found_to() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toString: "aa" );

            Assert.AreEqual( null, result );
        }

        #endregion

        #region WithoutFrom_ToIndex

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToIndex_negative_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToIndex_zero_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToIndex_positive_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toIndex: 11 );

            Assert.AreEqual( "SubstringEX", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToIndex_index_after_end_string() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toIndex: 100 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        #endregion

        #region WithoutFrom_ToLength

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToLength_negative_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToLength_zero_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToLength_positive_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringEX_WithoutFrom_ToLength_length_more_than_source_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                toLength: 100 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        #endregion
        
        #region FromString_WithoutTo

        [TestMethod()]
        public void SubstringEX_FromString_WithoutTo_general() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "stringEX" );

            Assert.AreEqual( "stringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromString_WithoutTo_not_found_from() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromString: "aa" );

            Assert.AreEqual( null, result );
        }

        #endregion

        #region FromIndex_WithoutTo

        [TestMethod()]
        public void SubstringEX_FromIndex_WithoutTo_negative_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: -5 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_WithoutTo_zero_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 0 );

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_WithoutTo_positive_index() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 2 );

            Assert.AreEqual( "bstringEX test, SubSubSubstringEX test", result );
        }

        [TestMethod()]
        public void SubstringEX_FromIndex_WithoutTo_index_after_source_length() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX(
                fromIndex: 100 );

            Assert.AreEqual( "", result );
        }

        #endregion
        
        #region FromString_WithoutTo

        [TestMethod()]
        public void SubstringEX_WithFrom_WithoutTo_general() {
            string result = "SubstringEX test, SubSubSubstringEX test".SubstringEX();

            Assert.AreEqual( "SubstringEX test, SubSubSubstringEX test", result );
        }

        #endregion

        #endregion

        #region SubstringShrinkEX
        
        #region Base
        
        [TestMethod()]
        public void SubstringShrinkEX_null_source() {
            string result = ((string)null).SubstringShrinkEX(
                toLength: 5 );

            Assert.AreEqual( null, result );
        }
        
        [TestMethod()]
        public void SubstringShrinkEX_empty_source() {
            string result = "".SubstringShrinkEX(
                toLength: 5 );

            Assert.AreEqual( "", result );
        }
        
        [TestMethod()]
        [ExpectedException(typeof( ArgumentException ))]
        public void SubstringShrinkEX_FromString_ToString_two_from_argument_exception() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "Sub",
                fromIndex: 5 );
        }
        
        [TestMethod()]
        [ExpectedException(typeof( ArgumentException ))]
        public void SubstringShrinkEX_FromString_ToString_two_to_argument_exception() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toString: "Sub",
                toIndex: 5 );
        }
        
        [TestMethod()]
        [ExpectedException(typeof( ArgumentException ))]
        public void SubstringShrinkEX_FromString_ToString_three_to_argument_exception() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toString: "Sub",
                toIndex: 5,
                toLength: 5 );
        }

        #endregion

        #region FromString_ToString

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToString_general() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "Sub",
                toString: "EX" );

            Assert.AreEqual( "stringShrink", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToString_repeat_string() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toString: "Sub" );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToString_not_found_from() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "aa",
                toString: "SubSub" );

            Assert.AreEqual( null, result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToString_not_found_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toString: "SubSub" );

            Assert.AreEqual( null, result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToString_not_found_from_and_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "aa",
                toString: "bb" );

            Assert.AreEqual( null, result );
        } // public void SubstringShrinkEX_FromString_ToString_GeneralTest()

        #endregion

        #region FromString_ToIndex

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToIndex_negative_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToIndex_index_before_from() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toIndex: 5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToIndex_index_after_from() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "Sub",
                toIndex: 11 );

            Assert.AreEqual( "stringSh", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToIndex_index_equal_from() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toIndex: 18 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToIndex_index_after_end_string() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toIndex: 100 );

            Assert.AreEqual( "SubstringShrinkEX test", result );
        }

        #endregion

        #region FromString_ToLength

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToLength_negative_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToLength_zero_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToLength_positive_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "Sub",
                toLength: 5 );

            Assert.AreEqual( "strin", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_ToLength_length_more_than_source_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "SubSub",
                toLength: 100 );

            Assert.AreEqual( "SubstringShrinkEX test", result );
        }

        #endregion

        #region FromIndex_ToString

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToString_negative_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toString: "EX" );

            Assert.AreEqual( "SubstringShrink", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToString_zero_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toString: "Sub" );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToString_positive_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 2,
                toString: "Sub" );

            Assert.AreEqual( "bstringShrinkEX test, ", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToString_index_after_source_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toString: "SubSub" );

            Assert.AreEqual( null, result );
        }

        #endregion

        #region FromIndex_ToIndex

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_negative_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_negative_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_negative_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toIndex: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_negative_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toIndex: 100 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_zero_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_zero_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_zero_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toIndex: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_zero_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toIndex: 100 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_positive_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_positive_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_positive_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toIndex: 5 );

            Assert.AreEqual( "st", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_positive_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toIndex: 100 );

            Assert.AreEqual( "stringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_more_than_length_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_more_than_length_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_more_than_length_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toIndex: 5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToIndex_more_than_length_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toIndex: 100 );

            Assert.AreEqual( "", result );
        }

        #endregion

        #region FromIndex_ToLength

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_negative_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_negative_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_negative_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_negative_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5,
                toLength: 100 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_zero_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_zero_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_zero_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_zero_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0,
                toLength: 100 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_positive_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_positive_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_positive_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toLength: 5 );

            Assert.AreEqual( "strin", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_positive_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 3,
                toLength: 100 );

            Assert.AreEqual( "stringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_more_than_length_from_and_nagetive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_more_than_length_from_and_zero_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_more_than_length_from_and_positive_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toLength: 5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_ToLength_more_than_length_from_and_more_than_length_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100,
                toLength: 100 );

            Assert.AreEqual( "", result );
        }

        #endregion

        #region WithoutFrom_ToString

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToString_general() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toString: "EX" );

            Assert.AreEqual( "SubstringShrink", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToString_not_found_to() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toString: "aa" );

            Assert.AreEqual( null, result );
        }

        #endregion

        #region WithoutFrom_ToIndex

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToIndex_negative_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toIndex: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToIndex_zero_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toIndex: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToIndex_positive_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toIndex: 11 );

            Assert.AreEqual( "SubstringSh", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToIndex_index_after_end_string() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toIndex: 100 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        #endregion

        #region WithoutFrom_ToLength

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToLength_negative_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toLength: -5 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToLength_zero_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toLength: 0 );

            Assert.AreEqual( "", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToLength_positive_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toLength: 5 );

            Assert.AreEqual( "Subst", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_WithoutFrom_ToLength_length_more_than_source_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                toLength: 100 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        #endregion
        
        #region FromString_WithoutTo

        [TestMethod()]
        public void SubstringShrinkEX_FromString_WithoutTo_general() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "stringShrinkEX" );

            Assert.AreEqual( " test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromString_WithoutTo_not_found_from() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromString: "aa" );

            Assert.AreEqual( null, result );
        }

        #endregion

        #region FromIndex_WithoutTo

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_WithoutTo_negative_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: -5 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_WithoutTo_zero_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 0 );

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_WithoutTo_positive_index() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 2 );

            Assert.AreEqual( "bstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        [TestMethod()]
        public void SubstringShrinkEX_FromIndex_WithoutTo_index_after_source_length() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX(
                fromIndex: 100 );

            Assert.AreEqual( "", result );
        }

        #endregion
        
        #region FromString_WithoutTo

        [TestMethod()]
        public void SubstringShrinkEX_WithFrom_WithoutTo_general() {
            string result = "SubstringShrinkEX test, SubSubSubstringShrinkEX test".SubstringShrinkEX();

            Assert.AreEqual( "SubstringShrinkEX test, SubSubSubstringShrinkEX test", result );
        }

        #endregion

        #endregion

    } // public class StringExtensionTests
} // namespace PGCafe.Tests