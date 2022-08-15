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

        DropdownValueChanged(dropdown);
        dropdown.onValueChanged.AddListener(delegate {DropdownValueChanged(dropdown);});
    }

    public void OnPointerClick() 
    {
        print("clicked");
    }

    void DropdownValueChanged(Dropdown change)
    {
        transform.parent.gameObject.GetComponent<turretController>().turretType = change.value;
        print(transform.parent.gameObject.GetComponent<turretController>().turretType);
        if(change.value > 0) 
        {
            transform.parent.gameObject.GetComponent<turretController>().togglePurchase(1);
        }
        else 
        {
            transform.parent.gameObject.GetComponent<turretController>().togglePurchase(2);
        }
    }
}
