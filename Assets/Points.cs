using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int countPoints;
    // Start is called before the first frame update
    void Awake()
    {
        countPoints = transform.childCount;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
