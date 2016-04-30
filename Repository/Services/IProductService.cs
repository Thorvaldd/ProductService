using DAL.Models;
using System.Collections.Generic;

namespace Repository.Services
{
    public interface IProductService
    {

        List<Products> GetAll();
    }
}
