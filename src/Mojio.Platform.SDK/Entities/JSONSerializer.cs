#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using Mojio.Platform.SDK.Contracts;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Mojio.Platform.SDK.Entities
{
    public class JSONSerializer : ISerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings();

        static JSONSerializer()
        {
            //Settings.Converters.Add(new IPEndPointConverter());
        }

        public JSONSerializer(IDIContainer resolver)
        {
            if (Settings.ContractResolver?.GetType() != typeof(ContractResolver))
            {
                Settings.ContractResolver = new ContractResolver(resolver);
                Settings.Formatting = Formatting.Indented;
                Settings.NullValueHandling = NullValueHandling.Ignore;
            }
        }

        public string ContentType => "application/json";

        public byte[] Serialize(object entity)
        {
            return Encoding.UTF8.GetBytes(SerializeToString(entity));
        }

        public string SerializeToString(object entity)
        {
            return JsonConvert.SerializeObject(entity, Settings);
        }

        public T Deserialize<T>(Stream stream)
        {
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return Deserialize<T>(buffer);
        }

        public T Deserialize<T>(byte[] input)
        {
            return Deserialize<T>(Encoding.UTF8.GetString(input, 0, input.Length));
        }

        public object Deserialize(byte[] input)
        {
            return Deserialize(Encoding.UTF8.GetString(input, 0, input.Length));
        }

        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input, Settings);
        }

        public object Deserialize(string input, Type serviceType)
        {
            return JsonConvert.DeserializeObject(input, serviceType);
        }

        public object Deserialize(string input)
        {
            return JsonConvert.DeserializeObject(input, Settings);
        }
    }
}