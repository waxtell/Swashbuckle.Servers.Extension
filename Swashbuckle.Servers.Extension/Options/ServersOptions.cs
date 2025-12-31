using System.Collections.Generic;
using Microsoft.OpenApi;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.Servers.Extension
{
    public class ServersOptions
    {
        public IEnumerable<OpenApiServer> Servers { get; set; }
    }
}
