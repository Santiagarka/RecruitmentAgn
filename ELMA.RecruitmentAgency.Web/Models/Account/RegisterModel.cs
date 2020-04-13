using System.ComponentModel.DataAnnotations;

namespace RecruitmentAgency.Web.Models.Account
{

    /// <summary>
    /// Модель для регистрации пользователя
    /// </summary>
    public class RegisterModel
    {

        public static RegisterModel New
        {
            get { return new RegisterModel(); }
        }

        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "Не указана электронная почта")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
