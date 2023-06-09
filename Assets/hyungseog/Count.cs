using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public static float time;

    private void Awake()
    {
        time = 180f;
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;

        timeText.text = Mathf.Ceil(time).ToString();
    }
}

