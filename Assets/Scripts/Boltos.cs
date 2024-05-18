using UnityEngine;

class Boltos : MonoBehaviour
{
    [SerializeField] string AdventureRank;
    [SerializeField] int AdventureDailyIncome;
    [SerializeField] int GoldBag;
    [SerializeField] int BuyProductPrice;
    [SerializeField] bool YouCanBuyIt;
    [SerializeField] int Credit;
    [SerializeField] int DaysAfterPayback;
    [SerializeField] int CreditInterest;
    [SerializeField] string CreditPayBack;
    int DailySpent;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Mennyi Aranyad Van?");
    }

    // Update is called once per frame
    void Update()
    {
        // A kalandor (vev�) napi bev�tele �s a megtakar�t�sai
        if (AdventureRank == "A") { AdventureDailyIncome = 25; DailySpent = 3; GoldBag = (AdventureDailyIncome - DailySpent) * 10; }
        if (AdventureRank == "B") { AdventureDailyIncome = 5; DailySpent = 2; GoldBag = (AdventureDailyIncome - DailySpent) * 10; }
        if (AdventureRank == "C") { AdventureDailyIncome = 1; DailySpent = 1; GoldBag = (AdventureDailyIncome - DailySpent) * 10; }
        if (AdventureRank != "A" && AdventureRank != "B" && AdventureRank != "C") { AdventureDailyIncome = 0; }

        //Tud e v�s�rolni?
        if (BuyProductPrice <= GoldBag + 100) { YouCanBuyIt = true; } else { YouCanBuyIt = false; }


        //A tartoz�s m�rt�ke
        //if (YouCanBuyIt = false) { Credit = 0; }
        //if (YouCanBuyIt = true) { Credit = (BuyProductPrice - GoldBag); }

        if (BuyProductPrice <= GoldBag + 100) { Credit = (BuyProductPrice - GoldBag); }
        if (BuyProductPrice > GoldBag + 100) { Credit = 0; }
        if (GoldBag > BuyProductPrice) { Credit = 0; }


        //kamat �s hat�rid�
        if (DaysAfterPayback <= 7) { CreditInterest = 0; }
        if (DaysAfterPayback > 7) { CreditInterest = Credit / 10; }
        if (DaysAfterPayback > 30) { CreditInterest = Credit / 2; }


       
        if (DaysAfterPayback * (AdventureDailyIncome - DailySpent) >= Credit + CreditInterest) { CreditPayBack = "You succesfully paid beck the gold!"; }
        if (DaysAfterPayback > 0 && DaysAfterPayback * (AdventureDailyIncome - DailySpent) < Credit + CreditInterest) { CreditPayBack = "You can't pay beck the gold!, You are dead!, Game Over!"; }
        if (Credit == 0) { CreditPayBack = "You have no debt"; }

    }
}
