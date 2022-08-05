using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using System.IO;

public class TextManager : MonoBehaviour
{
    [SerializeField] Text _mainText;
    List<string> _texts = new List<string>();

    int _currentLineNum = 0;
    int _currentCharNum = 0;
    int _textInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        _mainText.text = "";
        StartCoroutine(LoadText());
    }

    IEnumerator LoadText()
    {
        enabled = false;
        Addressables.LoadAssetAsync<TextAsset>("Assets/Text/novel.txt").Completed += novelData =>
        {
            StringReader reader = new StringReader(novelData.Result.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                _texts.Add(line);
            }
            enabled = true;
        };
        yield return new WaitForSeconds(1);
    }

    // Update is called once per frame
    void Update()
    {
        ControlText();
    }

    //テキストをコントロール
    void ControlText()
    {
        if (_currentCharNum < _texts[_currentLineNum].Length) DisplayText();
        else NextLineWhenMouseButtonUp();
    }

    //テキストを表示
    void DisplayText()
    {
        if (_textInterval == 0)
        {
            _mainText.text += _texts[_currentLineNum][_currentCharNum];
            _currentCharNum++;
            _textInterval = 3;
        }
        else _textInterval--;
    }

    //マウスボタンが離されたとき次の行へ
    void NextLineWhenMouseButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _currentLineNum++;
            _currentCharNum = 0;
            _mainText.text = "";
        }
    }
}