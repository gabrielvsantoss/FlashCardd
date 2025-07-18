using ControleDeBar.Dominio.ModuloCard;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WebApp.Models;

namespace ControleDeBar.WebApp.Extensions;

public static class CardExtensions
{
    public static Card ParaEntidade(this FormularioCardViewModel formularioVM)
    {
        return new Card(formularioVM.Numero, formularioVM.Secao, formularioVM.Titulo, formularioVM.TextoFrente, formularioVM.TextoTras);
    }

    public static DetalhesCardsViewModel ParaDetalhesVM(this Card card)
    {
        return new DetalhesCardsViewModel(
                card.Id,
                card.Numero,
                card.Secao,
                card.Titulo,
                card.TextoFrente,
                card.TextoTras
        );
    }
}
