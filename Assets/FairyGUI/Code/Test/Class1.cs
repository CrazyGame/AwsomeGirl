using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

namespace Assets.FairyGUI.Code.Test
{
    class Class1
    {
        IEnumerator SoapHandler()
        {
            string request = @"http://10.0.180.120:10000/EdgBaseService";


            StringBuilder soap = new StringBuilder();

            soap.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            soap.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
            soap.Append("<soap12:Body>");
            soap.Append("<getWeather xmlns=\"http://WebXml.com.cn/\">");
            soap.Append("<theCityCode>深圳</theCityCode>");
            soap.Append("<theUserID></theUserID>");
            soap.Append("</getWeather>");
            soap.Append("</soap12:Body>");
            soap.Append("</soap12:Envelope>");

            WWWForm form = new WWWForm();
            var headers = form.headers;

            headers["Content-Type"] = "text/xml; charset=utf-8";
            headers["SOAPAction"] = request;
            headers["User-Agent"] = "gSOAP/2.8";

            WWW w = new WWW("http://ws.webxml.com.cn/WebServices/WeatherWS.asmx", Encoding.UTF8.GetBytes(soap.ToString()), headers);
            yield return w;
            if (w.isDone)
            {
                if (w.error != null)
                {
                    //print(w.error);
                }
                else
                {
                   // ParsingXml(w.text, Request_Type.SOAP);
                }
            }
        }
    }
}
