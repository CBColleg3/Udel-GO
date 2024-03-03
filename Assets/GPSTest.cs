using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GPSTest : MonoBehaviour
{
    public TextMeshProUGUI lat;
    public TextMeshProUGUI lon;

    void Update()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogError("Location not enabled");
        }
        else if (Input.location.status != LocationServiceStatus.Running)
        {
            Input.location.Start(1, 0.1f);
        }
        Debug.LogError(Input.location.status);

        lat.text = Input.location.lastData.latitude.ToString();
        print(Input.location.lastData.latitude);
        lon.text = Input.location.lastData.longitude.ToString();
        print(Input.location.lastData.longitude);
    }
}
