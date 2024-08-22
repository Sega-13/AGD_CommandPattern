using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    // A stack to keep track of executed commands.
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();

    public CommandInvoker() => SubscribeToEvents();
    private void SubscribeToEvents() => GameService.Instance.EventService.OnReplayButtonClicked.AddListener(SetReplayStack);

    public void SetReplayStack()
    {
        GameService.Instance.ReplayService.SetCommandStack(commandRegistry);
        commandRegistry.Clear();
    }
    /// <summary>
    /// Process a command, which involves both executing it and registering it.
    /// </summary>
    /// <param name="commandToProcess">The command to be processed.</param>
    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }

    /// <summary>
    /// Execute a command, invoking its associated action.
    /// </summary>
    /// <param name="commandToExecute">The command to be executed.</param>
    public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

    /// <summary>
    /// Register a command by adding it to the command registry stack.
    /// </summary>
    /// <param name="commandToRegister">The command to be registered.</param>
    public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);
    private bool RegistryEmpty() => commandRegistry.Count == 0;

    private bool CommandBelongsToActivePlayer()
    {
        return (commandRegistry.Peek() as UnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
    }
    public void Undo()
    {
        if (!RegistryEmpty() && CommandBelongsToActivePlayer())
        {
            commandRegistry.Pop().Undo();
        } 
    }
}