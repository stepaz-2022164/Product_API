using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products_Server.Models
{
    public class Product
    {
        public int Id { get; set; } //Propiedades publicas y aplicacion de los metodos get y set
        [MaxLength(50, ErrorMessage =" El campo {0} debe contener {1} caractéres.")] //Atributos y/o metadatos
        public string Name { get; set; } = null!;
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener {1} caractéres.")]
        public string Description { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

    }
}
