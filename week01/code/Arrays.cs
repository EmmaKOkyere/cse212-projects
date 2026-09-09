public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number'
    /// followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3,
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}