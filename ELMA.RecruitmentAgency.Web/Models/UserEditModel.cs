using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentAgency.Web.Models
{
    public class UserEditModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login
        {
            get;
            set;
        }

        /// <summary>
        /// Электронная почта
        /// </summary>
        [DisplayName("Электронная почта")]
        [Required]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Роль
        /// </summary>
        [DisplayName("Роль")]
        public int? RoleId
        {
            get;
            set;
        }
    }
}
