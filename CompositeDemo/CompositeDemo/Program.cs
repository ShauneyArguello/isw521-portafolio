using CompositeDemo.Modelos;

// ============================================================
// Construcción del árbol de ejemplo:
//
// Proyecto/
//   src/
//     Program.cs
//     Modelos/
//       Empleado.cs
//       Departamento.cs
//   docs/
//     readme.md
//   config.json
// ============================================================

var raiz = new Carpeta("Proyecto");

var src = new Carpeta("src");
src.Agregar(new Archivo("Program.cs", 12));

var modelos = new Carpeta("Modelos");
modelos.Agregar(new Archivo("Empleado.cs", 8));
modelos.Agregar(new Archivo("Departamento.cs", 6));

// Una carpeta puede contener OTRA carpeta: aquí está la recursión.
src.Agregar(modelos);

var docs = new Carpeta("docs");
docs.Agregar(new Archivo("readme.md", 3));

raiz.Agregar(src);
raiz.Agregar(docs);
raiz.Agregar(new Archivo("config.json", 1));

// ============================================================
// Uso del patrón: el cliente (este Main) SOLO conoce
// IElementoSistema. No necesita saber si "raiz" es un archivo
// o una carpeta con 10 niveles de profundidad — llama a los
// mismos 3 métodos sin importar la complejidad interna.
// ============================================================

Console.WriteLine("=== Árbol del proyecto ===\n");
raiz.Mostrar();

Console.WriteLine("\n=== Estadísticas (calculadas recursivamente) ===");
Console.WriteLine($"Tamaño total: {raiz.ObtenerTamano()} KB");
Console.WriteLine($"Cantidad de archivos: {raiz.ContarArchivos()}");

// ------------------------------------------------------------
// Demostración extra: tratar una Carpeta y un Archivo suelto
// EXACTAMENTE igual, sin ningún if/else que pregunte el tipo.
// Esto es lo que realmente resuelve el patrón Composite.
// ------------------------------------------------------------
Console.WriteLine("\n=== Tratamiento uniforme (Leaf vs Composite) ===");
List<IElementoSistema> elementosSueltos = new()
{
    new Archivo("nota.txt", 1),
    raiz // una carpeta completa, tratada igual que un archivo suelto
};

foreach (var elemento in elementosSueltos)
{
    Console.WriteLine($"\n'{elemento.Nombre}' pesa {elemento.ObtenerTamano()} KB " +
                       $"y contiene {elemento.ContarArchivos()} archivo(s).");
}
