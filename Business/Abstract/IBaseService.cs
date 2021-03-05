using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBaseService<S>
    {
        IResult Add(S s);
        IResult Update(S s);
        IResult Delete(S s);
        

    }
}
