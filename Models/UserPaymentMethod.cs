using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class UserPaymentMethod
{
  public int Id { get; set; }
  public string UserId { get; set; }
  public int PaymentOptionId { get; set; }
  public List<Order> Orders { get; set; }
  public Cart Cart { get; set; }
  public PaymentOption PaymentOption { get; set; }
}
