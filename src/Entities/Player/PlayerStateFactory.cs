using Godot;
using System;

public class PlayerStateFactory {
    public PersistentState New(PlayerPersistentState state)
    {
        PersistentState newState = null;

        switch (state)
        {
            case PlayerPersistentState.ON_GROUND:
                newState = new OnGroundState();
                break;

            case PlayerPersistentState.ON_AIR:
                newState = new OnAirState();
                break;
        }

        return newState;
    }

    public MainAction New(PlayerMainAction state)
    {
        MainAction newState = null;

        switch (state)
        {
            case PlayerMainAction.JUMP:
                newState = new Jump();
                break;

            case PlayerMainAction.JETPACK:
                newState = new Jetpack();
                break;

            case PlayerMainAction.GLIDE:
                newState = new Jump();
                break;
                
            case PlayerMainAction.TELEPORT:
                newState = new Jump();
                break;
        }

        return newState;
    }

    public SecondaryAction New(PlayerSecondaryAction state)
    {
        SecondaryAction newState = null;

        switch (state)
        {
            case PlayerSecondaryAction.FASTFALL_AND_ROLL:
                newState = new FastFallAndRoll();
                break;

            case PlayerSecondaryAction.SWITCH_GRAVITY:
                newState = new FastFallAndRoll();
                break;

            case PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY:
                newState = new FastFallAndRoll();
                break;
                
            case PlayerSecondaryAction.SPAWN_BLOCKS:
                newState = new FastFallAndRoll();
                break;
        }

        return newState;
    }
}