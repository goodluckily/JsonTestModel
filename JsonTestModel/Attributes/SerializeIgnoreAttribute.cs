using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTestModel.Attributes
{

    /// <summary>
    /// 序列化时忽略
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SerializeIgnoreAttribute: Attribute
    {
        public SerializeIgnoreAttribute() 
        {
            
        }
    }
}
