using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_JoinEvent : MonoBehaviour
{
    [SerializeField] GameObject uI_JoinEvent;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayEventUI(bool value)
    {
        uI_JoinEvent.SetActive(value);
    }

    public void DisplayTooFarAwayUI(bool value)
    {
        text.SetText("You're too far away... get closer to the stop!");
        uI_JoinEvent.SetActive(value);
    }
}
