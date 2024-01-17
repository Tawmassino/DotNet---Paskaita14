namespace Paskaita14.DTOs
{
    public class CreateShoppingListDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<ShoppingListItemDTO> Items { get; set; }


    }
}
