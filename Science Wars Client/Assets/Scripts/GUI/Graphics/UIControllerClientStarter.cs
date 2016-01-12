using UnityEngine;
using System.Collections;
using NetWorker.Utilities;
using Assets.Scripts.Engine;

public class UIControllerClientStarter : MonoBehaviour {

    //Singleton Pattern
    private static UIControllerClientStarter _instance = null;
    public static UIControllerClientStarter getInstance()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("ControllerClientStarter");
            if (go != null)
                _instance = go.GetComponent<UIControllerClientStarter>();
        }

        return _instance;
    }

    public UIInput input_username;
    public UIInput input_password;
    public UILabel output_loginResult;

    public GameObject panel_connected;
    public GameObject panel_connecting;
    public GameObject panel_connectionFailied;

    void Start()
    {
        input_username.text = "Username";
        input_username.selected = true;
    }

    void Update()
    {
        if (input_username.selected && Input.GetKeyUp(KeyCode.Tab))
            input_password.selected = true;
        else if (input_password.selected && Input.GetKeyUp(KeyCode.Tab))
            input_username.selected = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Assets.Scripts.Engine.Network.server.Disconnect();
            Application.Quit();
        }
    }

    public void btn_TryAgainClick()
    {
        tryingToConnect();
        Assets.Scripts.Engine.Network.connect();
    }

    public void btn_LoginClick()
    {
        RawMessage message = new RawMessage();
        message.putUTF8String("username", input_username.text);
        message.putUTF8String("password", input_password.text);

        Assets.Scripts.Engine.Network.sslStream.WriteSingleMessage(message);
        RawMessage msg = Assets.Scripts.Engine.Network.sslStream.ReadSingleMessage();
        if (msg == null)
        {
            Assets.Scripts.Engine.Network.server.Disconnect();
            output_loginResult.text = "Connection is Lost.";
            return;
        }

        if (msg.getBool("response"))
        {
            //Assets.Scripts.Engine.Network.sslStream.Close();  // DUE TO A BUG -kardeslerim- WE CANNOT CLOSE THE STREAM.
            // Cunku close yaparsak, nereden geldigi belirsiz 37 byte, serverda bu client'a ait messageListenera dusuyor. 
            // sadece unity'de oluyor, .net'te duzgun calisiyor. Muhtemelen Mono kaynakli bir sorun.

            Assets.Scripts.Engine.Network.server.ListenForMessages();
            output_loginResult.color = Color.green;
        }

        output_loginResult.text = msg.getUTF8String("reason");
        input_username.text = "";
        input_password.text = "";
        input_username.selected = true;
        StartCoroutine(hideLoginResult());
    }

    public IEnumerator hideLoginResult()
    {
        yield return new WaitForSeconds(2f);
        output_loginResult.text = "";
    }

    public void tryingToConnect()
    {
        panel_connecting.SetActive(true);
        panel_connected.SetActive(false);
        panel_connectionFailied.SetActive(false);
    }

    public void connectionFailed()
    {
        panel_connecting.SetActive(false);
        panel_connected.SetActive(false);
        panel_connectionFailied.SetActive(true);
    }

    public void connectionSuccessful()
    {
        panel_connecting.SetActive(false);
        panel_connected.SetActive(true);
        panel_connectionFailied.SetActive(false);
    }
}
