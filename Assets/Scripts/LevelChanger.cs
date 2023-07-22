using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject nextLevelUI;
    private int reachedCars = 0;
    public void ChangeLevel(Component sender, object data)
    {
        if(data is int)
        {
            int totalCars = cars.Length;
            int carNumber = (int)data;
            reachedCars += carNumber;
            if (totalCars == reachedCars)
            {
                StartCoroutine(WaitForUi());
            }
        }
        
    }
    IEnumerator WaitForUi()
    {
        yield return new WaitForSeconds(2f);
        nextLevelUI.SetActive(true);
    }
}
