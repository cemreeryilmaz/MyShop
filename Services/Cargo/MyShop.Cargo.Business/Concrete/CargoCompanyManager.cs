using MyShop.Cargo.Business.Abstract;
using MyShop.Cargo.DataAccess.Abstract;
using MyShop.Cargo.Entity.Concrete;

namespace MyShop.Cargo.Business.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal companyDal)
        {
            _cargoCompanyDal = companyDal;
        }

        public void TDelete(int id)
        {
            _cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanyDal.Update(entity);
        }
    }
}
