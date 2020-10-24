using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandeler : MonoBehaviour
{

    public void loadTankGame()
    {
        SceneManager.LoadScene("Top Tank Movement");
    }

    public void loadPlayerGame()
    {
        SceneManager.LoadScene("Top Player Movement");
    }

    public void load2DPlayerGame()
    {
        SceneManager.LoadScene("2D movement");
    }
}
