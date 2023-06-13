using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    public static Count instance;

    [HideInInspector]
    public TextMeshProUGUI timeText;
    [HideInInspector]
    public float time;
    public int limitTime;

    private SceneStateManager SSM;

    private void Awake()
    {
        instance = this;
        time = limitTime;
        timeText = GetComponent<TextMeshProUGUI>();
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

        timeText.text = "left time: " + Mathf.Ceil(time);

    }
}

