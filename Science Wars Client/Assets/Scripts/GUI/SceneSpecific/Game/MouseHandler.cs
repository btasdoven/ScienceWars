using UnityEngine;
using System.Collections;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI;
using System;
using Assets.Scripts.GUI.SceneSpecific.Game;

public class MouseHandler {

    static public Type selectedTowerType = null;
    static public ITowerGUI lastSelectedTower = null;
    static public IMinionGUI lastSelectedMinion = null;

    static RaycastHit hitInfo;
    static RaycastHit hitInfoNGUI;

    static bool towerSlotClicked = false;
    static bool towerClicked = false;
    static bool minionClicked = false;
    static bool guiClicked = false;
    static GameObject obje = null;
    static Camera nguiCamera;

    static Assets.Scripts.GUI.Graphics.Graphics graphics;
    
    static public void initialize(Assets.Scripts.GUI.Graphics.Graphics graphics)
    {
        MouseHandler.graphics = graphics;
        nguiCamera = GameObject.Find("NGUICamera").camera;
    }

	static public void handleMouseClicks() 
	{
        if (Input.GetKeyDown(KeyCode.Mouse0) && GUIUtility.hotControl == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            towerSlotClicked = false;
            towerClicked = false;
            minionClicked = false;
            guiClicked = false;
            obje = null;

            if (Physics.Raycast(ray, out hitInfo, 1000.0f))
            {
                obje = hitInfo.collider.gameObject;

                if (obje.name.StartsWith("towerSlot_"))
                {
                    towerSlotClicked = true;
                }
                else if (obje.name.StartsWith("t_"))
                {
                    towerClicked = true;
                }
                else if (obje.name.StartsWith("m_"))
                {
                    minionClicked = true;
                }
                else
                {
                    // collider'i olan ama bizim istedigimiz turde obje olmayan bi objeye tiklanmissa
                    Ray rayNGUI = nguiCamera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(rayNGUI, out hitInfoNGUI, 1000.0f))
                    {
                        guiClicked = true;
                    }
                }
            }
            else
            {
                // collider'i olan herhangi bir seye tiklanmamissa
            }


            if (towerSlotClicked)
                onTowerSlotSelected(obje);
            else
                onTowerSlotDeselected();

            if (towerClicked)
                onTowerSelected(obje);
            else
                onTowerDeselected();

            if (minionClicked)
                onMinionSelected(obje);
            else
                onMinionDeselected();
        }
	}

    // select functions
    private static void onTowerSlotSelected(GameObject obje)
    {
        int towerSlot = System.Int32.Parse(obje.name.Substring("towerSlot_".Length)) - 1;
        int boardId = System.Int32.Parse(obje.transform.parent.parent.parent.gameObject.name.Substring("board_".Length));
        Board board = Game.getBoardById(boardId);

        if (board != PlayerMe.self.board)
            return;

        if (board.towers[towerSlot] == null)
        {
            if (selectedTowerType != null)
                graphics.sendCreateTowerRequest(selectedTowerType, towerSlot);
        }
    }

    private static void onTowerSelected(GameObject obje)
    {
        string objName = obje.name;
        string boardStr = obje.name.Substring(2, objName.LastIndexOf("_") - 2);
        string indexStr = obje.name.Substring(objName.LastIndexOf("_") + 1);
        int boardId = System.Int32.Parse(boardStr);
        int indexOnBoard = System.Int32.Parse(indexStr);
        Board board = Game.getBoardById(boardId);
        Tower tower = board.towers[indexOnBoard];

        // daha once bir kuleye tiklanmissa unselect'ini cagir.
        if (lastSelectedTower != null)
            lastSelectedTower.onTowerUnselected();

        lastSelectedTower = (ITowerGUI)tower.tag;
        graphics.activateTowerInfo(lastSelectedTower);

        lastSelectedTower.onTowerSelected();
        UIControllerGame.getInstance().alwaysActiveInfoPanel = true;
    }

    private static void onMinionSelected(GameObject obje)
    {
        string objName = obje.name;
        string instanceIDstr = obje.name.Substring(2);
        int instanceID = System.Int32.Parse(instanceIDstr);
        Minion minion = Game.getMinionById(instanceID);

        if (lastSelectedMinion != null)
            lastSelectedMinion.onMinionUnselected();
        lastSelectedMinion = (IMinionGUI)minion.tag;

        graphics.activateMinionInfo(lastSelectedMinion);
        
        lastSelectedMinion.onMinionSelected();
        UIControllerGame.getInstance().alwaysActiveInfoPanel = true;
    }

    // deselect functions
    private static void onTowerSlotDeselected()
    {
        if (!guiClicked)
        {
            selectedTowerType = null;
            UIControllerGame.getInstance().selectedTowerOverlayObject.SetActive(false);
        }
    }

    private static void onTowerDeselected()
    {
        if (!guiClicked)
        {
            if (lastSelectedTower != null)
                lastSelectedTower.onTowerUnselected();
                
            lastSelectedTower = null;
            UIControllerGame.getInstance().alwaysActiveInfoPanel = false;
            UIControllerGame.getInstance().panel_TowerInfo.SetActive(false);
        }
    }

    private static  void onMinionDeselected()
    {
        if (!guiClicked)
        {
            if (lastSelectedMinion != null)
                lastSelectedMinion.onMinionUnselected();

            lastSelectedMinion = null;
            if (!towerClicked)
            {
                UIControllerGame.getInstance().alwaysActiveInfoPanel = false;
                UIControllerGame.getInstance().panel_MinionInfo.SetActive(false);
            }
        }
    }
}
