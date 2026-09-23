using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("especialidades")]
public class Especialidad
{
    [Key]
    [Column("id_especialidad")]
    public int IdEspecialidad { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(50)]
    [Column("nombre_especialidad")]
    public string NombreEspecialidad { get; set; } = null!;

    [StringLength(200)]
    [Column("descripcion")]
    public string? Descripcion { get; set; }
}