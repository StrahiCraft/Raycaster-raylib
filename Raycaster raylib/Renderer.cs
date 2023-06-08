using Raylib_cs;
using System.Numerics;

namespace Raycaster_raylib
{
    public class Renderer
    {
        int pixelSize;
        int width;

        int mapSize;

        // TODO make a class for the map
        // TODO make a map editor in GUI
        public string[] map = new string[]
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
            for(int i = 0; i < width / pixelSize; i++)
            {
                
            }
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

        public void DrawPlayer(Vector2 position)
        {
            Raylib.DrawRectangle((int)(position.X * 10f * mapSize) / 10, (int)(position.Y * 10f * mapSize) / 10,
                mapSize, mapSize, Color.RED);
        }

        public void DrawDirectionRay(Vector2 position, Vector2 direction)
        {
            Raylib.DrawLine((int)(position.X * 10f * mapSize) / 10, (int)(position.Y * 10f * mapSize) / 10,
                    (int)(position.X * 10f * mapSize / 10 + direction.X * 7),
                    (int)(position.Y * 10f * mapSize / 10 + direction.Y * 7), Color.GREEN);
        }
    }
}
