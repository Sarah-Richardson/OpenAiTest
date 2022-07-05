using Newtonsoft.Json;

namespace OpenAiTest.Models
{
    /// <summary>
    /// AI Response.
    /// </summary>
    public class AiResponse
    {
        /// <summary>
        /// Response Id.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Object.
        /// </summary>
        [JsonProperty("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Created.
        /// </summary>
        [JsonProperty("created")]
        public int Created { get; set; }

        /// <summary>
        /// model.
        /// </summary>
        [JsonProperty("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Choices.
        /// </summary>
        [JsonProperty("choices")]
        public Choice[]? Choices { get; set; }
    }

    /// <summary>
    /// Choice.
    /// </summary>
    public class Choice
    {
        /// <summary>
        /// Test response from AI.
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; set; }

        /// <summary>
        /// Index.
        /// </summary>
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        /// Log problems.
        /// </summary>
        [JsonProperty("logprobs")]
        public object? LogProbs { get; set; }

        /// <summary>
        /// Finish reason.
        /// </summary>
        [JsonProperty("finish_reason")]
        public string? FinishReason { get; set; }
    }

}
