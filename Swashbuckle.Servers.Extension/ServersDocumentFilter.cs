using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.Servers.Extension
{
    internal class ServersDocumentFilter : IDocumentFilter
    {
        private readonly ServersOptions _options;

        public ServersDocumentFilter(ServersOptions options)
        {
            _options = options;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers = _options?.Servers?.ToList();
        }
    }
}