using Newtonsoft.Json;

namespace OpenAiTest.Models
{
    public class AiRequest
    {
        /// <summary>
        /// Model.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Prompt.
        /// </summary>
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// Temperature.
        /// </summary>
        [JsonProperty("temperature")]
        public double Temperature { get; set; }
        
        /// <summary>
        /// Max tokens.
        /// </summary>
        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }

        /// <summary>
        /// Frequency penalty.
        /// </summary>
        [JsonProperty("frequency_penalty")]
        public int FrequencyPenalty { get; set; }

        /// <summary>
        /// Presence penalty.
        /// </summary>
        [JsonProperty("presence_penalty")]
        public int PresencePenalty { get; set; }

        /// <summary>
        /// Top P.
        /// </summary>
        [JsonProperty("top_p")]
        public int TopP { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="prompt"></param>
        /// <param name="temperature"></param>
        /// <param name="maxTokens"></param>
        /// <param name="frequencyPenalty"></param>
        /// <param name="presencePenalty"></param>
        /// <param name="topP"></param>
        public AiRequest(string model, string prompt, double temperature, int maxTokens, int frequencyPenalty, int presencePenalty, int topP)
        {
            Model = model;
            Prompt = prompt;
            Temperature = temperature;
            MaxTokens = maxTokens;
            FrequencyPenalty = frequencyPenalty;
            PresencePenalty = presencePenalty;
            TopP = topP;
        }

        /// <summary>
        /// Converts object to json string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {         
            var json = JsonConvert.SerializeObject(this);
            return json;
        }

    }

}
