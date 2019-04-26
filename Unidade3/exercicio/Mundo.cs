using System.Collections.Generic;
namespace exercicio
{
    public class Mundo
    {
        private readonly Camera camera = new Camera();
        private List<Poligono> poligonos = new List<Poligono>();
        private Poligono poligonoSelecionado = null;
        private bool ehPonto = false;
    }
}