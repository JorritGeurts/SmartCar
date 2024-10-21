using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;

namespace SmartCar.Services
{
    public static class ApiKeys
    {
        public static string CustomVisionEndPoint => "https://smartcar-prediction.cognitiveservices.azure.com/";
        public static string PredictionKey => "21ab622a6e7d4812bac318c6f6913a9d";
        public static string ProjectId => "cc626039-8b5e-4b69-ba7d-cf2aa73c4f12";
        public static string PublishedName => "SmartCar";
    }

    public static class CustomVisionService
    {
        public static async Task<PredictionModel?> ClassifyImageAsync(Stream photoStream)
        {
            try
            {
                var endpoint = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(ApiKeys.PredictionKey))
                {
                    Endpoint = ApiKeys.CustomVisionEndPoint
                };

                // Send image to the Custom Vision API
                var results = await endpoint.ClassifyImageAsync(Guid.Parse(ApiKeys.ProjectId), ApiKeys.PublishedName, photoStream);

                // Return the most likely prediction
                return results.Predictions?.OrderByDescending(x => x.Probability).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new PredictionModel();
            }
        }
    }
}
