using RecruitmentAgency.Core.Entities;
using System;
using System.Collections.Generic;

namespace RecruitmentAgency.Web.Models
{
    public class VacancyViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Срок
        /// </summary>
        public DateTime Term { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Требования
        /// </summary>
        public string Requirements { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Активность
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        public List<Skill> Skills {get;set;}
    }

}
