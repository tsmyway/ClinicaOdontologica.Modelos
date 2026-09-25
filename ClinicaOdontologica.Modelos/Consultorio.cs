using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologica.Modelos;

[Table("consultorios")]
public class Consultorio
{
    [Key]
    [Column("id_consultorio")]
    public int IdConsultorio { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(10)]
    [Column("numero_sala")]
    public string NumeroSala { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Column("piso")]
    public int Piso { get; set; }

    [StringLength(100)]
    [Column("equipamiento_principal")]
    public string? EquipamientoPrincipal { get; set; }
    
    [JsonIgnore]
    public List<Cita> Citas { get; set; } = new List<Cita>();
}