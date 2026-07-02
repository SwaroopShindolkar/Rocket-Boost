using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    { 
        switch (other.gameObject.tag) 
        {
            case "Friendly": Debug.Log("Rocket on Launch Pad");
            break;
            case "Finish": completeScene();
            break;
            case "Fuel": Debug.Log("Fuel Refilled");
            break;
            default: ReloadScene();
            break;
        }
        void ReloadScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
        void completeScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
        }
    }
}
