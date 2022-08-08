using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    public GameObject turretPoint;
    public int turretID;
    public int turretType;
    public GameObject missle1;
    public GameObject mg1;

    // Start is called before the first frame update
    void Start()
    {
        
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
            case 1:
                Instantiate(mg1, turretPoint.transform);
                break;
        }
    }

    public void togglePurchase(bool on) 
    {
        if (on) 
        {
            
        }
    }

    void toggleWindow() 
    {
    
    }
}
