using System.Collections.Generic;
using System.Linq;
using FoodAPICore.DatabaseContext;
using FoodAPICore.Models;

namespace FoodAPICore.Repositories.FoodEfCore
{
    public class FoodEfCoreRepository : IFoodRepository
    {
        private readonly FoodDbContext _foodDbContext;

        public FoodEfCoreRepository(FoodDbContext foodDbContext)
        {
            _foodDbContext = foodDbContext;
        }

        public FoodItem GetSingle(int id)
        {
            return _foodDbContext.FoodItems.FirstOrDefault(x => x.Id == id);
        }

        public FoodItem Add(FoodItem item)
        {
            _foodDbContext.FoodItems.Add(item);
            _foodDbContext.SaveChanges();
            return GetSingle(item.Id);
        }

        public void Delete(int id)
        {
            FoodItem foodItem = GetSingle(id);
            _foodDbContext.FoodItems.Remove(foodItem);
            _foodDbContext.SaveChanges();
        }

        public FoodItem Update(int id, FoodItem item)
        {
            FoodItem existingFoodItem = GetSingle(id);
            _foodDbContext.FoodItems.Update(existingFoodItem);

            existingFoodItem.Id = item.Id;
            existingFoodItem.Calories = item.Calories;
            existingFoodItem.Name = item.Name;

            _foodDbContext.SaveChanges();
            return GetSingle(id);
        }

        public ICollection<FoodItem> GetAll()
        {
            return _foodDbContext.FoodItems.ToList();
        }

        public int Count()
        {
            return _foodDbContext.FoodItems.Count();
        }
    }
}
