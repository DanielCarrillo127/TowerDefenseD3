using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenWindow : MonoBehaviour
{
    public Image window;

    public void Open()
    {
        window.gameObject.SetActive(true);
    }
}
