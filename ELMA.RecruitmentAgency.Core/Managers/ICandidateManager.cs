using System.Collections.Generic;

using RecruitmentAgency.Core.Entities;

namespace RecruitmentAgency.Core.Managers
{
    public interface ICandidateManager
    {
        Candidate Get(int id);

        ICollection<Candidate> GetAll();

        Candidate Create(Candidate candidate);

        Candidate Update(Candidate candidate);

        void Delete(int id);
    }
}
