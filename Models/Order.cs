using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class Order
{
  public int Id { get; set; }
  public string CustomerId { get; set; }
  public bool IsComplete { get; set; }
  public int CartId { get; set; }
}
