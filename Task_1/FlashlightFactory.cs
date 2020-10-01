using HW_1.Batteries;

namespace HW_5
{
    public class FlashlightFactory
    {
        private class Flashlight : IIlluminant
        {
            private Battery battery;

            /// <summary>
            /// Текущее состояние фонарика
            /// </summary>
            private bool light;

            protected internal Flashlight(Battery battery)
            {
                this.battery = battery;
                Off();
            }

            /// <summary>
            /// Проверка состояния фонарика 
            /// </summary>
            public bool IsLight()
            {
                return light == true ? true : false;
            }

            public void Off()
            {
                light = false;
            }

            public void On()
            {
                if (battery.currentCharge > 0)
                {
                    light = true;
                    battery.ReduceBatteryCharge();
                }
            }
        }

        public IIlluminant GetFlashlight(Battery battery)
        {
            Flashlight flashlight = new Flashlight(battery);
            return flashlight;
        }
    }
}
