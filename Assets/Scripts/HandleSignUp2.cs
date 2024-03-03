
/*using System.Collections;
using UnityEngine;
using System.SimpleJson;

using UnityEngine.Networking;
using TMPro;
public class LoadJSON : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_InputField password;
    public TMP_InputField hostURL;
    //    public TMP_Text countryTxt;    TMP_Text can be used to desplay data from the json body
    public void fetchData()
    {
        string userEmail = userName.text;       //pulls the user submitted text from text field
        string userPassword = password.text;    //pulls the user submitted text from text field
        UserCreds credentials = new UserCreds();
        credentials.userName = userEmail;              //sets the values of the serialized class credentials 
        credentials.password = userPassword;        //so that a JSON object can be sent as byte data
        StartCoroutine(SignUp(credentials));
    }
    IEnumerator SignUp(UserCreds credentials)
    {
        string URL = "http://localhost:5000";  //this is the rest api address pulled from the text field

        string jsonData = JsonUtility.ToJson(credentials);//this turns the class into a json string

        using (UnityWebRequest restAPI = UnityWebRequest.Put(URL + "/users/signup", jsonData))
        {
            restAPI.method = UnityWebRequest.kHttpVerbPOST;  //this is declaring that we are actually sending a POST not a PUT, this is a little hack as above we declared it a PUT

            restAPI.SetRequestHeader("content-type", "application/json");
            restAPI.SetRequestHeader("Accept", "application/json");

            yield return restAPI.SendWebRequest();//sends out the request and waits for the returned content.

            if (restAPI.isNetworkError || restAPI.isHttpError) //checks for errors
            {
                Debug.Log(restAPI.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                if (restAPI.isDone)
                {
                    JSONNode returnedBody = JSON.Parse(System.Text.Encoding.UTF8.GetString(restAPI.downloadHandler.data));//this takes the returned body from the rest api(this works for rest services that return JSON bodies only, use another configuration for other systems) and changes the content to UTF8 or "standard characters" so it can be turned into a string, it saves this data to the JSONNode object named returnedBody
                    if (returnedBody == null)// if there is no returned body this assumes the connection failed because my rest api returns a return value if the log in attempt is valid or invalid, so no return means it failed to work in general.
                    {
                        Debug.Log("failed log in");
                    }
                    else
                    {
                        Debug.Log(returnedBody);//this DISPLAYS the information the rest api sent in response to the POST.
                    }
                }
            }
        }

    }
}
*/