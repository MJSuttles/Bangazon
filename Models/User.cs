using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Bangazon.Models;

public class User
{
  [Key]
  public string Uid { get; set; }  // ✅ Firebase UID as primary key

  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  public string Zip { get; set; }

  public List<Order> Orders { get; set; } = new List<Order>();  // ✅ Ensure non-null List
  public List<UserPaymentMethod> UserPaymentMethods { get; set; } = new List<UserPaymentMethod>();
}
