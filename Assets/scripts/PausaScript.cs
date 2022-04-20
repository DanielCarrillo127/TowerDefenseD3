using UnityEngine;
using UnityEngine.UI;
public class PausaScript : MonoBehaviour
{
    bool isPaused = false;
    /* void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePause);
        //GetComponent<Button>().onClick.AddListener(Resume);
    } */
    public void TogglePause()
    {
        Debug.Log("Pausa");Debug.Log(isPaused);
        //Time.timeScale = 0;
        //Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        if (isPaused)
        {
            Time.timeScale = 1f;
              isPaused = false;
            
        }
        else
        {
            Time.timeScale = 0f;
              isPaused = true;
        }
    }
    /* public void Resume()
    {
        Debug.Log("Resumen");
        Time.timeScale = 1;
    } */
}