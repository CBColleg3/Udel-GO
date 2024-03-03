using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class GetMethod : MonoBehaviour
{
    // Start is called before the first frame update
    //InputField outputArea;
    public TMP_InputField outputArea;

    void Start()
    {
        //outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        Debug.Log(GameObject.Find("GetButton"));
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    void GetData() => StartCoroutine(GetData_Coroutine());


    IEnumerator GetData_Coroutine()
    {
        // outputArea.text = outputArea.text;
        Debug.Log(outputArea.text);  // Check if outputArea is not null
        //yield return null;
        // WWWForm playForm = new WWWForm();
        //         playForm.AddField("id", myJson.id);
        //         playForm.AddField("name", myJson.name);
        string uri = "http://localhost:5000/users";
        if (uri != null)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                    outputArea.text = request.error;
                else
                    outputArea.text = request.downloadHandler.text;
            }
        }
        else
        {
            outputArea.text = "Loading...";
            // Attempting to use mClass here will result in NullReferenceException
        }

    }
    // Update is called once per frame

}
