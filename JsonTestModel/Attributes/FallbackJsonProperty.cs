using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTestModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FallbackJsonProperty : Attribute
    {
        /// <summary>
        /// 首选名称
        /// </summary>
        public string PreferredName { get; }
        /// <summary>
        /// 其他名称
        /// </summary>
        public string[] FallbackReadNames { get; }
        public FallbackJsonProperty(string preferredName, params string[] fallbackReadNames)
        {
            PreferredName = preferredName;
            FallbackReadNames = fallbackReadNames;
        }
    }
}
