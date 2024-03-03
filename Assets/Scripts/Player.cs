// using UnityEngine;
// using System.Text;
// using UnityEngine.Networking;
// using System.Collections;

// public class Player : MonoBehaviour
// {
//     public float speed = 1.5f;

//     private Rigidbody2D _rigidBody2D;
//     private Vector2 _movement;

//     // void Start()
//     // {
//     //     _rigidBody2D = GetComponent<Rigidbody2D>();
//     //     _playerData = new PlayerData();
//     //     _playerData.plummie_tag = "nraboy";

//     //     _isGameOver = false;
//     // }

//     void Update()
//     {
//         // Mouse and keyboard input logic here ...
//     }

//     void FixedUpdate()
//     {
//         // Physics related updates here ...

//         if (_rigidBody2D.position.x > 24.0f && _isGameOver == false)
//         {
//             StartCoroutine(Upload(_playerData.Stringify(), result =>
//             {
//                 Debug.Log(result);
//             }));
//             _isGameOver = true;
//         }
//     }
//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         _playerData.collisions++;
//     }

//     IEnumerator Download(string id, System.Action<PlayerData> callback = null)
//     {
//         using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/plummies/" + id))
//         {
//             yield return request.SendWebRequest();

//             if (request.isNetworkError || request.isHttpError)
//             {
//                 Debug.Log(request.error);
//                 if (callback != null)
//                 {
//                     callback.Invoke(null);
//                 }
//             }
//             else
//             {
//                 if (callback != null)
//                 {
//                     callback.Invoke(PlayerData.Parse(request.downloadHandler.text));
//                 }
//             }
//         }
//     }
//     IEnumerator Upload(string profile, System.Action<bool> callback = null)
//     {
//         using (UnityWebRequest request = new UnityWebRequest("http://localhost:3000/plummies", "POST"))
//         {
//             request.SetRequestHeader("Content-Type", "application/json");
//             byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
//             request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//             request.downloadHandler = new DownloadHandlerBuffer();
//             yield return request.SendWebRequest();

//             if (request.isNetworkError || request.isHttpError)
//             {
//                 Debug.Log(request.error);
//                 if (callback != null)
//                 {
//                     callback.Invoke(false);
//                 }
//             }
//             else
//             {
//                 if (callback != null)
//                 {
//                     callback.Invoke(request.downloadHandler.text != "{}");
//                 }
//             }
//         }
//     }

//     void Start()
//     {
//         _rigidBody2D = GetComponent<Rigidbody2D>();
//         _playerData = new PlayerData();
//         _playerData.plummie_tag = "nraboy";
//         StartCoroutine(Download(_playerData.plummie_tag, result =>
//         {
//             Debug.Log(result);
//         }));
//     }


// }