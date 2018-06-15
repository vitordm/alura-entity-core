namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public byte LinguagemId { get; set; }
        public byte? LinguagemOriginalId { get; set; }
        public short Duracao { get; set; }
        public string Avaliacao { get; set; }

    }
}
