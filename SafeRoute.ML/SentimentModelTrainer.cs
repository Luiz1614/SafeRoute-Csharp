using Microsoft.ML;
using SafeRoute.Domain.Entities;

namespace SafeRoute.ML;

public class SentimentModelTrainer
{
    public static void TrainAndSave(string dataPath, string modelPath)
    {
        var mlContext = new MLContext();

        // Carregar dados
        var dataView = mlContext.Data.LoadFromTextFile<SentimentData>(
            dataPath, hasHeader: true, separatorChar: ',');

        // Pipeline de processamento e treinamento
        var pipeline = mlContext.Transforms.Text.FeaturizeText(
                "Features", nameof(SentimentData.FeedbackText))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

        // Treinar o modelo
        var model = pipeline.Fit(dataView);

        // Salvar o modelo treinado
        mlContext.Model.Save(model, dataView.Schema, modelPath);
    }
}
