using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloCard;

public class Card : EntidadeBase<Card>
{
    public string Titulo { get; set; }
    public string TextoFrente { get; set; }
    public string TextoTras { get; set; }
    public int Numero {get; set;}
    public string Secao { get; set; }
    public static int ContadorCards { get; set;  }
    public Card() { }

    public Card(int numero, string secao, string titulo, string textoFrente, string textoTras) : this()
    {
        Id = Guid.NewGuid();
        Numero = numero;
        Secao = secao;
        Titulo = titulo;
        TextoFrente = textoFrente;
        TextoTras = textoTras;
    }

    public override void AtualizarRegistro(Card registroEditado)
    {
        Secao = registroEditado.Secao;
        Titulo = registroEditado.Titulo;
        TextoFrente = registroEditado.TextoFrente;
        TextoTras = registroEditado.TextoTras;
    }
}