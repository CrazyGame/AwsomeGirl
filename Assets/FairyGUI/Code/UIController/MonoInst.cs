using System.Collections;
using UnityEngine;
namespace SimpleUI
{
    public class MonoInst : SingleInstance<MonoInst>
    {
        public MonoBehaviour MonoReference { get; set; }

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