using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonTestModel.Attributes;
using Newtonsoft.Json;

namespace JsonTestModel.Model
{
    public class OrderItem
    {
        [SerializeIgnore,FallbackJsonProperty(nameof(SkuId),"AId","BId")]
        public string SkuId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
