using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class OrderItem
{
  public int Id { get; set; }
  public int OrderId { get; set; }
  public int ProductId { get; set; }
  public int Quantity { get; set; }
  public string SellerId { get; set; }
  public List<Product> Products { get; set; }
}
