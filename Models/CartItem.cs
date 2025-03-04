using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class CartItem
{
  public int Id { get; set; }
  public int CartId { get; set; }
  public int ProductId { get; set; }
  public int Quantity { get; set; }
  public Product Product { get; set; }
}
