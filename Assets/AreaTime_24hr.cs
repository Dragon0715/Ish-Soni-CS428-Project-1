using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class AreaTime_24hr : MonoBehaviour
{
    public GameObject timeTextObject;
    string url = "https://timeapi.io/api/Time/current/coordinate?latitude=42.04&longitude=-88.03";

    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("GetDataFromWeb", 2f, 10f);   
    }

   
    void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

            	int startHour = webRequest.downloadHandler.text.IndexOf("hour",0);
            	int endHour = webRequest.downloadHandler.text.IndexOf(",",startHour);
                int startMin = webRequest.downloadHandler.text.IndexOf("minute",0);
            	int endMin = webRequest.downloadHandler.text.IndexOf(",",startMin);
                int hour = int.Parse(webRequest.downloadHandler.text.Substring(startHour + 6, endHour - startHour - 6));
                int minute = int.Parse(webRequest.downloadHandler.text.Substring(startMin + 8, endMin - startMin - 8));
                string minute0 = "";

                if (minute < 10) {
                    minute0 = "0"; //API gives min as a single digit if min < 10, so this will add the 0 EX: 8 --> 08
                } 
                timeTextObject.GetComponent<TextMeshPro>().text = hour.ToString() + ":" + minute0 + minute.ToString();
            }
        }
    }
}