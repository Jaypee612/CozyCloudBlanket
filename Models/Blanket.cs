using System.ComponentModel.DataAnnotations;

namespace CozyCloudBlanket.Models;

public class Blanket
{
    // Properties
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Size { get; set; }
    public required decimal Price { get; set; }
    public required string Material { get; set; }
    public required string Color { get; set; }
}