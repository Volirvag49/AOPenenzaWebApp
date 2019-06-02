using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EmployeeViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string FirstName { get; set; }
    
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength( maximumLength:50 ,ErrorMessage = "Длина строки должна быть до 50 символов")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Range(0, 130, ErrorMessage = "Недопустимый Возраст")]
        public int Age { get; set; }
    }
}