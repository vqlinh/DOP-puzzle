using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public GameObject hidenpart;
    public GameObject line;
    public Points points;
    public int count;
    public bool win=false;
    public Animator animator;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject tick;
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
        animator = GameObject.Find("Full").GetComponent<Animator>();
        animator.enabled = false;
        tick.SetActive(false);

    }
    private void Update()
    {
        if (win)
        {
            hidenpart.SetActive(true);
            animator.enabled = true;
            tick.SetActive(true);
            for (int i = 0; i < points.transform.childCount; i++)
            {
                GameObject child = points.transform.GetChild(i).gameObject;

                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                    spriteRenderer.enabled = false;
            }
            Invoke(nameof(Effect), 0.5f);
            win=false;
        }
    }
    void Effect()
    {
        GameObject eff = Instantiate(effect1, Vector2.zero, Quaternion.identity);
        GameObject eff2 = Instantiate(effect2, Vector2.zero, Quaternion.identity);
    }

}
