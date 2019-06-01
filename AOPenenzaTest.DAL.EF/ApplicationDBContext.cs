namespace AOPenenzaTest.DAL.EF
{
    using AOPenenzaTest.DAL.EF.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext()
            : base("name=WebAppConnection")
        {
            Database.SetInitializer<ApplicationDBContext>(new SampleData());
        }

        public ApplicationDBContext(string dbConnection) : base(dbConnection)
        {
            Database.SetInitializer<ApplicationDBContext>(new SampleData());
        }

        public DbSet<DbEmployee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationDBConfiguration());
        }
    }
}