using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Utils {
    public class SingletonDependency<T> : IDependency<T> {
        private T instance;
        private static object objLock;

        public SingletonDependency(T instance) {
            objLock = new object();
            this.instance = instance;
        }

        public SingletonDependency() {
            objLock = new object();
            this.instance = default(T);
        }

        public T Generate() {
            if(this.instance == null) {
                lock (objLock) {
                    if (this.instance == null) {
                        if (typeof(T).IsClass && !typeof(T).IsAbstract) {
                            var constructors = typeof(T).GetConstructors();
                            if (constructors.Length > 0) {
                                var constructor = constructors[0];
                                var parameters = constructor.GetParameters();
                                var parameterValues = new object[parameters.Length];
                                for (int i = 0; i < parameters.Length; i++) {
                                    parameterValues[i] = DependencyContainer.GetInstance().GetService(parameters[i].ParameterType);
                                }
                                this.instance = (T)constructor.Invoke(parameterValues);
                            } else {
                                throw new NotSupportedException($"No public constructors found for type {typeof(T)}");
                            }
                        } else { throw new NotSupportedException(); }
                    }
                }
            }
            return instance;
        }

    }
}