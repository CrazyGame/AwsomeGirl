using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class FightIconTest {

    [Test]
    public void FightIconTestSimplePasses() {


       int MoveForwardSpeed = 200;
       int RoundMax = 700;
       int CurrentPostion = 0;
       int InitPostion = 0;

        for (int i = 0; i < 5; i++)
        {
            CurrentPostion += MoveForwardSpeed;
            if (CurrentPostion > RoundMax)
            {
                CurrentPostion = CurrentPostion - RoundMax + InitPostion;
            }
        }

        Assert.AreEqual(CurrentPostion, 300);

        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator FightIconTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
