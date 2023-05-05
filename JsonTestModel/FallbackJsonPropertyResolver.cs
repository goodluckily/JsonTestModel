using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JsonTestModel.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonTestModel
{
    public class FallbackJsonPropertyResolver: CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// 多别名属性的解释器
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var typeMembers = GetSerializableMembers(type);
            var properties = new List<JsonProperty>();

            foreach (var member in typeMembers)
            {
                var property = CreateProperty(member, memberSerialization);
                properties.Add(property);
                var fallbackAttribute = member.GetCustomAttribute<FallbackJsonProperty>();
                if (fallbackAttribute == null)
                {
                    continue;
                }

                property.PropertyName = fallbackAttribute.PreferredName;
                foreach (var alternateName in fallbackAttribute.FallbackReadNames)
                {
                    var fallbackProperty = CreateProperty(member, memberSerialization);
                    fallbackProperty.PropertyName = alternateName;
                    properties.Add(fallbackProperty);
                }
            }

            return properties;
        }
    }
}
