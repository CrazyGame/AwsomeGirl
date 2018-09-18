using FairyGUI;

namespace SimpleUI
{
    public class FairTools
    {
        public static int GetGListItemIndex(object current, object[] allObject)
        {
            int index = 0;
            for (int i = 0; i < allObject.Length; i++)
            {
                if (allObject[i] == current)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}

