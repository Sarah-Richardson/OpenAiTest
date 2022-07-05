using Flurl.Http;
using OpenAiTest.Models;

namespace OpenAiTest.Services
{

    public class OpenAiService
    {
        #region AI configuration
        
        private const string Key = "Add your own key here";
        private const string Engine = "text-davinci-002";

        private const double Temperature = 0.7;
        private const int TopP = 1;
        private const int FrequencyPenalty = 0;
        private const int PresencePenalty = 0;
        private const int Tokens = 150;

        private const string Url = "https://api.openai.com/v1/completions";

        #endregion

        /// <summary>
        /// Respond to question.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public async Task<string> Answer(string question)
        {
            var answer = string.Empty;            

            try
            {
                var request = new AiRequest(Engine, question, Temperature, Tokens, FrequencyPenalty, PresencePenalty, TopP);
                var response = await Url.WithOAuthBearerToken(Key).PostJsonAsync(request);
                if(response.ResponseMessage.IsSuccessStatusCode)
                {
                    var result = await response.GetJsonAsync<AiResponse>();
                    var firstAnswer = result?.Choices?.FirstOrDefault();

                    answer = firstAnswer?.Text ?? String.Empty;
                }
            }
            catch (Exception e)
            {
                answer = e.Message;
            }
            return answer;
        }

    }
}
