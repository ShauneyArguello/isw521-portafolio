# CompositeDemo

Proyecto de ejemplo en C# que implementa el **patrón de diseño Composite**,
modelando un sistema de archivos (carpetas que pueden contener archivos
u otras carpetas).

## Estructura del proyecto

```
CompositeDemo/
├── CompositeDemo.csproj
├── Program.cs                    # Punto de entrada: arma el árbol y lo usa
└── Modelos/
    ├── IElementoSistema.cs       # Component: interfaz común
    ├── Archivo.cs                # Leaf: elemento sin hijos
    └── Carpeta.cs                # Composite: contiene otros IElementoSistema
```

## Cómo ejecutarlo

Requiere el SDK de .NET 8 instalado.

```bash
cd CompositeDemo
dotnet run
```

## Qué demuestra

1. **`IElementoSistema`** define el contrato común (`Mostrar`, `ObtenerTamano`,
   `ContarArchivos`) que tanto `Archivo` como `Carpeta` deben cumplir.
2. **`Archivo`** (Leaf) implementa ese contrato de forma directa y simple:
   no tiene hijos, así que no hay recursión.
3. **`Carpeta`** (Composite) implementa el mismo contrato, pero internamente
   mantiene una lista de `IElementoSistema` — que puede mezclar archivos
   y más carpetas — y delega cada operación a sus hijos, generando
   recursión de forma natural.
4. **`Program.cs`** actúa como cliente: arma un árbol de varios niveles
   y lo recorre usando únicamente los métodos de `IElementoSistema`,
   sin ningún `if/else` que distinga entre archivo y carpeta.

## Salida esperada

```
=== Árbol del proyecto ===

+ Proyecto/
  + src/
    - Program.cs (12 KB)
    + Modelos/
      - Empleado.cs (8 KB)
      - Departamento.cs (6 KB)
  + docs/
    - readme.md (3 KB)
  - config.json (1 KB)

=== Estadísticas (calculadas recursivamente) ===
Tamaño total: 30 KB
Cantidad de archivos: 5

=== Tratamiento uniforme (Leaf vs Composite) ===

'nota.txt' pesa 1 KB y contiene 1 archivo(s).

'Proyecto' pesa 30 KB y contiene 5 archivo(s).
```

Nota cómo el último bloque trata a `nota.txt` (un `Archivo` suelto) y a
`raiz` (una `Carpeta` con todo un árbol dentro) con exactamente el mismo
código — esa es la esencia del patrón Composite.
