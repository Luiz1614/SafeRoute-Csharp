using Microsoft.ML.Data;


namespace SafeRoute.Domain.Entities;

public class SentimentData
{
    [LoadColumn(0)]
    public string FeedbackText { get; set; }

    [LoadColumn(1)]
    public bool Label { get; set; }
}
