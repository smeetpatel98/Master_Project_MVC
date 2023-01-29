using MastersProject.DataAccessLayer.Area;
using MastersProject.DataAccessLayer.Area.City;
using MastersProject.DataAccessLayer.Area.Class;
using MastersProject.DataAccessLayer.Area.Course;
using MastersProject.DataAccessLayer.Area.StudentList;
using MastersProject.DataAccessLayer.Area.Subject;
using MastersProject.DataAccessLayer.Service.Area.City;
using MastersProject.DataAccessLayer.Service.Area.Class;
using MastersProject.DataAccessLayer.Service.Area.Country;
using MastersProject.DataAccessLayer.Service.Area.Course;
using MastersProject.DataAccessLayer.Service.Area.State;
using MastersProject.DataAccessLayer.Service.Area.StudentList;
using MastersProject.DataAccessLayer.Service.Area.Subject;
using MastersProject.ServiceLayer.ServiceInterface;
using MastersProject.ServiceLayer.ServiceInterface.City;
using MastersProject.ServiceLayer.ServiceInterface.Class;
using MastersProject.ServiceLayer.ServiceInterface.Course;
using MastersProject.ServiceLayer.ServiceInterface.State;
using MastersProject.ServiceLayer.ServiceInterface.StudentList;
using MastersProject.ServiceLayer.ServiceInterface.Subject;
using MastersProject.ServiceLayer.Services.Area;
using MastersProject.ServiceLayer.Services.Area.City;
using MastersProject.ServiceLayer.Services.Area.Class;
using MastersProject.ServiceLayer.Services.Area.Course;
using MastersProject.ServiceLayer.Services.Area.State;
using MastersProject.ServiceLayer.Services.Area.StudentList;
using MastersProject.ServiceLayer.Services.Area.Subject;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MastersProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //repo and service method
            container.RegisterType<ICountry, Country>();
            container.RegisterType<ICountryService, CountryService>();

            container.RegisterType<IState, State>();
            container.RegisterType<IStateService, StateService>();

            container.RegisterType<ICity, City>();
            container.RegisterType<ICityService, CityService>();

            container.RegisterType<ICourse, Course>();
            container.RegisterType<ICourseService, CourseService>();

            container.RegisterType<IClass, Class>();
            container.RegisterType<IClassService, ClassService>();

            container.RegisterType<ISubject, Subject>();
            container.RegisterType<ISubjectService, SubjectService>();

            container.RegisterType<IStudentList, StudentList>();
            container.RegisterType<IStudentListService, StudentListService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}