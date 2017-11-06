using UnityEngine;
using UnityEngine.UI;

//SCRIPT EFFECT:
//Contains currency, amount of each upgrade bought for use in upgrade functionality. Changes price of next upgrade upon buying one, removes price amount from currency.
//Displays current currency each update.

public class UpgradeControl : MonoBehaviour
{
    public int currency;
    public Text currencyDisplayBox;

    public Text rockPrice;                      //Drop the textbox containing the rock upgrade price to this variable
    public Text paperPrice;                     //Drop the textbox containing the paper upgrade price to this variable
    public Text scissorsPrice;                  //Drop the textbox containing the scissors upgrade price to this variable

    public int rockUpgradesBought;              //Use from rock powerup script to multiply a variable by the amount of upgrades bought
    public int paperUpgradesBought;             //Use from paper powerup script to multiply a variable by the amount of upgrades bought
    public int scissorsUpgradesBought;          //Use from scissors powerup script to multiply a variable by the amount of upgrades bought

    void Start()
    {
        currency = 0;
    }

    void Update()
    {
        currencyDisplayBox.text = "$" + currency;
    }


    public void rockUpgrade()
    {
        upgrade(int.Parse(rockPrice.text.Remove(0, 1)), rockPrice, ref rockUpgradesBought);
    }

    public void paperUpgrade()
    {
        upgrade(int.Parse(paperPrice.text.Remove(0, 1)), paperPrice, ref paperUpgradesBought);
    }

    public void scissorsUpgrade()
    {
        upgrade(int.Parse(scissorsPrice.text.Remove(0, 1)), scissorsPrice, ref scissorsUpgradesBought);
    }


    void upgrade(int Price, Text PriceBox, ref int UpgradesBoughtInt)
    {
        if (currency < Price) { return; }       //Returns (does nothing) if there is not enough currency to buy upgrade

        currency -= Price;
        UpgradesBoughtInt++;
        PriceBox.text = "$" + Price * 2;        //Price is multiplied by two. This can be changed if needed
    }
}
