
using UnityEngine;
using Extension;

public class HttpTools : MonoBehaviour
{
    string url = "http://baidu.com";
	void Start ()
    {
        HttpExtension httpExtension = new HttpExtension();
        string source = httpExtension.GetHttpWebRequest(url);
       Debug.Log(source);		
	}
}



