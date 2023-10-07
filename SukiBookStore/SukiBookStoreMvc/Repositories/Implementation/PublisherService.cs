using SukiBookStoreMvc.Models.Domain;
using SukiBookStoreMvc.Repositories.Abstrsct;

namespace SukiBookStoreMvc.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly DataBaseContext _dataBaseContext;

        public PublisherService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public bool Add(Publisher model)
        {
            try
            {
                _dataBaseContext.Publisher.Add(model);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null) 
                    return false;
                _dataBaseContext.Publisher.Remove(data);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Publisher FindById(int id)
        {
            return _dataBaseContext.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _dataBaseContext.Publisher.ToList(); 
        }

        public bool Update(Publisher model)
        {
            try
            {
                _dataBaseContext.Publisher.Update(model);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
