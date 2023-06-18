using LABClothingCollection.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LABClothingCollection.DTO.Request_DTO
{
    
    public class ModeloDTO
    {
        [Required(ErrorMessage = "Nome do modelo requerido")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(5, ErrorMessage = "Minimo de 5 caracteres")]
        public string? NomeModelo { get; set; }
        [ForeignKey("Colecao")]
        public virtual int IdColecao { get; set; }
        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Tipo))]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }
    }
}
