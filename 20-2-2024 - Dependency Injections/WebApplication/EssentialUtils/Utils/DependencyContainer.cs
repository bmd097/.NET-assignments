using EssentialUtils.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Utils {
    public sealed class DependencyContainer {
        private DependencyContainer() {
            dependencyMap = new Dictionary<object, object>();
        }
        private Dictionary<object, object> dependencyMap;
        private static DependencyContainer obj;
        private static object objLock = new object();
        public static DependencyContainer GetInstance() {
            if(obj == null) {
                lock(objLock) {
                    if(obj == null) 
                        obj = new DependencyContainer();
                }
            }
            return obj;
        }

        public void AddService<T>(IDependency<T> dependency) {
            if (dependency == null) throw new ArgumentNullException(nameof(dependency));
            Type serviceType = typeof(T);
            dependencyMap[serviceType] = dependency;
        }

        //public object GetService<T>(T type) {
        //    if (!dependencyMap.ContainsKey(type)) {
        //        throw new Exception("Bad Dependency Ask!");
        //    }

        //    if (type.Equals(typeof(Hotel))) {
        //        var dependency = (IDependency<Hotel>)dependencyMap[type];
        //        return dependency.Generate();
        //    } else if (type.Equals(typeof(Ostrich))) {
        //        var dependency = (IDependency<Ostrich>)dependencyMap[type];
        //        return dependency.Generate();
        //    } else if (type.Equals(typeof(Fish))) {
        //        var dependency = (IDependency<Fish>)dependencyMap[type];
        //        return dependency.Generate();
        //    } else if (type.Equals(typeof(Gills))) {
        //        var dependency = (IDependency<Gills>)dependencyMap[type];
        //        return dependency.Generate();
        //    }
        //    throw new Exception("Bad Type!");

        //}

        public object GetService(Type type) {
            if (!dependencyMap.ContainsKey(type)) {
                throw new Exception("Bad Dependency Ask!");
            }
            var dependencyMethod = typeof(IDependency<>)
                .MakeGenericType(type)
                .GetMethod("Generate");
            return dependencyMethod == null ? 
                throw new Exception("Bad Type!") : 
                dependencyMethod.Invoke(dependencyMap[type], null);
        }

    }
}