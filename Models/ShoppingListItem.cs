using System.ComponentModel.DataAnnotations.Schema;

namespace Paskaita14.Models
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int Order { get; set; }




        public int ShoppingListId { get; set; }

        [ForeignKey("ShoppingListId")]

        public ShoppingList ShoppingList { get; set; }
    }
}
