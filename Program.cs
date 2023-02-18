// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string[] rows = File.ReadAllLines("input.txt");

int[,] heightMap = HeightMap(rows);
int size = heightMap.GetLength(0);
HashSet<(int, int)> VisibleTrees = new ();  
PrintHeightMap(heightMap);
//left to right
for (int row = 0; row < size; row++)
{
    int tallest = int.MinValue;
    for (int col = 0; col < size; col++)
    { 
       int current = heightMap[row, col];
        if (current > tallest)
        {
            VisibleTrees.Add((row, col));
            tallest = current;  
        }
    }
    //right to left
     tallest = int.MinValue;
    for (int col = size-1; col > 0; col--)
    {
        int current = heightMap[row, col];
        if (current > tallest)
        {
            VisibleTrees.Add((row, col));
            tallest = current;
        }
    }
}


//Top to bottom
for (int col = 0; col < size; col++)
{
    int tallest = int.MinValue;
    for (int row = 0; row < size; row++)
    {
        int current = heightMap[row, col];
        if (current > tallest)
        {
            VisibleTrees.Add((row, col));
            tallest = current;
        }
    }
    //Bottom to top
     tallest = int.MinValue;
    for (int row = size-1; row >= 0; row--)
    {
        int current = heightMap[row, col];
        if (current > tallest)
        {
            VisibleTrees.Add((row, col));
            tallest = current;
        }
    }
}

Console.WriteLine(String.Join(",", VisibleTrees));
Console.WriteLine(VisibleTrees.Count());    

void PrintHeightMap(int[,] map)
{
    for (int row = 0; row < map.GetLength(0); row++)
    {
        for (int col = 0; col < map.GetLength(0); col++)
        {
            Console.Write(map[row, col]);
        }
        Console.WriteLine();
    }
}

int[,] HeightMap(string[] rows)
{
    int[,] heightMap = new int[rows.Length, rows.Length];
    for (int row = 0; row < rows.Length; row++)
    { 
       for(int col = 0; col < rows[row].Length; col++)
        {
            heightMap[row, col] = int.Parse($"{rows[row][col]}");
        }
    }
    return heightMap;
}