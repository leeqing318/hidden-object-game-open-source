using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomItemScript : MonoBehaviour {

    public Sprite[] Items;
    public int Index;
	// Use this for initialization
	void Start () {
        Index = RandomHelper.Get();
        Image displayImage = transform.GetChild(0).GetComponent<Image>();
        displayImage.sprite = Items[Index];
        //displayImage.SetNativeSize();
    }
}
