using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour {

	//得点
	private int score = 0;

	//Materialを入れる
	Material myMaterial;

	//Emissionの最小値
	private float minEmission = 0.3f;
	//Emissionの強度
	private float magEmission = 2.0f;
	//角度
	private int degree = 0;
	//発光速度
	private int speed = 10;
	//ターゲットのデフォルトの色
	Color defaultColor = Color.white;

	//得点を表示するテキスト
	private GameObject scoreText;

	//得点を更新する関数
	/*void UpdateScore(int add){
		
		this.score += add;
        this.scoreText.GetComponent<Text>().text = "SCORE " + this.score;
        Debug.Log (this.score);

	}*/

	// Use this for initialization
	void Start () {

		//シーン中のScoreTextのTextオブジェクトを取得
		this.scoreText = GameObject.Find ("Score");

		//タグによって光らせる色を変える
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		} else if (tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultColor = Color.cyan;
		}
	
		//オブジェクトにアタッチしているMaterialを取得
		this.myMaterial = GetComponent<Renderer>().material;

		//オブジェクトの最初の色を設定
		myMaterial.SetColor("EmissionColor", this.defaultColor*minEmission);
	}


	// Update is called once per frame
	void Update () {
		
		if (this.degree >= 0) {
			//光らせる強度を計算する
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

			//エミッションに色を設定する
			myMaterial.SetColor ("_EmissionColor", emissionColor);

			//現在の角度を小さくする
			this.degree -= this.speed;
		}
			
		


	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){

		//角度を180に設定
		this.degree = 180;

		if (other.gameObject.tag == "SmallStarTag") {

            this.score += 5;
            this.scoreText.GetComponent<Text>().text = "SCORE " + this.score;
            Debug.Log(this.score);

        } else if (other.gameObject.tag == "LargeStarTag") {

            this.score += 15;
            this.scoreText.GetComponent<Text>().text = "SCORE " + this.score;
            Debug.Log(this.score);

        } else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag") {

            //UpdateScore(10);
            this.score += 10;
            this.scoreText.GetComponent<Text>().text = "SCORE " + this.score;
            Debug.Log(this.score);

        }

	}

}
