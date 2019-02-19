# KafkaConsoleApp
Console App to publish and subscribe messages

Install Zookeeper and Kafka

Commands to run kafka for windows from kafka directory after installing kafka

.\bin\windows\zookeeper-server-start.bat ./config/zookeeper.properties

.\bin\windows\kafka-server-start.bat ./config/server.properties

.\bin\windows\kafka-server-start.bat ./config/server-1.properties &
.\bin\windows\kafka-server-start.bat ./config/server-2.properties &

.\bin\windows\kafka-topics.bat --create --zookeeper localhost:2181 --replication-factor 1 --partitions 1 --topic test-topic

.\bin\windows\kafka-topics.bat --create --zookeeper localhost:2181 --replication-factor 3 --partitions 1 --topic test-topic-replicated-topic

.\bin\windows\kafka-topics.bat --list --zookeeper localhost:2181

.\bin\windows\kafka-topics.bat --describe --zookeeper localhost:2181 --topic test-topic-replicated-topic

.\bin\windows\kafka-console-producer.bat --broker-list localhost:9092 --topic test-topic

.\bin\windows\kafka-console-producer.bat --broker-list localhost:9092 --topic test-topic-replicated-topic

.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic test-topic --from-beginning

.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic test-topic-replicated-topic --from-beginning
