using Microsoft.ML.Data;

namespace SafeRoute.Domain.Entities;

public class SentimentPrediction : SentimentData
{
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }
    public float Probability { get; set; }
    public float Score { get; set; }
}
