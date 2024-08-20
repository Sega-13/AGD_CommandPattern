using Command.Main;

public class AttackCommand : UnitCommand
{
    private bool willHitTarget;
    public AttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }
    public override void Execute() =>
        GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);


    public override bool WillHitTarget() => true;
   
}
