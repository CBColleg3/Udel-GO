using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPointer : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float amplitude;
    [SerializeField] float frequency;


    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        gameObject.transform.position = new Vector3(transform.position.x,  (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + 15f, transform.position.z);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on Event!");
    }
}
