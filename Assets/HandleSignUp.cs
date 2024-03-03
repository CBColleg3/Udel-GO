using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class SignUp : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField outputArea;
    public TMP_InputField username;
    public TMP_InputField password;

    void Start()
    {
        //outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        Debug.Log(GameObject.Find("SignUpButton"));
        GameObject.Find("SignUpButton").GetComponent<Button>().onClick.AddListener(PostUser);
    }

    void PostUser() => StartCoroutine(PostUser_Coroutine());


    IEnumerator PostUser_Coroutine()
    {
        // outputArea.text = outputArea.text;
        // Check if outputArea is not null
        //yield return null;
        WWWForm userForm = new WWWForm();
        if (username.text != null && password.text != null)
        {
            Debug.Log(password.text);
            Debug.Log(username.text);
            userForm.AddField("userName", username.text);
            userForm.AddField("password", password.text);
            string uri = "http://localhost:5000/users/signup";

            using (UnityWebRequest request = UnityWebRequest.Post(uri, userForm))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                    outputArea.text = request.error;
                else
                    outputArea.text = request.downloadHandler.text;
            }

        }
        username.text = "";
        password.text = "";
        // Update is called once per frame

    }
}