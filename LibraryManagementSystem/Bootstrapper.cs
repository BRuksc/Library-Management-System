using Autofac;
using Autofac.Core;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.UI;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public static class Bootstrapper
    {
        public static Autofac.IContainer Container { get; }

        public static void Run(Autofac.IContainer container)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WindowGuidContainer>().SingleInstance();
            container = builder.Build();

            ResolveSingletons(container);
        }

        private static void ResolveSingletons(Autofac.IContainer container)
        {
            container.Resolve<WindowGuidContainer>();
        }
    }
}
