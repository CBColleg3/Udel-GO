using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaSpotPosition
{
    public int x;
    public int y;
    
    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static TriviaSpotPosition Parse(string json)
    {
        return JsonUtility.FromJson<TriviaSpotPosition>(json);
    }
}
