using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    
    public GameObject[] OnObj;
    public GameObject[] OffObj;


    // Use this for initialization
    void Start () {

        

    }

    // Update is called once per frame
    void Update () {

    }

    // 2Dの場合のトリガー判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 物体がトリガーに接触しとき、１度だけ呼ばれる
        if (collision.gameObject.name == "Player")
        {
            foreach (GameObject On in OnObj)
            {
                On.GetComponent<SpriteRenderer>().enabled = true;
                On.GetComponent<Collider2D>().enabled = true;
            }
            foreach (GameObject Off in OffObj)
            {
                Off.GetComponent<SpriteRenderer>().enabled = false;
                Off.GetComponent<Collider2D>().enabled = false;
            }
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 物体がトリガーに接触している間、常に呼ばれる
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 物体がトリガーと離れたとき、１度だけ呼ばれる
    }
}
