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
        // zorgt ervoor dat het niet verdwijnt wanneer er van scene gewisseld wordt
        DontDestroyOnLoad(transform.gameObject);
        // zorgt ervoor dat er maar 1 gamemanager is
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        // laad data van account 1 in
        LoadAccountData(gameManagerAccountID);
    }

    // haalt de score op van het bijbehorende account
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
        PlayerPrefs.SetString(accountName, null);
        PlayerPrefs.Save();
    }
}
