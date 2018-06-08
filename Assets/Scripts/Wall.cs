using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private Vector3 pos;    //壁の現在座標
    private Vector3 savepos;//初期座標

    public GameObject Button;//スイッチ
    

	void Start () {
        Button = GameObject.Find("Switch");//タグでスイッチオブジェクトを見つける

        pos = savepos = transform.position;//初期壁座標取得
	}
	
	void Update () {
              
	}


    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //スイッチオン時呼び出される
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    public void WallOpen()
    {
        if (pos.y < savepos.y+5.0f) //初期座標から＋５まで、0.1ずつ壁を上昇
        {
            pos.y += 0.1f;
            transform.position = pos;
        }
    }

    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //スイッチオフ時呼び出される
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    public void WallClose()
    {
        if (pos.y >= savepos.y+1.0f)    //初期座標から＋１までは素早く壁が降りる
        {
            pos.y -= 0.5f;
            transform.position = pos;
        }//以降は初期位置まで0.1ずつ下がる。開閉の度初期位置からずれるのを防ぐため
        else if(pos.y>savepos.y && pos.y < savepos.y + 1.0f)
        {
            pos.y -= 0.1f;
            transform.position = pos;
        }

    }
}
