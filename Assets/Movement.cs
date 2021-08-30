using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject obj;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            obj.transform.localPosition = obj.transform.localPosition + new Vector3(-1f,0,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            obj.transform.localPosition = obj.transform.localPosition + new Vector3(1f,0,0);
        }
        if(Input.GetKey(KeyCode.W))
        {
            obj.transform.localPosition = obj.transform.localPosition + new Vector3(0,1f,0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            obj.transform.localPosition = obj.transform.localPosition + new Vector3(0,-1f,0);
        }
        
    }
}
