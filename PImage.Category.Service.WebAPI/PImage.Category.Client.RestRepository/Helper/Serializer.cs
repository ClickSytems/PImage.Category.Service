using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PImage.Category.Client.RestRepository.Helper
{
    public class Serializer
    {
        public static string Serialize<T>(object o)
        {
            String json;
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, (T)o);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }
            return json;
        }

        public static T DeSerialize<T>(System.IO.Stream stream)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
