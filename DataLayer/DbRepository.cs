using Microsoft.EntityFrameworkCore;
using Paskaita14.Models;

namespace Paskaita14.DataLayer
{
    public class DbRepository : IDbRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbcontext;

        public DbRepository(ShoppingListDbContext shoppingListDbcontext)
        {
            _shoppingListDbcontext = shoppingListDbcontext;
        }



        public int CreateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListDbcontext.ShoppingLists.Add(shoppingList);
            _shoppingListDbcontext.SaveChanges();//tik cia id gauna, iki tol ID neegzistuoja
            return shoppingList.Id;
        }

        public void DeleteShoppingList(int id)
        {
            var shoppingListtoDelete = _shoppingListDbcontext.ShoppingLists.Find(id);
            _shoppingListDbcontext.ShoppingLists.Remove(shoppingListtoDelete);

            //efektyvesnis budas:
            //var shoppingListtoDelete = new ShoppingList { Id = id };
            //_shoppingListDbcontext.ShoppingLists.Attach(shoppingListtoDelete);
            //_shoppingListDbcontext.ShoppingLists.Remove(shoppingListtoDelete);

            _shoppingListDbcontext.SaveChanges();
        }


        public ShoppingList GetShoppingListById(int id)
        {
            return _shoppingListDbcontext.ShoppingLists.Include(s => s.Items).FirstOrDefault(s => s.Id == id);
        }

        public List<ShoppingList> GetShoppingListsByUserId(int userId)
        {
            return _shoppingListDbcontext.ShoppingLists.Include(s => s.Items).Where(x => x.UserId == userId).ToList();
        }

        public void UpdateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListDbcontext.ShoppingLists.Update(shoppingList);
            _shoppingListDbcontext.SaveChanges();
        }
    }
}
