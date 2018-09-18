using UnityEngine;
using System.Collections;

namespace SimpleUI
{
    public class SimpleController : MonoBehaviour
    {
        private void Start()
        {
            MonoInst.SetupMono(this);
            SimpleFactory.CreateAppStart().StartApp(this);
            //FairyLoadBundle fairyLoadBundle = SimpleFactory.CreateFairyLoadBundle();
            //BundleComplete fairyWindow = SimpleFactory.CreateFairyWindow();
            //StartCoroutine(fairyLoadBundle.DownLoadData<LoginWindowBundle>(fairyWindow));
        }
    }

    public class MonoInst:SingleInstance<MonoInst>
    {
        MonoBehaviour MonoReference { get; set; }

        public static void SetupMono(MonoBehaviour monoBehaviour)
        {
            GetInstance.MonoReference = monoBehaviour;
        }

        public static void RunConrotine(IEnumerator coroutine)
        {
            GetInstance.MonoReference.StartCoroutine(coroutine);
        }

        public static void StopConrotine(IEnumerator coroutine)
        {
            GetInstance.MonoReference.StopCoroutine(coroutine);
        }
    }


}

