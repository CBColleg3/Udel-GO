using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Script : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    [TextArea]
    public string[] QuestionArray;
    
    // Start is called before the first frame update
    void Start()
    {
        int rng = Random.Range(0, QuestionArray.Length);
        textMeshProUGUI.SetText(QuestionArray[rng]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
