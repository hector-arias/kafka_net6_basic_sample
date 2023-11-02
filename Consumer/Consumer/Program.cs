using Confluent.Kafka;

string topicName = "producer_test1";

var config = new ConsumerConfig { GroupId = "messageConsumer", BootstrapServers = "192.168.102.55:29193", EnableAutoCommit = false };

using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
{
    consumer.Subscribe(topicName);

    while (true)
    {
        var consumeResult = consumer.Consume();
        Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Value}");
        consumer.Commit();
    }
}