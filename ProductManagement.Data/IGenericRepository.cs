namespace ProductManagement.Data
{
	public interface IGenericRepository<T> where T : class
		{
			void Create(T entity);
			void Update(T entity);
			void Delete(int id);
			List<T> GetAll();
			T GetById(int id);
		}
}
