using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownHandler : MonoBehaviour
{
    Dropdown dropdown;

    void Start() 
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    public void OnPointerClick() 
    {
        print("clicked");
    }

    void DropdownValueChanged(Dropdown change)
    {
        transform.parent.gameObject.GetComponent<turretController>().turretType = dropdown.value;
        print(transform.parent.gameObject.GetComponent<turretController>().turretType);
        if(dropdown.value > 0) 
        {
            transform.parent.gameObject.GetComponent<turretController>().togglePurchase(true);
        }
        else 
        {
            transform.parent.gameObject.GetComponent<turretController>().togglePurchase(false);
        }
    }
}
