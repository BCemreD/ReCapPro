using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        
        IDataResult<List<Product>> GetAll();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetByBrandId(int id);
        IDataResult<List<Product>> GetByColorId(int id);
    }
}
