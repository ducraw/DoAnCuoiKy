using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddProduct : MonoBehaviour
{
    public TextMeshProUGUI stockText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI totalPriceText;

    public GameObject shopButton;
    public GameObject editButton;
    public GameObject dataButton;
    public GameObject logButton;
    [SerializeField] private List<Log> logData = new List<Log>();

    private float totalPriceNum;

    private bool ifPress = false;

    [SerializeField] private List<CharSelect> charList = new List<CharSelect>();
    private int selectCharIndex;
    private int i2=0;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 960, false);
        //charList[selectCharIndex].priceText.text = "Price: " + charList[selectCharIndex].priceNum.ToString() + "$" ;

    }

    // Update is called once per frame
    void Update()
    {

        if (ifPress == true)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                charList[i].amountNum = 0;
            }
            ifPress = false;
        }


        for (int i = 0; i < charList.Count; i++)
            charList[i].amountText.text = charList[i].amountNum.ToString();

        charList[selectCharIndex].stockText.text = "Stock: " + charList[selectCharIndex].stockNum.ToString();

        totalPriceText.text = "Total Price: " + totalPriceNum.ToString() + "$";
        if (i2 > 4)
        {
            i2 = 0;
        }




    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void shopB()
    {
        shopButton.SetActive(true);
        editButton.SetActive(false);
        dataButton.SetActive(false);
        logButton.SetActive(false);
        for (int i = 0; i < charList.Count; i++)
        {
            charList[i].stockText.text = "Stock: " + charList[i].stockNum.ToString();
            charList[i].priceText.text = "Price: " + charList[i].priceNum.ToString() + "$";
        }

    }


    public void editB()
    {
        shopButton.SetActive(false);
        editButton.SetActive(true);
        dataButton.SetActive(false);
        logButton.SetActive(false);
    }

    public void dataaB()
    {
        shopButton.SetActive(false);
        editButton.SetActive(false);
        dataButton.SetActive(true);
        logButton.SetActive(false);
        for (int i = 0; i < charList.Count; i++)
        {
            charList[i].dataText.text = "+Name:" + charList[i].nameText.text + "\n+Price:" + charList[i].priceNum + "$" + "\n+Stock:" + charList[i].stockNum;
        }
    }

    public void logB()
    {
        shopButton.SetActive(false);
        editButton.SetActive(false);
        dataButton.SetActive(false);
        logButton.SetActive(true);
    }





    public void add()
    {
        if (charList[selectCharIndex].stockNum > 0)
        {
            charList[selectCharIndex].amountNum++;
            charList[selectCharIndex].stockNum--;
            totalPriceNum += charList[selectCharIndex].priceNum;
        }
    }

    public void saveChange()
    {
        for (int i = 0; i < charList.Count; i++)
        {
            charList[i].priceText.text = "Price: " + charList[i].priceEdit.text.ToString() + "$";
            charList[i].priceNum = int.Parse(charList[i].priceEdit.text);
            charList[i].stockNum = int.Parse(charList[i].stockEdit.text);
            charList[i].stockText.text = "Stock: " + charList[i].stockNum.ToString();

        }

    }
    [System.Serializable]
    public class CharSelect
    {
        public TextMeshProUGUI priceText;
        public TextMeshProUGUI stockText;
        public TextMeshProUGUI nameText;
        public TMP_InputField priceEdit;
        public TMP_InputField stockEdit;
        public TextMeshProUGUI amountText;
        public int amountNum = 0;
        public int stockNum = 10;
        public float priceNum = 60;
        public TextMeshProUGUI dataText;
    }

    [System.Serializable]
    public class Log
    {
        public string[] item;
        public string[] totalAmmount;
        public TextMeshProUGUI totalCost;
        public string text;
        private string finalText;
    }

    public void remove()
    {
        if (charList[selectCharIndex].amountNum > 0)
        {
            charList[selectCharIndex].amountNum--;
            charList[selectCharIndex].stockNum++;
            totalPriceNum -= charList[selectCharIndex].priceNum;
        }
    }

    public void SunAmount()
    {
        selectCharIndex = 0;
    }

    public void TulipAmount()
    {
        selectCharIndex = 1;
    }

    public void DaisyAmount()
    {
        selectCharIndex = 2;
    }

    public void RoseAmount()
    {
        selectCharIndex = 3;
    }

    public void save()
    {
        // for (int i = 0; i < charList.Count; i++)
        //{
        //  logData[i2].item[i] = charList[i].nameText;
        // logData[i2].totalAmmount[i] = charList[i].nameText;    
        //}
        ifPress = true;
        if (totalPriceNum != 0)
        {
            
            for (int i = 0; i < charList.Count; i++)
            {
                if (charList[i].amountNum != 0)
                {
                    logData[i2].item[i] = charList[i].nameText.text;
                    logData[i2].totalAmmount[i] = charList[i].amountText.text;
                    logData[i2].text += logData[i2].item[i] + ":"+logData[i2].totalAmmount[i]+ " (" + charList[i].priceNum + "$)" +"; " ;
                }
            }

       

            logData[i2].totalCost.text =logData[i2].text+ "Total cost: " + totalPriceNum.ToString() + "$";
            

            i2++;
        }
        totalPriceNum = 0;
           
    }
}



