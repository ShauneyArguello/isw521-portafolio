namespace CompositeDemo.Modelos;

/// <summary>
/// Leaf del patrón Composite.
/// Representa el "extremo" del árbol: un elemento que NO contiene
/// más elementos dentro. Implementa IElementoSistema directamente
/// y responde de forma trivial (no hay recursión posible).
/// </summary>
public class Archivo : IElementoSistema
{
    public string Nombre { get; }
    private readonly long _tamanoKb;

    public Archivo(string nombre, long tamanoKb)
    {
        Nombre = nombre;
        _tamanoKb = tamanoKb;
    }

    public void Mostrar(int nivel = 0)
    {
        string indentacion = new string(' ', nivel * 2);
        Console.WriteLine($"{indentacion}- {Nombre} ({_tamanoKb} KB)");
    }

    public long ObtenerTamano() => _tamanoKb;

    public int ContarArchivos() => 1;
}
