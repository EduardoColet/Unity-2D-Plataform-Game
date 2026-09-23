using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

public string level;

   private void OnEnable()
    {
        StartCoroutine(PauseAfterDelay(1f));
    }
public void restart(){
    SceneManager.LoadScene(level);
}
public void backToMenu(){
    SceneManager.LoadScene(0);
}

private IEnumerator PauseAfterDelay(float delay)
{
    yield return new WaitForSecondsRealtime(delay);
    Time.timeScale = 0; 
}


}
