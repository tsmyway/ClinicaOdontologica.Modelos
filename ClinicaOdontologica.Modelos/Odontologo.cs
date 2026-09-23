using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("odontologos")]
public class Odontologo
{
    [Key]
    [Column("id_odontologo")]
    public int IdOdontologo { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(50)]
    [Column("nombres")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(50)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(20)]
    [Column("registro_medico")]
    public string RegistroMedico { get; set; } = null!;

    [Required]
    [Column("id_especialidad")]
    public int IdEspecialidad { get; set; }
    
    [ForeignKey(nameof(IdEspecialidad))]
    public Especialidad Especialidad { get; set; } = null!;
}