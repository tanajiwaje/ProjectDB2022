using System.Web.Http;
using Unity;
using Unity.WebApi;
using ProjectDatabaseOperation;
using DatabaseOperationServices.Implementaion;
using DatabaseOperationServices.Interface;
using DatabaseOperationServices.Implementation;

namespace ProjectDB2022
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            container.RegisterType<ITopicService,TopicService>();
            container.RegisterType<ITopicContentService,TopicContentService>();
            container.RegisterType<IPostcategorieService,PostcategorieService>();
            container.RegisterType<ICityService,CityService>();
            container.RegisterType<ILocationService,LocationService>();
            container.RegisterType<IQualificationService,QualificationService>();
            container.RegisterType<ISpecilizationService,SpecilizationService>();
            container.RegisterType<IRoleService,RoleService>();
            container.RegisterType<IGenderService,GenderService>();
            container.RegisterType<IDesignationService,DesignationService>();
            container.RegisterType<IUserDetailService,UserDetailService>();
            container.RegisterType<IUserQualificationService,UserQualificationService>();
            //container.RegisterType<IExperienceDetailService,ExperienceDetailService>();
            container.RegisterType<IUserExpertise, UserExpertise>();
            container.RegisterType<IUserProfessionalExperinceService,UserProfessionalExperinceService>();
            container.RegisterType<IStateService, StateService>();
            container.RegisterType<IUserposts, UserPost>();
            container.RegisterType<IPostLikesDislikes, PostLikesDislikes>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}