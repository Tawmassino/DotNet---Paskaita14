using System.ComponentModel.DataAnnotations.Schema;

namespace Paskaita14.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }



        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }


        public List<ShoppingListItem> Items { get; set; }
       
    }
}
