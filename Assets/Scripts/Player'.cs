using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Takagi : MonoBehaviour {

    private Vector2 localVec;   //移動ベクトル
	public Rigidbody2D rd ;     //リジットボディ
	private float speed;        //スピード
	private bool warpflg=false; //ワープフラグ

	//Use this for initialization
	void Start () {
        //初期化関数

		rd = GetComponent<Rigidbody2D> ();

		localVec.x = 0.0f;
		localVec.y = -0.01f;


	}

	//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //自機
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
	void Update () {
		
        //左移動
		if (Input.GetKey (KeyCode.A)) { //Aキーを押されたら
			if (localVec.x <= 0.0f) {   //
				localVec.x -= 0.03f;    //左ベクトル足しこみ

			} else {
				localVec.x -= 0.1f;     //通常時の移動速度

			} 
		}//右移動
		else if (Input.GetKey (KeyCode.D)) {//
			if (localVec.x >= 0.0f) {       //
				localVec.x += 0.03f;        //
                  
			}
			else {
				localVec.x += 0.1f;         //
			}
		}
		else if(Mathf.Abs(localVec.x)>0.03f){//入力がないときの減速
			localVec.x = (Mathf.Abs(localVec.x) - 0.05f)*localVec.x*(1.0f/Mathf.Abs(localVec.x));
		}

        //速度を一定以上にならないように制御
		if (Mathf.Abs(localVec.x) > 0.5f) {
			localVec.x=localVec.x*(1.0f/Mathf.Abs(localVec.x))*0.5f;
		}
		else if(Mathf.Abs(localVec.x) < 0.03f){
			localVec.x=0.0f;
		}


        //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
        //ワープ処理
        //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

		if (warpflg) {
			warpflg = false;
			transform.position = GameObject.FindWithTag ("Ball").transform.position;
			rd.velocity = new Vector2 (localVec.x * 10.0f, localVec.y);

           
		}
		else{
			rd.velocity = new Vector2 (localVec.x * 10.0f, rd.velocity.y);

		}
//		transform.position = Pos;
	}

	public void WarpAfterVelocity(){
		
		warpflg = true;
	}
	
}
