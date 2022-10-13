using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Player : MonoBehaviour
{
    public GameObject prefab;

    public GameObject go_black;
    public GameObject go_white;
    GameObject black;
    GameObject white;

    public int index_X;
    public int index_Y;

    float rangeX_min;
    float rangeX_max;
    float rangeY_min;
    float rangeY_max;

    public bool IsClicked = false;//중복방지
   

    private void OnMouseDown()
    {
        if (GameManager.Instance.isBlackTurn && !IsClicked && !GameManager.Instance.isGameFinish)
        {
            
            black = Instantiate(go_black, transform.position, Quaternion.identity);
            GameManager.Instance.go_Array[index_X, index_Y] = black;
            GameManager.Instance.isBlackTurn = false;
            IsClicked = true;

            GameManager.Instance.CheckGameFinish();
            Debug.Log("흙돌 소환");

            StartCoroutine(AiRandomWhiteRock());
        }

    }

    IEnumerator AiRandomWhiteRock()
    {
        yield return new WaitForSeconds(0.2f);

        //ai 랜덤으로 위치 생성(틀렸음!!)
        rangeX_min = black.transform.position.x - 0.5f;
        rangeX_max = black.transform.position.x + 0.5f;
        float randomX = Random.Range(rangeX_min, rangeX_max);

        for(int i= 0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                GameObject piece = Instantiate(prefab, new Vector3(black.transform.position.x, black.transform.position.y, 0), Quaternion.identity);
               //...
            }
        }

        rangeY_min = black.transform.position.y - 0.5f;
        rangeY_max = black.transform.position.y + 0.5f;
        float randomY = Random.Range(rangeY_min, rangeY_max);

        GameObject white = Instantiate(go_white, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        GameManager.Instance.go_Array[index_X, index_Y] = white;
        GameManager.Instance.isBlackTurn = true;
        IsClicked = true;

        GameManager.Instance.CheckGameFinish();
        Debug.Log("백돌 소환");
    }

   
}
