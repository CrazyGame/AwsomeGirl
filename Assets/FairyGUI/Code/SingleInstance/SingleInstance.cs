public class SingleInstance <T> where T:new()
{
    static SingleInstance()
    {
        Instance = new T();
    }
    static  T Instance = default(T);
    public static T GetInstance { get {return Instance;} }
}

public static class SingleInstanceExtension
{
    public static bool SetBundlePackageOfPoolInstance(this object obj,FairyGUI.UIPackage bundlePackage)
    {
        FairyPackagePoolImplmentSingleInstance.GetInstance.bundlePackage = bundlePackage;
        return true;
    }

    public static FairyGUI.UIPackage GetBundlePackageOfPoolInstance(this object obj)
    {
       return  FairyPackagePoolImplmentSingleInstance.GetInstance.bundlePackage;
    }

    public static bool LoadBundle(this object obj)
    {
        return FairyPackagePoolImplmentSingleInstance.GetInstance.bundlePackage != null;
    }

    public static T Inst<T>(this object obj)where T: SingleInstance<T>,new()
    {
        T TempValue = SingleInstance<T>.GetInstance;
        return SingleInstance<T>.GetInstance;
    }
}

public class FairyPackagePoolImplmentSingleInstance:SingleInstance<FairyPackagePoolImplment>
{
    
}