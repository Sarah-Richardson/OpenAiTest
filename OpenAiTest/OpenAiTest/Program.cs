using OpenAiTest.Services;

namespace OpenAiTest
{
    internal class Program
    {
        static async Task Main()
        {
            var service = new OpenAiService();
            var speaker = new SpeechService();
            
            var question = Console.ReadLine();
            while(question!="q")
            {
                if(!string.IsNullOrEmpty(question))
                {
                    var answer = await service.Answer(question);
                    Console.WriteLine(answer);
                    await speaker.Say(answer);
                }                
                Console.WriteLine(); Console.WriteLine();
                question = Console.ReadLine();
            }
        }
    }
}