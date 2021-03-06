using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text descriptionText; 
    public Text modelNameText; 
    public Text costText;

    public void UpdateObjectPropertiesUI(Attributes objectAttributes)
    {
        string modelName = objectAttributes.Name;
        string cost = String.Format("$ {0}",objectAttributes.Cost);
        string description =
            String.Format("Properties :\n Health: {0}\n Damage: {1}\n Cost: {2}\n Description: {3}"
                , objectAttributes.Health,
                objectAttributes.Damage,
                objectAttributes.Cost,
                objectAttributes.Description);

        modelNameText.text = modelName;
        descriptionText.text = description;
        costText.text = cost;
    }

    public void SetAttributesToEmpty()
    {
        descriptionText.text = "Loading object ...";
        modelNameText.text = "Loading object ... ";
        costText.text = "Loading object ... ";
    } 
}
