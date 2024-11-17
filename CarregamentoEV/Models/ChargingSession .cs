using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarregamentoEV.Models
{
    public class ChargingSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ChargingStation")]
        public int ChargingStationId { get; set; }

        
        public ChargingStation? ChargingStation{ get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public string? UsuarioId { get; set; }
    }
}
