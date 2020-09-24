using Autofac;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.Core.Repositories.Abstract;
using System.Reflection;

namespace RecruitmentTask.INFRATRUCTURE.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(Company).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<ICompanyRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
