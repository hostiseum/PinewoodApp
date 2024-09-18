using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using System.Text.Json;

namespace PinewoodApp.CustomerAPI.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string jsonFile)
        {
            string jsonString = File.ReadAllText(jsonFile);
            T objects = JsonSerializer.Deserialize<T>(jsonString)!;
            return objects;
        }
    }
}
