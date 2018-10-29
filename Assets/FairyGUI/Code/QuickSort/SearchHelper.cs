public class SearchHelper
{
    /// <summary>
    /// 顺序查找
    /// </summary>
    public static int SequenceSearch(int[] arr, int value)
    {
        int length = arr.Length;
        for (int i = 0; i < length; i++)
        {
            if (arr[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// 二分法查找，非递归方法实现,二分查找的条件是原数组有序
    /// 没有找到，返回-1；找到了，则返回索引
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="height"></param>
    /// <param name="value"></param>
    private static int BinarySearch(int[] arr, int low, int height, int value)
    {
        if (arr == null || arr.Length == 0 || low >= height)
        {
            return -1;
        }
        int hi = height - 1;
        int lowValue = arr[low];
        int heightValue = arr[hi];
        if (lowValue > value || value > heightValue)
        {
            return -1;
        }
        int mid;
        while (low <= hi)
        {
            mid = (low + hi) >> 1;
            int item = arr[mid];
            if (item == value)
            {
                return mid;
            }
            else if (item > value)
            {
                hi = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return -1;
    }

    /// <summary>
    /// 二分法查找，递归方法实现,二分查找的条件是原数组有序
    /// 没有找到，返回-1；找到了，则返回索引
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="height"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int BinarySearchRecursive(int[] arr, int low, int height, int value)
    {
        if (arr == null || arr.Length == 0 || low >= height)
        {
            return -1;
        }
        int hi = height - 1;
        int lowValue = arr[low];
        int heightValue = arr[hi];
        if (lowValue > value || value > heightValue)
        {
            return -1;
        }
        int mid;
        if (low <= hi)
        {
            mid = (low + hi) >> 1;
            int item = arr[mid];
            if (item == value)
            {
                return mid;
            }
            else if (item > value)
            {
                return BinarySearchRecursive(arr, low, mid, value);
            }
            else
            {
                return BinarySearchRecursive(arr, mid + 1, hi, value);
            }
        }
        return -1;
    }

    /// <summary>
    /// 插值查找，是对二分法查找的优化
    /// 二分法: mid = low + 1/2 *(high - low)
    /// 插值查找:mid = low + ((point-array[low])/(array[high]-array[low]))*(high-low)
    /// 插值优化了mid，使之更接近查找数值在有序序列的实际位置
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="height"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int InterpolationSearch(int[] arr, int low, int height, int value)
    {
        if (arr == null || arr.Length == 0 || low >= height)
        {
            return -1;
        }
        int hi = height - 1;
        int lowValue = arr[low];
        int heightValue = arr[hi];
        if (lowValue > value || value > heightValue)
        {
            return -1;
        }
        int mid;
        while (low <= hi)
        {
            mid = low + ((value - lowValue) / (heightValue - lowValue)) * (hi - low);
            int item = arr[mid];
            if (item == value)
            {
                return mid;
            }
            else if (item > value)
            {
                hi = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return -1;
    }

    /// <summary>
    /// 斐波那契查找就是在二分查找的基础上根据斐波那契数列进行分割的。
    /// 在斐波那契数列找一个等于略大于查找表中元素个数的数F[n]，
    /// 将原查找表扩展为长度为F[n](如果要补充元素，则补充重复最后一个元素，直到满足F[n]个元素)，
    /// 完成后进行斐波那契分割，即F[n]个元素分割为前半部分F[n-1]个元素，后半部分F[n-2]个元素，
    /// 那么前半段元素个数和整个有序表长度的比值就接近黄金比值0.618,
    /// 找出要查找的元素在那一部分并递归，直到找到。
    /// middle = low + fb[k - 1] - 1
    /// </summary>
    public static int FbSearch(int[] arr, int value)
    {
        if (arr == null || arr.Length == 0)
        {
            return -1;
        }
        int length = arr.Length;
        // 创建一个长度为20的斐波数列
        int[] fb = MakeFbArray(20);
        int k = 0;
        while (length > fb[k] - 1)
        {
            // 找出数组的长度在斐波数列（减1）中的位置，将决定如何拆分
            k++;
        }
        // 满足黄金比例分割
        if (length == fb[k - 1])
        {
            return FindFbSearch(arr, fb, --k, value, length);
        }
        else
        {
            // 构造一个长度为fb[k] - 1的新数列
            int[] temp = new int[fb[k] - 1];
            // 把原数组拷贝到新的数组中
            arr.CopyTo(temp, 0);
            int tempLen = temp.Length;
            for (int i = length; i < tempLen; i++)
            {
                // 从原数组长度的索引开始，用最大的值补齐新数列
                temp[i] = arr[length - 1];
            }
            return FindFbSearch(temp, fb, k, value, length);
        }
    }

    private static int FindFbSearch(int[] arr, int[] fb, int k, int value, int length)
    {
        int low = 0;
        int hight = length - 1;
        while (low <= hight)
        {
            // 黄金比例分割点
            int middle = low + fb[k - 1] - 1;
            if (arr[middle] > value)
            {
                hight = middle - 1;
                // 全部元素 = 前半部分 + 后半部分 
                // 根据斐波那契数列进行分割，F(n)=F(n-1)+F(n-2)
                // 因为前半部分有F(n-1)个元素，F(n-1)=F(n-2)+F(n-3),
                // 为了得到前半部分的黄金分割点n-2， 
                // int middle = low + fb[k - 1] - 1; k已经减1了
                // 所以k = k - 1 
                k = k - 1;
            }
            else if (arr[middle] < value)
            {
                low = middle + 1;
                // 全部元素 = 前半部分 + 后半部分 
                // 根据斐波那契数列进行分割，F(n)=F(n-1)+F(n-2)
                // 因为后半部分有F(n-2)个元素，F(n-2)=F(n-3)+F(n-4),
                // 为了得到后半部分的黄金分割点n-3， 
                // int middle = low + fb[k - 1] - 1; k已经减1了
                // 所以k = k - 2 
                k = k - 2;
            }
            else
            {
                if (middle <= hight)
                {
                    return middle;// 若相等则说明mid即为查找到的位置
                }
                else
                {
                    return hight;// middle的值已经大于hight,进入扩展数组的填充部分,即原数组最后一个数就是要查找的数
                }
            }
        }
        return -1;
    }

    public static int[] MakeFbArray(int length)
    {
        int[] array = null;
        if (length > 2)
        {
            array = new int[length];
            array[0] = 1;
            array[1] = 1;
            for (int i = 2; i < length; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }
        }
        return array;
    }


    public struct IndexBlock
    {
        public int max;
        public int start;
        public int end;
    };

    const int BLOCK_COUNT = 3;

    private static void InitBlockSearch()
    {
        int j = -1;
        int k = 0;
        int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        IndexBlock[] indexBlock = new IndexBlock[BLOCK_COUNT];
        for (int i = 0; i < BLOCK_COUNT; i++)
        {
            indexBlock[i].start = j + 1;   //确定每个块范围的起始值
            j = j + 1;
            indexBlock[i].end = j + 4;     //确定每个块范围的结束值
            j = j + 4;
            indexBlock[i].max = a[j];      //确定每个块范围中元素的最大值
        }
        k = BlockSearch(12, a, indexBlock);

        if (k >= 0)
        {
           // Console.WriteLine("查找成功！你要查找的数在数组中的索引是：{0}\n", k);
        }
        else
        {

           // Console.WriteLine("查找失败！你要查找的数不在数组中。\n");
        }
    }

    /// <summary>
    /// 分块查找
    /// 分块查找要求把一个数据分为若干块，每一块里面的元素可以是无序的，但是块与块之间的元素需要是有序的。
    /// （对于一个非递减的数列来说，第i块中的每个元素一定比第i-1块中的任意元素大）
    /// </summary>
    private static int BlockSearch(int x, int[] a, IndexBlock[] indexBlock)
    {
        int i = 0;
        int j;
        while (i < BLOCK_COUNT && x > indexBlock[i].max)
        {
            //确定在哪个块中
            i++;
        }
        if (i >= BLOCK_COUNT)
        {
            //大于分的块数，则返回-1,找不到该数
            return -1;
        }
        //j等于块范围的起始值
        j = indexBlock[i].start;
        while (j <= indexBlock[i].end && a[j] != x)
        {
            //在确定的块内进行查找
            j++;
        }
        if (j > indexBlock[i].end)
        {
            //如果大于块范围的结束值，则说明没有要查找的数，j置为-1
            j = -1;
        }
        return j;
    }

}
