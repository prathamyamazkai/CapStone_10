using Microsoft.EntityFrameworkCore;
using LocalBusiness.ProductAPI.Data;

var builder = WebApplication.CreateSlimBuilder(args);

// ➕ Add services
builder.Services.AddControllers(); // Enables support for controllers

// 📦 Add Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔗 Connect to SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🛡️ Add authentication (for future JWT setup)
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddJwtBearer(options => { /* configure later */ });

// ⚙️ Add authorization (optional for now)
builder.Services.AddAuthorization();

var app = builder.Build();

// 🚀 Use Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⛓️ HTTPS redirection
app.UseHttpsRedirection();

// 🔐 Authentication & Authorization
// app.UseAuthentication(); // Uncomment when JWT is set up
app.UseAuthorization();

// 🎯 Map controller routes
app.MapControllers();

app.Run();
