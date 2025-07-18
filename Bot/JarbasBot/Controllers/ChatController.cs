using Microsoft.AspNetCore.Mvc;
using JarbasBot.Models;
using JarbasBot.Services;

namespace JarbasBot.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly OpenAiService _openAiService;

        public ChatController(OpenAiService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Question))
                return BadRequest("Pergunta não pode estar vazia, parça!");

            var response = await _openAiService.AskJarbas(request.Question);
            return Ok(new {answer = response});
        }
    }
}