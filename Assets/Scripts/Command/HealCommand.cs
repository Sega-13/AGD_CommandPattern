using Command.Main;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class HealCommand : UnitCommand
{
    private bool willHitTarget;

    public HealCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;

}
