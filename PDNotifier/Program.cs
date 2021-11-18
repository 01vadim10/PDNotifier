using Autofac;
using Autofac.Features.Variance;
using System;

namespace PDNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterEventing();
            Console.WriteLine("Hello World!");
        }
    }
}
