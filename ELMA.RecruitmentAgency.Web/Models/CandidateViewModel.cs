using RecruitmentAgency.Core.Entities;
using System;
using System.Collections.Generic;

namespace RecruitmentAgency.Web.Models
{
    public class CandidateViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Опыт работы (количество лет)
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public string FotoURL { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        public IEnumerable<Skill> Skills { get; set; }

        /// <summary>
        /// Ожидаемая зарплата
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        public int CreatorId { get; set; }

        public CandidateViewModel()
        {
            Skills = new List<Skill>();
        }
    }
}
