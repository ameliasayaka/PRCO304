﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls Scroll Animation of Menus
public class UIScrollScript : MonoBehaviour
{
    private bool isOpen;
    private bool isInteractable;
    private bool isBlockRaycast;
    private Animator panelAnimator;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        //panel = gameObject;
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        panelAnimator = gameObject.GetComponent<Animator>();
        isOpen = false;
        isInteractable = false;
    }

    //Method to call animation change
    public void Scroll()
    {
        //sets bool to state of panel
        isOpen = panelAnimator.GetBool("isOpen");
        //If panel already open will close & vice versa
        panelAnimator.SetBool("isOpen", !isOpen);
    }

    //toggle panel interactivity
    public void ToggleInteractive()
    {
        //Set bool
        isBlockRaycast = canvasGroup.blocksRaycasts;
        isInteractable = canvasGroup.interactable;
        
        //Change bool
        canvasGroup.interactable = !isInteractable;
        canvasGroup.blocksRaycasts = !isBlockRaycast;
    }
    
}
