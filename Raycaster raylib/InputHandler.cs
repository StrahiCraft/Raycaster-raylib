using Raylib_cs;

namespace Raycaster_raylib
{
    public static class InputHandler
    {
        static float sensitivity = 3.6f;

        public static void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
            {
                Renderer.Instance?.ChangeRenderType();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                Player.Instance?.MovePlayer(1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                Player.Instance?.RotatePlayer(-sensitivity);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                Player.Instance?.MovePlayer(-1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                Player.Instance?.RotatePlayer(sensitivity);
            }
        }
    }
}
