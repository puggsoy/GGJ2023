using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void EnableGameOver()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

}
