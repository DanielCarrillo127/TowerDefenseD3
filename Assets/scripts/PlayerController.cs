using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int money;
    public int vida;
    //Muestra dinero
    public string dintxt;
    public Text DinElem;
    public Text VidElem;
    // Start is called before the first frame update
    void Start()
    {
        money = 200;
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        DinElem.text = " " + "" + money.ToString();
        VidElem.text = " " + vida.ToString();
        if (vida == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void reduceLife(int vidaQuitada)
    {
        vida -= vidaQuitada;
    }
    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }
    public void substractMoney(int moneyToSubstract)
    {
        if (money - moneyToSubstract < 0)
        {
            Debug.Log("not enough money");
        }
        else
        {
            money -= moneyToSubstract;
        }

    }

    public int canPut(int moneyToSubs)
    {
        if (money - moneyToSubs < 0)
        {
            Debug.Log("not enough money");
            return -1;
        }
        else
        {
            Debug.Log(" enough money");
            return 1;
        }

    }
}