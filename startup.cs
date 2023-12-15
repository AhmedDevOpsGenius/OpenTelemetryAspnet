using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

public void ConfigureServices(IServiceCollection services)
{
    // ... your existing configurations

    // Configure OpenTelemetry TracerProvider with Jaeger exporter
    services.AddOpenTelemetryTracing((builder) => builder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("YourServiceName"))
        .AddAspNetCoreInstrumentation()
        .AddJaegerExporter(options =>
        {
            options.AgentHost = "your-jaeger-agent-host"; // Jaeger agent host
            options.AgentPort = 6831; // Jaeger agent port
        })
        .AddConsoleExporter()); // Optionally, add a console exporter for debugging

    // ... other configurations
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ... your existing configurations

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    // ... other configurations
}
