using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paskaita14.BusinessLogic;
using Paskaita14.DTOs;
using Paskaita14.Models;

namespace Paskaita14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {

        private readonly IShoppingListService _shoppingListService;
        private readonly IShoppingListMapper _shoppingListMapper;
        public ShoppingController(IShoppingListService shoppingListService, IShoppingListMapper shoppingListMapper)
        {
            _shoppingListService = shoppingListService;
            _shoppingListMapper = shoppingListMapper;
        }

        [HttpGet]
        public IActionResult GetAllShoppingLists(int userId)
        {
            var shoppingLists = _shoppingListService.GetUserShoppingLists(userId);
            return Ok(shoppingLists);
        }

        [HttpGet("{id}")]
        public IActionResult GetShoppingListById(int id, int userId)
        {
            var shoppingLists = _shoppingListService.GetShoppingListForUserById(id, userId);
            return Ok(shoppingLists);
        }

        [HttpPost]
        public IActionResult CreateShoppingList(CreateShoppingListDTO shoppingListDto, int userId)
        {
            var shoppingListEntity = _shoppingListMapper.Map(shoppingListDto, userId);
            var shoppingListId = _shoppingListService.CreateShoppingList(shoppingListEntity);
            return Ok(shoppingListId);
        }


        [HttpPut]
        public IActionResult UpdateShoppingList(ShoppingList shoppingList, int userId)
        {
            _shoppingListService.UpdateShoppingListForUser(shoppingList, userId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteShoppingList(int id, int userId)
        {
            _shoppingListService.DeleteShoppingListForUser(id, userId);
            return Ok();
        }
    }
}
