﻿using ControllerInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.Artists;

namespace HexStrategyGame.MainMenu
{
  public class MainMenuState : IGameState
  {
        readonly GameStateMachine gameStateMachine;
        readonly IPatron patron;
        readonly MainMenuData data;
        private delegate void ShiftState();

    public MainMenuState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      data = new MainMenuData();
      patron = new MainMenuArtist(data);
    }

    public void Update(Input input)
    {
      if (input.confirm.Pressed)
      {
        switch (data.CurrentSelection)
        {
          case "New":
            gameStateMachine.Pop();
            gameStateMachine.Push(gameStateMachine.gameSettingsState);
            break;
          case "Exit":
            gameStateMachine.Exit = true;
            break;
           default:
            break;
        }
      }
      else
      {
        CycleSelection(input);
      }
    }

    private void CycleSelection(Input input)
    {
      if (!input.VerticalMaintained()) {
        switch (input.Vertical())
        {
          case Direction.Up:
            data.MainMenuDecrement();
            break;
          case Direction.Down:
            data.MainMenuIncrement();
            break;
        }
      }
    }

    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
