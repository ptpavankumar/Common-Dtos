namespace CommonDtos.EventMessage
{
    public class EventMessage
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string TopicArn { get; set; }
        public string MessageId { get; set; }
        public string ReceiptHandle { get; set; }
    }
}