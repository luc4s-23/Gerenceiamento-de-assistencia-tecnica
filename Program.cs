using Microsoft.EntityFrameworkCore;
using paddockCcell;
using paddockCcell.Data;

// ----------------------------------------
// Parte 1: Adicionar Serviços (builder.Services)
// ----------------------------------------
var builder = WebApplication.CreateBuilder(args);

// Seus outros serviços
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Adicione o serviço de CORS AQUI
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// ----------------------------------------
// Parte 2: Configurar a Pipeline (app.Use...)
// ----------------------------------------

// Seus outros middlewares
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();

// Habilite o CORS AQUI (após UseRouting e antes de UseAuthorization)
app.UseCors("MyCorsPolicy");

app.UseAuthorization();

// Mapeie os controllers AQUI
app.MapControllers();

// A parte de ambiente de desenvolvimento deve estar mais no topo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();