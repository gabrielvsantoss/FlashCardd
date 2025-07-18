using System.Runtime.Intrinsics.X86;
using System.Text;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    [Route("gepeteco2.0")]
    public class PerguntasERespostasGepetecoController : Controller
    {
        public IActionResult Index()
        {
            PerguntasERespostasGepetecoViewModel  VM = new PerguntasERespostasGepetecoViewModel();

            return View(VM);
        }

        [HttpPost("tema/cadastrar")]
        public IActionResult Cadastrar(PerguntasERespostasGepetecoViewModel VM)
        {
            string introducao = "Me passe um vetor de strings com perguntas do tema";
            string conclusao = "Onde os 5 primeiros elementos do array serao as perguntas e os 5 ultimos serao as respostas (Preciso que o vetor tenha Exatamente 20 elementos, separe as perguntas por linhas e as respostas tambem, meu algoritmo é preparado pra receber as respostas por linhas voce nao pode fazer uma introdução ou algo assim passe direto as 5 perguntas e as 5 respostas";
            StringBuilder sb = new StringBuilder();
            sb.Append(introducao);
            sb.Append(VM.TemaPergunta);
            sb.Append(conclusao);
            VM.PerguntaCompleta = sb.ToString();
            return View(VM);
        }

       
    }
}
