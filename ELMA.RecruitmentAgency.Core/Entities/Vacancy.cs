using RecruitmentAgency.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Entities
{
    public class Vacancy:Entity
    {
        /// <summary>
        /// Название таблицы
        /// </summary>
        public const string TableName = "Vacancies";

        /// <summary>
        /// Название
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Срок
        /// </summary>
        public virtual DateTime Term { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public virtual string Company { get; set; }

        /// <summary>
        /// Требования
        /// </summary>
        public virtual string Requirements { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public virtual decimal Salary { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// Активность
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        public virtual IEnumerable<Skill> Skills { get; set; }

        public Vacancy()
        {
            Skills = new List<Skill>();
        }


    }
}
