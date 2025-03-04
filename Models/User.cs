using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class User
{
  public int Id { get; set; }
  public string Uid { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  public string Zip { get; set; }
  public List<Product> Products { get; set; }
  public List<UserPaymentMethod> UserPaymentMethods { get; set; }
  public List<Order> Orders { get; set; }
  public Cart Cart { get; set; }
}
