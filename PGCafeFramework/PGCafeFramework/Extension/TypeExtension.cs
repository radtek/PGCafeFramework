using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    /// <summary>
    /// Type's Extension.
    /// </summary>
    public static class TypeExtension {

        /// <summary> return default value of specify type. </summary>
        /// <param name="source">The source.</param>
        public static object DefaultValue( this Type source )
            => source.IsValueType ? Activator.CreateInstance( source ) : null;

    } // public static class TypeExtension
} // namespace PGCafe
