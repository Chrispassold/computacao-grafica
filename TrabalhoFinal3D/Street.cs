using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Timers;

namespace TrabalhoFinal3D
{
    class Street : Drawable
    {


        public const int STREET_QTD_LINES = 3;
        public const int STREET_WIDTH = STREET_QTD_LINES * 2;
        public const int STREET_QTD_OBSTACLES_LIMIT = 10;
        public const int STREET_INTERVAL_ADD_OBSTACLE = 1000;

        private double limitLeft, limitRight;

        private static Street instance = null;

        private Camera camera = Camera.Instance;
        private Timer timer = new Timer();
        Random random = new Random();
        private readonly List<Obstacle> obstacles = new List<Obstacle>();

        public static Street Instance
        {
            get
            {
                if (instance == null)
                    instance = new Street();

                return instance;
            }
            private set { instance = value; }
        }

        private Street()
        {
            limitLeft = -(STREET_WIDTH / 2);
            limitRight = (STREET_WIDTH / 2);
        }

        protected override void Desenha()
        {
            DrawLimit();
            DrawLines();
        }

        private void DrawLimit()
        {
            var lineLeft1 = new Ponto4D(limitLeft, 0, 300);
            var lineLeft2 = new Ponto4D(limitLeft, 0, 0);

            var lineRight1 = new Ponto4D(limitRight, 0, 300);
            var lineRight2 = new Ponto4D(limitRight, 0, 0);

            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Orange);
            GL.Begin(PrimitiveType.Lines);
            //limite da esquerda
            GL.Vertex3(lineLeft1.X, lineLeft1.Y, lineLeft1.Z);
            GL.Vertex3(lineLeft2.X, lineLeft2.Y, lineLeft2.Z);

            //limite da direita
            GL.Vertex3(lineRight1.X, lineRight1.Y, lineRight1.Z);
            GL.Vertex3(lineRight2.X, lineRight2.Y, lineLeft2.Z);

            GL.End();
        }

        private void DrawLines()
        {
            int distanceLines = STREET_WIDTH / STREET_QTD_LINES;

            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Orange);
            GL.Begin(PrimitiveType.Lines);
            for (int i = distanceLines; i < STREET_WIDTH; i += distanceLines)
            {
                GL.Vertex3(limitLeft + i, 0, 300);
                GL.Vertex3(limitLeft + i, 0, 0);
            }
            GL.End();
        }

        public int QuantityLines() => STREET_QTD_LINES;

        public double GetXAxiosByLine(int line)
        {
            if (line < 1 || line > STREET_QTD_LINES)
                throw new System.InvalidOperationException(string.Format("No line %d found", line));

            int distLines = STREET_WIDTH / STREET_QTD_LINES;
            var centerLineX = limitLeft + (line * distLines) - (distLines / 2);

            return centerLineX;
        }

        private void DrawObstacles()
        {

            for (int i = 0; i < obstacles.Count; i++)
            {
                var next = obstacles[i];

                if (next.IsOutOfScreen())
                    obstacles.Remove(next);
                else
                    next.Desenhar();
            }
        }

        public void Move(int speed)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                var next = obstacles[i];
                if (next != null)
                    next.Move(speed);
            }
        }

        private void AddObstable(object source, ElapsedEventArgs e)
        {
            if (STREET_QTD_OBSTACLES_LIMIT == obstacles.Count) return;

            int randomLine = random.Next(1, STREET_QTD_LINES + 1);

            var XAxios = GetXAxiosByLine(randomLine);

            var obstacle = new Obstacle(randomLine, new Ponto4D(XAxios, 0, camera.ymax + 10));

            obstacles.Add(obstacle);
        }

        public void Reset()
        {
            instance = new Street();
        }

    }
}
