
using ControleDeBar.Dominio.ModuloCard;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.ModuloCard;

public class RepositorioCardEmArquivo : RepositorioBaseEmArquivo<Card>, IRepositorioCard
{
    public RepositorioCardEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Card> ObterRegistros()
    {
        return contexto.Cards;
    }
}
