using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerButtons
{
    private PlayerButtons() { }

    private static PlayerButtons m_instatnce = null;

    public static PlayerButtons Instance
    {
        get
        {
            if (m_instatnce == null)
            {
                m_instatnce = new PlayerButtons();
            }
            return m_instatnce;
        }
    }

    private string m_WSADButtons = "WSAD";
    public string WSADButtons => m_WSADButtons;

    private string m_crouchButton = "Crouch";
    public string CrouchButton => m_crouchButton;

    private string m_jumpButton = "Jump";
    public string JumpButton => m_jumpButton;
    
}
