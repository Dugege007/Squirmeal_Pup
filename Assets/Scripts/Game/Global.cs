using QFramework;
using UnityEngine;

namespace SquirmealPup
{
    public class Global : Architecture<Global>
    {
        public static BindableProperty<int> Score = new(0);
        public static BindableProperty<float> CurrentTime = new(0);
        public static BindableProperty<bool> IsInTipsArea = new(true);

        public static BindableProperty<bool> TimeOver = new(false);
        public static BindableProperty<bool> GetEat = new(false);

        protected override void Init()
        {
        }

        [RuntimeInitializeOnLoadMethod]
        public static void AutoInit()
        {
        }

        public static void ResetData()
        {
            Score.Value = 0;
            CurrentTime.Value = 0;
            IsInTipsArea.Value = true;
            TimeOver.Value = false;
            GetEat.Value = false;
        }
    }
}
