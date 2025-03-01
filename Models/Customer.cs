using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Customer
{
  public int Id { get; set; }
  public string userId { get; set; }
  public PaymentType PaymentType { get; set; }
  public Cart Cart { get; set; }
  public Order Order { get; set; }
}
