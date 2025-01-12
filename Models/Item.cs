namespace FleamarketApp.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }    
    public string ImageURL { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string SellerId { get; set; }
    public string SellerPhoneNumber { get; set; }

}