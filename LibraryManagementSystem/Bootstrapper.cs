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
using System.Reflection;
using System.Windows;
using LibraryManagementSystem.Data.DataModels;

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
                try
                {
                    var builder = new ContainerBuilder();

                    builder.RegisterType<WindowGuidContainer>().As<IWindowGuidContainer>()
                        .SingleInstance();
                    builder.RegisterType<AddingTestCollectionData>().As<IAddingTestCollectionData<LibDataModel>>().SingleInstance();
                    builder.RegisterType<WindowPointer>().As<IWindowPointing>();
                    builder.RegisterType<WindowPointersCollection<IWindowPointing>>()
                        .SingleInstance();
                    builder.RegisterType<CommandsCreator>().As<ICommandsCreating>()
                        .SingleInstance();

                    RegisterAssembly(ref builder);

                    container = builder.Build();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void RegisterAssembly(ref ContainerBuilder builder)
        {
            
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}
