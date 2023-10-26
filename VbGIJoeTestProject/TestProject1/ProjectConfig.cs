using DotNetEnv;

namespace VbGIJoeTestProject;

public static class ProjectConfig
{
    public static string DeviceName = Env.GetString("DEVICE_NAME");
    public static string VbGiJoeAppPath = Env.GetString("VB_GI_JOE_APP_PATH");
}
