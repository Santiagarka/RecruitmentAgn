using System;
using System.Collections.Generic;

using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;

namespace RecruitmentAgency.Core.Managers.Impls
{
    public class CandidateManager : ICandidateManager
    {
        private readonly ICandidateRepository candidateRepository;

        public CandidateManager (ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public Candidate Create(Candidate candidate)
        {
            return candidateRepository.Create(candidate);
        }

        public void Delete(int id)
        {
            candidateRepository.Delete(id);
        }

        public Candidate Get(int id)
        {
            var candidate = candidateRepository.FirstOrDefault(id);
            return candidate;
        }

        public ICollection<Candidate> GetAll()
        {
            return candidateRepository.GetAllList();
        }

        public Candidate Update(Candidate candidate)
        {
            return candidateRepository.Update(candidate);
        }
    }
}
