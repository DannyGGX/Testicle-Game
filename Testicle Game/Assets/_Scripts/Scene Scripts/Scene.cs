using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scene
{
    public Scenes SceneName;
    public int BuildIndex;
}

/// <summary>
/// Names of the scenes for the build.
/// </summary>
public enum Scenes
{
    MainMenu,

    // Levels
    Level1,
}
