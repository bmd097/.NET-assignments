using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Utils {
    public class TransientDependency<T> : IDependency<T> {
        private static object objLock;

        public TransientDependency() { 
            objLock = new object();
        }

        public T Generate() {
            lock (objLock) {
                if (typeof(T).IsClass && !typeof(T).IsAbstract) {
                    var constructors = typeof(T).GetConstructors();
                    if (constructors.Length > 0) {
                        var constructor = constructors[0];
                        var parameters = constructor.GetParameters();
                        var parameterValues = new object[parameters.Length];
                        for (int i = 0; i < parameters.Length; i++) {
                            parameterValues[i] = DependencyContainer.GetInstance().GetService(parameters[i].ParameterType);
                        }
                        var instance = (T)constructor.Invoke(parameterValues);
                        return instance;
                    } else {
                        throw new NotSupportedException($"No public constructors found for type {typeof(T)}");
                    }
                } else { throw new NotSupportedException(); }
            }
        }
    }
}