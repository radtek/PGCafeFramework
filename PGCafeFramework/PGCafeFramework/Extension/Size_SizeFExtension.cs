using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGCafe.Object;

namespace PGCafe {
    /// <summary>
    /// Size and SizeF's Extension.
    /// </summary>
    public static class SizeExtension {
        
        #region Convert To

        /// <summary> Convert to <see cref="Size"/> with Round <see cref="SizeF.Width"/>, <see cref="SizeF.Height"/> property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Size"/> with Round <see cref="SizeF.Width"/>, <see cref="SizeF.Height"/> property.</returns>
        public static Size Round( this SizeF source ) {
            return new Size() {
                Width = (int)Math.Round( source.Width ),
                Height = (int)Math.Round( source.Height ),
            };
        } // public static Size Round( this SizeF source )

        /// <summary> Convert to <see cref="Size"/> with Floor <see cref="SizeF.Width"/>, <see cref="SizeF.Height"/> property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Size"/> with Floor <see cref="SizeF.Width"/>, <see cref="SizeF.Height"/> property.</returns>
        public static Size Floor( this SizeF source ) {
            return new Size() {
                Width = (int)Math.Floor( source.Width ),
                Height = (int)Math.Floor( source.Height ),
            };
        } // public static Size Round( this SizeF source )

        /// <summary> Convert to <see cref="Size"/> with Ceiling <see cref="SizeF.Width"/>, <see cref="SizeF.Height"/> property. </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="Size"/> with Ceiling <see cref="SizeF.Width"/>, <see cref="SizeF.Height"/> property.</returns>
        public static Size Ceiling( this SizeF source ) {
            return new Size() {
                Width = (int)Math.Ceiling( source.Width ),
                Height = (int)Math.Ceiling( source.Height ),
            };
        } // public static Size Ceiling( this SizeF source )

        #endregion

    } // public static class SizeExtension

} // namespace PGCafe
