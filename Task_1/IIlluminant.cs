namespace HW_5
{
    public interface IIlluminant
    {
        /// <summary>
        /// Включение
        /// </summary>
        void On();

        /// <summary>
        /// Выключение
        /// </summary>
        void Off();

        /// <summary>
        /// Светит/ Не светит
        /// </summary>
        bool IsLight();
    }
}