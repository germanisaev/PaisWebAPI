
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Data {
    public class DbContextClass: DbContext
    {
        protected readonly IConfiguration Configuration;

        protected readonly string[] _allowedOrigins;

        public DbContextClass(IConfiguration configuration, DbContextOptions<DbContextClass> options) : base(options) // , DbContextOptions<DbContextClass> options) : base(options
        {
            Configuration = configuration;

            _allowedOrigins = configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Employees> Employees => Set<Employees>();
        public DbSet<Departments> Departments => Set<Departments>();
        public DbSet<RoleCompanies> RoleCompanies => Set<RoleCompanies>();
    }
}
