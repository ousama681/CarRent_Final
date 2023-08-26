using CarRent.CarManagement.Domain;
using CarRent.CarManagement.Infrastructure.Persistence;
using CarRent.ContractManagement.Domain;
using CarRent.ContractManagement.Infrastructure.Persistence;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;

namespace CarRent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddDbContext<CustomerContext>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddDbContext<CarContext>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IRentContractRepository, RentContractRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddDbContext<RentContractContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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