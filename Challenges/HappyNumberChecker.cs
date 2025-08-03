using System;

class HappyNumberChecker
{
    private int number;

    public HappyNumberChecker(int number)
    {
        this.number = number;
    }


    public bool IsHappy()
    {
        int slow = number, fast = number;

        do
        {
            slow = SumOfSquares(slow);                
            fast = SumOfSquares(SumOfSquares(fast));   

            if (slow == 1 || fast == 1)
                return true;

        } while (slow != fast);

        return false;
    }
    private int SumOfSquares(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            int digit = num % 10;
            sum += digit * digit;
            num /= 10;
        }
        return sum;
    }
}

