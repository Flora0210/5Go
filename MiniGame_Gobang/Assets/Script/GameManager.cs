using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isBlackTurn = true;
    public Text count_Text;

    public GameObject[,] go_Array = new GameObject[19,19];//C#배열
    bool isCurrentPosisNull = false;// 현재위치가 null이니? = 아니! 
    int count = 0;
    string currentRock = "";
    public bool isGameFinish = false;

    public GameObject finishPopUp;
    private void Awake()
    {
        Instance = this;
        
    }
   

    public void CheckGameFinish()
    {
        // 연속으로 5개이상이면 게임 종료 (체크 함수)
        // 세로 체크
        for (int i = 0; i < 19; i++)
        {
            Debug.Log(i + "번째 칸 열 탐색");
            for (int j = 0; j < 19; j++)
            {
                if(go_Array[i,j] != null)
                {
                    if (currentRock == "")
                    {
                        currentRock = go_Array[i, j].gameObject.tag;
                        count++;
                        checkOverFive(count, currentRock);
                    }
                    else
                    {
                        if (currentRock == go_Array[i, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            count = 1;
                            currentRock = go_Array[i, j].gameObject.tag;
                        }
                    }
                }

                else
                {
                    currentRock = "";
                    count = 0;
                    //Debug.Log("못 찾았다");
                }
            }
        }

        // 가로체크
        for (int j = 0; j < 19; j++)
        {
            Debug.Log(j + "번째 칸 열 탐색");
            for (int i = 0; i < 19; i++)
            {
                if (go_Array[i, j] != null) // 무언가를 발견했다!
                {
                    if (currentRock == "") // 현재 찾으려는 바둑돌이 없다!(이전에 찾고있던 돌이 없었다)
                    {
                        currentRock = go_Array[i, j].gameObject.tag; // 현재 찾으려는 바둑돌을 지금 발견한 바둑돌(흑/백) 로 지정한다.
                        count++; // 일단 1개 발견했으니 count 증가
                        checkOverFive(count, currentRock);
                    } 
                    else
                    {
                        if (currentRock == go_Array[i, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            count = 1;
                            currentRock = go_Array[i, j].gameObject.tag;
                        }
                    }
                }

                else
                {
                    currentRock = "";
                    count = 0;
                    //Debug.Log("못 찾았다");
                }
            }
        }

        // 대각선체크(LeftUp-->RightDown 아래 반쪽)
        for(int i = 4; i < 18; i++)
        {
            int templ = i;
            for(int j = 0; j <= i; j++)
            {
                if (go_Array[templ, j] != null)
                {
                    if (currentRock == "")
                    {
                        currentRock = go_Array[templ, j].gameObject.tag;
                        count++;
                        checkOverFive(count, currentRock);
                    }
                    else
                    {
                        if (currentRock == go_Array[templ, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            currentRock = go_Array[templ, j].gameObject.tag;
                            count++;
                            checkOverFive(count, currentRock);
                        }


                    }
                }
                else
                {
                    currentRock = "";
                    count = 0;
                }
                templ--;
            }
        }

        // 대각선체크(LeftUp-->RightDown 위 반쪽)
        for (int i=0; i<=14; i++)
        {
            int templ = i;
            for (int j = 18; j>=i ; j--)
            {
                if (go_Array[templ, j] != null)
                {
                    if (currentRock == "")
                    {
                        currentRock = go_Array[templ, j].gameObject.tag;
                        count++;
                        checkOverFive(count, currentRock);
                    }
                    else
                    {
                        if (currentRock == go_Array[templ, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            currentRock = go_Array[templ, j].gameObject.tag;
                            count++;
                            checkOverFive(count, currentRock);
                        }


                    }
                }
                else
                {
                    currentRock = "";
                    count = 0;
                }
                templ++;
            }
        }

        // 대각선체크(RightUp-->LeftDown )

    }

    void checkOverFive(int count, string currentRock)
    {
        if(count >= 5)
        {
            Debug.Log("Finish. count : "+count);
            finishPopUp.SetActive(true);
            finishPopUp.transform.GetChild(0).GetComponent<Text>().text = currentRock+ " 승리!!";
            Time.timeScale = 0;
            isGameFinish = true;
        }
        
    }
}
