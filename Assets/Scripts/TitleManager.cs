using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance6;

    public GameObject playBtn;
    public GameObject guideBtn;
    public GameObject recordBtn;
    public GameObject guideImage;
    public GameObject quitBtn;
    public GameObject recordBoard;

    void Awake()
    {
        if (!instance6) instance6 = this;

        playBtn.SetActive(true);
        guideBtn.SetActive(true);
        recordBtn.SetActive(true);
        guideImage.SetActive(false);
        quitBtn.SetActive(false);
        recordBoard.SetActive(false);
    }

    public void main()
    {
        playBtn.SetActive(true);
        guideBtn.SetActive(true);
        recordBtn.SetActive(true);
        guideImage.SetActive(false);
        recordBoard.SetActive(false);
        quitBtn.SetActive(false);
    }

    public void guide()
    {
        playBtn.SetActive(false);
        guideBtn.SetActive(false);
        recordBtn.SetActive(false);
        guideImage.SetActive(true);
        quitBtn.SetActive(true);
    }

    public void record()
    {
        playBtn.SetActive(false);
        guideBtn.SetActive(false);
        recordBtn.SetActive(false);
        recordBoard.SetActive(true);
        quitBtn.SetActive(true);
    }
}
