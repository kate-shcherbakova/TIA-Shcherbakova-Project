using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityCheck : MonoBehaviour
{
    public bool isVisbile;

    public void onFound()
    {
        isVisbile = true;
    }

    public void onLost()
    {
        isVisbile = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
