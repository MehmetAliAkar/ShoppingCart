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
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
            
        }
    }
}
