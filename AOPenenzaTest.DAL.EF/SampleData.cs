using AOPenenzaTest.DAL.EF.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace AOPenenzaTest.DAL.EF
{
    public class SampleData : DropCreateDatabaseAlways<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            // Добавление пользователей           
            List<DbEmployee> employees = new List<DbEmployee>
            {
                new DbEmployee{LastName = "Абрамов", FirstName = "Адам", Patronymic = "Матвеевич", Age = 30},
                new DbEmployee{LastName = "Кузнецов", FirstName = "Матвей", Patronymic = "Ярославович", Age = 23},
                new DbEmployee{LastName = "Филиппова", FirstName = "Рената", Patronymic = "Ильинична ", Age =32},
                new DbEmployee{LastName = "Ильин", FirstName = "Макар", Patronymic = "Валерьевич", Age = 24},
                new DbEmployee{LastName = "Ичёткина", FirstName = "Милана", Patronymic = "Кирилловна", Age =42},
                new DbEmployee{LastName = "Андреев", FirstName = "Евсей", Patronymic = "Андреевич", Age = 53},
                new DbEmployee{LastName = "Кондратьева", FirstName = "Василиса", Patronymic = "Валерьевна", Age =19},
                new DbEmployee{LastName = "Тарская", FirstName = "Маргарита", Patronymic = "Станиславовна", Age = 36},
                new DbEmployee{LastName = "Дидиченко", FirstName = "Олег", Patronymic = "Георгиевич", Age =99},
                new DbEmployee{LastName = "Недашковская", FirstName = "Любава", Patronymic = "Петровна", Age = 32},
                new DbEmployee{LastName = "Никитина", FirstName = "Аполлинария", Patronymic = "Георгиевна", Age = 24},
                new DbEmployee{LastName = "Гусева", FirstName = "Мальвина", Patronymic = "Леонидовна", Age =32},
                new DbEmployee{LastName = "Никифоров", FirstName = "Парамон", Patronymic = "Тимофеевич", Age = 23},
                new DbEmployee{LastName = "Романова", FirstName = "Милана", Patronymic = "Яковлевна", Age =45},
                new DbEmployee{LastName = "Баженов", FirstName = "Виссарион", Patronymic = "Владимирович", Age = 56},
                new DbEmployee{LastName = "Николаев", FirstName = "Мечислав", Patronymic = "Валерьев", Age =17},
                new DbEmployee{LastName = "Орлова", FirstName = "Маргарита", Patronymic = "Тимофеевна", Age = 32},
                new DbEmployee{LastName = "Быков", FirstName = "Олег", Patronymic = "Дмитриевич", Age =90},

            };

            foreach (var item in employees)
            {
                context.Employees.Add(item);
            }

            context.SaveChanges();
            base.Seed(context);

        }

    }
}
