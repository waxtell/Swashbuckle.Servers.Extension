using System;
using System.Collections.Generic;
using Microsoft.OpenApi;

namespace Swashbuckle.Servers.Extension.Extensions;

public static class OpenApiServerExtensions
{
    public static OpenApiServer WithVariable(this OpenApiServer server, string key, OpenApiServerVariable value)
    {
        ArgumentNullException.ThrowIfNull(server);

        server.Variables ??= new Dictionary<string, OpenApiServerVariable>();
        server.Variables.Add(key, value);

        return server;
    }
}