using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public static bool IsModule1 = false;
    public static bool IsModule2 = false;
    public static bool IsModule3 = false;

    private void DisableModules()
    {
        IsModule1 = false;
        IsModule2 = false;
        IsModule3 = false;
    }

    public void SelectModule1()
    {
        DisableModules();
        IsModule1 = true;
    }

    public void SelectModule2()
    {
        DisableModules();
        IsModule2 = true;
    }

    public void SelectModule3()
    {
        DisableModules();
        IsModule3 = true;
    }
}
