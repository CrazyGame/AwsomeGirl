using System.Collections;
using FairyGUI;
/// <summary>
/// Reference to class generate from fairyGUI
/// </summary>
public interface FairyGUIBundle
{
    string ResName { get; }
}

/// <summary>
/// Load Asset bundle using www class from UnityEngine
/// </summary>
public interface FairyLoadBundle
{
    IEnumerator DownLoadData<T>(BundleComplete fairyWindow) where T : FairyGUIBundle, new();
   
}

public interface UIMedia
{
    GComponent Inject();
}

public interface UIMdeiaDispose
{
    bool Disposable { get; set; }
}

public interface WindowName
{
    string Key { get;}
}


public interface CreateCommand
{
    GComponent Command();
}


public interface BundleComplete
{
    void OnComplete();
}

public interface FairyPackagePool
{
    UIPackage bundlePackage { get; set;}
}