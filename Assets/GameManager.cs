using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public GameObject hidenpart;
    public GameObject line;
    public Points points;
    public int count;
    private void Awake()
    {
        i = this;
        if (line != null)
        {
            Instantiate(line, Vector2.zero, Quaternion.identity);
        }
    }
    void Start()
    {
        count = points.countPoints;
        hidenpart.SetActive(false);
  
    }

}
