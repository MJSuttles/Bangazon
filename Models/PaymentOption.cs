using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bangazon.Models;

public class PaymentOption
{
  public int Id { get; set; }
  public string Type { get; set; }
  public UserPaymentMethod UserPaymentMethod { get; set; }
}
