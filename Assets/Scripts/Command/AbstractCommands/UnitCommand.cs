using Command.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitCommand : ICommand
{
    public CommandData commandData;
    
    // References to the actor and target units, accessible by subclasses.
    protected UnitController actorUnit;
    protected UnitController targetUnit;

    /// <summary>
    /// Abstract method to execute the unit command. Must be implemented by concrete subclasses.
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Abstract method to determine whether the command will successfully hit its target.
    /// Must be implemented by concrete subclasses.
    /// </summary>
    public abstract bool WillHitTarget();
    public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;

    public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;
}
