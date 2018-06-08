using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//スイッチ画像をクリックするとオンオフが切り替わる
//このスクリプトはスイッチ画像をクリックされている時のみ動く
//
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


public class ChangeSprite : MonoBehaviour {

    public Sprite spriteBefore;
    public Sprite spriteAfter;
    private bool chFlg = false;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void changeSprite()
    {

        if (!chFlg)
        {
            this.gameObject.GetComponent<Image>().sprite = spriteAfter;
            chFlg = true;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = spriteBefore;
            chFlg = false;
        }

    }

}
