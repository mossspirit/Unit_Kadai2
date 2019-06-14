using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    [SerializeField]
    GameObject goCenterEyeAnchor;
    ReStart reStart;

	void Start () {
        reStart = GameObject.Find("ReStart").GetComponent<ReStart>();

        OVRManager.tiledMultiResLevel = OVRManager.TiledMultiResLevel.LMSMedium;
        OVRManager.display.displayFrequency = 72.0f;
    }
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update();


        //トリガーが轢かれているとTrue
        bool btnTri = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

        // 戻るボタンの状態
        bool btnBack = OVRInput.Get(OVRInput.Button.Back);

        // タッチパッドボタンの状態
        bool btnTouch = OVRInput.Get(OVRInput.Button.PrimaryTouchpad);

        // タッチパッドの触れている座標を取得
        Vector2 vecTouch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        // カメラの前方ベクトル、右ベクトルを取得
        Vector3 vecForward = goCenterEyeAnchor.transform.TransformDirection(Vector3.forward);
        Vector3 vecRight = goCenterEyeAnchor.transform.TransformDirection(Vector3.right);

        // 正規化
        vecForward.Normalize();
        vecRight.Normalize();

        // タッチパッドの上下を前方方向に、左右を左右方向に割り当てる
        vecForward *= vecTouch.y * Time.deltaTime;
        vecRight *= vecTouch.x * Time.deltaTime;

        // 位置更新
        transform.Translate(vecRight + vecForward);

        if (btnBack == true)
            reStart.reStart("OVRTest");

    }
}
