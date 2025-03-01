using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Product
{
  public int Id { get; set; }
  public string Name { get; set; }
  public bool IsAvailable { get; set; }
  public int Price { get; set; }
  public string Image { get; set; }
  public string Description { get; set; }
  public int Quantity { get; set; }
  public int CategoryId { get; set; }
  public int StoreId { get; set; }
  public CartItem CartItem { get; set; }
}
