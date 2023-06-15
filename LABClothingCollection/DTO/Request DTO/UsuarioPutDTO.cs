using LABClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LABClothingCollection.DTO.Request_DTO
{
    public class UsuarioPutDTO
    {
        [Required(ErrorMessage = "Campo nome de preenchimento obigatório!")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(10, ErrorMessage = "Minimo de 10 caracteres")]
        public string? NomeCompleto { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Data nascimento e obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        [StringLength(11, ErrorMessage = "Formato de dados 48999999999, total de 11 caracteres numéricos")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "Campo requerido e deve seguir a lista de tipos possiveis"), EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario TipoUsuario { get; set; }
    }
}
