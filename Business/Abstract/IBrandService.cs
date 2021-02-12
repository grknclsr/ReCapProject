﻿using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService:IBaseService<Brand>
    {
        IDataResult<List<Brand>> GetAll();
    }
}