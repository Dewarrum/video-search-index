using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Migrations;

var services = new ServiceCollection();

services.ConfigureInfrastructure();
services.AddSingleton<IMigrationService, MigrationService>();
services.AddSingleton<MigrationRunner>();

var serviceProvider = services.BuildServiceProvider();

var migrationRunner = serviceProvider.GetRequiredService<MigrationRunner>();

await migrationRunner.Run();