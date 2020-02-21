﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            swaggerGenOptions.AddOrUpdate(options);

            return swaggerGenOptions;
        }

        public static SwaggerGenOptions WithServers(this SwaggerGenOptions swaggerGenOptions, IEnumerable<OpenApiServer> servers)
        {
            var options = new ServersOptions { Servers = servers };

            swaggerGenOptions.AddOrUpdate(options);

            return swaggerGenOptions;
        }

        private static void AddOrUpdate(this SwaggerGenOptions swaggerGenOptions, ServersOptions options)
        {
            var filter = swaggerGenOptions
                            .DocumentFilterDescriptors
                            .Find(x => x.Type == typeof(ServersDocumentFilter));

            if (filter != null)
            {
                var existingOptions = (ServersOptions) filter.Arguments[0];

                existingOptions.Servers = existingOptions.Servers.Concat(options.Servers);
            }
            else
            {
                swaggerGenOptions.DocumentFilter<ServersDocumentFilter>(options);
            }
        }
    }
}
