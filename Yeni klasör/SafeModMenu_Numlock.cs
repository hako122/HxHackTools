
using UnityEngine;

public class ModMenu : MonoBehaviour
{
    private bool showMenu = false;
    private int tabIndex = 0;
    private string[] tabs = new string[] { "Visual", "Aimbot", "Misc" };

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Numlock))
            showMenu = !showMenu;
    }

    void OnGUI()
    {
        if (!showMenu) return;

        GUI.Box(new Rect(50, 50, 400, 500), "Unturned Hack Menu");

        tabIndex = GUI.Toolbar(new Rect(60, 80, 380, 25), tabIndex, tabs);

        GUILayout.BeginArea(new Rect(60, 120, 380, 360));
        GUILayout.BeginVertical("box");

        switch (tabIndex)
        {
            case 0:
                VisualTab();
                break;
            case 1:
                AimbotTab();
                break;
            case 2:
                MiscTab();
                break;
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void VisualTab()
    {
        GUILayout.Label("▶ Player ESP");
        Toggle("Enabled");
        Toggle("Name");
        Toggle("Distance");
        Toggle("Box");

        GUILayout.Space(10);
        GUILayout.Label("▶ Item ESP");
        Toggle("Enabled");
        Toggle("Name");
        Toggle("Distance");
    }

    void AimbotTab()
    {
        GUILayout.Label("▶ Aimbot Settings");
        Toggle("Aimbot");
        Toggle("OnKey");
        Toggle("AimbotShowFOV");
        Slider("AimbotFOV", 0f, 50f);
        Slider("AimSpeed", 0f, 20f);
    }

    void MiscTab()
    {
        GUILayout.Label("▶ Misc Options");
        Toggle("Freecam");
        Toggle("InteractThroughWalls");
        Toggle("ShowPlayerOnMap");
        Toggle("ShowWeaponInfo");
    }

    void Toggle(string label)
    {
        bool val = PlayerPrefs.GetInt(label, 0) == 1;
        bool newVal = GUILayout.Toggle(val, label);
        if (newVal != val)
            PlayerPrefs.SetInt(label, newVal ? 1 : 0);
    }

    void Slider(string label, float min, float max)
    {
        float val = PlayerPrefs.GetFloat(label, min);
        GUILayout.Label(label + ": " + val.ToString("0.0"));
        float newVal = GUILayout.HorizontalSlider(val, min, max);
        if (newVal != val)
            PlayerPrefs.SetFloat(label, newVal);
    }
}
