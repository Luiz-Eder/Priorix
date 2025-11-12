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

<<<<<<< HEAD
        public GeminiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
=======
        public GeminiService(string geminiApiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = "AIzaSyAXayfOAfp0NL9pxDJGykrC38aIO8h8C6g"; // 🔑 sua chave
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
        }

        public async Task<string> AnalyzeTaskAsync(string title, string description)
        {
<<<<<<< HEAD
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
=======
            string prompt =
                "Analise a tarefa abaixo e gere uma pontuação RICE (Reach, Impact, Confidence, Effort) " +
                "e um breve resumo explicativo:\n" +
                $"Título: {title}\nDescrição: {description}";
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956

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

<<<<<<< HEAD
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
=======
            // ✅ Atualizado para o modelo correto que sua conta possui
            var response = await _httpClient.PostAsync(
                $"https://generativelanguage.googleapis.com/v1/models/gemini-2.5-flash:generateContent?key={_apiKey}",
                content
            );

            var json = await response.Content.ReadAsStringAsync();

            try
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("candidates", out var candidates))
                {
                    return candidates[0]
                        .GetProperty("content")
                        .GetProperty("parts")[0]
                        .GetProperty("text")
                        .GetString() ?? "A IA não retornou texto.";
                }

                return $"Resposta inesperada da IA: {json}";
            }
            catch
            {
                return $"Erro ao processar resposta da IA: {json}";
            }
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
        }
    }
}
