using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Cart
{
  public int Id { get; set; }
  public string UserId { get; set; }
  public int UserPaymentMethod { get; set; }
  public CartItem CartItem { get; set; }
  public User User { get; set; }
  public UserPaymentMethod UserPaymentMethod { get; set; }
}
