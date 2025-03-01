using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class User
{
  public int Id { get; set; }
  public string Uid { get; set; }
  public string firstName { get; set; }
  public string lastName { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public string City { get; set; }
  public int Zip { get; set; }
  public Seller Seller { get; set; }
  public Customer Customer { get; set; }
}
