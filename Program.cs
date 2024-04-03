using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //Given array
        int[] given = { 1, 1, 2, 2, 2, 3, 3, 3, 3, 5, 5, 6, 7, 8 };

        Dictionary<int,int> arrayCount = new Dictionary<int, int>();

        //If given array is empty

        for(int i = 0; i < given.Length; i++){
            if (arrayCount.ContainsKey(given[i])){
                arrayCount[given[i]]++;
            }
            else{
                arrayCount.Add(given[i],1);
            }
        }

        if(arrayCount.Count == 0){
            Console.WriteLine("The given array is empty!");
        }
        else{
            foreach (var item in arrayCount)
            {
                Console.Write(item.Key + " = " + item.Value + ", ");
            }
        }

    }
}
