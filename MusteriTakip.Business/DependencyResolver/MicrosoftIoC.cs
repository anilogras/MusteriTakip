using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MusteriTakip.Business.Concrete;
using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;

namespace MusteriTakip.Business.DependencyResolver
{
    public static class MicrosoftIoC
    {
        public static void AddCustomDependencies(this IServiceCollection services)
        {

            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;                
                opt.Lockout.MaxFailedAccessAttempts = 0;

                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MusteriTakipContext>();


            services.AddDbContext<MusteriTakipContext>();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

            services.AddScoped<ICariAdresService, CariAdresManager>();
            services.AddScoped<ICariAdresDal, CariAdresRepository>();

            services.AddScoped<ICariService, CariManager>();
            services.AddScoped<ICariDal, CariRepository>();

            services.AddScoped<ICariVdService, CariVdManager>();
            services.AddScoped<ICariVdDal, CariVdRepository>();

            services.AddScoped<IFisOzellikService, FisOzellikManager>();
            services.AddScoped<IFisOzellikDal, FisOzellikRepository>();

            services.AddScoped<IFisService, FisManager>();
            services.AddScoped<IFisDal, FisRepository>();

            services.AddScoped<IKDVService, KDVManager>();
            services.AddScoped<IKDVDal, KDVRepository>();

            services.AddScoped<IRoleServices, AppRoleManager>();

            services.AddScoped<IUserServices, UserManager>();
            services.AddScoped<IUserDal, UserRepository>();


            services.AddScoped<IIlService, IlManager>();
            services.AddScoped<IIlDal, IlRepository>();

            services.AddScoped<IIlceService, IlceManager>();
            services.AddScoped<IIlceDal, IlceRepository>();

            services.AddScoped<ICariCepService, CariCepManager>();
            services.AddScoped<ICariCepDal, CariCepRepository>();

            services.AddScoped<ICariEMailService, CariEMailManager>();
            services.AddScoped<ICariEMailDal, CariEMailRepository>();

            services.AddScoped<ICariFaxService, CariFaxManager>();
            services.AddScoped<ICariFaxDal, CariFaxRepository>();

            services.AddScoped<ICariTelefonService, CariTelefonManager>();
            services.AddScoped<ICariTelefonDal, CariTelefonRepository>();

            services.AddScoped<ICariWebSiteService, CariWebSiteManager>();
            services.AddScoped<ICariWebSiteDal, CariWebSiteRepository>();

            services.AddScoped<IAlertifyMessages, AlertifyMessages>();
        }

    }
}
