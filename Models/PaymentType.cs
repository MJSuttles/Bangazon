using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class PaymentType
{
  public int Id { get; set; }
  public string Type { get; set; }
  public string CustomerId { get; set; }
  public Cart Cart { get; set; }
}
