﻿using System;
using DryIoc;
using Networker.Interfaces;

namespace Networker.Common
{
    public class DryIocContainer : IContainerIoc
    {
        public readonly Container Container;

        public DryIocContainer()
        {
            this.Container = new Container();
        }

        public void RegisterSingleton<T>(T instance)
        {
            this.Container.RegisterInstance(instance);
        }

        public void RegisterSingleton<T>()
        {
            this.Container.Register<T>(Reuse.Singleton);
        }

        public void RegisterType<TImplementation>()
        {
            this.Container.Register<TImplementation>();
        }

        public void RegisterType<TService, TImplementation>()
            where TImplementation: TService
        {
            this.Container.Register<TService, TImplementation>();
        }

        public void RegisterType<TService, TImplementation>(IocReuse reuse)
            where TImplementation: TService
        {
            switch(reuse)
            {
                case IocReuse.Singleton:
                    this.Container.Register<TService, TImplementation>(Reuse.Singleton);
                    break;
                default:
                    this.Container.Register<TService, TImplementation>();
                    break;
            }
        }

        public void RegisterType<TImplementation>(IocReuse reuse)
        {
            switch(reuse)
            {
                case IocReuse.Singleton:
                    this.Container.Register<TImplementation>(Reuse.Singleton);
                    break;
                default:
                    this.Container.Register<TImplementation>();
                    break;
            }
        }

        public void RegisterType(Type type)
        {
            this.Container.Register(type);
        }

        public T Resolve<T>()
        {
            return this.Container.Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            return this.Container.Resolve<T>(type);
        }

        public void VerifyResolutions()
        {
            this.Container.VerifyResolutions();
        }
    }
}