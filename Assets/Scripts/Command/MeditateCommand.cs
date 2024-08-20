using Command.Main;

public class MeditateCommand : UnitCommand
{
    private bool willHitTarget;

    public MeditateCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;

}
