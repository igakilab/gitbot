
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
}