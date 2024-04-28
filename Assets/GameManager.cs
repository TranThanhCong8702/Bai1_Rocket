using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<GameObject> Balls;
    [SerializeField] List<Vector3> FreePos;
    [SerializeField] GameObject Player;

    [SerializeField] GameObject GamePlay;
    [SerializeField] GameObject MainUI;
    [SerializeField] GameObject EndPanel;
    [SerializeField] GameObject IngamePanel;
    [SerializeField] Text points;
    [SerializeField] Text EndTxt;

    public int PlayerPoints = 0;

    public void PlayGame()
    {
        Time.timeScale = 1f;
        Player.SetActive(true);
        MainUI.SetActive(false);
        IngamePanel.SetActive(true);
        PlayerPoints = 0;
        points.text = PlayerPoints.ToString();
        GamePlay.SetActive(true);
    }

    public void BackMain()
    {
        EndPanel.SetActive(false);
        MainUI.SetActive(true);
        GamePlay.SetActive(false);
        IngamePanel.SetActive(false);
    }

    public void AddPoints()
    {
        PlayerPoints++;
        points.text = PlayerPoints.ToString();
        if(PlayerPoints == 10)
        {
            Time.timeScale = 0f;
            EndPanel.SetActive(true);
            EndTxt.text = "YOU WIN";
        }
    }
    public void Loss()
    {
        Time.timeScale = 0f;
        EndPanel.SetActive(true);
        EndTxt.text = "YOU LOSS";
    }

    private void Awake()
    {
        Instance = this;
    }
    public Vector3 FindPos()
    {
        FreePos.Clear();
        for(int i = -4; i < 5; i++)
        {
            for(int j = -4; j < 5; j++)
            {
                Vector3 temp = new Vector3(i, 0.5f, j);
                if (CheckFreePos(temp))
                {
                    FreePos.Add(temp);
                }
            }
        }
        int k = Random.Range(0, FreePos.Count);
        return FreePos[k];
    }
    public bool CheckFreePos(Vector3 pos)
    {
        int dem = 0;
        foreach(GameObject obj in Balls)
        {
            if(obj.transform.position.Equals(pos))
            {
                dem++;
            }
        }
        Debug.Log(dem);
        if(dem == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
