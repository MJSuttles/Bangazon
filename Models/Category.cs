using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Bangazon.Models;

public class Category
{
  public int Id { get; set; }
  public string Title { get; set; }
  public List<Product> Products { get; set; }
}
