internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        builder.Services.ConfigureAutoMapper();
        builder.Services.ConfigureCors();
        builder.Services.ConfigureIISIntegration();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.ConfigureLoggerService();
        builder.Services.ConfigureRepositoryManager();
        builder.Services.ConfigureServiceManager();
        builder.Services.ConfigureDbConnection(builder.Configuration);
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
            .AddApplicationPart(typeof(AssemblyReference).Assembly);

        var app = builder.Build();
       // var logger = app.Services.GetRequiredService<ILoggerManager>();
        //app.ConfigureExceptionHandler(logger);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
            app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.MapControllers();
        
        app.Run();
    }
}