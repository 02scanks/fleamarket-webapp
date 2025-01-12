using System.Net.Http.Headers;
using FleamarketApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleamarketApp.Controllers;
public class ItemController : Controller
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;

    public ItemController(AppDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    // Returns a view displaying all items available for sale
    [Route("marketplace")]
    public async Task<IActionResult> Dashboard()
    {
        var marketplaceItems = await _context.GlobalItems.ToListAsync();
        return View(marketplaceItems);
    }


    // Returns a view where the user can list a new item for sale
    [Route("create")]
    [Authorize]
    public async Task<IActionResult> CreateListing()
    {
        Item newItem = new Item();
        return View(newItem);
    }

    [HttpPost]
    [Authorize]
    [Route("create")]
    public async Task<IActionResult> CreateListing(Item item, string username)
    {
        // validate
        if(!ModelState.IsValid)
            return View(item);

        User currentUser = await _userRepository.GetUserByUsernameAsync(username);
        item.SellerPhoneNumber = currentUser.PhoneNumber;
        
        // add to db
        await _context.GlobalItems.AddAsync(item);
        await _context.SaveChangesAsync();

        return RedirectToAction("ItemDetail", new {id = item.Id});
    }

    [Route("item")]
    public async Task<IActionResult> ItemDetail(int id)
    {
        var item = await _context.GlobalItems
            .FirstOrDefaultAsync(i => i.Id == id);

        return View(item);
    }

    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> Search(string query)
    {
        var queriedItems = await _context.GlobalItems
            .Where(i => i.Name.ToLower().Contains(query.ToLower()))
            .ToListAsync();

        return View(queriedItems);
    }
}