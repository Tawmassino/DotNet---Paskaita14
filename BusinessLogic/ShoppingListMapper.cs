using Paskaita14.DTOs;
using Paskaita14.Models;

namespace Paskaita14.BusinessLogic
{
    public interface IShoppingListMapper
    {
        ShoppingList Map(CreateShoppingListDTO shoppingListDTO, int userId);
    }

    public class ShoppingListMapper : IShoppingListMapper
    {
        public ShoppingList Map(CreateShoppingListDTO shoppingListDTO, int userId)
        {
            return new ShoppingList
            {
                Title = shoppingListDTO.Title,
                UserId = userId,
                Description = shoppingListDTO.Description,

                Items = shoppingListDTO.Items.Select(x => new ShoppingListItem
                {
                    Title = x.Title,
                    Quantity = x.Quantity
                }).ToList()
            };
        }
    }
}
