using StorageMaster.Core;
using System;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
