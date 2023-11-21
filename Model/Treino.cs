using System.ComponentModel.DataAnnotations;

namespace ControleExercicios.Model
{
    public class Treino
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Usuario { get; set; } = string.Empty;
        [Required]
        public string DiaTreino { get; set; } = string.Empty;
        [Required]
        public string PrimeiroExercicio { get; set; } = string.Empty;
        [Required]
        public string SegundoExercicio { get; set; } = string.Empty;
        [Required]
        public string TerceiroExercicio { get; set; } = string.Empty;
        public string QuartoExercicio { get; set; } = string.Empty;
        public string QuintoExercicio { get; set; } = string.Empty;
        public string SextoExercicio { get; set; } = string.Empty;
        public string SetimoExercicio { get; set; } = string.Empty;
        
    }
}