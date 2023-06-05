using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPos;
    float targetPosY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject != null)
        {
            if(target.transform.position.y < 0){
                targetPosY = 0;
            }else
            {
                targetPosY = target.transform.position.y;
            }
            targetPos.Set(0, targetPosY, target.transform.position.z - 1);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}
