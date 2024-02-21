using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Utils {
    public interface IDependency<T> {
        T Generate();
    }
}
