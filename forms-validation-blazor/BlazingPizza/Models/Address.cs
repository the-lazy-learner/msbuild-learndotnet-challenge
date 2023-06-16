using System.ComponentModel.DataAnnotations;

namespace BlazingPizza;

public class Address
{
    public int Id { get; set; }

    [Required, MinLength(3, ErrorMessage = "Please use a name longer than 3 letters."), MaxLength(100, ErrorMessage = "Please use a name fewer than 100 letters.")]
    public string? Name { get; set; }

    [Required, MinLength(5, ErrorMessage = "Please use an Address line longer than 5 letters."), MaxLength(100, ErrorMessage = "Please use an Address Line fewer than 100 letters.")]
    public string? Line1 { get; set; }

    [MaxLength(100, ErrorMessage = "Please use an Address line fewer than 100 letters.")]
    public string? Line2 { get; set; }

    [Required, MinLength(3, ErrorMessage = "Please use a city name longer than 3 letters."), MaxLength(50, ErrorMessage = "Please use a city name fewer than 50 letters.")]
    public string? City { get; set; }

    [Required, MinLength(3, ErrorMessage = "Please use a region longer than 3 letters."), MaxLength(20, ErrorMessage = "Please use a region fewer than 20 letters.")]
    public string? Region { get; set; }

    [Required, RegularExpression(@"^([0-9]{5-6})$", ErrorMessage = "Please use a valid postal code with 5 or 6 digits.")]
    public string? PostalCode { get; set; }
}
