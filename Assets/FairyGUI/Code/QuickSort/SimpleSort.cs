using System.Collections.Generic;
namespace SimpleSort
{
    public class SortHelper 
    {
        public static void SelectSort(IList<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                int min = i;
                int temp = data[i];
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (data[j] < temp)
                    {
                        min = j;
                        temp = data[j];
                    }
                }
                if (min != i)
                    Swap(data, min, i);
            }
        }
        private static void Swap(IList<int> data, int min, int i)
        {
            int dwTmp = data[min];
            data[min] = data[i];
            data[i] = dwTmp;
        }
    }
}


