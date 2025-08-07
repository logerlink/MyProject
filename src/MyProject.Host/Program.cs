using Volo.Abp;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();  // 使用autofac，不然dbcontext注入不成功，导致dbcontext抛出空指针异常。除此还需要在MyProjectHostModule的DepensOn加入typeof(AbpAutofacModule)模块
// 配置ABP
builder.Services.AddApplication<MyProjectHostModule>(); // ABP v8.x初始化方式

var app = builder.Build();

// 无需调用InitializeAbp()，v8.x已集成到UseAbp()中

app.InitializeApplication();
app.Run();
