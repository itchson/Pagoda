using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    public int levelRank;
    private Vector3 scale;
    //public bool isSelected = false;

    private SpriteRenderer spriteRoof;
    private SpriteRenderer spriteRoom;

    TowerManager towerManager;

    bool isSelectedLevel;

    private void Start() 
    {
        towerManager = GetComponentInParent<TowerManager>();
        spriteRoof = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRoom = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Object Pressed..");
        //this.transform.localScale += new Vector3(-0.2f,-0.2f);
        //transform.position += new Vector3(.2f,0);

        if(isSelectedLevel) isSelectedLevel = false;
        if(!isSelectedLevel) isSelectedLevel = true;

        if(towerManager.isLevelSelected == true)
        {
            
            //transform.localScale += new Vector3(-0.2f,-0.2f);

            spriteRoom.sortingOrder = 2;
            spriteRoof.sortingOrder = 3;
            //isSelected = false;
            towerManager.isLevelSelected = false;
        }
        else if(towerManager.isLevelSelected == false)
        {
            //transform.localScale += new Vector3(0.2f,0.2f);
            //spriteRoom.sortingOrder = 0;
            //spriteRoof.sortingOrder = 1;
            //isSelected = true;
            towerManager.isLevelSelected = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(towerManager.isLevelSelected == true) return;

        transform.localScale += new Vector3(0.2f,0.2f);
        //transform.position += new Vector3(-.2f,0);
        Debug.Log("Entering Object");

        spriteRoom.sortingOrder = 2;
        spriteRoof.sortingOrder = 3;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(towerManager.isLevelSelected == true) return;

        transform.localScale -= new Vector3(0.2f,0.2f);
        //transform.position += new Vector3(.2f,0);
        Debug.Log("Exiting Object");
        
        spriteRoom.sortingOrder = 0;
        spriteRoof.sortingOrder = 1;
    }

}
