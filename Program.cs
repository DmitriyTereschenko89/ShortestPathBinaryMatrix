namespace ShortestPathBinaryMatrix
{
	internal class Program
	{
		public class BinaryMatrixShortestPath
		{
			private List<int[]> GetNeighbors(int[][] grid, int r, int c, int distance, int n)
			{
				int[] deltaR = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };
				int[] deltaC = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
				List<int[]> neighbors = new();
				for (int i = 0; i < 8; ++i)
				{
					int newR = deltaR[i] + r;
					int newC = deltaC[i] + c;
					if (newR >= 0 && newR < n && newC >= 0 && newC < n && grid[newR][newC] == 0)
					{
						neighbors.Add(new int[] { newR, newC, distance + 1 });
					}
				}
				return neighbors;
			}

			public int ShortestPathBinaryMatrix(int[][] grid)
			{
				int n = grid.Length;
				if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
				{
					return -1;
				}
				Queue<int[]> queue = new();
				queue.Enqueue(new int[] { 0, 0, 1 });
				while (queue.Count > 0)
				{
					int queueCount = queue.Count;
					while (queueCount-- > 0)
					{
						int[] cell = queue.Dequeue();
						if (cell[0] == n - 1 && cell[1] == n - 1)
						{
							return cell[2];
						}
						List<int[]> neighbors = GetNeighbors(grid, cell[0], cell[1], cell[2], n);
						foreach (int[] neighbor in neighbors)
						{
							int r = neighbor[0];
							int c = neighbor[1];
							int distance = neighbor[2];
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