namespace CentralitaDB_App.Models
{

    using System.ComponentModel.DataAnnotations;

    public class Llamada
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de origen es requerido")]
        [StringLength(20)]
        public string NumOrigen { get; set; }

        [Required(ErrorMessage = "El número de destino es requerido")]
        [StringLength(20)]
        public string NumDestino { get; set; }

        [Required(ErrorMessage = "La duración es requerida")]
        public float Duracion { get; set; }

        [Required(ErrorMessage = "El tipo de llamada es requerido")]
        [StringLength(20)]
        public string TipoLlamada { get; set; }

        [Required(ErrorMessage = "El horario de origen es requerido")]
        [StringLength(20)]
        public string HorarioOrigen { get; set; }

        [Required(ErrorMessage = "El horario de destino es requerido")]
        [StringLength(20)]
        public string HorarioDestino { get; set; }

        [Required(ErrorMessage = "La tecnología móvil es requerida")]
        [StringLength(20)]
        public string TecnologiaMovil { get; set; }

        [Required(ErrorMessage = "El costo es requerido")]
        public float Costo { get; set; }
    }


}
