using AzureDevOpsWebhookConsumer.Api;
using AzureDevOpsWebhookConsumer.Common.Middlewares;
using AzureDevOpsWebhookConsumer.Configuration;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery();
builder.Services.AddAuthentication();
builder.Services.Configure<BasicAuthCredentialsOptions>(builder.Configuration.GetSection(BasicAuthCredentialsOptions.BasicAuthCredentials));

var app = builder.Build();

app.UseAntiforgery();

app.MapGet("/", () => "Azure DevOps Webhook Consumer");

app.UseMiddleware<BasicAuthenticationMiddleware>();

app.MapAzureDevOpsWebhookRepo();

app.Run();
