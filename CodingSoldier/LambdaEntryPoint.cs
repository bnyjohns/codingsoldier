﻿using Microsoft.AspNetCore.Hosting;
using CodingSoldier.App_Start;

namespace CodingSoldier
{
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseStartup<Startup>()
                .UseLambdaServer();
        }
    }
}
