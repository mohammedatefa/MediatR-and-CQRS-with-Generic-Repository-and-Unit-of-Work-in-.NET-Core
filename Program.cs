using CQRS_MediatR.Context;
using CQRS_MediatR.Repository;
using CQRS_MediatR.Utilities.UOW;
using CQRS_MediatR.Utilities.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace CQRS_MediatR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add Connection string
            builder.Services.AddDbContext<NewsPaperContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            });

            //Inject UOW && Generic Repository
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Inject AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            //Inject MediatoR
            builder.Services.AddMediatR(
                config =>
                config.RegisterServicesFromAssemblies(typeof(Program).Assembly));

            //Inject FluentValidators
            builder.Services.AddValidatorsFromAssemblyContaining<ArticleCreatorValidator>();


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
}