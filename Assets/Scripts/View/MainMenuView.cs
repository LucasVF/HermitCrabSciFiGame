using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//View Class for Main Menu
public class MainMenuView : BaseView
{
    public override ViewNames GetName() => ViewNames.MainMenu;

    //No SetUp is required as of yet
    //In the future, stages may be added to the SetUp, so as to allow for multiple Stages to be selected before going into Game View
    public override void SetUpView(){} 
}
