using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public const int NUMBER_OF_ITEMS = 5;
    public static ItemPanel Instance;

    public UnityEvent OnStageClear;
    public Sprite[] Items;
    public BottomItemScript[] BottomItems;
    public int FoundItems = 0;
   
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        int[] currentIndexes = new int[5];
        int historyCount = RandomHelper.History.Count;

        for (int i = 0; i < NUMBER_OF_ITEMS; i++)
        {
            currentIndexes[i] = RandomHelper.History[historyCount - 1 - i];
        }

        for (int i = 0; i < Items.Length; i++)
        {
            transform.GetChild(i).GetComponent<MainItemScript>().Index = i;
            if (Array.IndexOf(currentIndexes, i) > -1)
                transform.GetChild(i).GetComponent<Image>().sprite = Items[i];
            else
                transform.GetChild(i).GetComponent<Image>().enabled = false;
        }

        BottomItems = FindObjectsOfType<BottomItemScript>();
        FoundItems = 0;
    }
    public void HideItemWithIndex(int index)
    {
        foreach (BottomItemScript btmItem in BottomItems)
        {
            if (btmItem.Index == index)
            {
                btmItem.transform.GetChild(0).GetComponent<Image>().enabled = false;
                FoundItemAndCheckWin();
                break;
            }
        }
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
    private void FoundItemAndCheckWin()
    {
        FoundItems++;
        if (FoundItems >= NUMBER_OF_ITEMS)
        {
            print("Game Win !!!!!!!!!!!!");
            if(OnStageClear!=null)
            {
                OnStageClear.Invoke();
            }
        }
    }
}
