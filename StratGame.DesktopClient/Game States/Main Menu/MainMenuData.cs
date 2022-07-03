using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MainMenu
{
  public class MainMenuData
  {
    private int MMOption { get; set; }
    private static int MMLength { get { return Enum.GetNames(typeof(MainMenuOption)).Length; } }
    public string CurrentSelection { get { return Enum.GetName(typeof(MainMenuOption), MMOption); } }

    public MainMenuData()
    {
      MMOption = 0;
    }

    public void MainMenuIncrement()
    {
      MMOption++;
      if (MMOption == MMLength)
      {
        MMOption = 0;
      }
    }

    public void MainMenuDecrement()
    {
      MMOption--;
      if (MMOption < 0)
      {
        MMOption = MMLength - 1;
      }
    }
  }
}
