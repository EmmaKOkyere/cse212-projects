static int[] ListSelector(int[] list1, int[] list2, int[] select)
{
    int[] result = new int[select.Length];

    int index1 = 0;
    int index2 = 0;

    for (int i = 0; i < select.Length; i++)
    {
        if (select[i] == 1)
        {
            result[i] = list1[index1];
            index1++;
        }
        else if (select[i] == 2)
        {
            result[i] = list2[index2];
            index2++;
        }
    }

    return result;
}