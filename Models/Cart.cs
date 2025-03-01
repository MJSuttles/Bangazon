using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Cart
{
  public int Id { get; set; }
  public string CustomerId { get; set; }
  public int PaymentType { get; set; }
  public CartItem CartItem { get; set; }
  public Order Order { get; set; }
}
