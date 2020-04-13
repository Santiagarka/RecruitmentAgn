using RecruitmentAgency.Domain.Entities;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Entities
{
    /// <summary>
    /// Скилл
    /// </summary>
    public class Skill: Entity
    {
        /// <summary>
        /// Имя таблицы
        /// </summary>
        public const string TableName = "Skills";

        /// <summary>
        /// Имя
        /// </summary>
        public virtual string Name { get; set; }

        public virtual IEnumerable<Vacancy> Vacancies { get; set; }

        public virtual IEnumerable<Candidate> Candidates { get; set; }

        public Skill()
        {
            Vacancies = new List<Vacancy>();
            Candidates = new List<Candidate>();
        }
    }
}
