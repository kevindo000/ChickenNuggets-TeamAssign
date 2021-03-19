using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text descriptionText; 
    public Text modelNameText; 
    public Text healthText; 
    public Text damageText; 
    public Text costText;

    public void UpdateObjectPropertiesUI(Attributes objectAttributes)
    {
        damageText.text = String.Format("$ {0}",objectAttributes.Damage);
        modelNameText.text = objectAttributes.Name;
        descriptionText.text = objectAttributes.Description;
        costText.text = String.Format("$ {0}",objectAttributes.Cost);;
        healthText.text = String.Format("$ {0}",objectAttributes.Health);;
        
    }

    public void SetAttributesToEmpty()
    {
        descriptionText.text = "Loading object ...";
        modelNameText.text = "Loading object ... ";
        costText.text = "Loading object ... ";
        damageText.text = "Loading object ... ";
    } 
}
