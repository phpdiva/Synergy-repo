using UnityEngine;
using System.Collections;

public class GreyBox : MonoBehaviour
{
    public GameObject PressJump;
    public GameObject PressN;
    private GameObject text;
    public float delayBeforeAnimation = 1;

    private int petalToCorrupt = 0;
    private float startTimer = 0;
    private bool winGlow = false;

    private void FastStart()
    {
        UpdatePicture();
        if (this.GetComponent<AnimateRGB>() != null) //if its a box with a square artound it ie not the last ending flower
        {
            this.GetComponent<AnimateRGB>().SetRGBA(4, 0.3f);//0.58f   <put this number back instead of 0, to get green box
            this.transform.FindChild("Petal1").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 1);
            this.transform.FindChild("Petal2").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 1);
            this.transform.FindChild("Petal3").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 1);
            this.transform.FindChild("Petal4").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 1);
            this.transform.FindChild("PlantHead").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 1);
            //int percentComplete = (Application.loadedLevel * 5);//gets out of 100% by times by 5
            GUIText progressText = this.transform.FindChild("YourProgression").gameObject.guiText;
            progressText.text = Application.loadedLevel + "/20";
        }
    }

    private void Update()
    {
        if (startTimer == 0)
        {
            startTimer = Time.fixedTime;
        }
        float currentTime = Time.fixedTime;

        if (currentTime > startTimer + delayBeforeAnimation) //if current time is greater than startTimer +1 second.
        {
            if (petalToCorrupt > 0)
            {
                if (petalToCorrupt == 4)  //if its the last one
                {
                    this.transform.FindChild("PlantHead").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 0.0f, 0.1f);
                    this.transform.FindChild("TooCorrupt").gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 1.0f);
                }

                string Petal = "Petal" + petalToCorrupt;
                this.transform.FindChild("FlowerGlow").GetComponent<AnimateSprite>().PlayAnimation("DarkCloud", 1);
                this.gameObject.transform.FindChild(Petal).gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalDie", 1);
                petalToCorrupt = 0; //reset it
                startTimer = 0;
            }
            else if (winGlow)    //win aniamtion dleay??
            {
                this.transform.FindChild("FlowerGlow").gameObject.GetComponent<AnimateSprite>().PlayAnimation("Glow", 1);
                winGlow = false;
            }
        }
    }

    public int InitialiseBox(int petalsLeft)
    {
        FastStart();

        if (petalsLeft == PlayerPrefs.GetInt("lives"))			//checks that there has not been a change
        {
            text = (GameObject)Instantiate(PressJump);
            text.transform.parent = this.transform;
            text.transform.localPosition = new Vector3(-0.68f, -0.4786608f, -4f);
            winGlow = true;
            if (petalsLeft < 4)     //regrow petals
            {
                petalsLeft = petalsLeft + 1;
                PlayerPrefs.SetInt("lives", petalsLeft);
                string Petal;
                switch (PlayerPrefs.GetInt("lives"))
                {
                    case 2:
                        Petal = "Petal" + 3;
                        this.gameObject.transform.FindChild(Petal).gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalRegrow", 1);
                        break;

                    case 3:
                        Petal = "Petal" + 2;
                        this.gameObject.transform.FindChild(Petal).gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalRegrow", 1);
                        break;

                    case 4:
                        Petal = "Petal" + 1;
                        this.gameObject.transform.FindChild(Petal).gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalRegrow", 1);
                        break;
                }
            }
        }
        else if (petalsLeft == 0)
        {
            text = (GameObject)Instantiate(PressN);
            text.transform.parent = this.transform;
            text.transform.localPosition = new Vector3(-0.68f, -0.4786608f, -4f);
            petalToCorrupt = 4;
            //special ending
        }
        else
        {
            text = (GameObject)Instantiate(PressJump);
            text.transform.parent = this.transform;
            text.transform.localPosition = new Vector3(-0.68f, -0.4786608f, -4f);

            switch (petalsLeft)
            {
                case 1:
                    {
                        petalToCorrupt = 3;
                        //this.gameObject.transform.FindChild("Petal3").gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalDie", 1);
                    }
                    break;

                case 2:
                    {
                        petalToCorrupt = 2;
                        //this.gameObject.transform.FindChild("Petal2").gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalDie", 1);
                    }
                    break;

                case 3:
                    {
                        petalToCorrupt = 1;
                        //this.gameObject.transform.FindChild("Petal1").gameObject.GetComponent<AnimateSprite>().PlayAnimation("PetalDie", 1);
                    }
                    break;
            }
        }
        return petalsLeft;
    }

    private void UpdatePicture()
    {
        switch (PlayerPrefs.GetInt("lives"))
        {

            case 1:
                {
                    this.gameObject.transform.FindChild("Petal1").gameObject.GetComponent<AnimateSprite>().SetFrameSet(93);
                    this.gameObject.transform.FindChild("Petal2").gameObject.GetComponent<AnimateSprite>().SetFrameSet(93);
                    this.gameObject.transform.FindChild("Petal3").gameObject.GetComponent<AnimateSprite>().SetFrameSet(93);
                }
                break;

            case 2:
                {
                    this.gameObject.transform.FindChild("Petal1").gameObject.GetComponent<AnimateSprite>().SetFrameSet(93);
                    this.gameObject.transform.FindChild("Petal2").gameObject.GetComponent<AnimateSprite>().SetFrameSet(93);
                }
                break;

            case 3:
                {
                    this.gameObject.transform.FindChild("Petal1").gameObject.GetComponent<AnimateSprite>().SetFrameSet(93);
                }
                break;
        }
    }

}
