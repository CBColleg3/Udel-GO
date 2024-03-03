using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mapbox.Examples;
using Mapbox.Utils;

public class EventPointer : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    [SerializeField] float yOffset;

    LocationStatus playerLocation;
    public Vector2d eventPos;

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        gameObject.transform.position = new Vector3(transform.position.x,  (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + yOffset, transform.position.z);
    }

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        var curPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLong());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = curPlayerLocation.GetDistanceTo(eventLocation);


        Debug.Log("Clicked on Event!");
        Debug.Log("curPlayerLat: " + curPlayerLocation.Latitude + "curPlayerLong: " + curPlayerLocation.Longitude);
        Debug.Log("distance: " + distance);

        
    }
}
