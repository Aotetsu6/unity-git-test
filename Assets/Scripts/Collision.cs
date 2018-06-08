using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//当たり判定を管理
//
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


public class Collision : MonoBehaviour {

    SpriteRenderer render;

    //画像はSwitch_OFFオブジェクトのinspectorビューから登録している
    public Sprite spriteBefore; //オフのスイッチ画像
    public Sprite spriteAfter;  //オンのスイッチ画像

    //スイッチのオンオフフラグ
    public bool switchFlag = false;

    GameObject WallObj;
    Wall wallScript;

    void Start () {

        render = GetComponent<SpriteRenderer>();//スプライトレンダー取得

        WallObj = GameObject.Find("Wall");//Wallオブジェクト

        wallScript=WallObj.GetComponent<Wall>();//Wallオブジェクト内のスクリプトWallへのアクセス
    }
	
	void Update () {

        if (switchFlag == true) {
            wallScript.WallOpen();//Wallスクリプト内のメソッド呼び出し
        }
        else
        {
            wallScript.WallClose();
        }
		
	}

    // 2Dの場合の当たり判定
    // 物体が接触しとき、１度だけ呼ばれる
    public void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.name == "Player")//自機と接触
        {
            render.sprite = spriteAfter;//ON画像に切り替え
            switchFlag = true;
        }
    }


    // 物体が接触している間、常に呼ばれる
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }


    // 物体が離れたとき、１度だけ呼ばれる
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")//自機と離れる
        {
            render.sprite = spriteBefore;//OFF画像に切り替え
            switchFlag = false;
        }
    }


    //プロパティ
    public bool SwitchFlag
    {
        get { return this.switchFlag; }
        private set { }
    }

}
