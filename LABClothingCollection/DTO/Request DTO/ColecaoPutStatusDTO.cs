using LABClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LABClothingCollection.DTO.Request_DTO
{
    public class ColecaoPutStatusDTO
    {
        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(StatusColecao))]
        public StatusColecao Status { get; set; }
    }
}
