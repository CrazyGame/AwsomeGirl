using UnityEngine;
using SimpleUI;

public class SimpleController : MonoBehaviour
{
    private void Start()
    {
        FairyLoadBundle fairyLoadBundle = SimpleFactory.CreateFairyLoadBundle();
        FairyWindow fairyWindow = SimpleFactory.CreateFairyWindow();
        StartCoroutine(fairyLoadBundle.DownLoadData<TabControllerBundle>(fairyWindow));
    }
}
