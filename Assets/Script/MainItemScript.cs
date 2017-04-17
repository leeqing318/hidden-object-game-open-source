using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainItemScript : MonoBehaviour {

    public int Index;

	public void HideTheBottomItem()
    {
        ItemPanel.Instance.HideItemWithIndex(this.Index);
    }

}
