using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseManager<S>
    {
        void Add(S s);
        void Update(S s);
        void Delete(S s);
        List<S> GetAll();

    }
}
