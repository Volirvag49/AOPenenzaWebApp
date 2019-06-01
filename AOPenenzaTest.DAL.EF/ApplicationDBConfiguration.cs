using AOPenenzaTest.DAL.EF.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AOPenenzaTest.DAL.EF
{
    public class ApplicationDBConfiguration : EntityTypeConfiguration<DbEmployee>
    {
        public ApplicationDBConfiguration()
        {
            ToTable("DbEmployees").HasKey(p => p.Id);

            Property(P => P.FirstName).IsRequired().HasMaxLength(50);
            Property(P => P.LastName).IsRequired().HasMaxLength(50);
            Property(P => P.Patronymic).HasMaxLength(50);
            Property(p => p.Age);
        }
    }
}
