using System;

class MaxCircularSubarraySu
{
    private int[] nums;

    public MaxCircularSubarraySu(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            throw new ArgumentException("Массив не может быть пустым.");

        this.nums = nums;
    }

    public int Calculate()
    {
        int totalSum = 0;
        int maxSum = nums[0];
        int curMax = 0;
        int minSum = nums[0];
        int curMin = 0;

        foreach (int num in nums)
        {

            curMax = Math.Max(num, curMax + num);
            maxSum = Math.Max(maxSum, curMax);


            curMin = Math.Min(num, curMin + num);
            minSum = Math.Min(minSum, curMin);

            totalSum += num;
        }


        if (maxSum < 0)
            return maxSum;

        return Math.Max(maxSum, totalSum - minSum);
    }
}

