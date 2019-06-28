using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Timers;

namespace TrabalhoFinal
{
    class Street : Drawable
    {

        public const int STREET_WIDTH = 300;
        public const int STREET_QTD_LINES = 3;
        public const int STREET_QTD_OBSTACLES_LIMIT = 10;
        public const int STREET_INTERVAL_ADD_OBSTACLE = 1000;

        private double xmin, xmax;

        private static Street instance = null;

        private Timer timer = new Timer();
        Random random = new Random();
        private Camera camera;
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
            camera = Camera.Instance();
            var center = camera.Center();

            xmin = center.X - (STREET_WIDTH / 2);
            xmax = center.X + (STREET_WIDTH / 2);

            timer.Interval = STREET_INTERVAL_ADD_OBSTACLE;
            timer.Elapsed += AddObstable;
            timer.Enabled = true;
        }

        public void Draw()
        {
            DrawLimit();
            DrawLines();
            DrawObstacles();
        }

        public int QuantityLines() => STREET_QTD_LINES;

        public double GetXAxiosByLine(int line)
        {
            if (line < 1 || line > STREET_QTD_LINES)
                throw new System.InvalidOperationException(string.Format("No line %d found", line));

            int distLines = STREET_WIDTH / STREET_QTD_LINES;
            var centerLineX = xmin + (line * distLines) - (distLines / 2);

            return centerLineX;
        }

        private void DrawLimit()
        {
            var lineLeft1 = new Point4D(xmin, camera.ymax);
            var lineLeft2 = new Point4D(xmin, camera.ymin);

            var lineRight1 = new Point4D(xmax, camera.ymax);
            var lineRight2 = new Point4D(xmax, camera.ymin);

            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Lines);
            //limite da esquerda
            GL.Vertex2(lineLeft1.X, lineLeft1.Y);
            GL.Vertex2(lineLeft2.X, lineLeft2.Y);

            //limite da direita
            GL.Vertex2(lineRight1.X, lineRight1.Y);
            GL.Vertex2(lineRight2.X, lineRight2.Y);

            GL.End();
        }

        private void DrawLines()
        {
            int distanceLines = STREET_WIDTH / STREET_QTD_LINES;

            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Lines);
            for (int i = distanceLines; i < STREET_WIDTH; i += distanceLines)
            {
                GL.Vertex2(xmin + i, camera.ymax);
                GL.Vertex2(xmin + i, camera.ymin);
            }
            GL.End();
        }

        private void DrawObstacles()
        {

            for (int i = 0; i < obstacles.Count; i++)
            {
                var next = obstacles[i];

                if (next.IsOutOfScreen())
                    obstacles.Remove(next);
                else
                    next.Draw();
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

            var obstacle = new Obstacle(randomLine, new Point4D(XAxios, camera.ymax + 10));

            obstacles.Add(obstacle);
        }

        public void Reset()
        {
            instance = new Street();
        }

    }
}
