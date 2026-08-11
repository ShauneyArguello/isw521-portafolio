namespace CompositeDemo.Modelos;

/// <summary>
/// Component del patrón Composite.
/// Define las operaciones que TANTO un elemento simple (Archivo)
/// como un elemento compuesto (Carpeta) deben poder responder.
///
/// Gracias a esta interfaz, el código que consume estos objetos
/// (por ejemplo Program.cs) nunca necesita preguntar
/// "¿esto es un archivo o una carpeta?" — simplemente llama a estos
/// métodos y el comportamiento correcto ocurre según el tipo real.
/// </summary>
public interface IElementoSistema
{
    /// <summary>
    /// Nombre del elemento (archivo o carpeta).
    /// </summary>
    string Nombre { get; }

    /// <summary>
    /// Muestra el elemento en consola, indentado según su profundidad
    /// dentro del árbol.
    /// </summary>
    /// <param name="nivel">Nivel de profundidad, usado para la indentación.</param>
    void Mostrar(int nivel = 0);

    /// <summary>
    /// Tamaño en KB. En un Archivo es un valor fijo;
    /// en una Carpeta es la suma recursiva de todo su contenido.
    /// </summary>
    long ObtenerTamano();

    /// <summary>
    /// Cantidad de archivos contenidos. En un Archivo siempre es 1;
    /// en una Carpeta es la suma recursiva de sus hijos.
    /// </summary>
    int ContarArchivos();
}
