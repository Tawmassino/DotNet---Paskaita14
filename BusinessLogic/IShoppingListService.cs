using Paskaita14.Models;

namespace Paskaita14.BusinessLogic
{
    public interface IShoppingListService
    {
        /// <summary>
        /// Inserts shopping list to database
        /// </summary>
        /// <param name="shoppingList">Shoping list to create</param>
        /// <returns>Inserted shopping list ID</returns>
        int CreateShoppingList(ShoppingList shoppingList);
        ShoppingList GetShoppingListForUserById(int id, int userId);
        List<ShoppingList> GetUserShoppingLists(int userId);
        void UpdateShoppingListForUser(ShoppingList shoppingList, int userId);
        void DeleteShoppingListForUser(int id, int userId);
    }
}
