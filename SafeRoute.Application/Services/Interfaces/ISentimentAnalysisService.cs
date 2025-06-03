using SafeRoute.Domain.Entities;

namespace SafeRoute.Application.Services.Interfaces
{
    public interface ISentimentAnalysisService
    {
        SentimentPrediction Predict(string text);
    }
}