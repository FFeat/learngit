using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FFeat.Note.Bll;
using FFeat.Note.IBll;
using FFeat.Note.UI.Models;

namespace FFeat.Note.UI.App_Start
{
    public class AutofacConfig
    {
        public static void AutofacRegister()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<LoginCheckFilterAttribute>().PropertiesAutowired().SingleInstance();

            var controllers = Assembly.Load("FFeat.Note.UI");
            builder.RegisterControllers(controllers).PropertiesAutowired();


            var BllName = Assembly.Load("FFeat.Note.Bll");
            builder.RegisterTypes(BllName.GetTypes()).AsImplementedInterfaces();
            var DalName = Assembly.Load("FFeat.Note.Dal");
            builder.RegisterTypes(DalName.GetTypes()).AsImplementedInterfaces();
            var FactoryName = Assembly.Load("FFeat.Note.Factory");
            builder.RegisterTypes(FactoryName.GetTypes()).AsImplementedInterfaces();
            var IBllName = Assembly.Load("FFeat.Note.IBll");
            builder.RegisterTypes(IBllName.GetTypes()).AsImplementedInterfaces();
            var IDalName = Assembly.Load("FFeat.Note.IDal");
            builder.RegisterTypes(IDalName.GetTypes()).AsImplementedInterfaces();

            //builder.RegisterType<ActionInfoService>().As<IActionInfoService>().PropertiesAutowired();
            //builder.RegisterType<RoleInfoService>().As<IRoleInfoService>().PropertiesAutowired();
            //builder.RegisterType<MyActionFilterAttribute>().SingleInstance();
            //builder.RegisterType<LoginCheckFilterAttribute>().SingleInstance();
            //builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }

    }
}