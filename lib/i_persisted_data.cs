using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public interface IPersistedData
  {
    Location[,,][] load();
  }
}

