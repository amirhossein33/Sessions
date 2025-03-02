// Program.cs
using ContextPoolingWithState;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region TenantResolution
// Tenant Resolution - ??????? TenantId ?? ????? ???????
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenant>(sp =>
{
    var tenantIdString = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.Query["TenantId"];

    return tenantIdString != StringValues.Empty && int.TryParse(tenantIdString, out var tenantId)
        ? new Tenant(tenantId)
        : null;
});
#endregion

#region RegisterSingletonContextFactory
// ??? Singleton Context Factory ???? LibraryContext
builder.Services.AddPooledDbContextFactory<LibraryContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("LibraryContext")));
#endregion

#region RegisterScopedContextFactory
builder.Services.AddScoped<LibraryScopedFactory>();
#endregion

#region RegisterDbContext

builder.Services.AddScoped(
    sp => sp.GetRequiredService<LibraryScopedFactory>().CreateDbContext());
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
