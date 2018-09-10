using System.Collections;
using FairyGUI;
/// <summary>
/// Reference to class generate from fairyGUI
/// </summary>
public interface FairyGUIBundle
{
    string BundleName { get; }
    string ResName { get; }
}

/// <summary>
/// Load Asset bundle using www class from UnityEngine
/// </summary>
public interface FairyLoadBundle
{
    IEnumerator DownLoadData<T>(FairyWindow fairyWindow) where T : FairyGUIBundle, new();
}

public interface FairyWindow
{
    Window CreateWindow(GObject obj);
}