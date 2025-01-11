using System.Net.Http.Headers;
using FleamarketApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleamarketApp.Controllers;
public class ItemController : Controller
{
    private readonly AppDbContext _context;

    public ItemController(AppDbContext context)
    {
        _context = context;
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
    public IActionResult CreateListing()
    {
        Item newItem = new Item();
        return View(newItem);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateListing(Item item)
    {
        // validate
        if(!ModelState.IsValid)
            return View(item);

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