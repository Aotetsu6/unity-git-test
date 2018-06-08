using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//ボールの起動を表示する処理
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


public class BallGuide : MonoBehaviour {
	private LineRenderer linerenderer;
	public GameObject ballobj;
	private Vector3 pos;
	private List<Vector3> GuideList=new List<Vector3>();

	// Use this for initialization
	void Start () {
		linerenderer = GetComponent<LineRenderer> ();
		linerenderer.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		//ガイド
		if (Input.GetKey (KeyCode.Mouse0) == false) {
			Vector3 tmpVec;
			pos = GameObject.FindWithTag ("Player").transform.position;
			tmpVec = Vector3.Normalize ((ballobj.GetComponent<Ball> ().MousePosToScreenPos () - pos)) * 10.0f;
			DrawGuideLine (pos, tmpVec);
		}
		}


		private void DrawGuideLine(Vector3 plPos,Vector3 BallVec){
			int maxstep = 100;
			GuideList.Clear ();

			Vector2 gravity = Physics2D.gravity * Time.fixedDeltaTime;
			Vector2 GuideVec = new Vector2 (BallVec.x, BallVec.y);
			Vector2 GuidePos = new Vector2 (plPos.x, plPos.y);
		for (int i=0; i < maxstep; i++) {
			for (int j = 0; j < 3; j++) {
				Vector2 nextPos = GuidePos + (GuideVec * Time.fixedDeltaTime);
				GuideVec += gravity;
				GuidePos = nextPos;
			}
			GuideList.Add (GuidePos);

		}
				
			linerenderer.positionCount = GuideList.Count;
			linerenderer.SetPositions (GuideList.ToArray());
		}
	}

