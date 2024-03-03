using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Text;
public class LoginHandler : MonoBehaviour
{
    // Start is called before the first frame update
    //InputField outputArea;
    public TMP_InputField outputArea;
    public TMP_InputField userName;
    public TMP_InputField password;
    public TMP_InputField dbaddress;

    public PlayerData user;

    void Start()
    {
        user = new PlayerData();
        //user = GetComponent<PlayerData>();
        //outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        GameObject.Find("LoginButton").GetComponent<Button>().onClick.AddListener(UserSpots);
    }

    void UserSpots() => StartCoroutine(UserSpots_Coroutine());


    IEnumerator UserSpots_Coroutine()
    {
        user.userName = userName.text;
        user.password = password.text;

        //user.triviaSpots = usermap.triviaSpots;
        Debug.Log("vic locations " + user.UserName);

        string uri = "http://"+dbaddress.text+":5000/login";

        using (UnityWebRequest request = new UnityWebRequest(uri, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(user.Stringify());
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                outputArea.text = request.downloadHandler.text;
        }

    }
    // Update is called once per frame

}
