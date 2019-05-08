using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ApiUtility.EventConfig
{
    public class EventConfigParser : IEventConfigParser
    {
        private const string FileName = "service-bus.json";
        private const string QueuesKeyName = "queues[0]";
        private const string PublishTopicsKeyName = "publishTopics";
        private const string SubscribeTopicsKeyName = "subscribeTopics";
        private const string DeadLetterQueueKeyName = "deadLetterQueue";
        private const string NameKeyName = "name";
        private const string QueueVisibilityTimeOutKeyName = "visibilityTimeOut";
        private const string QueueMaxTimeTopicInQueueKeyName = "maxTimeTopicInQueue";
        private const string QueueMaxReceiveCountKeyName = "maxReceiveCount";
        private readonly JObject _jObject;

        public EventConfigParser() : this(FileName)
        {
        }

        public EventConfigParser(string fileName)
        {
            var json = File.ReadAllText(fileName);
            _jObject = JObject.Parse(json);
        }

        protected JToken QueueToken => _jObject.SelectToken(QueuesKeyName);

        protected JToken PublishTopicsToken => _jObject.SelectToken(PublishTopicsKeyName);

        protected JToken DeadLetterQueueToken => QueueToken.SelectToken(DeadLetterQueueKeyName);

        public string QueueName => QueueToken.SelectToken(NameKeyName).Value<string>();

        public string QueueVisibilityTimeOut =>
            QueueToken.SelectToken(QueueVisibilityTimeOutKeyName).Value<string>();

        public string QueueMaxTimeTopicInQueue =>
            QueueToken.SelectToken(QueueMaxTimeTopicInQueueKeyName).Value<string>();

        public string QueueMaxReceiveCount => QueueToken.SelectToken(QueueMaxReceiveCountKeyName).Value<string>();

        public Dictionary<string, string> SubscribeTopics =>
            QueueToken.SelectToken(SubscribeTopicsKeyName).ToObject<Dictionary<string, string>>();

        public string DeadLetterQueueName => DeadLetterQueueToken.SelectToken(NameKeyName).Value<string>();

        public string DeadLetterQueueVisibilityTimeOut =>
            DeadLetterQueueToken.SelectToken(QueueVisibilityTimeOutKeyName).Value<string>();

        public string DeadLetterQueueMaxTimeTopicInQueue => DeadLetterQueueToken
            .SelectToken(QueueMaxTimeTopicInQueueKeyName)
            .Value<string>();

        public string DeadLetterQueueMaxReceiveCount => DeadLetterQueueToken.SelectToken(QueueMaxReceiveCountKeyName)
            .Value<string>();

        public Dictionary<string, string> PublishTopics => PublishTopicsToken.ToObject<Dictionary<string, string>>();
    }
}