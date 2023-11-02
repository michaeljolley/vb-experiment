using DotNetEnv;

namespace WebGIJoeTestProject;

public static class ProjectConfig
{
    public static string Browser = Env.GetString("BROWSER");
    public static string RunEnvironment = Env.GetString("RUN_ENVIRONMENT");
    public static string Url = Env.GetString("URL");
}
