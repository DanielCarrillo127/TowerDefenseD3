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
        money = 100;
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        DinElem.text = "Dinero: " + "$" + money.ToString();
        VidElem.text = "Vida: " + vida.ToString();
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
}
