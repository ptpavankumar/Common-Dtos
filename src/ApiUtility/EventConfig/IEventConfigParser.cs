using System.Collections.Generic;

namespace ApiUtility.EventConfig
{
    public interface IEventConfigParser
    {
        string QueueName { get; }
        string QueueVisibilityTimeOut { get; }
        string QueueMaxTimeTopicInQueue { get; }
        string DeadLetterQueueName { get; }
        string DeadLetterQueueMaxReceiveCount { get; }
        string DeadLetterQueueVisibilityTimeOut { get; }
        string DeadLetterQueueMaxTimeTopicInQueue { get; }
        Dictionary<string, string> PublishTopics { get; }
        Dictionary<string, string> SubscribeTopics { get; }
        string QueueMaxReceiveCount { get; }
    }
}