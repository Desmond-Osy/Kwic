using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public interface IFilter<T>
    {
        T Execute(T input);
    }
}
