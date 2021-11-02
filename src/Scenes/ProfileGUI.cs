using Godot;
using System;

/// <summary>
///     Panel that displays the data of the currently active profile.
/// </summary>
public class ProfileGUI : NinePatchRect {

    /// <summary>
    ///     Emitted when the shop button is pressed.
    /// </summary>
    [Signal]
    public delegate void ShopPressed();

    /// <summary>
    ///     Emitted when the edit profile button is pressed.
    /// </summary>
    [Signal]
    public delegate void EditPressed();

    public override void _Ready()
    {
        this.GetNode("Shop").Connect("pressed", this, nameof(this.OnShopPressed));
        this.GetNode("LogOut").Connect("pressed", this, nameof(this.OnLogOutPressed));
        this.GetNode("Edit").Connect("pressed", this, nameof(this.OnEditPressed));

        this.UpdateUI();
    }

    /// <summary>
    ///     Updates the information currently displayed on the GUI.
    /// </summary>
    public void UpdateUI()
    {
        this.GetNode<Label>("Completed").Text = Profile.CurrentSession.Info.CompletedLevels.Count + "/3 completado";
        this.GetNode<Label>("ProfileName").Text = Profile.CurrentSession.Info.Name;
        this.GetNode<TextureRect>("Avatar").Texture = Profile.CurrentSession.Info.Avatar.ToTexture();
    }

    public void OnShopPressed()
    {
        this.EmitSignal("ShopPressed");
    }

    public void OnEditPressed()
    {
        this.EmitSignal("EditPressed");
    }

    public void OnLogOutPressed()
    {
        Profile.CurrentSession.LogOut();
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.PROFILE_SELECT);
    }
}
