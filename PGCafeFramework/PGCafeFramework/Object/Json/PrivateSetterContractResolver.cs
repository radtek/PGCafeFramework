using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PGCafe.Object {

    public class PrivateSetterContractResolver : DefaultContractResolver {

        protected override JsonProperty CreateProperty( MemberInfo member, MemberSerialization memberSerialization ) {
            var jProperty = base.CreateProperty( member, memberSerialization );
            if ( jProperty.Writable )
                return jProperty;

            jProperty.Writable = member.As<PropertyInfo>()?.GetSetMethod( true ) != null;

            return jProperty;
        } // protected override JsonProperty CreateProperty( MemberInfo member, MemberSerialization memberSerialization )

    } // public class PrivateSetterContractResolver : DefaultContractResolver

} // namespace PGCafe.Object
