using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject prefab;
    GameObject ClickPos;
    float clickPosX = -4.526f;
    float clickPosY = -4.583f;

    void Start()
    {
        for(int i = 0; i < 19; i++)
        {
            for (int j=0;j<19; j++)
            {
                GameObject piece = Instantiate(prefab, new Vector3(clickPosX, clickPosY, 0), Quaternion.identity);
                piece.GetComponent<Click_Pos>().index_X = j;
                piece.GetComponent<Click_Pos>().index_Y = i;
                clickPosX += 0.5f;
            }
            clickPosX = -4.526f;
            clickPosY += 0.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
