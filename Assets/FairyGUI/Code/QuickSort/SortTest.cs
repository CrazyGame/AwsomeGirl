using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using SimpleSort;

public class SortTest
{
    [Test]
    public void SortTestSimplePasses() {

        List<int> list = new List<int>();
        list.Add(5);
        list.Add(90);
        list.Add(1);
        list.Add(15);
        SortHelper.SelectSort(list);
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
        Assert.AreEqual(list[0], 1);      
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator SortTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
