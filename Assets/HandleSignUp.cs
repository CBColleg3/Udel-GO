using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Mapbox.MapMatching;
using System.Text;
using Mapbox.Examples;
using UnityEditorInternal;
public class HandleSignUp : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField outputArea;
    public TMP_InputField userName;
    public TMP_InputField password;
    public TMP_InputField dbaddress; 
    
    public PlayerData user;
    public SpawnOnMap usermap;

    void Start()
    {
        //outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        user = new PlayerData();
        
        
        GameObject.Find("SignUpButton").GetComponent<Button>().onClick.AddListener(PostUser);
    }

    void PostUser() => StartCoroutine(PostUser_Coroutine());


    IEnumerator PostUser_Coroutine()
    {
        // outputArea.text = outputArea.text;
        // Check if outputArea is not null
        //yield return null;
        
        
        if (userName.text != null && password.text != null && usermap.triviaSpots != null)
        {
            Debug.Log(password.text);
            Debug.Log(userName.text);

            user.userName = userName.text;
            user.password = password.text;

            user.triviaSpots = usermap.triviaSpots;
            Debug.Log("vic locations " + user.triviaSpots.GetType());
            /*if (user.triviaSpotPositions == null) 
            {
                
            } else {
                
            }*/
            string uri = "http://128.4.159.165:5000/users/signup";
            Debug.Log("Hey " + uri);
            /*
            var link = new WWW("http://localhost:5000/users/signup", userForm);

            // this is what you need to add
            yield return link;


            if (link.error != "")
            {
                Debug.Log("Error uploading: " + link.error);
            }
            else
            {
                Debug.Log("Finished uploading data");
            }
            */

            using (UnityWebRequest request = new UnityWebRequest(uri,"POST"))
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
        //userName.text = "";
        //password.text = "";
        // Update is called once per frame

    }
}