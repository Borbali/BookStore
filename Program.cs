
using Microsoft.EntityFrameworkCore;
using BookStore.Model;

public class Program {
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<BookContext>(options =>
        {
            options.UseSqlServer("Server=DESKTOP-1N3EMRI;Database=Bookstore;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        });

        var app = builder.Build();


        if (!app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}