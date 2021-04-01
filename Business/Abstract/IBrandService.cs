﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null);
        Brand Get(Expression<Func<Brand, bool>> filter);
    }
}
