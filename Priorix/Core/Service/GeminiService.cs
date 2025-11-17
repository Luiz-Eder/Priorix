using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Priorix.Core.Services
{
    public class GeminiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> AnalyzeTaskAsync(string title, string description)
        {
            // ✅ Endpoint atualizado do Gemini 2.0 Flash
            var endpoint =
                $"https://generativelanguage.googleapis.com/v1/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            // ✅ Prompt melhorado
            var prompt = @$"
Você é uma IA que analisa tarefas de desenvolvimento usando critérios RICE.

Aqui está a tarefa:

Título: {title}
Descrição: {description}

 Gere:
 - Análise detalhada
 - Pontuação RICE estimada (Reach, Impact, Confidence, Effort)
 - Cálculo final
 - Sua conclusão final
";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(endpoint, content);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return $"Erro Gemini: {json}";

            // ✅ Extração segura do texto
            using var doc = JsonDocument.Parse(json);

            var text =
                doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return text ?? "Nenhuma resposta da IA.";
        }
    }
}
