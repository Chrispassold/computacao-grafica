using System;

namespace TrabalhoFinal3D
{
    class Car : Cubo
    {
        private int? initialLine = null;

        private int currentLine;
        public int CurrentLine { set => Instance.currentLine = value; get => Instance.currentLine; }

        private static Car instance = null;

        public static Car Instance
        {
            get
            {
                if (instance == null)
                    instance = new Car();

                return instance;
            }
            private set { instance = value; }
        }

        private Car()
        {
            TamahoAresta(0.5f);
        }

        public void SetPosition(int line, double x)
        {
            if (initialLine == null)
                initialLine = line;

            CurrentLine = line;

            if (line.Equals(initialLine))
            {
                AtribuirIdentidade();
            }
            else
            {
                TranslacaoXYZ(x, 0, 0);
            }

        }

        public void Reset()
        {
            instance = new Car();
        }

        public double DistanceFrom(Obstacle obstacle)
        {
            var center = obstacle.CloneCenter();

            if (Instance.Center == null) return center.Z;

            return center.Z - Instance.Center.Z;
        }


    }
}
