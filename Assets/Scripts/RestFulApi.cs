using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.IO;



//TFG by Gerard Opazo Porcar
public class RestFulApi : MonoBehaviour
{
    //public static DataCollector myclass = new DataCollector();
    //TextMesh text3d;
    [ContextMenu("Test APIGet")]
    public async void ApiGetJson()
    {

        var url = "https://telraam-api.net/v1/segments/active_minimal";

        var httpResponse = new HttpResponse(new JsonSerialzeOpt());
        var jsonDeserialized = await httpResponse.Get<DeserializeJsonResp>(url);    //gets json deserialized
        //Call parser
        foreach (var i in jsonDeserialized.features)
            {
            var temp = i.properties.id.ToString();
            if (temp.Equals("166098")) // 9000001301 = Calle Roger de Flor, Barcelona, Spain, calle concurrida:166098, 9000000197, 9000001214,421535, 351311, 279386
            {
                Debug.Log(i.properties.id.ToString());
                Debug.Log(i.properties.pedestrian_avg.ToString());
                Debug.Log(i.properties.bike_avg.ToString());
                Debug.Log(i.properties.car_avg.ToString());
                Debug.Log(i.properties.lorry_avg.ToString());
                //myclass.id = i.properties.id.ToString();
                //myclass.pedestrian_avg = i.properties.pedestrian_avg;
                //myclass.bike_avg = i.properties.bike_avg;
                //myclass.car_avg = i.properties.car_avg;
                //myclass.lorry_avg = i.properties.lorry_avg;
                GetComponent<TextMesh>().text = "id: " + i.properties.id.ToString() + "\npedestrian: " + i.properties.pedestrian_avg.ToString()
                    + "\nbike: " + i.properties.bike_avg.ToString()  + "\ncar: " + i.properties.car_avg.ToString() + "\nlorry: " + i.properties.lorry_avg.ToString();

                
            }
            
            //else
            //    Debug.Log("Not Found");
                    
            }
    }
    /*var url = "https://telraam-api.net/v1/segments/active_minimal";
var ApiKey = "mvnWKjkhtO4XXbjeyPQsE9Z8Coa40dAD4lo8P7h6";
using (var www = UnityWebRequest.Get(url))
    {
    www.SetRequestHeader("X-Api-Key", ApiKey);
    www.SetRequestHeader("Accept", "application/json");
    www.SetRequestHeader("Content-Type", "application/json ");
    var operation = www.SendWebRequest();
    Debug.Log(ApiKey);

    while (!operation.isDone)
    {
        await Task.Yield();
    }
    var jsonResp = www.downloadHandler.text;
    if (www.result != UnityWebRequest.Result.Success)
        Debug.Log($"Failed:{www.error}");
    try
    {
        Debug.Log($"Okey:{www.downloadHandler.text}");
    }
    catch(Exception exception)
    {
        Debug.LogError($"Could not parse the response of the json {jsonResp}.{exception.Message}");
    }


    //JSONNode jsonobject = JSON.Parse(www.downloadHandler.text);

    //string info = jsonobject["sanitized"];

    //print("The data extracted is: " + info);


    //https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8
     */
}



