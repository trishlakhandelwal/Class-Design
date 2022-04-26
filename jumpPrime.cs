//Author: Trishla Khandelwal
//Date: 01/18/2022
//Revision History: version 1 used for P1
//Platform : C# using Visual Studio Code
class jumpPrime
{
    //This class encapsulates a positive integer, which must be at least 4-digits long
    //Clients can request the prime numbers above(up) or below(down) to the encapsulated positive integer
    //encapsulated number will ‘jump’ after a limited number of queries, 
    //that will be the number determined by the distance between the two closest prime numbers

    //Class Invariant: the encapsulated a positive integer must be at least 4-digits long, 
    //otherwise a default value of 1000 will be used

    // Interface Invariant:
    // up()
    // postCondition: returns closest prime number that is higher than the encapsulated number
    // returns -1 if inactive
    //
    // down()
    // postCondition: returns closest prime number that is lower than the encapsulated number
    // returns -1 if inactive
    //
    // revive()
    // Revives a jumpPrime object. An attempt to revive an active jumpPrime object causes that object to be permanently deactivated.
    // Returns true on a successful revive attempt
    // postCondition: state may be changed
    //
    // reset()
    // Resets an ACTIVE jumpPrime object, resetting it's queries count and number of jumps made.
    // Returns true when successfully resetted
    //
    // isActive()
    // returns true if object is active


    //States: Active- a call to up or down will return a valid prime number
    //Inactive- a call to up or down will return -1
    //The jumpPrime object may automatically become inactive after the no. of jumps exceeds MAX_JUMPS
    //Dead- The object can no longer be revived 
    //The client may revive a jumpPrime object, if it is inactive 
    //The client may reset a jumpPrime object that is active, which will reset the count of queries to 0
    //An attempt to revive an active jumpPrime object causes that object to be permanently dead

    // Implementation Invariant:
    // When jumpPrime 'jumps' the new number is direction is determined by the closest prime number, upPrime or downPrime
    // The number encapsulated is generated randomly between the range of 1000-9999
    // Permanently deactivated objects will act forever inactive.

    //number encapsulated
    private int num;
    //count of queries
    private int qCount;
    //bool to track state of object(Active/Inactive)
    private bool active;
    //count of jumps
    private int jCount;
    //bool to track permanent deactivation
    private bool deactivated;
    //max number of queries before jump required
    private int maxQueries;
    //maximum number of jumps allowed
    private int maxJumps;
    //the return values for up and down
    private int upperPrime;
    private int lowerPrime;

    //Default Constructor
    //Initializating num with 1009 which is already a prime number
    //Maximum number of jumps allowed is 5
    //Max number of queries before jump required is the difference between the upperPrime and lowerPrime number
    public jumpPrime()
    {

        num = 1009;
        qCount = 0;
        active = true;
        jCount = 0;
        deactivated = false;
        maxJumps = 5;
        lowerPrime = calculateLowerPrime();
        upperPrime = calculateHigherPrime();
        maxQueries = upperPrime - lowerPrime;
    }

    //Parameterized constructor
    //Maximum number of jumps allowed is 5
    //max number of queries before jump required is the difference between the upperPrime and lowerPrime number
    public jumpPrime(int value)
    {
        if (value > 999)
            num = value;
        else
        {
            num = 1000;
        }
        qCount = 0;
        active = true;
        jCount = 0;
        deactivated = false;
        maxJumps = 5;
        lowerPrime = calculateLowerPrime();
        upperPrime = calculateHigherPrime();
        maxQueries = upperPrime - lowerPrime;
    }

    //If object is active, return next prime number higher than value
    //If object is not active, return -1
    //postCondition: if qCount reaches maxQueries, value is jumped to a value higher than the next higher prime number
    public int up()
    {
        if (active)
        {
            qCount++;
            if (qCount > maxQueries)
            {
                jump();
            }
            return upperPrime;
        }
        else
        {
            return -1;
        }
    }

    //If object is active, return next prime number lower than value
    //If object is not active, return -1
    //postCondition: if qCount reaches maxQueries, value is jumped to a value lower than the next lower prime number
    public int down()
    {
        if (active)
        {
            qCount++;
            if (qCount > maxQueries)
            {
                jump();
            }
            return lowerPrime;
        }
        else
        {
            return -1;
        }
    }

    public bool revive()
    {
        if (!active && !deactivated)
            active = true;

        else
        {
            deactivated = true;
            active = false;
        }

        return active;
    }

    public bool reset()
    {
        if (!active || deactivated)
        {
            return false;
        }

        qCount = 0;
        jCount = 0;

        return true;
    }

    public bool isActive()
    {
        return active;
    }

    bool isPrime(int n)
    {
        // This is checked so that we can skip middle five numbers in below loop
        if (n % 2 == 0 || n % 3 == 0)
            return false;

        for (int i = 5; i * i <= n; i = i + 6)
            if (n % i == 0 ||
                n % (i + 2) == 0)
                return false;

        return true;
    }
    //Calculates the next higher Prime number
    public int calculateHigherPrime()
    {
        int prime = num;
        bool found = false;

        while (!found)
        {
            prime++;

            if (isPrime(prime))
                found = true;
        }

        upperPrime = prime;
        return upperPrime;

    }
    //Calculates the next lower Prime number
    public int calculateLowerPrime()
    {
        int prime = num;
        bool found = false;

        while (!found)
        {
            prime--;

            if (isPrime(prime))
                found = true;
        }

        lowerPrime = prime;
        return lowerPrime;
    }

    //The number will ‘jump’ after a limited number of queries i.e the difference between the two closest upper and lower prime numbers
    bool jump()
    {
        if (jCount == maxJumps)
        {
            jCount = 0;
            active = false;
            return false;
        }

        qCount = 0;
        calculateLowerPrime();
        calculateHigherPrime();
        maxQueries = (upperPrime - lowerPrime);
        jCount++;

        return true;
    }
}
