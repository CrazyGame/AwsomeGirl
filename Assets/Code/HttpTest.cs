using UnityEngine;
using CI.HttpClient;
using System;

public class HttpTest : MonoBehaviour {

    HttpClient httpClient = new HttpClient();
    // Use this for initialization
    void Start () {

        StringContent stringContent = new StringContent("", System.Text.Encoding.UTF8, "application/json");

        httpClient.Post(new Uri("http://www.baidu.com"), null, HttpCompletionOption.AllResponseContent, (r) =>
        {
            string encodeData = System.Text.Encoding.UTF8.GetString(r.Data, 0, r.Data.Length);
            Debug.Log(encodeData);
        });

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
