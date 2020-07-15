using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    public Slider frequencySlider;
    public Text frequencyText;
    public Slider speedSlider;
    public Text speedText;
    public Slider cameraSlider;
    public Text cameraText;

    private GameObject generalManager;
    
    void Start()
    {
        generalManager = GameObject.Find("GeneralManager");
        speedSlider.onValueChanged.AddListener (delegate {SpeedValueChangeCheck ();});
        speedSlider.value =  generalManager.GetComponent<GeneralManager>().initialSpeed;
        frequencySlider.onValueChanged.AddListener (delegate {FrequencyValueChangeCheck ();});
        frequencySlider.value =  speedSlider.value =  generalManager.GetComponent<GeneralManager>().frequency;
        speedText.text =  generalManager.GetComponent<GeneralManager>().initialSpeed.ToString();
        frequencyText.text = "1/" + generalManager.GetComponent<GeneralManager>().frequency.ToString();

        cameraSlider.onValueChanged.AddListener (delegate {CameraValueChangeCheck ();});
        cameraSlider.value =  generalManager.GetComponent<GeneralManager>().activeCamera;
        cameraText.text = generalManager.GetComponent<GeneralManager>().activeCamera.ToString();
    }
    private void SpeedValueChangeCheck()
	{
		 generalManager.GetComponent<GeneralManager>().initialSpeed = speedSlider.value;
         speedText.text = speedSlider.value.ToString();
	}
    private void FrequencyValueChangeCheck()
	{
        int val =  Mathf.RoundToInt(frequencySlider.value);
		generalManager.GetComponent<GeneralManager>().frequency = val;
        frequencyText.text = "1/" + val.ToString();

	}
     private void CameraValueChangeCheck()
	{
        int val =  Mathf.RoundToInt(cameraSlider.value);
        generalManager.GetComponent<GeneralManager>().activeCamera = val;
        cameraText.text = val.ToString();
	}
}
