using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public GameObject hidenpart;
    public GameObject line;
    public Points points;
    public int count;
    public bool win = false;
    public Animator animator;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject tick;

    public float time;
    public TextMeshProUGUI cooldown;
    public bool timer = true;
    public UiPanelDotween ui;
    public Sprite lose;
    public Sprite replay;
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
            Invoke(nameof(UiWin), 1f);
            win = false;
        }


        if (!win&& time > 0)
        {
            time -= Time.deltaTime;
            cooldown.text = Mathf.CeilToInt(time).ToString();
            if (time<=0)
            {
                ui.PanelFadeIn();

                GameObject.Find("Board").GetComponent<Image>().sprite=lose;
                GameObject.Find("Next").GetComponent<Image>().sprite = replay;
                Debug.Log("Lose");

                timer = false;
            }

        }


    }
    void Effect()
    {
        GameObject eff = Instantiate(effect1, Vector2.zero, Quaternion.identity);
        GameObject eff2 = Instantiate(effect2, Vector2.zero, Quaternion.identity);
    }
    void UiWin()
    {
        ui.PanelFadeIn();
    }

}
