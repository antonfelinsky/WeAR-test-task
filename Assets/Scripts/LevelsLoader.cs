using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader : MonoBehaviour {

    #region Methods
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadBasic()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadAR()
    {
        SceneManager.LoadScene(2);
    } 
    #endregion

}
