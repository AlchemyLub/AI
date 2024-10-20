namespace AlchemyLub.AI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AiController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    [Experimental("SKEXP0070")]
    public async Task<IActionResult> GetOllamaResponse(CancellationToken cancellationToken = default)
    {
        Uri uri = new Uri("http://localhost:11434");
        string modelId = "llama3.1:8b";

        OllamaChatCompletionService chatService = new(modelId, uri);

        ChatHistory chatHistory = new("You are a helpful assistant that knows about AI");

        chatHistory.AddUserMessage("Hi, I'm looking for book suggestions");

        IReadOnlyList<ChatMessageContent> response = await chatService.GetChatMessageContentsAsync(chatHistory, cancellationToken: cancellationToken);

        return Ok(response);
    }
}
