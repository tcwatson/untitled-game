using UnityEditor;

public class WebGLBuilder
{
    static void PerformBuild()
    {
        string[] scenes = { "Assets/Scenes/Main.unity" };
        BuildPipeline.BuildPlayer(scenes, "./builds", BuildTarget.WebGL, BuildOptions.None);
    }
}
