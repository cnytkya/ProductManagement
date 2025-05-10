using ProductManagement.Models.Abstract;
using ProductManagement.Models.Interface;
using Newtonsoft.Json;

namespace ProductManagement.Data
{
    public class GenericRepository<T> : IGenericRepository<T>where T : BaseEntity, IEntity
    {
        private readonly string _filePath;

        public GenericRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public void Create(T entity)
        {
            var allItems = GetAll();
            entity.Id = allItems.Any() ? allItems.Max(x => x.Id) + 1 : 1;
            allItems.Add(entity);
            SaveAll(allItems);
        }

        public void Update(T entity)
        {
            var allItems = GetAll();
            var index = allItems.FindIndex(x => x.Id == entity.Id);
            if (index != -1)
            {
                allItems[index] = entity;
                SaveAll(allItems);
            }
        }

        public void Delete(int id)
        {
            var allItems = GetAll();
            var item = allItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                allItems.Remove(item);
                SaveAll(allItems);
            }
        }

        private void SaveAll(List<T> items)
        {
            var json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
