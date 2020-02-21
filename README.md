# Swashbuckle.Servers.Extension
Specify the collection of servers for your API

(Servers collection **will** be included when using Swashbuckle.AspNetCore.Cli)

Configuring the servers at startup:

```csharp
            services.AddSwaggerGen(c =>
            {
                c.WithServers
                (
                    new List<OpenApiServer>
                    {
                        new OpenApiServer { Url = "http://localhost:5000" },
                        new OpenApiServer { Url = "https://www.yourcustomdomain.com" }
                    }
                );
```
