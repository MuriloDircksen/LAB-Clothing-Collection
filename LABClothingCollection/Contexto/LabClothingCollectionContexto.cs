using LABClothingCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace LABClothingCollection.Contexto
{
    public class LabClothingCollectionContexto : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Colecao> Colecoes { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }

        public LabClothingCollectionContexto() { }

        public LabClothingCollectionContexto(DbContextOptions<LabClothingCollectionContexto> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                    new Usuario
                    {
                        Id = 1,
                        NomeCompleto = "Pedro Henrique Danilo Monteiro",
                        Genero = "Masculino",
                        DataNascimento = new DateOnly(1968, 05, 22),
                        CpfOuCnpj = "58080200343",
                        Telefone = "48985460199",
                        Email = "pedro.henrique.monteiro@serteccontabil.com.br",
                        TipoUsuario = TipoUsuario.ADMINISTRADOR,
                        Status = StatusUsuario.ATIVO
                    },
                    new Usuario
                    {
                        Id = 2,
                        NomeCompleto = "Luna Lavínia Ramos",
                        DataNascimento = new DateOnly(1981, 04, 17),
                        CpfOuCnpj = "84052854233",
                        Email = "lunalaviniaramos@comercialrafael.com.br",
                        TipoUsuario = TipoUsuario.CRIADOR,
                        Status = StatusUsuario.INATIVO
                    },
                    new Usuario
                    {
                        Id = 3,
                        NomeCompleto = "Vicente Tiago de Paula",
                        DataNascimento = new DateOnly(1990, 03, 22),
                        CpfOuCnpj = "81456627000153",
                        Telefone = "86992875039",
                        Email = "vicente.tiago.depaula@multmed.com.br",
                        TipoUsuario = TipoUsuario.OUTRO,
                        Status = StatusUsuario.ATIVO
                    },
                    new Usuario
                    {
                        Id = 4,
                        NomeCompleto = "Kevin Mateus Samuel Bernardes",
                        DataNascimento = new DateOnly(2000, 02, 23),
                        CpfOuCnpj = "61869109000154",
                        Telefone = "83982174816",
                        Email = "kevin_mateus_bernardes@genesyslab.com",
                        TipoUsuario = TipoUsuario.OUTRO,
                        Status = StatusUsuario.INATIVO
                    },
                    new Usuario
                    {
                        Id = 5,
                        NomeCompleto = "Priscila Rayssa Alice da Cunha",
                        Genero = "Feminino",
                        DataNascimento = new DateOnly(1986, 08, 22),
                        CpfOuCnpj = "30554862000",
                        Telefone = "51986585903",
                        Email = "priscila_dacunha@hormail.com",
                        TipoUsuario = TipoUsuario.GERENTE,
                        Status = StatusUsuario.ATIVO
                    }


                );

        }
    }
}
