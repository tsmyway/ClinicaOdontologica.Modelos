using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("tratamientos")]
public class Tratamiento
{
    [Key]
    [Column("id_tratamiento")]
    public int IdTratamiento { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(100)]
    [Column("nombre_tratamiento")]
    public string NombreTratamiento { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Column("costo_base", TypeName = "numeric(10,2)")]
    public decimal CostoBase { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Column("duracion_estimada_minutos")]
    public int DuracionEstimadaMinutos { get; set; }

    public List<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();
}