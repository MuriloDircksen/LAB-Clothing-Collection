using LABClothingCollection.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LABClothingCollection.DTO.Request_DTO
{
    
    public class ModeloDTO
    {
        [Required(ErrorMessage = "Nome do modelo requerido")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(5, ErrorMessage = "Minimo de 5 caracteres")]
        public string? NomeModelo { get; set; }
        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Tipo))]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }
    }
}
