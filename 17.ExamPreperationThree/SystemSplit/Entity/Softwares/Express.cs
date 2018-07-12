using System;
using System.Collections.Generic;
using System.Text;

public class Express:Software
    {
        public Express(string name, int consumCapacity, int consumMemory) : base(name, consumCapacity, consumMemory * 2)
        {
        }
    }
   