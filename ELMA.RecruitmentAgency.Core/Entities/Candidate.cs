using RecruitmentAgency.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Entities
{

    /// <summary>
    /// Кандидат
    /// </summary>
    public class Candidate : Entity
    {

        /// <summary>
        /// Название таблицы
        /// </summary>
        public const string TableName = "Candidates";

        /// <summary>
        /// ФИО
        /// </summary>
        public virtual string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public virtual DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Опыт работы (количество лет)
        /// </summary>
        public virtual int Experience { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public virtual string FotoURL { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        public virtual IEnumerable<Skill> Skills{get;set;}

        /// <summary>
        /// Ожидаемая зарплата
        /// </summary>
        public virtual decimal Salary { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        public virtual User Creator { get; set; }

        public Candidate()
        {
            Skills = new List<Skill>();
        }
    }
}
