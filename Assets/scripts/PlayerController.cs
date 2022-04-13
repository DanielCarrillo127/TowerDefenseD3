using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int money;
    //Muestra dinero
    public string dintxt;
    public Text DinElem;
    // Start is called before the first frame update
    void Start()
    {
        money = 10;
    }

    // Update is called once per frame
    void Update()
    {
        DinElem.text = "Dinero: " + money.ToString();
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
}
