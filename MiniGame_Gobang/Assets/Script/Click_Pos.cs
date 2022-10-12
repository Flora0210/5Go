using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click_Pos : MonoBehaviour
{
    public GameObject go_black;
    public GameObject go_white;
    
    public int index_X;
    public int index_Y;

    public bool IsClicked = false;//중복방지

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.isBlackTurn&& !IsClicked && !GameManager.Instance.isGameFinish)
        {
            GameObject black = Instantiate(go_black, transform.position, Quaternion.identity);
            GameManager.Instance.go_Array[index_X,index_Y] = black;
            GameManager.Instance.isBlackTurn = false;
            IsClicked = true;

            GameManager.Instance.CheckGameFinish();
            Debug.Log("흙돌 소환");

            //StartCoroutine(AiWhiteRock());//
        }
        else if(!GameManager.Instance.isBlackTurn && !IsClicked && !GameManager.Instance.isGameFinish)
        {
            GameObject white = Instantiate(go_white, transform.position, Quaternion.identity);
            GameManager.Instance.go_Array[index_X, index_Y] = white;
            GameManager.Instance.isBlackTurn = true;
            IsClicked = true;

            GameManager.Instance.CheckGameFinish();
            Debug.Log("백돌 소환");

            //StartCoroutine(AiBlackRock());//
        }
       
    }
    //IEnumerator AiWhiteRock()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    GameObject white = Instantiate(go_white, transform.position, Quaternion.identity);
    //    GameManager.Instance.go_Array[index_X, index_Y] = white;
    //    GameManager.Instance.isBlackTurn = true;
    //    IsClicked = true;

    //    GameManager.Instance.CheckGameFinish();
    //    Debug.Log("백돌 소환");
    //}
    //IEnumerator AiBlackRock()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    GameObject black = Instantiate(go_black, transform.position, Quaternion.identity);
    //    GameManager.Instance.go_Array[index_X, index_Y] = black;
    //    GameManager.Instance.isBlackTurn = false;
    //    IsClicked = true;

    //    GameManager.Instance.CheckGameFinish();
    //    Debug.Log("흙돌 소환");
    //}

}
