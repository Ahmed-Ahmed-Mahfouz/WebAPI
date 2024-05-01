using Lab2.Models;
using Lab2.Repository;
using Lab2.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txt = "";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Register Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "My API",
                    Description = "This is my API",
                    Version = "v1",
                    TermsOfService = new Uri("http://tempuri.org/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "AhmedMahfouz",
                        Email = "ahmedmahfouz098@gmail.com",
                    },
                });
                c.IncludeXmlComments("D:\\WebAPI-ITI\\Lab2\\Lab2\\myfile.xml");
                c.EnableAnnotations();
            });

            builder.Services.AddDbContext<ITIContext>(opt =>
            {
                opt.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ITIcon"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            //builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            //builder.Services.AddScoped<IGenericRepository<Department>, GenericRepository<Department>>();
            //builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();
            builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme="Schema").AddJwtBearer("Schema",op=>
            {
                string key = "welcome to my secret key Ahmed Ahmed Mahfouz";
                var secretkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = secretkey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(txt);

            app.MapControllers();

            app.Run();
        }
    }
}
