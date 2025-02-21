using ShoppingCart.Cargo.DataAccessLayer.Abstract;
using ShoppingCart.Cargo.DataAccessLayer.Concrete;
using ShoppingCart.Cargo.DataAccessLayer.Repositories;
using ShoppingCart.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Cargo.DataAccessLayer.EntitiyFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context) 
        {

        }
    }
}
