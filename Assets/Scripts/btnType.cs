using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class btnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnBtnClick()
    {
        switch(currentType)
        {
            case BTNType.Play:
                SoundManager.instance5.buttonClick();
                Invoke("invokeLoading", 0.1f);
                break;

            case BTNType.Guide:
                SoundManager.instance5.buttonClick();
                TitleManager.instance6.guide();
                buttonScale.localScale = defaultScale;
                break;

            case BTNType.Record:

                break;

            case BTNType.Retry:
                SoundManager.instance5.buttonClick();
                Invoke("invokeRetry", 0.1f);
                break;

            case BTNType.Quit:
                SoundManager.instance5.buttonClick();
                TitleManager.instance6.main();
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    //효과음을 끝까지 재생시키기 위해 약간 지연시켜준다.
    public void invokeLoading()
    {
        SceneManager.LoadScene("Loading");
    }

    public void invokeRetry()
    {
        SceneManager.LoadScene("Demo");
    }
}
