namespace exercicio
{
    internal class Ponto4D
    {
        /// <summary>
        /// Coordenadas do ponto
        /// </summary>
        private double x;
        private double y;
        private double z;
        private double w;
        public Ponto4D(double x = 0.0, double y = 0.0, double z = 0.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 1;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

    }
}