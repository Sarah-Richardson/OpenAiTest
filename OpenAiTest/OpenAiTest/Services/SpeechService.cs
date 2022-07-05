using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.Media;
using WMPLib;

namespace OpenAiTest.Services
{

    /// <summary>
    /// Speech Service.
    /// </summary>
    public class SpeechService
    {
        #region Speech Configuration

        private readonly RegionEndpoint _awsRegion = RegionEndpoint.EUWest1;
        private const string Key = "Add your own key here";
        private const string Secret = "Add your own secret here";
        private readonly AmazonPollyClient _client;

        private string LanguageCode = "en-GB";
        private string SpeakingVoice = "Arthur";

        #endregion;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SpeechService()
        {
            _client = new AmazonPollyClient(Key, Secret,_awsRegion);
        }

        /// <summary>
        /// Says the given text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task Say(string text)
        {
            var isSsml = text.StartsWith("<speak>");

            var request = new SynthesizeSpeechRequest
            {
                LanguageCode = LanguageCode,
                VoiceId = (VoiceId)SpeakingVoice,
                Text = text,
                OutputFormat = OutputFormat.Mp3,
                LexiconNames = null,
                TextType = isSsml ? TextType.Ssml : TextType.Text,
                Engine = isSsml ? Engine.Standard : Engine.Neural
            };

            var response = await _client.SynthesizeSpeechAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var mp3Filename = $"{Guid.NewGuid().ToString()}.mp3";

                await using (var fileStream = File.Create(mp3Filename))
                {
                    await response.AudioStream.CopyToAsync(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                }
                var player = new WindowsMediaPlayer()
                {
                    URL = mp3Filename
                };

                player.controls.play();
            }
            else
            {
                Console.WriteLine($"Error: SynthesizeSpeechAsync returned HTTP status code {response.HttpStatusCode}");
            }
        }

    }
}
