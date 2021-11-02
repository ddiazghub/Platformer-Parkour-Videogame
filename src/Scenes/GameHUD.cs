using Godot;
using System;

public class GameHUD : CanvasLayer
{
    [Signal]
    public delegate void PausePressed();
    
    [Signal]
    public delegate void PauseMouseEntered();
    
    [Signal]
    public delegate void PauseMouseExited();

    public override void _Ready()
    {
        this.GetNode("Pause").Connect("pressed", this, nameof(this.OnPausePressed));
        this.GetNode("Pause").Connect("mouse_entered", this, nameof(this.OnPauseMouseEntered));
        this.GetNode("Pause").Connect("mouse_exited", this, nameof(this.OnPauseMouseExited));
    }

    public void SetPoints(int points)
    {
        this.GetNode<PointsCounter>("PointsCounter").Set((UInt32) points);
    }

    public void SetProgress(double percent)
    {
        this.GetNode<ProgressBar>("Progress").Value = percent;
    }

    public void SetAttempts(int number)
    {
        this.GetNode<AttemptsCounter>("AttemptsCounter").Set(number);
    }

    public void SetActions(PlayerMainAction main, PlayerSecondaryAction secondary)
    {
        if (main != this.GetNode<MainActionPickup>("MainAction").Type)
        {
        this.GetNode<MainActionPickup>("MainAction").Type = main;
        this.GetNode<Label>("MainAction/MainLabel").Text = MainAction.GetTypeAsStringEsp(main);
        }
        
        if (secondary != this.GetNode<SecondaryActionPickup>("SecondaryAction").Type)
        {
            this.GetNode<SecondaryActionPickup>("SecondaryAction").Type = secondary;
            this.GetNode<Label>("SecondaryAction/SecondaryLabel").Text = SecondaryAction.GetTypeAsStringEsp(secondary);
        }
    }

    public void OnPausePressed()
    {
        this.EmitSignal("PausePressed");
    }

    public void OnPauseMouseEntered()
    {
        this.EmitSignal("PauseMouseEntered");
    }
    
    public void OnPauseMouseExited()
    {
        this.EmitSignal("PauseMouseExited");
    }
}