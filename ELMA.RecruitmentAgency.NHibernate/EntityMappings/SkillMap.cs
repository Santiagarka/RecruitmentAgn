using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using RecruitmentAgency.Core.Entities;

namespace RecruitmentAgency.NHibernate.EntityMappings
{
    public class SkillMap: ClassMapping<Skill>
    {
        public SkillMap()
        {
            Id(property => property.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Type(NHibernateUtil.Int32);
                mapper.Column("Id");
            });

            Property(property => property.Name, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Set(property => property.Vacancies, collectionMapping =>
            {
                collectionMapping.Key(k => k.Column("SkillId"));
                collectionMapping.Table("Vacancies_Skills");
               
            },
            mapping => {
                mapping.ManyToMany(m => m.Column("VacancyId"));
                }
            );

            Set(property => property.Candidates, collectionMapping =>
            {
                collectionMapping.Key(k => k.Column("SkillId"));
                collectionMapping.Table("Candidates_Skills");

            },
            mapping => {
                mapping.ManyToMany(m => m.Column("CandidateId"));
            }
            );

            Table(Skill.TableName);
        }
    }
}
