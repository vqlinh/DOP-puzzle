using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider;
    float time = 2f;  // Thời gian để thanh trượt giảm từ 1 về 0
    float maxTime;    // Lưu lại giá trị thời gian ban đầu

    // Start is called before the first frame update
    void Start()
    {
        maxTime = time;  // Lưu lại thời gian ban đầu
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            float full = time / maxTime;  // Tính giá trị của thanh trượt
            slider.value = full;
        }
        else
        {
            slider.value = 0f;
            LoadNextScene();
        }
    }
    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
