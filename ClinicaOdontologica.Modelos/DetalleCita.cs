using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologica.Modelos;

[Table("detallescita")]
public class DetalleCita
{
    [Key]
    [Column("id_detalle_cita")]
    public int IdDetalleCita { get; set; }

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Required]
    [Column("id_tratamiento")]
    public int IdTratamiento { get; set; }

    [Required]
    [Column("costo_aplicado", TypeName = "numeric(10,2)")]
    public decimal CostoAplicado { get; set; }

    [StringLength(200)]
    [Column("observaciones")]
    public string? Observaciones { get; set; }
    
    [ForeignKey(nameof(IdCita))]
    [JsonIgnore]
    public Cita? Cita { get; set; }

    [ForeignKey(nameof(IdTratamiento))]
    [JsonIgnore]
    public Tratamiento? Tratamiento { get; set; }
}