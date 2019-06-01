namespace AOPenenzaTest.DAL.EF.Entities
{
    public class DbEmployee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
    }
}
