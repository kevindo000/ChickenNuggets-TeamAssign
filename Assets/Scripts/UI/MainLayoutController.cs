using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLayoutController: MonoBehaviour
{
    // Start is called before the first frame update
    public IMainLayout mainLayoutHandler;
    // Start is called before the first frame update

    public Button nextButton;
    public Button previousButton;
        
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        GameManagerScript gameManagerScript = gameManagerObject.GetComponent<GameManagerScript>();
        mainLayoutHandler = gameManagerScript;
            
        nextButton.onClick.AddListener(OnNextButtonClicked);
        previousButton.onClick.AddListener(OnPreviousButtonClicked);
    }

    void Update()
    {
        
    }

    void OnNextButtonClicked()
    {
        mainLayoutHandler.nextButtonPressed();    
    }

    void OnPreviousButtonClicked()
    {
        
        mainLayoutHandler.previousButtonPressed();    
    }
    
    
}
