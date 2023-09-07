using Microsoft.OpenApi.Models;

namespace Swashbuckle.Servers.Extension.Extensions
{
    public static class OpenApiServerExtensions
    {
        public static OpenApiServer WithVariable(this OpenApiServer server, string key, OpenApiServerVariable value)
        {
            server.Variables.Add(key, value);

            return server;
        }
    }
}