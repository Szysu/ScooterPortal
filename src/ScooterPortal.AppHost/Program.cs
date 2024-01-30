var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddSqlServerContainer("database", "Aaa123456", 14330)
    .WithVolumeMount("database", "/var/opt/mssql", VolumeMountType.Named)
    .AddDatabase("ScooterPortal");

var apiservice = builder.AddProject<Projects.ScooterPortal_ApiService>("apiservice")
    .WithReference(database);

builder.AddProject<Projects.ScooterPortal_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();