using System;

namespace NoName.Framework.Core.File
{
    public class Global
    {
        private static Global _instance = new Global();

        public Int32 X { get; set; }

        public static Global Instance
        {
            get => _instance;
        }
    }

    public class A
    {
        private static Int32 I { get; set; } = 0;

        private static Int32 AA { get; set; } = Global.Instance.X;

        private Int32 BB { get; set; }

        void Exec()
        {
            Global.Instance.X = I++ * 2;
            BB = Global.Instance.X;
        }
    }

}
