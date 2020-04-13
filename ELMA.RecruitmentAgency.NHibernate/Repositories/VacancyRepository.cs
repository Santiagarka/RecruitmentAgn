using NHibernate;
using NHibernate.Transform;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;
using System;
using System.Linq;

namespace RecruitmentAgency.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="Vacancy"/>
    /// </summary>
    public class VacancyRepository : NHRepositoryBase<Vacancy, int>, IVacancyRepository
    {
        /// <summary>
        /// Конструктор экземпляра <see cref="VacancyRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public VacancyRepository(ISession session) 
            : base(session)
        {
        }

        public void CreateProc(Vacancy entity)
        {
            //var stringSkills = string.Join("|", entity.Skills.Select(s => s.Id).ToList());
            Session.CreateSQLQuery("EXEC [dbo].[CreateVacancy] :Name, :Description, :Term, :Company, :Requirements, :Salary, :CreatorId, :StringSkills")
                .SetParameter<string>("Name", entity.Name)
                .SetParameter<string>("Description", entity.Description)
                .SetParameter<DateTime>("Term", entity.Term)
                .SetParameter<string>("Company", entity.Company)
                .SetParameter<string>("Requirements", entity.Requirements)
                .SetParameter<decimal>("Salary", entity.Salary)
                .SetParameter<int>("CreatorId", entity.Creator.Id)
                .SetParameter<string>("StringSkills", string.Join("|", entity.Skills.Select(s => s.Id).ToList()))
                .SetResultTransformer(Transformers.AliasToBean(typeof(Vacancy)))
                .UniqueResult<Vacancy>();
        }
    }
}
