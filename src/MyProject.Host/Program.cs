using Volo.Abp;
using MyProject.Host;

var builder = WebApplication.CreateBuilder(args);

// 配置ABP
builder.Services.AddApplication<MyProjectHostModule>(); // ABP v8.x初始化方式

var app = builder.Build();

// 无需调用InitializeAbp()，v8.x已集成到UseAbp()中

app.InitializeApplication();
app.Run();
