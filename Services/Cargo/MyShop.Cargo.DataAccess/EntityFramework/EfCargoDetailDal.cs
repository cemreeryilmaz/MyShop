using MyShop.Cargo.DataAccess.Abstract;
using MyShop.Cargo.DataAccess.Concrete;
using MyShop.Cargo.DataAccess.Repositories;
using MyShop.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Cargo.DataAccess.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }
}
