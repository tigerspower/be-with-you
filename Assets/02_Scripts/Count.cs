using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    public static Count instance;

    public TextMeshProUGUI timeText;
    public float time;
    public int limitTime;

    private SceneStateManager SSM;

    private void Awake()
    {
        instance = this;
        time = limitTime;
    }

    private void Start()
    {
        SSM = SceneStateManager.instance;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            SSM.OnFail();
        }

        timeText.text = Mathf.Ceil(time).ToString();

    }
}

