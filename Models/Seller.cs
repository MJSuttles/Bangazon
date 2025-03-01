using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Seller
{
  public int Id { get; set; }
  public string userId { get; set; }
  public Store Store { get; set; }
}
