using System;
using System.Collections.Generic;
using DAL.Models;
using Repository.Interfaces;
using System.Linq;

namespace Repository.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uof;
        public ProductService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public List<Products> GetAll()
        {
            var result = _uof.Repository<Products>().Get().ToList();
            return result;
        }
    }
}
