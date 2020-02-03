using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.Servers.Extension
{
    public static class SwaggerGenOptionsExtensions
    {
        public static SwaggerGenOptions WithServers(this SwaggerGenOptions swaggerGenOptions, Action<ServersOptions> setupAction)
        {
            var options = new ServersOptions();

            setupAction.Invoke(options);

            swaggerGenOptions.DocumentFilter<ServersDocumentFilter>(options);

            return swaggerGenOptions;
        }

        public static SwaggerGenOptions WithServers(this SwaggerGenOptions swaggerGenOptions, IEnumerable<OpenApiServer> servers)
        {
            var options = new ServersOptions { Servers = servers };
      
            swaggerGenOptions.DocumentFilter<ServersDocumentFilter>(options);

            return swaggerGenOptions;
        }
    }
}
