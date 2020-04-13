using RecruitmentAgency.NHibernate.Repositories;
using RecruitmentAgency.Core.Repositories;
using RecruitmentAgency.NHibernate;

using Microsoft.Extensions.DependencyInjection;

using NHibernate.Mapping.ByCode;

using NHibernate.Cfg;
using NHibernate.Dialect;
using RecruitmentAgency.Core.Managers;
using RecruitmentAgency.Core.Managers.Impls;

namespace RecruitmentAgency.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecruitmentAgencyCore(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IVacancyManager, VacancyManager>();
            services.AddScoped<ICandidateManager, CandidateManager>();
            services.AddScoped<ISkillManager, SkillManager>();

            return services;
        }

        public static IServiceCollection AddRecruitmentAgencyNHibernate(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(RecruitmentAgencyNHibernateModule).Assembly.ExportedTypes);
            var mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionString;
            });
            configuration.AddMapping(mappings);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            return services;
        }
    }
}
