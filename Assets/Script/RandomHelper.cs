using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RandomHelper
{
    public static List<int> History = new List<int>();
    public const int MAX_INDEX = 30;
    public static void clearHistory()
    {
        History.Clear();
    } 
    public static int Get()
    {
        if (History.Count >= MAX_INDEX)
        {
            clearHistory();
        }
        int random = UnityEngine.Random.Range(0, MAX_INDEX);
        while (History.Contains(random))
        {
            random = UnityEngine.Random.Range(0, MAX_INDEX);
        }
        History.Add(random); 
        return random;
    }
}

