using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretController : MonoBehaviour
{
    public GameObject turretUI;
    public int turretID;
    public int turretType;
    public GameObject missle1;
    public GameObject mg1;
    public GameObject purchaseButt;
    public GameObject gunButt;
    public GameObject missileButt;

    private Color normal;
    private Color highlight;
    private Image gunButtImg;
    private Image missileButtImg;

    // Start is called before the first frame update
    void Start()
    {
        normal = new Color(0.21f, 1f, 0.91f, 0.5f);
        highlight = new Color(0f, 0.33f, 0.72f, 0.78f);
        gunButtImg = gunButt.GetComponent<Image>();
        missileButtImg = missileButt.GetComponent<Image>();
        purchaseButt.SetActive(false);
        gunButtImg.color = normal;
        missileButtImg.color = normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void purchase() 
    {
        print("purchased");
        switch (turretType) 
        {
            case 0:
                break;
            case 1:
                Instantiate(mg1, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(missle1, transform.position, transform.rotation);
                break;
        }
    }

    public void togglePurchase(int type) 
    {
        if (type == turretType)
        {
            type = 0;
        }
        switch (type)
        {
            case 0:
                gunButtImg.color = normal;
                missileButtImg.color = normal;
                purchaseButt.SetActive(false);
                turretType = 0;
                break;
            case 1:
                gunButtImg.color = highlight;
                missileButtImg.color = normal;
                purchaseButt.SetActive(true);
                turretType = 1;
                break;
            case 2:
                gunButtImg.color = normal;
                missileButtImg.color = highlight;
                purchaseButt.SetActive(true);
                turretType = 2;
                break;

        }
    }

    void toggleWindow() 
    {
    
    }
}
