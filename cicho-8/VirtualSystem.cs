namespace cicho;

public static class VirtualSystem
{
    private static bool _running;
    public static bool IsRunning => _running;

    public static void Boot()
    {
        _running = true;
    }

    public static void Shutdown()
    {
        _running = false;
    }
}