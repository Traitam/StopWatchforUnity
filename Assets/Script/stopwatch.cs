using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stopwatch : MonoBehaviour {
    public Text sec;
    public Text min;
    public Button startButton;
    public Button stopButton;
    public Button resetButton;
    private float _time;
    private float _mintime;
    private bool _flag=false;


	// Update is called once per frame
    //毎フレームごとの処理-------------------------
	void Update () {
        if (!_flag)
        {
            startButton.interactable = true;
            stopButton.interactable = false;
            resetButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
            stopButton.interactable = true;
            resetButton.interactable = false;

            //時間加算
            _time += Time.deltaTime;
            //秒テキストに時間を入れる
            sec.text = _time.ToString("N2");

            //もし1分になったら分のテキストに追加
            if (_time >= 60)
            {
                _mintime++;
                min.text = Mathf.CeilToInt(_mintime).ToString();
                sec.text = "0";
                _time = 0;
            }

        }

	
	}


    //ボタン処理---------------------------
    //スタートボタン
    public void StartButton()
    {
        _flag = true;
    }

    //ストップボタン
    public void StopButton()
    {
        _flag = false;
    }

    public void ResetButton()
    {
        sec.text="0.00";
        min.text = "0";
        _time = 0;
    }
}
