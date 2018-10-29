using System;
using System.IO;
using System.Net;
using UnityEngine;

namespace Extension
{
    public class HttpExtension
    {
        bool finish = false;
        HttpWebRequest myReq;
        public  string GetHttpWebRequest(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                myReq = (HttpWebRequest)WebRequest.Create(uri);
                myReq.Accept = "*/*";
                myReq.KeepAlive = true;
              
                myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                string stateObj = "";
                IAsyncResult aresult = myReq.BeginGetResponse(AsyncCallback, stateObj);
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("采集指定网址异常，" + ex.Message);
            }
        }

        public  void AsyncCallback(IAsyncResult aresult)
        {
            Debug.Log(aresult.AsyncState);
            if (aresult.IsCompleted)
            {

                //HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
                //Stream receviceStream = result.GetResponseStream();
                //StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("gb2312"));
                //string strHTML = readerOfStream.ReadToEnd();
                //Debug.Log(strHTML);
                //readerOfStream.Close();
                //receviceStream.Close();
                //result.Close();


                finish = true;
            }
        }
    }
}

