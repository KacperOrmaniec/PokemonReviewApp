using MySql.Data.MySqlClient;
using PokemonReviewApp;

internal class Program
{
    static MySqlConnection con;

    public static void Connect(string user, string password)
    {
        con = new MySqlConnection();

        try
        {
            con.ConnectionString = "server = localhost; User Id = " + user + "; " +
                "Persist Security Info = True; database = pokemonreview; Password = " + password;
            con.Open();
            Console.WriteLine("Succesfully connected!");

        }

        catch (Exception e)
        {
            Console.WriteLine("Not Successful! due to " + e.ToString());
        }
    }
    private static void Main(string[] args)
    {
        Connect("root", "Kacperormaniec1");

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
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