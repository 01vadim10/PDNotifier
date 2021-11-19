using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PDNotifier.Tests
{
    public abstract class UnitTests
    {
        public ILifetimeScope BeginScope()
        {
            var builder = new ContainerBuilder();
            var ass = Assembly.GetAssembly(typeof(Dashboard));

            // register publish interfaces
            builder.RegisterAssemblyTypes(ass)
              .AsClosedTypesOf(typeof(ISend<>))
              .SingleInstance();

            // register subscribers
            builder.RegisterAssemblyTypes(ass)
              .Where(t =>
                t.GetInterfaces()
                  .Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IHandle<>)))
              .PropertiesAutowired()
              .OnActivated(act =>
              {
                  var instanceType = act.Instance.GetType();
                  var interfaces = instanceType.GetInterfaces();
                  foreach (var i in interfaces)
                  {
                      if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandle<>))
                      {
                          var arg0 = i.GetGenericArguments()[0];
                          var senderType = typeof(ISend<>).MakeGenericType(arg0);
                          var allSenderTypes = typeof(IEnumerable<>).MakeGenericType(senderType);
                          var allServices = act.Context.Resolve(allSenderTypes);
                          foreach (var service in (IEnumerable)allServices)
                          {
                              var eventInfo = service.GetType().GetEvent("OnChange");
                              var handleMethod = instanceType.GetMethod("Handle");
                              var handler = Delegate.CreateDelegate(
                          eventInfo.EventHandlerType, null, handleMethod);
                              eventInfo.AddEventHandler(service, handler);
                              var namePropInfo = instanceType.GetProperty("Name");
                          }
                      }
                  }
              })
              .SingleInstance()
              .AsSelf();
            //builder.Register(c => )
            
            return builder.Build();
        }
    }
}
