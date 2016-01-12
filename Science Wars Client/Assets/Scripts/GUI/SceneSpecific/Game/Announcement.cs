using UnityEngine;

namespace Assets.Scripts.GUI.SceneSpecific.Game
{
    class Announcement
    {
        public enum ScreenPosition { MiddleCenter, MiddleTop, MiddleBottom }
        public static UILabel staticGameObject;

        public static void make(string text, ScreenPosition position, float duration, float fontSize = 30.0f)
        {
            Debug.Log(UIControllerGame.getInstance().announcementSampleObject);
            UILabel gameObject = (UILabel)GameObject.Instantiate(UIControllerGame.getInstance().announcementSampleObject);
            gameObject.text = text;

            switch (position)
            {
                case ScreenPosition.MiddleBottom:
                    gameObject.transform.parent = UIControllerGame.getInstance().panel_AnnouncementsMiddleBottom.transform;
                    break;
                case ScreenPosition.MiddleCenter:
                    gameObject.transform.parent = UIControllerGame.getInstance().panel_AnnouncementsMiddleCenter.transform;
                    break;
                case ScreenPosition.MiddleTop:
                    gameObject.transform.parent = UIControllerGame.getInstance().panel_AnnouncementsMiddleTop.transform;
                    break;
            }

            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localScale = new Vector3(fontSize, fontSize, 1);
            GameObject.Destroy(gameObject.gameObject, duration);
        }
    }
}
