using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.ExampleEvent += IncreaseSize;
    }
    void IncreaseSize()
    {
        transform.localScale = new Vector3(2, 2, 2);
    }
    private void OnDisable()//neu khong co ham nay thi khi doi tuong bi pha huy ma van goi su kien se bi  loi 
    {
        EventManager.ExampleEvent -= IncreaseSize;
    }
    public void XinChao()
    {
        Debug.Log("Hello world");    
    }
}
