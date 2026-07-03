public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of doubles with the given 'length'.
        // 2. Use a loop that runs from 0 up to length-1.
        // 3. For each index i, calculate (i+1) * number.
        //    - Example: if number = 3 and i = 0 → (0+1)*3 = 3
        //               if i = 1 → (1+1)*3 = 6, etc.
        // 4. Store the result in the array at position i.
        // 5. After the loop finishes, return the array.

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
        // PLAN:
        // 1. Understand that rotating right by 'amount' means the last 'amount' elements
        //    move to the front, and the rest shift to the right.
        // 2. Use List slicing with GetRange:
        //    - Take the last 'amount' elements: data.GetRange(data.Count - amount, amount).
        //    - Take the first part: data.GetRange(0, data.Count - amount).
        // 3. Clear the original list (or remove all elements).
        // 4. Add the last part first, then add the first part.
        // 5. This modifies the original list in place.

        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
