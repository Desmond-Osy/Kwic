using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public abstract class PipeLine<T>
    {
        protected readonly List<IFilter<T>> filters = new List<IFilter<T>>();

        ///To Regiser filter in the pipelien
        ///
        public PipeLine<T> Register(IFilter<T> filter)
        {
            filters.Add(filter);
            return this; 
        }

        ///To start processing on the pipeline
        ///
        public abstract T Process(T input);
    }
}
