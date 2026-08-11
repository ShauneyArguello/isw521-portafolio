namespace CompositeDemo.Modelos;

/// <summary>
/// Composite del patrón Composite.
/// Representa un nodo que SÍ puede contener otros elementos:
/// archivos individuales u otras carpetas (composición recursiva).
///
/// La clave del patrón está aquí: Carpeta no distingue si cada hijo
/// es un Archivo o otra Carpeta. Simplemente delega cada operación
/// a IElementoSistema, y la recursión ocurre sola gracias a que
/// Carpeta también implementa esa misma interfaz.
/// </summary>
public class Carpeta : IElementoSistema
{
    public string Nombre { get; }
    private readonly List<IElementoSistema> _elementos = new();

    public Carpeta(string nombre)
    {
        Nombre = nombre;
    }

    /// <summary>
    /// Agrega un elemento hijo (puede ser un Archivo o una Carpeta).
    /// </summary>
    public void Agregar(IElementoSistema elemento)
    {
        _elementos.Add(elemento);
    }

    /// <summary>
    /// Quita un elemento hijo.
    /// </summary>
    public void Quitar(IElementoSistema elemento)
    {
        _elementos.Remove(elemento);
    }

    public void Mostrar(int nivel = 0)
    {
        string indentacion = new string(' ', nivel * 2);
        Console.WriteLine($"{indentacion}+ {Nombre}/");

        // Delegación recursiva: no importa si el hijo es Archivo o Carpeta,
        // ambos responden a Mostrar() de la misma forma.
        foreach (var elemento in _elementos)
        {
            elemento.Mostrar(nivel + 1);
        }
    }

    public long ObtenerTamano()
    {
        // Suma recursiva: cada hijo calcula su propio tamaño
        // (trivial si es Archivo, recursivo si es otra Carpeta).
        return _elementos.Sum(e => e.ObtenerTamano());
    }

    public int ContarArchivos()
    {
        return _elementos.Sum(e => e.ContarArchivos());
    }
}
