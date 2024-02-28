using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI�� �����ϱ� ���ؼ� ���

public class PlayerInform : MonoBehaviour
{
    public static PlayerInform instance;    // statci(����)���� �����Ͽ� ��𿡼��� �ڱ� �ڽ��� �����ϵ��� �����.
    public Text PlayerScore;      //UI�� ǥ�õǴ� "Score : " 
    private int CurrentScore = 0;   //���� ���϶����� �ö󰡴� ����

    void Awake()
    {
        if (!instance) instance = this; //�̰� �߿�..
        // �������� �ڽ��� üũ�Ͽ� �ڱ� �ڽ��� �����Ѵ�.
        // ���� �ʴ´ٸ� nullreferenceexception ���� �߻�

        PlayerScore.text = CurrentScore.ToString("Score : 0");  // int������ ���� ������ UI Text�� ������ �� �ֵ��� ����ȯ  
    }

    public void AddScore(int getScore)
    {
        CurrentScore += getScore;
        PlayerScore.text = CurrentScore.ToString("Score : 0");  // UIâ�� ���� ���� ������Ʈ
    }
}
