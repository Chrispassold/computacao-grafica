namespace TrabalhoFinal3D
{
    class Constants
    {
        //CAMERA
        public const float FAR = 50;
        public const float NEAR = 1;
        public const double CAMERA_X = 600;
        public const double CAMERA_Y = 600;
        public const double CAMERA_Z = 600;

        //DRIVER
        public const int DRIVER_INTERVAL_MOVE = 300;

        //STREET
        public const int STREET_DISTANCE = (int) FAR;
        public const int STREET_DISTANCE_ADD_OBSTACLE = STREET_DISTANCE - 5;
        public const int STREET_QTD_LINES = 3;
        public const int STREET_WIDTH = STREET_QTD_LINES * 2;
        public const int STREET_QTD_OBSTACLES_LIMIT = 1;
        public const int STREET_INTERVAL_ADD_OBSTACLE = 100;

    }
}
