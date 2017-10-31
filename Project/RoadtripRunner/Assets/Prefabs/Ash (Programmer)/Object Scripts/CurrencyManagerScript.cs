using UnityEngine;
using UnityEngine.UI;

public class CurrencyManagerScript : MonoBehaviour
{
    public int currency;
    public Text textBox;

	void Start ()
    {
        currency = 0;
	}

    void Update()
    {
        textBox.text = "$" + currency;
    }
}
