using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

public class Player : MonoBehaviour {

    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //現在自機画像は犬（dog01.png）
    //32*32ドット。
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


    //変数定義
    public float flap = 550f;
    public float scroll = 10f;
    float direction = 0f;
    Rigidbody2D rb2d;

    private bool warpflg = false; //ワープフラグ
    
    void Start () {

        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	
	void Update () {

        if      (Input.GetKey(KeyCode.RightArrow))  { direction = 1f; } //右移動
        else if (Input.GetKey(KeyCode.LeftArrow))   { direction = -1f; }//左移動
        else { direction = 0f; }
        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);


        
        //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
        //ワープ処理
        //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
        if (warpflg)
        {
            warpflg = false;//ワープ終了
            transform.position = GameObject.FindWithTag("Ball").transform.position;//自機座標をボール座標で上書き
            
        }
        else
        {
            
        }

    }

    public void WarpAfterVelocity()
    {
        transform.position = GameObject.FindWithTag("Ball").transform.position;//自機座標をボール座標で上書き
      
    }
}
