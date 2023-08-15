using GymWeb.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GymWeb.Models;

public class Members
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public DateTime Birthday { get; set; }
    public string? Email { get; set; }
    public DateTime Registration { get; set; }
   
    public string? IsDeleted { get; set; }
}