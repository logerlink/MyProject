using Volo.Abp;

var builder = WebApplication.CreateBuilder(args);

// ����ABP
builder.Services.AddApplication<MyProjectHostModule>(); // ABP v8.x��ʼ����ʽ

var app = builder.Build();

// �������InitializeAbp()��v8.x�Ѽ��ɵ�UseAbp()��

app.InitializeApplication();
app.Run();
