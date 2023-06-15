using LABClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LABClothingCollection.DTO.Request_DTO
{
    public class ColecaoPutDTO
    {
        [Required(ErrorMessage = "Nome da coleção é obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(10, ErrorMessage = "Minimo de 10 caracteres")]
        public string NomeColecao { get; set; }
        [Required(ErrorMessage = "Nome da marca é obrigatório")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Orçamento é obrigatório")]
        public double? Orcamento { get; set; }

        [Required(ErrorMessage = "Data lançamento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataLancamento { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Estacao))]
        public Estacao Estacao { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(StatusColecao))]
        public StatusColecao Status { get; set; }
    }
}
