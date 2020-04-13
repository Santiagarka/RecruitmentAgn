using AutoMapper;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Web.Models;
using RecruitmentAgency.Web.Models.Account;

namespace RecruitmentAgency.Web
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<RegisterModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<User, UserEditModel>();
            CreateMap<UserEditModel, User>();
            CreateMap<Vacancy, VacancyViewModel>();
            CreateMap<VacancyCreateModel, Vacancy>();
            CreateMap<Candidate, CandidateViewModel>();
            CreateMap<CandidateCreateModel, Candidate>();
            CreateMap<Candidate, CandidateCreateModel>();
        }
    }
}
