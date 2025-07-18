
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ControleDeBar.WebApp.Models;

public class CardsComIAViewModel
{
    public string TextoFrente { get; set; }
    public string TextoTras { get; set; }
    public int ContadorFrente { get; set; } 
    public int ContadorTras { get; set; }
    public string[] Perguntas { get; set; }

    public string[]  Respostas{ get; set; }

}

public class VisualizarCardsComIAViewModel
{
    public List<DetalhesCardsViewModel> Registros { get; set; }
    public string Tema { get; set; }
    public string TextoFrente { get; set; }
    public string TextoTras { get; set; }
    public VisualizarCardsComIAViewModel() { }
  
}

public class DetalhesCardComIAViewModel
{
    public string TextoFrente { get; set; }
    public string TextoTras { get; set; }

    public DetalhesCardComIAViewModel(string textoFrente, string textoTras)
    {
        TextoFrente = textoFrente;
        TextoTras = textoTras;
    }
}

