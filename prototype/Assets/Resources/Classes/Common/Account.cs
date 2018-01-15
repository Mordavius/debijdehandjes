using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour {

    private GameManager GameManager;
    public GameObject buttonAccount1;
    public GameObject buttonAccount2;
    public GameObject buttonAccount3;

    private void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (GameManager.gameManagerAccountID == 1)
        {
            buttonAccount1.GetComponent<Image>().color = Color.green;
            buttonAccount2.GetComponent<Image>().color = Color.white;
            buttonAccount3.GetComponent<Image>().color = Color.white;
        }
        else if (GameManager.gameManagerAccountID == 2)
        {
            buttonAccount1.GetComponent<Image>().color = Color.white;
            buttonAccount2.GetComponent<Image>().color = Color.green;
            buttonAccount3.GetComponent<Image>().color = Color.white;
        }
        else if (GameManager.gameManagerAccountID == 3)
        {
            buttonAccount1.GetComponent<Image>().color = Color.white;
            buttonAccount2.GetComponent<Image>().color = Color.white;
            buttonAccount3.GetComponent<Image>().color = Color.green;
        }
    }

    public void ChooseAccount1()
    {
        GameManager.LoadAccountData(1);
    }

    public void ChooseAccount2()
    {
        GameManager.LoadAccountData(2);
    }

    public void ChooseAccount3()
    {
        GameManager.LoadAccountData(3);
    }

    public void ResetAccount1()
    {
        GameManager.ResetAccountData(1);
    }

    public void ResetAccount2()
    {
        GameManager.ResetAccountData(2);
    }

    public void ResetAccount3()
    {
        GameManager.ResetAccountData(3);
    }

    //OnValueChanged, dynamic ipv static REMINDER VOOR RUBEN
    public void ChangeAccountName1(string newName)
    {
        Debug.Log(newName);
        GameManager.SaveAccountNameData(newName, 1);
    }

    public void ChangeAccountName2(string newName)
    {
        GameManager.SaveAccountNameData(newName, 2);
    }

    public void ChangeAccountName3(string newName)
    {
        GameManager.SaveAccountNameData(newName, 3);
    }
}
