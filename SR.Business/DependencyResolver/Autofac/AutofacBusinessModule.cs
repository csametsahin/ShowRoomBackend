﻿using Autofac;
using SR.Business.Abstract;
using SR.Business.Concrete;
using SR.Core.Utilities.Localization;
using SR.DataAccess.Abstract;
using SR.DataAccess.Concrete.EntityFramework;

namespace SR.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<PlanManager>().As<IPlanService>();
            builder.RegisterType<EfPlanDal>().As<IPlanDal>();
            builder.RegisterType<ShowRoomManager>().As<IShowRoomService>();
            builder.RegisterType<EfShowRoomDal>().As<IShowRoomDal>();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>();
            builder.RegisterType<EfShowRoomImagesDal>().As<IShowRoomImagesDal>();
            builder.RegisterType<LocalizationService>().As<ILocalizationService>();
        }
    }
}
