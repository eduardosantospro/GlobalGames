namespace GlobalGamesCet49.Models
{
    using System.ComponentModel.DataAnnotations;
    using GlobalGamesCet49.Dados.Entidades;
    using Microsoft.AspNetCore.Http;

    // Esta view vai herdar a info de Inscricao
    public class InscricaoViewModel : Inscricao
    {
        [Display(Name = "Foto/Avatar")]
        // IFormFile -> Microsoft.AspNetCore.Http
        public IFormFile FicheiroDeImagem { get; set; }
    }
}
