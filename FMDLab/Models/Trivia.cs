using System.Text.Json.Serialization;

namespace FMDLab.Models;

public class TriviaResponse
{
    public List<Trivia>? Results { get; set; }
}

public class Trivia
{
    [JsonPropertyName("question")]
    public string Question { get; set; } = string.Empty;
    [JsonPropertyName("correct_answer")]
    public string CorrectAnswer{ get; set; } = string.Empty;
}