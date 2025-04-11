using UnityEngine;

public class Loader
{
    public static void Init()
    {
        GameObject obj = new GameObject();
        obj.AddComponent<ModMenu>();
        GameObject.DontDestroyOnLoad(obj);
    }
}
