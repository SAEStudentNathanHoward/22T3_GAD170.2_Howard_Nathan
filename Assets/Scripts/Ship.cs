using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NathanHoward
{
    public class Ship : MonoBehaviour
    {
        //Creation of the 2 lists
        [SerializeField] List<string> currentCrewNames;
        [SerializeField] List<string> currentCrewHobbies;

        // game objects that link objects in my scene
        [SerializeField] GameObject mainCanvas;
        [SerializeField] GameObject endCanvas;
        [SerializeField] GameObject bloodSplatter;

        [SerializeField] TMP_Text crewNameOutput1;
        [SerializeField] TMP_Text crewNameOutput2;
        [SerializeField] TMP_Text crewNameOutput3;
        [SerializeField] TMP_Text crewNameOutput4;
        [SerializeField] TMP_Text crewNameOutput5;
        [SerializeField] TMP_Text crewNameOutput6;
        [SerializeField] TMP_Text crewNameOutput7;
        [SerializeField] TMP_Text crewNameOutput8;
        [SerializeField] TMP_Text crewNameOutput9;

        private int currentCrewCount = 0;
        
        // Update slowluy removes bloodsplatter if it is on the screen
        private void Update()
        {
            if (bloodSplatter.GetComponent<CanvasGroup>().alpha > 0f)
            {
                bloodSplatter.GetComponent<CanvasGroup>().alpha -= 0.001f;
            }

            if (currentCrewCount != 0)
            {
                // Updating the text on the canvas to the names and hobbies of the hired crewmates
                crewNameOutput1.text = currentCrewNames[0] + " | " + currentCrewHobbies[0];
                crewNameOutput2.text = currentCrewNames[1] + " | " + currentCrewHobbies[1];
                crewNameOutput3.text = currentCrewNames[2] + " | " + currentCrewHobbies[2];
                crewNameOutput4.text = currentCrewNames[3] + " | " + currentCrewHobbies[3];
                crewNameOutput5.text = currentCrewNames[4] + " | " + currentCrewHobbies[4];
                crewNameOutput6.text = currentCrewNames[5] + " | " + currentCrewHobbies[5];
                crewNameOutput7.text = currentCrewNames[6] + " | " + currentCrewHobbies[6];
                crewNameOutput8.text = currentCrewNames[7] + " | " + currentCrewHobbies[7];
                crewNameOutput9.text = currentCrewNames[8] + " | " + currentCrewHobbies[8];
            }
        }

        // Public method to add crewmembers to the ship
        public void AddToShip(bool isAlien, string newCrewName, string newCrewHobby)
        {
            // Checking to see if the new crew member is an alien
            if (isAlien == false)
            {
                // Add the new crew member to the list along with their hobby
                currentCrewNames.Add(newCrewName);
                currentCrewHobbies.Add(newCrewHobby);

                currentCrewCount += 1;

                //Debug.Log(currentCrewCount);

                if (currentCrewCount == 10)
                {
                    mainCanvas.SetActive(false);
                    endCanvas.SetActive(true);
                }
            }
            else
            {
                // Code that calls the killing of a random amount of Crew Members
                EliminateCrewmates(Random.Range(1,3));
            }
        }

        // Method used to Destroy the Crewmates
        // Needs input from AddToShip
        private void EliminateCrewmates(int amountKilled)
        {
            
            //Debug.Log(amountKilled);

            // Sifting through to delete a random number of crewmates
            for (int i = 0; i < amountKilled; i++)
            {
                // Creation of a random int to track which crewmate to delete
                int currentCrewIndex = Random.Range(1, currentCrewCount);
                
                //Debug.Log(currentCrewIndex);
               
                // Removal of the crew names and hobbies
                currentCrewNames.RemoveAt(currentCrewIndex);
                currentCrewHobbies.RemoveAt(currentCrewIndex);

                //Debug.Log("End of for i");
                //Debug.Log("i = " + i);

                currentCrewCount -= amountKilled;
                
                //Debug.Log(currentCrewCount);
                bloodSplatter.GetComponent<CanvasGroup>().alpha = 1;
            }

            Debug.Log("Alien Detected! You have just lost " + amountKilled + " crewmates!");
        }

    }
}
