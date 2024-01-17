using Paskaita14.DataLayer;
using Paskaita14.Models;

namespace Paskaita14.BusinessLogic
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IDbRepository _dbRepository;

        public ShoppingListService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }



        public int CreateShoppingList(ShoppingList shoppingList)
        {
            return _dbRepository.CreateShoppingList(shoppingList);
        }

        public void DeleteShoppingListForUser(int id, int userId)
        {
            var shoppingList = _dbRepository.GetShoppingListById(id);
            if (shoppingList == null)
            {
                throw new Exception("Shopping List not found");
            }
            if (shoppingList.UserId != userId)
            {
                throw new Exception("User is trying to delete foreign shopping list");
            }
            _dbRepository.DeleteShoppingList(id);
        }

        public ShoppingList GetShoppingListForUserById(int id, int userId)
        {
            var shoppingList = _dbRepository.GetShoppingListById(id);
            if (shoppingList == null)
            {
                throw new Exception("Shopping List not found");
            }
            if (shoppingList.UserId != userId)
            {
                throw new Exception("User is trying to get foreign shopping list");
            }

            return shoppingList;
        }

        public List<ShoppingList> GetUserShoppingLists(int userId)
        {
            return _dbRepository.GetShoppingListsByUserId(userId);
        }

        public void UpdateShoppingListForUser(ShoppingList shoppingList, int userId)
        {
            var shoppingListFromDB = _dbRepository.GetShoppingListById(shoppingList.Id);//ziuri ar gero userio
            if (shoppingListFromDB == null)
            {
                throw new Exception("Shopping List not found");
            }
            if (shoppingListFromDB.UserId != userId)
            {
                throw new Exception("User is trying to update foreign shopping list");
            }
            _dbRepository.UpdateShoppingList(shoppingList);

        }
    }
}
