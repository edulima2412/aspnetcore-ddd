using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Usado para criar as migrações
            var connectionString = "Persist Security Info=True;Server=localhost\\SQLEXPRESS; Database=db-api; Trusted_Connection=true; User ID=sa; Password=admin123";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseSqlServer(connectionString);

            // if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            // {
            //     connectionString = Environment.GetEnvironmentVariable("DB_CONNECT_SQL");
            //     optionBuilder.UseSqlServer(connectionString);
            // }
            // else
            // {
            //     connectionString = Environment.GetEnvironmentVariable("DB_CONNECT_MYSQL");
            //     optionBuilder.UseMySql(connectionString);
            // }

            return new MyContext(optionBuilder.Options);
        }
    }
}
