using JsonTestModel.Model;
using Newtonsoft.Json;
namespace JsonTestModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.反序列
            //能解析多个key 能解析到指定属性上去
         
            //相当于 json多属性解析

            string json1 = "{\"SkuId\":\"1111\",\"AId\":\"2222\",\"BId\":\"33333\"}"; // 以最后一个为主!
            string json2 = "{\"AId\":\"44444\"}";
            string json3 = "{\"BId\":\"55555\"}";
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CompositeContractResolver()
            };
            var m1 = JsonConvert.DeserializeObject<OrderItem>(json1);//能正确解析到
            var m2 = JsonConvert.DeserializeObject<OrderItem>(json2);//能正确解析到
            var m3 = JsonConvert.DeserializeObject<OrderItem>(json3);//能正确解析到


            //2.序列化


            Console.ReadKey();
        }
    }
}