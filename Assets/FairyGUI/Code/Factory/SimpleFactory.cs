public class SimpleFactory
{
    public static FairyLoadBundle CreateFairyLoadBundle()
    {
        return new FairyLoadBundleImplement();
    }

    public static FairyWindow CreateFairyWindow()
    {
        return new FairyWindowImplement();
    }
}
