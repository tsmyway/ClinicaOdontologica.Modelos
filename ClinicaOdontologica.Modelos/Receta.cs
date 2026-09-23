using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("recetas")]
public class Receta
{
    [Key]
    [Column("id_receta")]
    public int IdReceta { get; set; }

    [Required]
    [Column("fecha_emision")]
    public DateTime FechaEmision { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Column("indicaciones")]
    public string Indicaciones { get; set; } = null!;

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }
    
    [ForeignKey(nameof(IdCita))]
    public Cita Cita { get; set; } = null!;
}