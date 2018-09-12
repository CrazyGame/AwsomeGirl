public class SimpleFactory
{
    public static FairyLoadBundle CreateFairyLoadBundle()
    {
        return new FairyLoadBundleImplement();
    }

    public static BundleComplete CreateFairyWindow()
    {
        return new FairyStartBundleImplement();
    }
}
