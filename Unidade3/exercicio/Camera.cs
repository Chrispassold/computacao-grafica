namespace exercicio
{
    public class Camera
    {

        private static Camera instance = null;

        private double xMin, xMax, yMin, yMax, zMin, zMax;

        private Camera(double xMin = -300, double xMax = 300, double yMin = -300, double yMax = 300, double zMin = -1, double zMax = 1)
        {
            this.xMin = xMin; this.xMax = xMax;
            this.yMin = yMin; this.yMax = yMax;
            this.zMin = zMin; this.zMax = zMax;
        }
        public double xmin { get => xMin; set => xMin = value; }
        public double xmax { get => xMax; set => xMax = value; }
        public double ymin { get => yMin; set => yMin = value; }
        public double ymax { get => yMax; set => yMax = value; }
        public double zmin { get => zMin; set => zMin = value; }
        public double zmax { get => zMax; set => zMax = value; }

        public void panEsq() { xMin += 2; xMax += 2; }
        public void panDir() { xMin -= 2; xMax -= 2; }
        public void panCim() { yMin -= 2; yMax -= 2; }
        public void panBai() { yMin += 2; yMax += 2; }
        //TODO: falta testa os limites de zoom    
        public void zoomIn()
        {
            xMin += 2; xMax -= 2; yMin += 2; yMax -= 2;
        }
        //TODO: falta testa os limites de zoom    
        public void zoomOut()
        {
            xMin -= 2; xMax += 2; yMin -= 2; yMax += 2;
        }

        public static Camera Initialize(double xMin = -300, double xMax = 300, double yMin = -300, double yMax = 300, double zMin = -1, double zMax = 1)
        {
            if (instance == null)
                instance = new Camera(xMin, xMax, yMin, yMax, zMin, zMax);

            return instance;
        }

        public static Camera Instance()
        {
            if (instance == null)
                throw new System.Exception("Instance not initialized");

            return instance;
        }

    }
}