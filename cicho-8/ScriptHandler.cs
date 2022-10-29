using NLua;

namespace cicho;

public static class ScriptHandler
{
    private static string _root;
    public static string ScriptPath = string.Empty;
    public static readonly Lua Lua;

    private static string[] _predefinedFunctions;
    private static Dictionary<string, LuaFunction> _referencedFunctions;

    static ScriptHandler()
    {
        Lua = new Lua();
        Setup();
    }

    private static void Setup()
    {
        _root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        _root = Path.Combine(_root, "cicho-8");
        Directory.CreateDirectory(_root);
        _predefinedFunctions = new[]
        {
            "_init",
            "_update"
        };
        _referencedFunctions = new Dictionary<string, LuaFunction>();
    }
    
    public static void Load(string scriptPath)
    {
        ScriptPath = scriptPath;
    }

    public static void Run(string scriptPath = "")
    {
        if (scriptPath == string.Empty)
        {
            scriptPath = ScriptPath;
        }

        if (!File.Exists(scriptPath))
        {
            throw new FileNotFoundException();
        }
        
        Lua.DoFile(scriptPath);
    }
}