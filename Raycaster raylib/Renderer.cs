using Raylib_cs;
using System.Security.AccessControl;

namespace Raycaster_raylib
{
    public class Renderer
    {
        int pixelSize;
        int width, height;

        int mapSize;

        string[] map = new string[]
        {
            "############...####...###",
            "##....###...............#",
            "##......................#",
            "##......................#",
            "##........#......###...##",
            "##.....................##",
            "##......................#",
            "############..........###",
            "############..........###",
            "############..........###",
            "############..........###",
            "#########################"
        };

        bool renderFirstPerson = true;
        public bool RenderingMap { get => !renderFirstPerson; }

        public static Renderer? Instance;

        public Renderer(int pixelSize, int width, int height)
        {
            Instance = this;

            this.pixelSize = pixelSize;
            this.width = width / pixelSize;
            this.height = height / pixelSize;

            mapSize = width > height? width / map[0].Length 
                : height / map.Length;
        }

        ~Renderer()
        {
            Instance = null;
        }

        public void ChangeRenderType()
        {
            renderFirstPerson = !renderFirstPerson;
        }

        public void Render()
        {
            if(renderFirstPerson)
            {
                RenderFirstPerson();
                return;
            }
            Render2D();
        }

        void RenderFirstPerson()
        {

        }

        void Render2D()
        {
            for(int x = 0; x < map[0].Length; x++)
            {
                for(int y = 0; y < map.Length; y++)
                {
                    DrawPixelMap(x, y);
                }
            }
        }

        public void DrawPixel(int x, int y, Color pixelColor)
        {
            Raylib.DrawRectangle(x * pixelSize, y * pixelSize, pixelSize, pixelSize, pixelColor);
        }

        public void DrawPixelMap(int x, int y)
        {
            Color pixelColor = Color.WHITE;

            if (map[y][x] == '.')
            {
                pixelColor = Color.GRAY;
            }

            Raylib.DrawRectangle(x  * mapSize, y  * mapSize, mapSize,  mapSize, pixelColor);
        }

        public void DrawPixelMap(int x, int y, Color pixelColor)
        {
            Raylib.DrawRectangle(x * mapSize, y * mapSize, mapSize, mapSize, pixelColor);
        }
    }
}
