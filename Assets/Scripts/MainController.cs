using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class MainController : MonoBehaviour
{
    //�ڑ�����URL
    private const string URL = "http://zipcloud.ibsnet.co.jp/api/search";

    //�Q�[���I�u�W�F�N�gUI > Button��Inspector > On Click()����Ăяo�����\�b�h
    public void OnClick()
    {
        //�R���[�`�����Ăяo��
        StartCoroutine("OnSend", URL);
    }

    //�R���[�`��
    IEnumerator OnSend(string url)
    {
        //POST������
        WWWForm form = new WWWForm();
        form.AddField("zipcode", 1000001);

        //URL��POST�ŗp��
        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        //UnityWebRequest�Ƀo�b�t�@���Z�b�g
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URL�ɐڑ����Č��ʂ��߂��Ă���܂őҋ@
        yield return webRequest.SendWebRequest();

        //�G���[���o�Ă��Ȃ����`�F�b�N
        if (webRequest.isNetworkError)
        {
            //�ʐM���s
            Debug.Log(webRequest.error);
        }
        else
        {
            //�ʐM����
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}