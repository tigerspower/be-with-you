using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Star : MonoBehaviour
{
    private float timeTaken;

    [SerializeField]
    private List<GameObject> starObjects;

    private void Start()
    {
        
    }

    public void OnClear()
    {
        if (timeTaken <= 60)
        {
            Debug.Log("60��");
        }
        else if (timeTaken <= 120)
        {
            Debug.Log("120��");
            starObjects[0].SetActive(false);
        }
        else if (timeTaken <= 180)
        {
            Debug.Log("180��");
            starObjects[1].SetActive(false);
        }
        else
        {
            Debug.Log("Ÿ�Ӿƿ�");
        }

        Console.ReadLine();
    }
    

    private void Update()
    {
        OnClear();
    }
}