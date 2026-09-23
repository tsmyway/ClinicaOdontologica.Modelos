using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Models;

[Table("pacientes")]
public class Paciente
{
    [Key]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(10)]
    [Column("dni")]
    public string Dni { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(50)]
    [Column("nombres")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(50)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Column("fecha_nacimiento")]
    public DateOnly FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [EmailAddress]
    [StringLength(100)]
    [Column("email")]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    [Column("telefono")]
    public string? Telefono { get; set; }
    
    public HistorialMedico? HistorialMedico { get; set; }
}