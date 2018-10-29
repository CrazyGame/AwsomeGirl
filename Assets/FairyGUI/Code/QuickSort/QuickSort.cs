/*
*   功    能:C#泛型版的超级优化的快速排序算法和插入排序、二分查找算法
*   创建日期:2005年8月5日
*   创建   人:孤帆
*/

using System.Collections.Generic;

namespace QuickSort
{
    public static class QSort<T>
    {
        //插入排序
        public static void InsertSort(ref T[] List, int Lo, int Hi, IComparer<T> comparer)
        {
            while (Hi >= Lo)
            {
                int pMax = Lo;
                for (int pNow = Lo; pNow <= Hi; pNow++)
                {
                    if (comparer.Compare(List[pNow], List[pMax]) > 0)
                        pMax = pNow;
                }

                //    交换高位记录和最大数记录
                T dwTmp = List[pMax];
                List[pMax] = List[Hi];
                List[Hi] = dwTmp;

                --Hi;//高位指针往Lo指针移动
            }
        }
        public static void InsertSort(ref T[] List, int Lo, int Hi)
        {
            InsertSort(ref List, Lo, Hi, Comparer<T>.Default);
        }
        public static void InsertSort(ref T[] List)
        {
            InsertSort(ref List, List.GetLowerBound(0), List.GetUpperBound(0));
        }

        //快速排序
        public static void QuickSort(T[] List, int Lo, int Hi, IComparer<T> comparer)
        {
            if (Hi <= Lo) return;

            if ((Hi - Lo) <= 8)
            {
                InsertSort(ref List, Lo, Hi, comparer);
            }
            else
            {
                int pLo = Lo;
                int pHi = Hi;
                T vPivot = List[Lo + (Hi - Lo) >> 1];//分割点

                while (pLo <= pHi)
                {
                    //扫描左半区间的元素是否小于分割点
                    while (pLo < Hi && (comparer.Compare(List[pLo], vPivot) < 0))
                        ++pLo;

                    //扫描右半区间的元素是否大于分割点
                    while (pHi > Lo && (comparer.Compare(vPivot, List[pHi]) < 0))
                        --pHi;

                    // 交换pLo和pHi之间的元素
                    //(这时 List(pLo) > vPivot 而 List(Hi) <vPivot ，所以要交换他们)
                    if (pLo <= pHi)
                    {
                        T Temp = List[pLo];
                        List[pLo] = List[pHi];
                        List[pHi] = Temp;

                        ++pLo;
                        --pHi;
                    }
                }

                if (Lo < pHi)
                {
                    QuickSort(List, Lo, pHi, comparer);//左半区间递归((pHi -- Hi 已经ok))
                }

                if (pLo < Hi)
                {
                    QuickSort(List, pLo, Hi, comparer);//右半区间递归((Lo --pLo 已经ok))
                }
            }
        }
        public static void QuickSort(T[] List, int Lo, int Hi)
        {
            QuickSort(List, Lo, Hi, Comparer<T>.Default);
        }
        public static void QuickSort(T[] List)
        {
            QuickSort(List, List.GetLowerBound(0), List.GetUpperBound(0));
        }

        //二叉查找
        public static int BinarySearch(T[] List, int Lo, int Hi, T vFind, IComparer<T> comparer)
        {
            while (Lo <= Hi)
            {
                int pMid = Lo + ((Hi - Lo) >> 1);
                int cmpResult = comparer.Compare(List[pMid], vFind);
                if (cmpResult == 0)
                {
                    return pMid;
                }
                else if (cmpResult < 0)
                {
                    Lo = pMid + 1;//在右半区间找
                }
                else
                {
                    Hi = pMid - 1;//在左半区间找
                }
            }

            return ~Lo;
        }
        public static int BinarySearch(T[] List, int Lo, int Hi, T vFind)
        {
            return BinarySearch(List, Lo, Hi, vFind, Comparer<T>.Default);
        }
        public static int BinarySearch(T[] List, T vFind)
        {
            return BinarySearch(List, List.GetLowerBound(0), List.GetUpperBound(0), vFind);
        }
    }
}
