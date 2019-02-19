using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace Kafka.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your message. Enter q for quitting");
            var message = default(string);

            // The Kafka endpoint address
            string kafkaEndpoint = "localhost:9092";

            // The Kafka topic we'll be using
            string kafkaTopic = "test-topic";

            while ((message = Console.ReadLine()) != "q")
            {
                // Create the producer configuration
                var producerConfig = new Dictionary<string, object>
                {
                    {"bootstrap.servers", kafkaEndpoint}
                };

                using (var producer = new Producer<Null, string>(producerConfig, null, new StringSerializer(Encoding.UTF8)))
                {
                    producer.ProduceAsync(kafkaTopic, null, message).GetAwaiter().GetResult();
                    producer.Flush(100);
                }
            }
        }
    }
}