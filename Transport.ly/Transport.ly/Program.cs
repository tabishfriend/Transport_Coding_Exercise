// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Transport.Core;
using Transport.Core.Interfaces;

var services = new ServiceCollection();
services
    .AddSingleton<StartupService, StartupService>()
    .AddSingleton<IOrderService, OrderService>()
    .AddSingleton<IDataSourceService, JsonDataSourceService>()
    .AddSingleton<IPrintService, PrintConsoleService>()
    .BuildServiceProvider();


var startupService = services.BuildServiceProvider().GetService<StartupService>();
startupService.PrintSchedule();
startupService.PrintOrderSchedule();