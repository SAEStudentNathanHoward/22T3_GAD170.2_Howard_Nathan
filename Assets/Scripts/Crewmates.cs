using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NathanHoward
{
    public class Crewmates : MonoBehaviour
    {
        // Creation of my lists
        [SerializeField] List<string> possibleCrewNames = new List<string>();
        [SerializeField] List<string> possibleCrewHobbies = new List<string>();
        [SerializeField] List<string> possibleAlienHobbies = new List<string>();

        //Linking of the Ship script
        public Ship shipScript;

        //Variables used to detirmine if the crewmate is an alien
        private int alienTemp;
        public bool isAlien = false;

        public string newCrewmateName;
        public string newCrewmateHobby;

        //Original declaration for GameObjects to assign in Inspector
        //Ended up using the UI builtin inspector for on click and put it to the respective methods below
        //[SerializeField] GameObject rejectCrewmate;
        //[SerializeField] GameObject hireCrewmate;

        //Fields to control the Name and Hoby text fields in the game
        [SerializeField] TMP_Text crewNameText;
        [SerializeField] TMP_Text crewHobyText;
        
        // On start of the program it creates a random crewmate
        private void Start()
        {
            CreateCrewmate(Random.Range(1, 30), Random.Range(1, 30));
        }

        // The method that controls the creation of the crewmates
        // Needs 2 numbers passed into it
        private void CreateCrewmate(int crewNameGrab, int crewHobbyGrab)
        {
            // Coin flip to detirmine of the proposed crewmate is an Alien
            alienTemp = Random.Range(1, 20);
            
            // Checking the outcome of the coin flip
            if (alienTemp >= 15)
            {
                isAlien = true;

                // Grabbing the created crewmates name and hobby
                newCrewmateName = possibleCrewNames[crewNameGrab];
                newCrewmateHobby = possibleAlienHobbies[crewHobbyGrab];
                
                // Setting the UI text to display the name and hobby
                crewNameText.text = newCrewmateName;
                crewHobyText.text = newCrewmateHobby;
                
            }
            else
            {
                isAlien = false;
                
                // Grabbing the created crewmates name and hobby
                newCrewmateName = possibleCrewNames[crewNameGrab];
                newCrewmateHobby = possibleCrewHobbies[crewHobbyGrab];

                // Setting the UI text to display the name and hobby
                crewNameText.text = newCrewmateName;
                crewHobyText.text = newCrewmateHobby;
            }
        }

        // The method called when the "Reject" button is pressed
        public void RejectCrewmate()
        {
            //Debug.Log("REJECT CREWMATE");

            // Resets the alien variable and creates a new crewmate
            isAlien = false;
            CreateCrewmate(Random.Range(1, 30), Random.Range(1, 30));
        }

        // The method called when the "Hire" button is pressed
        public void HireCrewmate()
        {
            //Debug.Log("HIRE CREWMATE");

            // Sending the variable to the Ship script and passing the required values
            shipScript.AddToShip(isAlien, newCrewmateName, newCrewmateHobby);

            // Resets the alien variable and creates a new crewmate
            isAlien = false;
            CreateCrewmate(Random.Range(1, 30), Random.Range(1, 30));
        }
    }
}
