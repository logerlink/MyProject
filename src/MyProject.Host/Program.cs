using Volo.Abp;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();  // ʹ��autofac����Ȼdbcontextע�벻�ɹ�������dbcontext�׳���ָ���쳣�����˻���Ҫ��MyProjectHostModule��DepensOn����typeof(AbpAutofacModule)ģ��
// ����ABP
builder.Services.AddApplication<MyProjectHostModule>(); // ABP v8.x��ʼ����ʽ

var app = builder.Build();

// �������InitializeAbp()��v8.x�Ѽ��ɵ�UseAbp()��

app.InitializeApplication();
app.Run();
