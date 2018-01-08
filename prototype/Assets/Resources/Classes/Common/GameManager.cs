using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int score;
    public string accountScore;
    public string accountName;
    public string accountName1;
    public string accountName2;
    public string accountName3;
    public int gameManagerAccountID = 1;

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        LoadAccountData(gameManagerAccountID);
    }

	public void LoadAccountData(int accountID) {
        gameManagerAccountID = accountID;
        accountName = "name-" + gameManagerAccountID;
        accountScore = "score-" + gameManagerAccountID;

        score = PlayerPrefs.GetInt(accountScore);
    }

    public void SaveAccountScoreData(int newScore)
    {
        score = newScore;
        accountScore = "score-" + gameManagerAccountID;
        
        PlayerPrefs.SetInt(accountScore, newScore);
        PlayerPrefs.Save();
    }

    public void SaveAccountNameData(string newName, int accountID)
    {
        switch (accountID)
        {
            case 1:
                accountName1 = newName;
                break;

            case 2:
                accountName2 = newName;
                break;

            case 3:
                accountName3 = newName;
                break;
        }
        gameManagerAccountID = accountID;
        accountName = "name-" + gameManagerAccountID;

        PlayerPrefs.SetString(accountName, newName);
        Debug.Log(newName);
        PlayerPrefs.Save();
    }

    public void ResetAccountData(int accountID)
    {
        gameManagerAccountID = accountID;
        accountName = "name-" + gameManagerAccountID;
        accountScore = "score-" + gameManagerAccountID;
        score = 0;
        PlayerPrefs.SetInt(accountScore, 0);
        PlayerPrefs.SetString(accountScore, null);
        PlayerPrefs.Save();
    }
}
