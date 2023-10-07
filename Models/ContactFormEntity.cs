using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Crito.Models;
public class ContactFormEntity
{
    public Guid Id { get; set; } 
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime Created { get; set; } 

}
