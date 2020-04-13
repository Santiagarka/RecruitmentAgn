using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentAgency.Web.Models
{
    public class VacancyCreateModel
    {
        /// <summary>
        /// Новый экземпляр
        /// </summary>
        public static VacancyCreateModel New
        {
            get { return new VacancyCreateModel(); }
        }

        /// <summary>
        /// Название
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Срок
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Срок")]
        public DateTime Term { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Компания")]
        public string Company { get; set; }

        /// <summary>
        /// Требования
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Требования")]
        public string Requirements { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        [DisplayName("Скиллы")]
        public IEnumerable<int> SkillsId { get; set; }
    }
}
