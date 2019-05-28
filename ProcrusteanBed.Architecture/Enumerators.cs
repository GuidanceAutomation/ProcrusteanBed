using System;
using System.Collections.Generic;

namespace ProcrusteanBed.Architecture
{
    public static class Enumerators
    {
        public static readonly HashSet<Type> DirectiveTypes = new HashSet<Type>()
        {
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(float),
            typeof(System.Net.IPAddress)
        };
    }

    public enum TaskType
    {
        UnorderedList = 0,
        OrderedList = 1,
        AtomicMoveList = 2,
        GoToNode = 3,
        ServiceAtNode = 4
    };
}
