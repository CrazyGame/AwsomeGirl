using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;

public class RegularTest
{

    [Test]
    public void RegularTestSimplePasses() {

        string input = @"http://10.0.120.183:8080/TPlant/static/602cf9f0d3614a96b39c77dc451682cd/8b78287ed9784a75842c25370a7ee2d9/034c1f75ccba46e0bfa8972fc7e2a84d/60-F8831S-J0804-01-2.svg";
        string expected = @"60-F8831S-J0804-01-2.svg";

        string pattern = @"[0-9]{2,2}-[A-Za-z0-9]{6,6}-[A-Za-z0-9]{5,5}-[0-9]{2,2}-[0-9]{1}.svg";

        Match matched = Regex.Match(input, pattern);
        Assert.AreEqual(matched.Value, expected);


        string[] first = input.Split('/');
        int firstCount = first.Length;
        string result = first[firstCount - 1];
        Assert.AreEqual(result, expected);



    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator RegularTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
