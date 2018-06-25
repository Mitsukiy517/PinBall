using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour {

    //得点
    private int score = 0;

    //得点を表示するテキスト
    private GameObject scoreText;

    //得点を更新する関数
    public void UpdateScore(int add){
		
		this.score += add;
        this.scoreText.GetComponent<Text>().text = "SCORE " + this.score;

	}

    // Use this for initialization
    void Start () {

        //シーン中のScoreTextのTextオブジェクトを取得
        this.scoreText = GameObject.Find("Score");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
