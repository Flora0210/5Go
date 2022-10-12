using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Player : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AiPlayer()
    {
       if( GameManager.Instance.isBlackTurn)
       {

       }
       else if (!GameManager.Instance.isBlackTurn)
       {

       }
    }
    
    public Vector3 GetAiRandomPosition()
    {
        Vector3 go_ai = new Vector3(0, 0, 0);
        return go_ai;
    }

}
