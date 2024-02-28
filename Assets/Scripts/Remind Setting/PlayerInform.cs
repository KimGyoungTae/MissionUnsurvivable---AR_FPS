using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI에 접근하기 위해서 사용

public class PlayerInform : MonoBehaviour
{
    public static PlayerInform instance;    // statci(정적)으로 선언하여 어디에서나 자기 자신을 저장하도록 만든다.
    public Text PlayerScore;      //UI에 표시되는 "Score : " 
    private int CurrentScore = 0;   //적을 죽일때마다 올라가는 점수

    void Awake()
    {
        if (!instance) instance = this; //이거 중요..
        // 정적으로 자신을 체크하여 자기 자신을 저장한다.
        // 넣지 않는다면 nullreferenceexception 오류 발생

        PlayerScore.text = CurrentScore.ToString("Score : 0");  // int형으로 받은 점수를 UI Text에 갱신할 수 있도록 형변환  
    }

    public void AddScore(int getScore)
    {
        CurrentScore += getScore;
        PlayerScore.text = CurrentScore.ToString("Score : 0");  // UI창에 현재 점수 업데이트
    }
}
