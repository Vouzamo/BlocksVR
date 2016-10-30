// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 							ProtoBlox 1.0, Copyright Â© 2013, RipCord Development
//											buttonBehaviour.js
//										    info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script controls the different states of a button.


private var offState : Color;				//Used to store the initial material colour
var overState : Color;  					//Defines the colour the button changes to when the cursor hovers over it
var clickState : Color;						//Defines the colour the button changes to when it is clicked on

private var buttonState : String;  			//Stores the current state of the button
var fadeTime : float = 0.25;				//The amount of time it takes for the button colour to fade from one state to the next


function Awake() {

	//Defines the offState colour of the button as the colour it is when the scene starts
	offState = GetComponent.<Renderer>().material.color;

}

//Highlight button
function OnMouseEnter() {
	ColourChange("Over");
}

//Remove highlight from button
function OnMouseExit() {
	ColourChange("Off");
	
}

//Change button to click colour
function OnMouseDown() {
	GetComponent.<Renderer>().material.color = clickState;
}

//This function controls the colour change for the various button states
function ColourChange(_buttonStates)	{

	var currentColor = GetComponent.<Renderer>().material.color;
	var timeLeft = fadeTime;
	
	while (timeLeft > 0) {

		if (_buttonStates == "Over") {
			GetComponent.<Renderer>().material.color = Color.Lerp(currentColor, overState, (fadeTime - timeLeft) / fadeTime);
		}

		if (_buttonStates == "Off") {
			GetComponent.<Renderer>().material.color = Color.Lerp(currentColor, offState, (fadeTime - timeLeft) / fadeTime);
		}

		yield;
		timeLeft -= Time.deltaTime;
	}
}

// BUTTON ACTION --------------------

function OnMouseUp() {

	GetComponent.<Renderer>().material.color = overState;

}