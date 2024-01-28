using QFramework;
using UnityEngine;

namespace SquirmealPup
{
    public class Global : Architecture<Global>
    {
        public static BindableProperty<int> Score = new(0);
        public static BindableProperty<float> CurrentTime = new(0);

        protected override void Init()
        {
        }

        [RuntimeInitializeOnLoadMethod]
        public static void AutoInit()
        {
        }
    }
}
