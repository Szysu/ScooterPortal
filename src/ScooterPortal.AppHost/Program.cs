var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.ScooterPortal_ApiService>("apiservice");

builder.AddProject<Projects.ScooterPortal_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();