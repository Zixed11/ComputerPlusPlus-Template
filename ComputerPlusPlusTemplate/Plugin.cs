using BepInEx;
using GorillaNetworking;
using System;
using UnityEngine;
using UnityEngine.Device;
using Utilla;
using ComputerPlusPlus;
using WalkSimulator.Tools;
using ComputerPlusPlus.Tools;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using System.Linq;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

namespace ZixedComputer
{
    [BepInPlugin("com.yourname.gorillatag.yourpluginname", "YourPluginName", "1.0.0")]
    [BepInDependency("com.kylethescientist.gorillatag.computerplusplus")]
    public class Plugin : BaseUnityPlugin
    {

    }

    public class ZixedPlusPlus : IScreen
    {
        public string Title => "TEMPLATE";

        public string Description => "Press [Option 1] to toggle between this room's";

        bool somethingHappened = false;

        bool RoomInfo;

        public void Start()
        {

        }

        public string GetContent()
        {
            string RoomName = "Room Code: " + PhotonNetwork.CurrentRoom.Name + "\n";
            string pcount = "Players in this room: " + PhotonNetwork.CurrentRoom.PlayerCount + "\n";
            string mode = "GameMode: " + GorillaComputer.instance.currentGameMode + "\n\n";

            if (PhotonNetwork.InRoom)
            {
                if (RoomInfo)
                {
                    return RoomName + pcount + mode;
                }
            }
            else
            {
                return "Not connected to room.";
            }

            return string.Empty;
        }

        public void OnKeyPressed(GorillaKeyboardButton button)
        {
            if (button.characterString == "option1")
            {
                RoomInfo = !RoomInfo;
            }
        }
    }
}
