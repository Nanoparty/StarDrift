using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool clicked = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
        Debug.Log("Clicked");
    }

    public bool getClicked()
    {
        return clicked;
    }
    public void setClicked(bool b)
    {
        clicked = b;
    }
}