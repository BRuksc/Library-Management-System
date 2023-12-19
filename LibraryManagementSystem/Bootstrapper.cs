using Autofac;
using Autofac.Core;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.WindowsPointing;
using LibraryManagementSystem.WindowsPointing.Interfaces;

namespace LibraryManagementSystem
{
    public static class Bootstrapper
    {
        private static Autofac.IContainer? container;
        public static Autofac.IContainer Container
        {
            get
            {
                if (container == null)
                {
                    Run();
                }

                return container;
            }
        }

        public static void Run()
        {
            if (container == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<WindowGuidContainer>().As<IWindowGuidContainer>().
                    SingleInstance();
                builder.RegisterType<WindowPointersCollection>().SingleInstance();

                container = builder.Build();
            }
        }
    }
}
