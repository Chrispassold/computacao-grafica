namespace TrabalhoFinal
{
    /// <summary>
    /// Classe que define um ponto no espa�o 3D com a coordenada homog�nea (w) da Transforma��o Geometrica
    /// </summary>
    public class Point4D
    {
        private double x;
        private double y;
        private double z;
        private double w;
        /// <summary>
        /// Inst�ncia um ponto 3D com a coordenada homog�nea w
        /// </summary>
        /// <param name="x">coordenada eixo x</param>
        /// <param name="y">coordenada eixo y</param>
        /// <param name="z">coordenada eixo z</param>
        /// <param name="w">coordenada espa�o homog�neo</param>
        public Point4D(double x = 0.0, double y = 0.0, double z = 0.0, double w = 1.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        // Operator overloaded
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pto1"></param>
        /// <param name="pto2"></param>
        /// <returns></returns>
        public static Point4D operator +(Point4D pto1, Point4D pto2) => new Point4D(pto1.X + pto2.X, pto1.Y + pto2.Y, pto1.Z + pto2.Z);

        //TODO: a sobreescre��o do operador + funciona mais o - ou -- n�o
        // public static Ponto4D operator -(Ponto4D pto) => new Ponto4D(-pto.X, -pto.Y, -pto.Z);

        //TODO: Testar estas fun��es e ver se precisam existir
        // public static bool operator ==(Ponto4D pto1, Ponto4D pto2) {
        //   return ((pto1.X == pto2.X) && (pto1.Y == pto2.Y) && (pto1.Z == pto2.Z));
        // }
        // public static bool operator !=(Ponto4D pto1, Ponto4D pto2) {
        //   return ((pto1.X != pto2.X) && (pto1.Y != pto2.Y) && (pto1.Z != pto2.Z));
        // }
        /// <summary>
        /// Obter e atribuir a coordenada x
        /// </summary>
        /// <value>coordenada x</value>
        public double X { get => x; set => x = value; }
        /// <summary>
        /// Obter e atribuir a coordenada y
        /// </summary>
        /// <value>coordeanda y</value>
        public double Y { get => y; set => y = value; }
        /// <summary>
        /// Obter e atribuir a coordenada z
        /// </summary>
        /// <value>coordeanda z</value>
        public double Z { get => z; set => z = value; }
        /// <summary>
        /// Obter e atribuir a coordenada homog�nea w
        /// </summary>
        /// <value>coordeanda w</value>
        public double W { get => w; set => w = value; }
        /// <summary>
        /// Inverte todos os valores das coordenadas do ponto
        /// </summary>
        public void inverterSinal()
        {
            x *= -1;
            y *= -1;
            z *= -1;
        }

        public Point4D Clone() => new Point4D(x, y, z, w);

        public override string ToString()
        {
            return string.Format("x:{0}, y:{1}, z:{2}, w:{3}", x, y, z, w);
        }

        public void MoverDireita(double factor)
        {
            X = X + factor;
        }

        public void MoverCima(double factor)
        {
            Y = Y + factor;
        }

        public void MoverEsquerda(double factor)
        {
            X = X - factor;
        }

        public void MoverBaixo(double factor)
        {
            Y = Y - factor;
        }
    }
}
