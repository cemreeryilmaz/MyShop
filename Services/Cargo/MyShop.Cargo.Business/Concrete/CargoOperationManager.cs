using MyShop.Cargo.Business.Abstract;
using MyShop.Cargo.DataAccess.Abstract;
using MyShop.Cargo.Entity.Concrete;

namespace MyShop.Cargo.Business.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        ICargoOperationDal _cargoOperationDal;
        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
           return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
