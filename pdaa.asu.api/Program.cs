using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System.IO;

namespace pdaa.asu.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((ctx, config) =>
                    {
                        var env = ctx.HostingEnvironment;

                        config.SetBasePath(env.ContentRootPath);
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true,
                            reloadOnChange: true);
                        config.AddEnvironmentVariables();
                    }
                        )
                        .UseUrls("https://*:4456;https://localhost:4456;https://0.0.0.0:4456")
                        .UseStartup<Startup>()

                        .UseSerilog((context, cfg) =>
                        {
                            //// setup AWS CloudWatch client
                            //var awsAccessKey = context.Configuration["Serilog:AwsAccessKey"];
                            //var awsSecretKey = context.Configuration["Serilog:AwsSecretKey"];
                            //var awsRegion = context.Configuration["Serilog:AwsRegion"];

                            //AWSCredentials credentials = new BasicAWSCredentials(awsAccessKey, awsSecretKey);
                            //IAmazonCloudWatchLogs client = new AmazonCloudWatchLogsClient(credentials,
                            //    Amazon.RegionEndpoint.GetBySystemName(awsRegion));

                            //var logGroupName = "SchedulerLogGroup/" + context.HostingEnvironment.EnvironmentName +
                            //                   "/Main";

                            //CloudWatchSinkOptions options = new CloudWatchSinkOptions
                            //{
                            //    LogGroupName = logGroupName,
                            //    TextFormatter = new JsonFormatter(),
                            //    MinimumLogEventLevel = LogEventLevel.Information,
                            //    BatchSizeLimit = 100,
                            //    Period = TimeSpan.FromSeconds(10),
                            //    CreateLogGroup = true,
                            //    RetryAttempts = 5
                            //};

                            cfg
                                .MinimumLevel.Debug()
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                .MinimumLevel.Override("System", LogEventLevel.Warning)
                                .Enrich.FromLogContext()
                                .WriteTo.Console(
                                //outputTemplate:
                                //"[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                                //theme: AnsiConsoleTheme.Literate
                                );
                            //.WriteTo.AmazonCloudWatch(options, client);

                            var saveToLocalLog = context.Configuration["SaveLocalLog"].ToLowerInvariant() == "true";

                            if (saveToLocalLog)
                            {
                                if (!Directory.Exists("Log"))
                                    Directory.CreateDirectory("Log");

                                cfg.WriteTo.File(@"Log\PdaaSite-.log", rollingInterval: RollingInterval.Day);
                            }
                        }, preserveStaticLogger: false);
                });
    }
}
