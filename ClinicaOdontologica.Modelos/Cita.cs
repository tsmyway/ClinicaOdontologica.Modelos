using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologica.Modelos;

[Table("citas")]
public class Cita
{
    [Key]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Required]
    [Column("fecha_cita")]
    public DateTime FechaCita { get; set; }

    [StringLength(200)]
    [Column("motivo")]
    public string? Motivo { get; set; }

    [StringLength(20)]
    [Column("estado_cita")]
    public string? EstadoCita { get; set; } = "Pendiente";

    [Required]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Required]
    [Column("id_odontologo")]
    public int IdOdontologo { get; set; }

    [Required]
    [Column("id_consultorio")]
    public int IdConsultorio { get; set; }
    
    [ForeignKey(nameof(IdPaciente))]
    [JsonIgnore]
    public Paciente? Paciente { get; set; }

    [ForeignKey(nameof(IdOdontologo))]
    [JsonIgnore]
    public Odontologo? Odontologo { get; set; }

    [ForeignKey(nameof(IdConsultorio))]
    [JsonIgnore]
    public Consultorio? Consultorio { get; set; }
    
    [JsonIgnore]
    public Factura? Factura { get; set; }
    
    [JsonIgnore]
    public List<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();
    
    [JsonIgnore]
    public List<Receta> Recetas { get; set; } = new List<Receta>();
}