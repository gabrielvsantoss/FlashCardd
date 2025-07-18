using ControleDeBar.Dominio.ModuloCard;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloCard;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

[Route("cards")]
public class CardController : Controller
{
    private readonly IRepositorioCard _repositorioCard;

    public CardController()
    {
        var contexto = new ContextoDados(true);
        _repositorioCard = new RepositorioCardEmArquivo(contexto);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = _repositorioCard.SelecionarRegistros();
        return View(new VisualizarCardsViewModel(registros));
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() => View(new CadastrarCardViewModel());

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarCardViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var entidade = vm.ParaEntidade();
        Card.ContadorCards++;
        entidade.Numero = Card.ContadorCards;
        _repositorioCard.CadastrarRegistro(entidade);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet("edicaocards")]
    public IActionResult EdicaoCards(CardsComIAViewModel cardsComIA)
    {
       

        
        return View("ParteDeTras", cardsComIA);
    }

    [HttpPost("edicaocards")]
    public IActionResult EdicaoCards(CardsComIAViewModel VM, ItensChatGptViewModel itens)
    {

        if (itens.Lista != null)
        {
            CardsComIAViewModel ViewNova = new CardsComIAViewModel();
            ViewNova.Perguntas = itens.Lista;
            ViewNova.Respostas = itens.Lista;
            ViewNova.ContadorFrente = 0;
            ViewNova.ContadorTras = 5;

            return View("ParteDaFrente", ViewNova);
        }

        else
        {
            if (itens.Lista != null)
            {
                VM.Perguntas = itens.Lista;
                VM.Respostas = itens.Lista;
                return View("ParteDaFrente", VM);
            }

            else
            {
                return View("ParteDaFrente", VM);
            }
        }
    }


}
