using ControleDeBar.Dominio.ModuloCard;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class FormularioCardViewModel
{
    public string TextoFrente {get; set;}
    public string TextoTras {get; set;}
    public string Titulo {get; set;}
    public string Secao {get; set;}
    public int Numero { get; set; }
}

public class CadastrarCardViewModel : FormularioCardViewModel
{
    public CadastrarCardViewModel() { }

    public CadastrarCardViewModel(int numero, string secao, string titulo, string textoFrente, string textoTras) : this()
    {
        Numero = numero;
        Secao = secao;
        Titulo = titulo;
        TextoFrente = textoFrente;
        TextoTras = textoTras;
    }
}


public class VisualizarCardsViewModel
{
    public List<DetalhesCardsViewModel> Registros { get; set; }
    public string SecaoEscolhida { get; set; }
    public List<Card> Cards { get; set; }
    public bool cardsAcabaram { get; set; }
    public  int Contador { get; set; } = 1;

    public VisualizarCardsViewModel() { }
    public VisualizarCardsViewModel(List<Card> cards)
    {
        Registros = new List<DetalhesCardsViewModel>();

        foreach (var p in cards)
            Registros.Add(p.ParaDetalhesVM());
    }
}

public class DetalhesCardsViewModel
{
    public Guid Id { get; set; }
    public string TextoFrente { get; set; }
    public string Secao { get; set; }
    public string TextoTras {get; set; }
    public string Titulo { get; set; }
    public int Numero { get; set; }

    public DetalhesCardsViewModel(Guid id, int numero, string secao, string titulo, string textoFrente, string textoTras)
    {
        Id = id;
        Numero = numero;
        Secao = secao;
        Titulo = titulo;
        TextoFrente = textoFrente;
        TextoTras = textoTras;
    }
}

public class SelecionarCardViewModel
{
    public Guid Id { get; set; }

    public string Titulo { get; set; }

    public SelecionarCardViewModel(Guid id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}