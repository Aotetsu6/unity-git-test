using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


public class MainCamera : MonoBehaviour {

	private Vector3 plpos;  //プレイやー座標
	private Vector3 blpos;  //ボール座標
	private Vector3 cpos;   //カメラ座標
	private Camera cam;     //

    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //初期化関数
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void Start () {
		cam=GetComponent<Camera> ();

		cpos=GameObject.FindWithTag ("Player").transform.position;

	}
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //更新処理
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void Update () {
        //プレイやークラスから自機座標取得
		plpos = GameObject.FindWithTag ("Player").transform.position;

        {
			SpriteRenderer tmprender;
			float speed = 0.3f;

            //ボールの状態取得
            tmprender = GameObject.FindWithTag ("Ball").GetComponent<SpriteRenderer> ();

			if (tmprender.enabled) {//ボールが描画されているかどうか判定
				blpos = GameObject.FindWithTag ("Ball").transform.position;                     //ボール座標
				cpos.x = Mathf.SmoothStep (cpos.x, plpos.x + (blpos.x - plpos.x) * 0.5f, speed);//プレイヤーとボールの中間を
				cpos.y = Mathf.SmoothStep (cpos.y, plpos.y + (blpos.y - plpos.y) * 0.5f, speed);//注視点にする


			} else {//ぼーるが描画状態じゃないとき
                
                //自機を追い続ける
                //左クリックを離した瞬間にカメラが瞬間移動しないような処理を書こう


                //
				if (speed * speed > (plpos.x-cpos.x)*(plpos.x-cpos.x)+(plpos.y-cpos.y)*(plpos.y-cpos.y)) {
					cpos = plpos;
				} else {
					cpos.x = Mathf.SmoothStep (cpos.x, plpos.x, speed);
					cpos.y = Mathf.SmoothStep (cpos.y, plpos.y, speed);

				}
			}
			cpos.z = -0.5f;

			transform.position = cpos;

		}
	}
}
