using Confluent.Kafka;

string topicName = "producer_test1";

var config = new ProducerConfig() { BootstrapServers = "192.168.102.55:29193" };

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    while (true)
    {
        //Console.Write("Enter message: ");
        var text = "\"StatusTYRq\":{\"xsd1:RqUID\":\"bae8583e-f870-4286-943d-b5b7b3709793\",\"xsd1:NetworkTrnInfo\":{\"xsd1:NetworkOwner\":\"AppPersonas\"},\"xsd1:LongText\":\"wT4DCKKJ5MZzsN7rb9yVfS7WgaCzPd4Y6N\",\"xsd1:CSPhoneNum\":\"$573008860896\",\"xsd1:CustType\":\"$tin\",\"xsd1:Amt\":\"100598.00\",\"Q1:SnapshotStatusRq\":{\"xsd1:TrnSrc\":\"$573008860896\",\"xsd1:ViewDtlPref\":\"PERSON\",\"Q1:SignerStatusRq\":{\"xsd1:TrnSrc\":\"wT4DCKKJ5MZzsN7rb9yVfS7WgaCzPd4Y6N\",\"Q1:LabelsSignerStatusRq\":{\"xsd1:Name\":\"Weymar Andrei Merchan\",\"xsd1:LastName\":\"Fajardo\",\"xsd1:IdentNum\":\"1020817521\",\"xsd1:ClientIden\":\"CC\",\"xsd1:DepBkOrdStatusCode\":\"1063\",\"xsd1:AgentType\":\"BANCO FINANDINA\"}},\"Q1:TargetStatusRq\":{\"xsd1:TrnSrc\":\"$573008860896\",\"xsd1:ViewDtlPref\":\"PERSON\",\"Q1:SignerTargetRq\":{\"xsd1:TrnSrc\":\"wi516ZJRtNkr1M2n5h2fwE3ygsA1tV5ksB\"},\"Q1:LabelsTargetStatusRq\":{\"xsd1:Name\":\"WEYMAR ANDREI FAJARDO\",\"xsd1:LastName\":\". .\",\"xsd1:IdentNum\":\"1020817521\",\"xsd1:ClientIden\":\"OTR\",\"xsd1:DepBkOrdStatusCode\":\"1551\",\"xsd1:AgentType\":\"DAVIPLATA\"}},\"Q1:SymbolStatusRq\":{\"xsd1:TrnSrc\":\"$tin\",\"xsd1:ViewDtlPref\":\"SYMBOL\",\"Q1:SymbolSingerRq\":{\"xsd1:TrnSrc\":\"wd7VoAD3PzRdRRuKUbSUzL2gFgSD4Z8HRC\"}}},\"Q1:LabelsListStatusRq\":{\"xsd1:CardType\":\"3rX6ATgD8x2coHYtu\",\"xsd1:SearchType\":\"202310011815358040\",\"xsd1:ViewDtlPref\":\"SEND\",\"xsd1:Code\":\"COMPLETED\",\"xsd1:Desc\":\" \",\"xsd1:SumType\":\"TRANSFER\",\"xsd1:NewUpDt\":\"2023-10-01T18:15:38-05:00\",\"xsd1:TerminalType\":\"1\",\"xsd1:Channel\":\"APP\",\"xsd1:TrnType\":\"870c95306ce4c37e4db02f89f18c2ef8fe80bc7e49b464c78b8146f09d58c9ea\"},\"xsd1:DevAlmType\":\"a4ed97e1-f173-42ae-8716-7bd4d80f4dad\"}}";

        var result = producer.ProduceAsync(topicName, new Message<Null, string> { Value = text }).GetAwaiter().GetResult();

        
        Console.WriteLine($"Event sent on Partition: {result.Partition} with Offset: {result.Offset}");
    }

}