using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[System.Serializable]
public class PlayerData {
    public int people;
    public float coins;
    public int planet;
    public int[] FoundPlanets = new int[9];    
    public float[] PlanetProgress = new float[9];


    public PlayerData(int people,float coins,int planet) {
        this.people = people;
        this.coins = coins;
        this.planet = planet;
        FoundPlanets[2] = 1;
        for(int i=0; i<9; i++){
       		PlanetProgress[i]=1.5f;
        }
    }
    public PlayerData(int people,float coins,int planet,float[] PlanetProgress) {
        this.people = people;
        this.coins = coins;
        this.planet = planet;
        FoundPlanets[2] = 1;
        this.PlanetProgress = PlanetProgress;

    }
    public void SetCoins(float coins) {
        this.coins = coins;
    }
    public int planetIsFound(int n){
   		return FoundPlanets[n];
    }
    public void changePlanetProgress(float n, int i){
    	PlanetProgress[i] +=n;
    }




}


public class ChangeCoins : MonoBehaviour
{

    private static int currentPlanet;
    private Color progressColor;
    public Text people;
    public Text coins;
    public Text productioncoins;
    private static int number=0;
    private static float tempcoins;
    private float temptime = 0f;
    public Image ProgressBar;
    public static GameObject StartButton;
    float temptime1 = 0f;
	PlayerData player;
    private void TouchCoins()
    {
        if (Input.touchCount == 1)
        {
            tempcoins+= 1;
        }
    }
    public void CoinsPerSecond() {
        float coin = 0.01f;
        if (temptime1 >= 1f)
        {
            tempcoins += coin;
            temptime1 = 0f;
        }
        temptime1 +=Time.deltaTime;
        productioncoins.text = coin.ToString();

    }
    public void changePlanetNumber(int n) {
        currentPlanet = n;
    }
    public void CallerChangePlanetNumber(float n){
    	player.PlanetProgress[currentPlanet]+=n;
    }


    public int returnNumber() {
        return currentPlanet;
    }
    public int planetFound(int n){
    	return player.planetIsFound(n);
    }

    public void startNewGame(){
    	player = new PlayerData(0,0f,2);
    	currentPlanet = 2;
    	number = 0;
    	tempcoins = 0;
    	SaveData();
    }



    void Start() {
    	StartButton = GameObject.Find("ButtonStart");
        player = LoadData();
        currentPlanet = player.planet;
        people.text = player.people.ToString();
        coins.text = player.coins.ToString();
        tempcoins = player.coins;
        ProgressBar.fillAmount = player.PlanetProgress[currentPlanet]/100;


    }


    void Update() {
        CoinsPerSecond();
        coins.text = tempcoins.ToString("F2");
        if (temptime >= 10f)
        {
            SaveData();
            temptime = 0f;
        }
        temptime+= 1 * Time.deltaTime;
        ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount,player.PlanetProgress[currentPlanet]/100f,2.5f*Time.deltaTime);	
        progressColor =	Color.Lerp(Color.white,Color.green,player.PlanetProgress[currentPlanet]/100f);
        ProgressBar.color = progressColor;
    }
    
   
    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(number,tempcoins,currentPlanet,player.PlanetProgress);
        formatter.Serialize(stream, data);
        stream.Close();


    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/data.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else {
            StartButton.SetActive(false);
            PlayerData novi = new PlayerData(0, 0f,2);
            //Debug.LogError("Save file not found");
            return novi;
        }
    }



}
