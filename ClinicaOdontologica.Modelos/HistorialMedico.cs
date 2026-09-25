using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologica.Modelos;

[Table("historialesmedicos")]
public class HistorialMedico
{
    [Key]
    [Column("id_historial")]
    public int IdHistorial { get; set; }

    [StringLength(200)]
    [Column("alergias")]
    public string? Alergias { get; set; } = "Ninguna";

    [StringLength(200)]
    [Column("enfermedades_previas")]
    public string? EnfermedadesPrevias { get; set; } = "Ninguna";

    [StringLength(5)]
    [Column("tipo_sangre")]
    public string? TipoSangre { get; set; }

    [Required]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }
    
    [ForeignKey(nameof(IdPaciente))]
    [JsonIgnore]
    public Paciente? Paciente { get; set; }
}