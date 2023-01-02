using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject o;

    public void LogText(string text)
    {
        Debug.Log(text);
    }

    private void Update()
    {
        if (o.GetComponent<Clickable>().getClicked())
        {
            o.GetComponent<Clickable>().setClicked(false);
            LogText("Planet");
        }
    }
}
