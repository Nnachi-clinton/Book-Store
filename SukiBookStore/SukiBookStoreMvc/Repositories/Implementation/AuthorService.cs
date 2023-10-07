using SukiBookStoreMvc.Models.Domain;
using SukiBookStoreMvc.Repositories.Abstrsct;

namespace SukiBookStoreMvc.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DataBaseContext _dataBaseContext;

        public AuthorService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public bool Add(Author model)
        {
            try
            {

                _dataBaseContext.Author.Add(model);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var data = this.FindById(Id);
                if (data == null)

                    return false;

                _dataBaseContext.Author.Remove(data);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Author FindById(int Id)
        {
            return _dataBaseContext.Author.Find(Id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _dataBaseContext.Author.ToList();
        }

        public bool Update(Author model)
        {
            try
            {

                _dataBaseContext.Author.Update(model);
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
