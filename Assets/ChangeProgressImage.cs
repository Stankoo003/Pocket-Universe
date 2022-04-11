using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProgressImage : MonoBehaviour
{
	private Sprite[] planetImage;
	public Image current;
	bool once = true;
	 public Sprite Venus;
    void Start()
    {
    	planetImage = new Sprite[9];
    	planetImage[0] = Resources.Load<Sprite>("PlanetImages/MercuryImage");
    	planetImage[1] = Resources.Load<Sprite>("PlanetImages/VenusImage");
    	planetImage[2] = Resources.Load<Sprite>("PlanetImages/EarthImage");
    	planetImage[3] = Resources.Load<Sprite>("PlanetImages/MarsImage");
    	planetImage[4] = Resources.Load<Sprite>("PlanetImages/JupiterImage");
    	planetImage[5] = Resources.Load<Sprite>("PlanetImages/SaturnImage");
    	planetImage[6] = Resources.Load<Sprite>("PlanetImages/UranusImage");
    	planetImage[7] = Resources.Load<Sprite>("PlanetImages/NeptuneImage");
    	planetImage[8] = Resources.Load<Sprite>("PlanetImages/PlutoImage");
    	ChangeIcon();

    }
    public void ChangeIcon(){
    	int k = this.GetComponent<ChangeCoins>().returnNumber();
		current.sprite =planetImage[k];
    }
    public void ChangeIcon(int n){
    	current.sprite = planetImage[n];
    }

    
 
}
