using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace Kafka.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Kafka endpoint address
            string kafkaEndpoint = "localhost:9092";

            // The Kafka topic we'll be using
            string kafkaTopic = "test-topic";

            // Create the consumer configuration
            var consumerConfig = new Dictionary<string, object>
            {
                {"group.id", "my-consumer"},
                {"bootstrap.servers", kafkaEndpoint},
                {"enable.auto.commit", "false"}
            };

            // Create the consumer
            using (var consumer =
                new Consumer<Null, string>(consumerConfig, null, new StringDeserializer(Encoding.UTF8)))
            {
                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string>() { kafkaTopic });

                // Subscribe to the OnMessage event
                consumer.OnMessage += (obj, msg) =>
                {
                    Console.WriteLine(
                        $"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} Received: {msg.Value}");
                };

                // Handle Cancel Keypress 
                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit.");

                // Poll for messages
                while (!cancelled)
                {
                    consumer.Poll(100);
                }
            }
        }
    }
}
