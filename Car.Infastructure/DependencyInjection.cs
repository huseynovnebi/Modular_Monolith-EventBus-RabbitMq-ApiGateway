using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infastructure
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            {

                services.AddDbContext<CarDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-O7KPC84\\MSSQLSERVER01;" +
      "Initial Catalog=Modular_Car;" + "TrustServerCertificate=True;" + "Integrated Security=True;"
    ), ServiceLifetime.Scoped);
                return services;
            }
        }
}
