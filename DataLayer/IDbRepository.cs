using Paskaita14.Models;

namespace Paskaita14.DataLayer
{
    public interface IDbRepository
    {
        /// <summary>
        /// Inserts shopping list to database
        /// </summary>
        /// <param name="shoppingList">Shopping list to create</param>
        /// <returns>Inserted shopping list ID</returns>
        int CreateShoppingList(ShoppingList shoppingList);
        ShoppingList GetShoppingListById(int id);
        List<ShoppingList> GetShoppingListsByUserId(int userId);
        void UpdateShoppingList(ShoppingList shoppingList);
        void DeleteShoppingList(int id);
    }
}
