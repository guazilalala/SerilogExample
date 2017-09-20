using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogExample.Serilog
{
    public static class SerilogSetup
    {
		public static void ConfigureSerilogMSSQL(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = @"Data Source=.;Initial Catalog=Serilog;Persist Security Info=True;User ID=sa;Password=infohand.com";  // or the name of a connection string in your .config file
			var tableName = "Logs";
			var columnOptions = new ColumnOptions();  // optional

			var log = new LoggerConfiguration()
				.WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOptions)
				.CreateLogger();
		}

		public static void ConfigureSerilogRollFile(this IServiceCollection services, IConfiguration configuration)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.RollingFile("Logs\\{Date}.xt")
				.CreateLogger();
		}
	}
}
