using UnityEngine;
using SimpleUI;

public class SimpleController : MonoBehaviour
{
    private void Start()
    {
        SimpleUIBinder.BindAll();

        FairyLoadBundle fairyLoadBundle = SimpleFactory.CreateFairyLoadBundle();
        BundleComplete fairyWindow = SimpleFactory.CreateFairyWindow();
        StartCoroutine(fairyLoadBundle.DownLoadData<LoginWindowBundle>(fairyWindow));        
    }
}
