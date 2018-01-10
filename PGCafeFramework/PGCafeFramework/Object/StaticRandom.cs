using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PGCafe.Object {
    /// <summary> Provide static and thread safe random object. </summary>
    public static class StaticRandom {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>( () => new Random( Interlocked.Increment( ref seed ) ) );

        /// <summary> Random object </summary>
        public static Random Random => random.Value;

        /// <summary> return positive random value. </summary>
        public static int Next() => StaticRandom.Random.Next();
        
        /// <summary> return positive random value which smaller than <paramref name="maxValue"/>. </summary>
        public static int Next( int maxValue ) => StaticRandom.Random.Next( maxValue );
        
        /// <summary> return positive random value which >= <paramref name="minValue"/> and &lt; <paramref name="maxValue"/>. </summary>
        public static int Next( int minValue, int maxValue ) => StaticRandom.Random.Next( minValue, maxValue );

        /// <summary> fill the buffer with random value </summary>
        /// <param name="buffer">The buffer need fill random value.</param>
        public static void NextBytes( byte[] buffer ) => StaticRandom.Random.NextBytes( buffer );

        /// <summary> return double between 0.0 and 1.0 ( not include 1.0 ) </summary>
        public static double NextDouble() => StaticRandom.Random.NextDouble();
        
        /// <summary> return double between 0.0 and <paramref name="maxValue"/> ( not include <paramref name="maxValue"/> ) </summary>
        public static double NextDouble( double maxValue ) => StaticRandom.Random.NextDouble( maxValue );
        
        /// <summary> return double between <paramref name="minValue"/> and <paramref name="maxValue"/> ( not include <paramref name="maxValue"/> ) </summary>
        public static double NextDouble( double minValue, double maxValue ) => StaticRandom.Random.NextDouble( minValue, maxValue );

    } // public static class StaticRandom
} // namespace PGCafe.Object
