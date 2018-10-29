using UnityEngine;
using FairyGUI;
using UnityEngine.UI;

namespace SimpleUI
{
    public class SimpleController : MonoBehaviour
    {
        public static SimpleController Instance;
        public Text DebugText;
        public static void AddGUIDebug(string info)
        {
            Instance.DebugText.text += info;
        }
        private void Start()
        {
            Instance = this;
            UIObjectFactory.SetLoaderExtension(typeof(MyGLoader));
            MonoInst.SetupMono(this);
            SimpleFactory.CreateAppStart().StartApp(this);        
        }
    }
}

