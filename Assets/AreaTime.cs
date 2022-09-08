using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class AreaTime : MonoBehaviour
{
    public GameObject timeTextObject;
    string url = "https://timeapi.io/api/Time/current/coordinate?latitude=40.71&longitude=-74.0";

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
                string AMorPM;

            	int startHour = webRequest.downloadHandler.text.IndexOf("hour",0);
            	int endHour = webRequest.downloadHandler.text.IndexOf(",",startHour);
                int startMin = webRequest.downloadHandler.text.IndexOf("minute",0);
            	int endMin = webRequest.downloadHandler.text.IndexOf(",",startMin);
                int hour = int.Parse(webRequest.downloadHandler.text.Substring(startHour + 6, endHour - startHour - 6));
                int minute = int.Parse(webRequest.downloadHandler.text.Substring(startMin + 8, endMin - startMin - 8));

                //Debug.Log(":\nhour= " + hour + " min= " + minute);

                if (hour > 12) {
                    hour = hour - 12;
                    AMorPM = "PM";
                } else {
                    AMorPM = "AM";
                }

                timeTextObject.GetComponent<TextMeshPro>().text = hour.ToString() + ":" + minute.ToString() + " " + AMorPM;
            }
        }
    }
}