using LABClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LABClothingCollection.DTO.Request_DTO
{
    public class UsuarioPutStatusDTO
    {
        [Required(ErrorMessage = "Campo requerido e deve seguir a lista de tipos possiveis"), EnumDataType(typeof(StatusUsuario))]
        public StatusUsuario Status { get; set; }
    }
}
