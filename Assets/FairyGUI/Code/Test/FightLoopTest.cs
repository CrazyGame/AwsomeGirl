using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;



public interface FinishInterface
{
    bool IsFinish();
}


public class ActionA :FinishInterface
{

    bool isFinish = true;
    public void SetFinish(bool isFinish)
    {
        this.isFinish = isFinish;
    }

    public bool IsFinish()
    {
        return isFinish;
    }
}


public class ActionB : FinishInterface
{

    bool isFinish = true;
    public void SetFinish(bool isFinish)
    {
        this.isFinish = isFinish;
    }

    public bool IsFinish()
    {
        return isFinish;
    }
}



public class FightLoopTest
{

    int  currentIndex = 0;
    List<FinishInterface> listActions = new List<FinishInterface>();

  

    FinishInterface LoopActions(int index)
    {
        if (index >= listActions.Count) return null;
        if (listActions[index].IsFinish())
        {
            index++;
            if (currentIndex >= listActions.Count)
            {
                index = 0;
            }
        }
        return LoopActions(index);
    }


    [Test]
    public void FightLoopTestSimplePasses() {


        int count = 0;

        listActions.Add(new ActionA());
        listActions.Add(new ActionB());

        while (count < 3)
        {
            FinishInterface finishInterface = LoopActions(currentIndex);
            count++;
        }
        Assert.AreEqual(count, 3);
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator FightLoopTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
