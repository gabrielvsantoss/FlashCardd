using ControleDeBar.Dominio.ModuloCard;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloCard;
using ControleDeBar.Infraestrutura.SqlServer.ModuloProduto;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

[Route("praticar")]
public class PraticarController : Controller
{
    private readonly IRepositorioCard repositorioCard;

    public PraticarController()
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioCard = new RepositorioCardEmArquivo(contexto);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = repositorioCard.SelecionarRegistros();

        var visualizarVM = new VisualizarCardsViewModel(registros);

        ViewBag.SecaoSelecionada = null;
        return View(visualizarVM);
    }
    [HttpGet("praticar/secao/{secao}/{Contador:int}")]
    public IActionResult Praticar(string Secao, int contador)
    {
        var registros = repositorioCard.SelecionarRegistros();


        
        string secaoSelecionada = ViewBag.SecaoSelecionada;
        List<Card> cardsSecaoSelecionada = new List<Card>();
        foreach(var item in registros)
        {
            if(item.Secao == Secao)
            {
                cardsSecaoSelecionada.Add(item);
            }
        }
        VisualizarCardsViewModel visualizarVM = new VisualizarCardsViewModel(registros);

        visualizarVM.SecaoEscolhida = Secao;
        visualizarVM.Cards = cardsSecaoSelecionada;
        visualizarVM.Contador = contador;
        return View(visualizarVM);
    }

    [HttpPost("Respostas")]
    public IActionResult Resposta(VisualizarCardsViewModel model)
    {
        var registros = repositorioCard.SelecionarRegistros();
        List<Card> cardsSecaoSelecionada = new List<Card>();
        foreach (var item in registros)
        {
            if(item.Secao == model.SecaoEscolhida)
            {
                cardsSecaoSelecionada.Add(item);
            }
        }

        model.Cards = cardsSecaoSelecionada;
        return View(model);
    }
}
