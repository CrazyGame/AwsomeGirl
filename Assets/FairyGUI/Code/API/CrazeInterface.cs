using System.Collections;
using FairyGUI;
using UnityEngine;
/// <summary>
/// Reference to class generate from fairyGUI
/// </summary>
public interface AssetBundleResName
{
    string ResName { get; }
}

/// <summary>
/// Load Asset bundle using www class from UnityEngine
/// </summary>
public interface FairyLoadBundle
{
    IEnumerator DownLoadData<T>(BundleComplete fairyWindow) where T : AssetBundleResName, new();
   
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
    void OnComplete(AssetBundle bundle);
}



public interface FairyPackagePool
{
    UIPackage bundlePackage { get; set;}
}