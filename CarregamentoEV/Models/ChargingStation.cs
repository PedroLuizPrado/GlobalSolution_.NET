using System.ComponentModel.DataAnnotations;

namespace CarregamentoEV.Models
{
    public class ChargingStation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        public string? Localizacao { get; set; }

        public bool Disponivel { get; set; }
    }
}
