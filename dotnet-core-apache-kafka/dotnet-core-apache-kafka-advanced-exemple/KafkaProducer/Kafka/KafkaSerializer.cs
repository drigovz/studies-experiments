﻿using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Kafka
{
    public class KafkaSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
                return null;

            if (typeof(T) == typeof(Ignore))
                throw new NotSupportedException("Not Supported data format.");

            var json = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
