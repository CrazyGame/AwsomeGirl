using System.Collections.Generic;
using UnityEngine;
namespace SimpleUI
{
    public class ListManager<T> where T : SingleInstance<T>, new()
    {
        List<T> DataList = new List<T>();
    }



    public class PaymentData 
    {
        public double PaymentAmountA { get; set; }
        public double PaymentAmountB { get; set; }
        public double PaymentAmountC { get; set; }
        public double PaymentAmountD { get; set; }
        public double PaymentCoins { get; set; }

        public static double GetAmountValue(PaymentData paymentData, int index)
        {
            switch (index)
            {
                case 0:
                    return paymentData.PaymentAmountA;
                case 1:
                    return paymentData.PaymentAmountB;
                case 2:
                    return paymentData.PaymentAmountC;
                case 3:
                    return paymentData.PaymentAmountD;
                case 4:
                    return paymentData.PaymentCoins;
                default:
                    return 0;
            }
        }
    }

    public class PlayerInfo
    {
        public string PlayerName { get; set; }       
    }

    public class PlayerDesInfo 
    {
        public string Des { get; set; }      
    }

    public class PlayerTexture 
    {
        public Texture RoleTexture { get; set; }       
    }

    public class CurrentPlayIndex
    {
        public int index { get; set; }
    }
}


