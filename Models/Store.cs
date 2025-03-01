using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Store
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string SellerId { get; set; }
  public Product Product { get; set; }
}
