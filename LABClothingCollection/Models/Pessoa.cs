﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LABClothingCollection.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "Campo nome de preenchimento obigatório!")]
        [MaxLength(200, ErrorMessage ="Máximo de 200 caracteres")]
        [MinLength(10, ErrorMessage = "Minimo de 10 caracteres")]
        public string? NomeCompleto { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage ="Data nascimento e obrigatório")]
        [DataType(DataType.Date)]
        public DateOnly? DataNascimento { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Somente números, dando 11 caracteres")]
        [MaxLength(13, ErrorMessage = "Somente números, dando 13 caracteres")]
        public string? CpfOuCnpj { get; set; }

        

        [StringLength(1, ErrorMessage = "Formato de dados 48999999999, total de 11 caracteres numéricos")]
        public string Telefone { get; set; }

    }
}
