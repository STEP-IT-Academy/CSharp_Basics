namespace HW_1
{
    static class Extensions
    {
        // Расширение для смены знаков элементов массива на противоположный
        public static int[] ChangeSign(this One_DimensionalArray obj)
        {
            int[] someArray = new int[obj.GetArray.Length];

            for (int i = 0; i < someArray.Length; i++)
            {
                someArray[i] = (obj.GetArray[i] * -1);
            }

            return someArray;
        }
    }
}