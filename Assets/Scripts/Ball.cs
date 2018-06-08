using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝



//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//ボールクラス
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
public class Ball :MonoBehaviour {

	private Vector3 pos;//ボールの座標
	public GameObject plobj;//
	Rigidbody2D rd ;
	SpriteRenderer render;

    GameObject Player;//プレイヤーオブジェクト

    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //初期化関数
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void Start () {
		rd = GetComponent<Rigidbody2D> ();
		render = GetComponent<SpriteRenderer> ();
		render.enabled=false;//見えないようにする

        Player = GameObject.Find("Player");//プレイヤーオブジェクト
	
	}

    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //更新処理
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void Update () {
        
        //左クリック
        //ボール投てき

        //if (Input.GetKeyDown (KeyCode.Mouse0)&&!render.enabled) {//左クリック中かつ
        //    //pos = GameObject.FindWithTag ("Player").transform.position;//プレイヤーの座標からボールの座標取得
        //    //transform.position = pos;   //
        //    //rd.velocity = Vector3.Normalize ((MousePosToScreenPos () - pos))*10.0f; //ボールのベクトルとスピード
        //    transform.position = MousePosToScreenPos();//クリックした場所の座標をボールの座標にする
        //    render.enabled = true;        //描画開始
        //}

        if (Input.GetMouseButton(0))//左クリック中
            //クリックしながらゲームを起動された時の対処が必要
        {
            transform.position = MousePosToScreenPos();//クリックした場所の座標をボールの座標にする

            render.enabled = true;        //描画開始
        }

		//ワープ時
		if (Input.GetKeyUp (KeyCode.Mouse0)&&render.enabled) {//クリックが離された時
			render.enabled=false;//ボールの描画終了

            Player player = Player.GetComponent<Player>();//プレイヤーオブジェクトのPlayer.csスクリプトを参照？
            player.WarpAfterVelocity();//Player.csのワープ関数を呼び出し
            		
		}
	}


    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //マウス座標をスクリーン座標に変換する
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
	 public Vector3 MousePosToScreenPos(){
		Vector3 worldpos;
		Vector3 mousepos;
		mousepos = Input.mousePosition;//クリックされた場所のスクリーン座標を取得

		worldpos=Camera.main.ScreenToWorldPoint(mousepos);//スクリーン座標をワールド座標へ変換
		 //mousepos=Camera.main.WorldToViewportPoint (worldpos);

		return worldpos;
	}


}
