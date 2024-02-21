using EssentialUtils.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Utils;

namespace EssentialUtils {
    internal class Program {
        static void Main(string[] args) {
            var dependencyContainer = DependencyContainer.GetInstance();
            dependencyContainer.AddService(new SingletonDependency<Gills>());
            dependencyContainer.AddService(new TransientDependency<Hotel>());
            dependencyContainer.AddService(new SingletonDependency<Ostrich>());
            dependencyContainer.AddService(new TransientDependency<Fish>());
            Hotel h = (Hotel)dependencyContainer.GetService(typeof(Hotel));
            dependencyContainer.GetService(typeof(Hotel));

            Console.ReadLine();
        }
    }
}
