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

    public Text notificationText;


    // Start is called before the first frame update
    void Start()
    {
        money = 100;
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
        if(vida<=50)
        {
            StartCoroutine(sendNotification("BE CAREFUL, YOUR LIFE IS LOW", Color.red,1));
        }
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
            StartCoroutine(sendNotification("NOT ENOUGH CASH, Hint: kill enemies to earn money ",Color.red, 1));
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
            StartCoroutine(sendNotification("NOT ENOUGH CASH, Hint: kill enemies to earn money",Color.red , 1));
            return -1;
        }
        else
        {
            Debug.Log(" enough money");
            return 1;
        }

    }

    IEnumerator sendNotification(string text,Color colors , int time)
    {
        notificationText.color = colors;
        notificationText.text = text;
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }

}