using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor;

    //void OnEnable()
    //{
    //    EventManager.ExampleEvent += SetNewColor;
    //}
    void Start()
    {
        EventManager.ExampleEvent += SetNewColor;
    }

    
    void SetNewColor()
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }
    private void OnDisable()
    {
        EventManager.ExampleEvent -= SetNewColor;
    }
    public void XinChao()
    {
        Debug.Log("Hello world");
    }
}
