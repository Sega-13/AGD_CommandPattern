using Command.Main;

public class MeditateCommand : UnitCommand
{
    private bool willHitTarget;
    private int previousMaxHealth;

    public MeditateCommand(CommandData commandData)
    {
        previousMaxHealth = targetUnit.CurrentMaxHealth;
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
    public override void Undo()
    {
        if (willHitTarget)
        {
            var healthToReduce = targetUnit.CurrentMaxHealth - previousMaxHealth;
            targetUnit.CurrentMaxHealth = previousMaxHealth;
            targetUnit.TakeDamage(healthToReduce);
        }
        actorUnit.Owner.ResetCurrentActiveUnit();
    }

}
