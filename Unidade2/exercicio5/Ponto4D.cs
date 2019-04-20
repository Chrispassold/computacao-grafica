using System;
namespace exercicio5
{
    internal class Ponto4D
    {
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

        public static Ponto4D InstanceFrom(double angulo, double raio)
        {
            Ponto4D ponto = new Ponto4D(raio, raio, raio);
            ponto.UpdateAngulo(angulo);

            return ponto;
        }

        public void UpdateAngulo(double angulo)
        {
            this.X = (this.Raio() * Math.Cos(Math.PI * angulo / 180.0));
            this.Y = (this.Raio() * Math.Sin(Math.PI * angulo / 180.0));
            this.Z = 0;
        }

        private double Raio()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public override string ToString()
        {
            return string.Format("[Ponto4D => x: {0}, y:{1}, z:{2}]", this.X, this.Y, this.Z);
        }

    }
}