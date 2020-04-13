using System.Collections.Generic;

using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;

namespace RecruitmentAgency.Core.Managers.Impls
{
    public class VacancyManager : IVacancyManager
    {
        private readonly IVacancyRepository vacancyRepository;

        public VacancyManager(IVacancyRepository vacancyRepository)
        {
            this.vacancyRepository = vacancyRepository;
        }

        public Vacancy Create(Vacancy vacancy)
        {
            return vacancyRepository.Create(vacancy);
        }

        public void Delete(int id)
        {
            vacancyRepository.Delete(id);
        }

        public Vacancy Get(int id)
        {
            var vacancy = vacancyRepository.FirstOrDefault(id);
            return vacancy;
        }

        public ICollection<Vacancy> GetAll()
        {
            return vacancyRepository.GetAllList();
        }

        public Vacancy Update(Vacancy vacancy)
        {
            return vacancyRepository.Update(vacancy);
        }

        public void CreateProc(Vacancy vacancy)
        {
            vacancyRepository.CreateProc(vacancy);
        }
    }
}
