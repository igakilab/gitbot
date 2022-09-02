
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour
{
    public void ClickStageOneButton()
    {
        SceneManager.LoadScene("StageOne");
    }
    public void ClickStageTwoButton()
    {
        SceneManager.LoadScene("StageTwo");
    }
    public void ClickStageThreeButton()
    {
        SceneManager.LoadScene("StageThree");
    }
}