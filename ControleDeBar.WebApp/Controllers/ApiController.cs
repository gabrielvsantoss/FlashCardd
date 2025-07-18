using System.Text.Json;
using System.Threading.Tasks;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    [Route("api")]
    public class APIController : Controller
    {
        private static readonly string apiURL = "https://api.openai.com/v1/chat/completions";
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("texto-com-gpt/{pergunta}")]
        public async Task<IActionResult> TextoComGpt([FromRoute] string pergunta)
        {
            try
            {
                var resposta = await ObterRespostaChatGpt(pergunta);


                var linhas = resposta
                    .Split('\n')
                    .Select(l => l.Trim())
                    .Where(l => l != "")
                    .ToArray();

                ItensChatGptViewModel itens = new ItensChatGptViewModel();
                itens.Lista = linhas;

                return View(itens);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        static async Task<string> ObterRespostaChatGpt(string pergunta)
        {
            client.DefaultRequestHeaders.Clear();

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Você é um assistente útil." },
                    new { role = "user", content = pergunta }
                },
                max_tokens = 200,
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiURL, content);
            string responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao chamar a API: {response.StatusCode} - {responseString}");
            }

            using JsonDocument doc = JsonDocument.Parse(responseString);
            return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
    }
}
