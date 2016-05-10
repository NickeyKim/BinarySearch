using System;

namespace BinarySearh
{
	class Program{

		public static int binarySearch(int[] array, int target) {
			try
			{
				return binarySearch(array, target, 0, array.Length - 1);
			}
			catch{
				throw;
			}

		}
		public static int iterBinarySearch (int[] array, int target){
			int lower = 0;
			int upper = array.Length - 1;
			int center, range;

			if (lower > upper) {
				throw new Exception ("Limits reversed");
			}

			while (true) {
				range = upper - lower;
				if (range == 0 && array [lower] != target) {
					throw new Exception ("Element not in array");
				}
				if (array [lower] > array [upper]) {
					throw new Exception ("Array not Solved");
				}
				center = range / 2 + lower;
				if (target == array [center]) {
					return center;
				} else if (target < array [center]) {
					upper = center - 1; 
					} else { 
					lower = center + 1;
				}
			}
		}
		private static int binarySearch(int[] array, int target, int lower, int upper){
			int center, range; 
			range = upper - lower;

			if (range < 0) {
				throw new Exception("Limits reversed.");
			} else if (range == 0 && array[lower] != target) {
				throw new Exception("Target element no found.");
			}
			if (array[lower] > array[upper]) {
				throw new Exception("Array not sorted.");
			}

			center = range / 2 + lower;
			if (array[center] == target) {
				return center;
			} else if (array[center] > target) {
				return binarySearch(array, target, lower, center - 1);
			} else {  //(array[center] > target)
				return binarySearch(array, target, center + 1, upper);
			}
		}

		public static void Main(string[] args) {
			int[] testArray = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
			try {
				Console.WriteLine("Searching 6 :"+binarySearch(testArray, 6));
				Console.WriteLine("Searching 5 :"+iterBinarySearch(testArray, 5));

			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
	}
}
