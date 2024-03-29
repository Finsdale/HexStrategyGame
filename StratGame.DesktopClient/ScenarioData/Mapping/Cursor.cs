﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ControllerInput;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.ScenarioData;
using HexStrategyGame.Game_States;

namespace HexStrategyGame.MapData
{
  public class Cursor
  {
    public Position Position { get; set; }

    float frameTimer = 0.0f;

    readonly Scenario scenario;

    bool lastRight = true;

    public Cursor(Scenario scenario)
    {
      Position = new Position(new Point());
      this.scenario = scenario;
    }

    public void Update(Input input)
    {
      if (!input.DirectionHeld()) {
        frameTimer = 0.0f;
        Step(input.direction);
      }
      else if (input.direction != Direction.None) {
        if (frameTimer >= 2.5f) {
          frameTimer = 2.0f;
          Step(input.direction);
        }
        else {
          frameTimer += 0.1f;
        }
      }
    }

    public void Step(Direction direction)
    {
      bool moved;
      switch (direction) {
        case Direction.Up:
          if (lastRight) {
            moved = MoveBy(MapConst.NE);
            if (!moved) MoveBy(MapConst.NW);
            else lastRight = false;
          }
          else {
            moved = MoveBy(MapConst.NW);
            if (!moved) MoveBy(MapConst.NE);
            else lastRight = true;
          }
          break;

        case Direction.Down:
          if (lastRight) {
            moved = MoveBy(MapConst.SE);
            if (!moved) MoveBy(MapConst.SW);
            else lastRight = false;
          }
          else {
            moved = MoveBy(MapConst.SW);
            if (!moved) MoveBy(MapConst.SE);
            else lastRight = true;
          }
          break;

        case Direction.UpLeft:
          moved = MoveBy(MapConst.NW);
          if (!moved) {
            moved = MoveBy(MapConst.W);
            if (!moved) MoveBy(MapConst.NE);
          }
          lastRight = false;
          break;

        case Direction.UpRight:
          moved = MoveBy(MapConst.NE);
          if (!moved) {
            moved = MoveBy(MapConst.E);
            if (!moved) MoveBy(MapConst.NW);
          }
          lastRight = true;
          break;

        case Direction.DownLeft:
          moved = MoveBy(MapConst.SW);
          if (!moved) {
            moved = MoveBy(MapConst.W);
            if (!moved) MoveBy(MapConst.SE);
          }
          lastRight = false;
          break;

        case Direction.DownRight:
          moved = MoveBy(MapConst.SE);
          if (!moved) {
            moved = MoveBy(MapConst.E);
            if (!moved) MoveBy(MapConst.SW);
          }
          lastRight = true;
          break;

        case Direction.Left:
          MoveBy(MapConst.W);
          lastRight = false;
          break;

        case Direction.Right:
          MoveBy(MapConst.E);
          lastRight = true;
          break;
      }
      scenario.ClampCameraToPosition(Position);
    }

    public bool MoveBy(Position movement)
    {
      bool result = false;
      Position newPos = Position + movement;
      MapTile mapTile = scenario.GetTileAtMapLocation(newPos);
      if (mapTile.TileTerrain != Terrain.Empty) {
        Position = newPos;
        result = true;
      }
      return result;
    }
  }
}
