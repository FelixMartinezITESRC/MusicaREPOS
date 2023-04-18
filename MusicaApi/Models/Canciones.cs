using System;
using System.Collections.Generic;

namespace MusicaApi.Models;

public partial class Canciones
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Duracion { get; set; } = null!;
}
