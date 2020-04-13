using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using RecruitmentAgency.Core.Entities;

namespace RecruitmentAgency.NHibernate.EntityMappings
{
    /// <summary>
    /// Маппинг сущности <see cref="Candidate"/>
    /// </summary>
    public class CandidateMap : ClassMapping<Candidate>
    {
        public CandidateMap()
        {
            Id(property => property.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Type(NHibernateUtil.Int32);
                mapper.Column("Id");
            });

            Property(property => property.FIO, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.DateOfBirth, mapping =>
            {
                mapping.Type(NHibernateUtil.DateTime);
                mapping.NotNullable(true);
            });

            Property(property => property.Experience, mapping =>
            {
                mapping.Type(NHibernateUtil.Int32);
                mapping.NotNullable(true);
            });

            Property(property => property.FotoURL, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(false);
            });

            Property(property => property.Salary, mapping =>
            {
                mapping.Type(NHibernateUtil.Decimal);
                mapping.NotNullable(true);
            });

            ManyToOne(property => property.Creator, mapping =>
            {
                mapping.Column("CreatorId");
                mapping.NotNullable(true);
            });

            Set(property => property.Skills, collectionMapping =>
            {
                collectionMapping.Key(k => k.Column("CandidateId"));
                collectionMapping.Table("Candidates_Skills");
                collectionMapping.Cascade(Cascade.All);
            },
            mapping => {
                mapping.ManyToMany(m => m.Column("SkillId"));
            }
            );

            Table(Candidate.TableName);
        }
    }
}
