using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    /// <summary>
    /// Random's Extension.
    /// </summary>
    public static class RandomExtension {

        /// <summary> return random double value with max value( not include ). </summary>
        /// <param name="source">The source.</param>
        /// <param name="maxValue">The maximum value.</param>
        public static double NextDouble( this Random source, double maxValue ) => source.NextDouble() * maxValue;

        /// <summary> return random double value with min value( include ) and max value( not include ). </summary>
        /// <param name="source">The source.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public static double NextDouble( this Random source, double minValue, double maxValue ) => source.NextDouble() * ( maxValue - minValue ) + minValue;

    } // public static class RandomExtension
} // namespace PGCafe
