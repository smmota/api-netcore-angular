using Autofac;
using NTec.Application;
using NTec.Application.Interfaces;
using NTec.Application.Mappers;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Core.Interfaces.Services;
using NTec.Domain.Services;
using NTec.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTec.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<SetorApplicationService>().As<ISetorApplicationService>();
            builder.RegisterType<CargoApplicationService>().As<ICargoApplicationService>();
            builder.RegisterType<ColaboradorApplicationService>().As<IColaboradorApplicationService>();
            builder.RegisterType<UsuarioApplicationService>().As<IUsuarioApplicationService>();

            builder.RegisterType<SetorService>().As<ISetorService>();
            builder.RegisterType<CargoService>().As<ICargoService>();
            builder.RegisterType<ColaboradorService>().As<IColaboradorService>();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();

            builder.RegisterType<SetorRepository>().As<ISetorRepository>();
            builder.RegisterType<CargoRepository>().As<ICargoRepository>();
            builder.RegisterType<ColaboradorRepository>().As<IColaboradorRepository>();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();

            builder.RegisterType<SetorMapper>().As<ISetorMapper>();
            builder.RegisterType<CargoMapper>().As<ICargoMapper>();
            builder.RegisterType<ColaboradorMapper>().As<IColaboradorMapper>();
            builder.RegisterType<UsuarioMapper>().As<IUsuarioMapper>();

            #endregion
        }
    }
}
