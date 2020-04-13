using System.Collections.Generic;

using RecruitmentAgency.Core.Entities;

namespace RecruitmentAgency.Core.Managers
{
    public interface IVacancyManager
    {
        Vacancy Get(int id);

        ICollection<Vacancy> GetAll();

        Vacancy Create(Vacancy vacancy);

        Vacancy Update(Vacancy vacancy);

        void Delete(int id);

        void CreateProc(Vacancy vacancy);
    }
}
