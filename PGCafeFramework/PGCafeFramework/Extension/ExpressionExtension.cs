using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PGCafe {
    /// <summary> Extension of Expression </summary>
    public static class ExpressionExtension {

        /// <summary> Get the property info from <see cref="Expression"/> lambda. </summary>
        /// <typeparam name="TSource"> Type of source Class </typeparam>
        /// <typeparam name="TProperty"> Type of property </typeparam>
        /// <param name="propertyLambda"> lambda of property </param>
        public static PropertyInfo GetPropertyInfo<TSource, TProperty>( Expression<Func<TSource, TProperty>> propertyLambda ) {
            Type type = typeof( TSource );

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if ( member == null )
                throw new ArgumentException( $"Expression '{propertyLambda.ToString()}' refers to a method, not a property." );

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if ( propInfo == null )
                throw new ArgumentException( $"Expression '{propertyLambda.ToString()}' refers to a field, not a property." );

            if ( type != propInfo.ReflectedType && !type.IsSubclassOf( propInfo.ReflectedType ) )
                throw new ArgumentException( $"Expresion '{propertyLambda.ToString()}' refers to a property that is not from type {type}." );

            return propInfo;
        } // public static PropertyInfo GetPropertyInfo<TSource, TProperty>( Expression<Func<TSource, TProperty>> propertyLambda )
    } // public static class ExpressionExtension
} // namespace PGCafe
