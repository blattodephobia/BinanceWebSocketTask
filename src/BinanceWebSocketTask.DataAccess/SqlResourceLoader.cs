using System.Reflection;

namespace BinanceWebSocketTask.DataAccess
{
    internal static class SqlResourceLoader
    {
        public static string LoadScript(string name)
        {
            Assembly? resourcesAssembly = Assembly.GetAssembly(typeof(SqlResourceLoader));
            string? insertAggPayloadResourceName = resourcesAssembly?.GetManifestResourceNames()?.FirstOrDefault(rsc => rsc == $"BinanceWebSocketTask.DataAccess.Scripts.{name}");
            Stream? resourceStream = insertAggPayloadResourceName != null
                ? resourcesAssembly?.GetManifestResourceStream(insertAggPayloadResourceName)
                : null;
            if (resourceStream != null)
            {
                using var resourceReader = new StreamReader(resourceStream);
                return resourceReader.ReadToEnd();
            }
            else
            {
                throw new FileNotFoundException($"Specified SQL script {name} could not be found.");
            }
        }
    }
}
