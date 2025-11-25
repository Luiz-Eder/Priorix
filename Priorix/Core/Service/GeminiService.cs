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
            // ✅ Endpoint do Gemini 2.0 Flash
            var endpoint = $"https://generativelanguage.googleapis.com/v1/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            // ✅ Prompt OTIMIZADO COM PRIORIDADE
            var prompt = @$"
Aja como um Product Owner experiente. Sua missão é reescrever a tarefa abaixo de forma profissional, clara e direta.

Entrada:
Título: {title}
Descrição original: {description}

REGRAS DE FORMATAÇÃO (OBRIGATÓRIO):
1. NÃO use negrito (**), itálico (*) ou qualquer marcação Markdown.
2. NÃO use introduções como 'Aqui está a sugestão' ou 'Com base na análise'.
3. O texto deve ser breve, ideal para ser lido rapidamente em um card Kanban.

ESTRUTURA DA RESPOSTA:
[Parágrafo único com a descrição da tarefa, focando no objetivo e critério de aceitação]

Prioridade Sugerida: [Baixa / Média / Alta]

[Linha em branco]

RICE Score Estimado:
Alcance: [Número]
Impacto: [Número]
Confiança: [Percentual]
Esforço: [Número]
Score Final: [Resultado]

[Linha em branco]

Justificativa: [Uma frase  explicando a prioridade]
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
                return $"Erro na API Gemini: {json}";

            // ✅ Extração segura com try-catch
            try
            {
                using var doc = JsonDocument.Parse(json);

                var text = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                return text ?? "A IA não retornou texto.";
            }
            catch
            {
                return "Não foi possível processar a resposta da IA (formato inválido ou bloqueio de segurança).";
            }
        }
    }
}