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
        List<string> possibleCrewNames = new List<string>();
        List<string> possibleCrewHobbies;

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
        
        private void Start()
        {
            CreateCrewmate(Random.Range(1, 50), Random.Range(1, 50));
        }

        private void CreateCrewmate(int crewNameGrab, int crewHobbyGrab)
        {
            alienTemp = Random.Range(1, 2);
            if (alienTemp == 1)
            {
                isAlien = true;
                

                crewNameText.text = newCrewmateName;
                crewHobyText.text = newCrewmateHobby;
                
            }
            else
            {
                isAlien = false;

            }
        }

        public void RejectCrewmate()
        {
            Debug.Log("REJECT CREWMATE");
            isAlien = false;
        }

        public void HireCrewmate()
        {
            Debug.Log("HIRE CREWMATE");
            isAlien = false;
        }
    }
}
