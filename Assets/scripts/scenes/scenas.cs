using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class scenas : MonoBehaviour
{
    public void Scene1() {  
        SceneManager.LoadScene("StartMenu");  
    }  
    public void Scene2() {  
        SceneManager.LoadScene("Map1");  
    }  
    public void Scene3() {  
        SceneManager.LoadScene("GameOver");  
    }  
}
