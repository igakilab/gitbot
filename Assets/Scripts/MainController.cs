using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class MainController : MonoBehaviour
{
    //接続するURL
    private const string URL = "http://zipcloud.ibsnet.co.jp/api/search";

    //ゲームオブジェクトUI > ButtonのInspector > On Click()から呼び出すメソッド
    public void OnClick()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", URL);
    }

    //コルーチン
    IEnumerator OnSend(string url)
    {
        //POSTする情報
        WWWForm form = new WWWForm();
        form.AddField("zipcode", 1000001);

        //URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }
        else
        {
            //通信成功
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}