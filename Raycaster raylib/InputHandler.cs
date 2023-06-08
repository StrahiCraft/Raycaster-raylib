using Raylib_cs;

namespace Raycaster_raylib
{
    public static class InputHandler
    {
        public static void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
            {
                Renderer.Instance?.ChangeRenderType();
            }
        }
    }
}
