namespace ShortestPathBinaryMatrix
{
	internal class Program
	{
		public class BinaryMatrixShortestPath
		{
			private List<int[]> GetNeighbors(int[][] grid, int r, int c, int distance, int n)
			{
				List<int[]> neighbors = new();
				int[] deltaRow = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };
				int[] deltaCol = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
				for (int i = 0; i < 8; ++i)
				{
					int newR = deltaRow[i] + r;
					int newC = deltaCol[i] + c;
					if (newR >= 0 && newR < n && newC >= 0 && newC < n && grid[newR][newC] == 0)
					{
						neighbors.Add(new int[] { newR, newC, distance + 1 });
					}
				}
				return neighbors;
			}

			public int ShortestPathBinaryMatrix(int[][] grid)
			{
				if (grid[0][0] == 1)
				{
					return -1;
				}
				int n = grid.Length;
				Queue<int[]> queue = new();
				queue.Enqueue(new int[] { 0, 0, 1 });
				while(queue.Count > 0)
				{
					int queueSize = queue.Count;
					while(queueSize-- > 0)
					{
						int[] cell = queue.Dequeue();
						List<int[]> neighbors = GetNeighbors(grid, cell[0], cell[1], cell[2], n); 
						foreach (int[] neighbor in neighbors)
						{
							int r = neighbor[0];
							int c = neighbor[1];
							int distance = neighbor[2];
							if (r == n - 1 && c == n - 1)
							{
								return distance;
							}
							grid[r][c] = 1;
							queue.Enqueue(new int[] { r, c, distance });
						}
					}
				}
				return -1;
			}
		}

		static void Main(string[] args)
		{
			BinaryMatrixShortestPath shortestPathBinaryMatrix = new();
            Console.WriteLine(shortestPathBinaryMatrix.ShortestPathBinaryMatrix(new int[][]
			{
				new int[] { 0, 1 }, new int[] { 1, 0 }
			}));
			Console.WriteLine(shortestPathBinaryMatrix.ShortestPathBinaryMatrix(new int[][]
			{
				new int[] { 0, 0, 0 }, new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 }
			}));
			Console.WriteLine(shortestPathBinaryMatrix.ShortestPathBinaryMatrix(new int[][]
			{
				new int[] { 1, 0, 0 }, new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 }
			}));
		}
	}
}