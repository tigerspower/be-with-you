using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    private SceneStateManager SSM;

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPos;
    float targetPosY;
    // Start is called before the first frame update
    void Start()
    {
        SSM = SceneStateManager.instance;
    }

     
    void Update()
    {
        if(target.gameObject != null)
        {
            print(SSM.stageIndex - 1 * 250);
            if(target.transform.position.y < ((SSM.stageIndex - 1) * 250) - 3)
            {
                targetPosY = ((SSM.stageIndex - 1) * 250) - 3;
            }
            else
            {
                targetPosY = target.transform.position.y;
            }
            targetPos.Set(0, targetPosY, target.transform.position.z - 1);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}   
