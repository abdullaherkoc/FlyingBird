using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite mMetal, gMetal, sMetal, bMetal;
    public Image metalImage;

    private void Start()
    {
        metalImage.GetComponent<Image>();
    }
    private void Update()
    {

        int gameScore = GameManager.gameScore;
        if (gameScore > 0 && gameScore <= 1)
        {
            metalImage.sprite = mMetal;
        }
        else if (gameScore > 1 && gameScore <= 2)
        {
            metalImage.sprite = bMetal;
        }
        else if (gameScore > 2 && gameScore <= 3)
        {
            metalImage.sprite = sMetal;
        }
        else if (gameScore > 3)
        {
            metalImage.sprite = gMetal;
        }
    }

}
