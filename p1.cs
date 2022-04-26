// //Author: Trishla Khandelwal
// //Date: 01/18/2022
// //Revision History: version 1 used for P1
// //Platform : C# using Visual Studio Code
// class p1
// {
//     public static void Main(string[] args)
//     {
//         bool status;

//         //invoking default constructor
//         jumpPrime jPrime1 = new jumpPrime();

//         //We are passing jPrime1 here, which means the number encapsulated will be 1009 (which is a prime number), as initialized in the constructor 
//         //Assumption: Even if a prime number is encapsulated, the result will still be the closest Lower and Upper Prime number
//         Console.WriteLine("******** Testing up() and down() on a prime number ********");
//         testUpAndDown(jPrime1);

//         Random rnd = new Random();
//         //returns random integers >= 1000 and < 9999
//         int num = rnd.Next(1000, 9999);
//         Console.WriteLine("******** Testing up() and down() on " + num +" ********");
//         //invoking parameterized constructor
//         //Creating 3 jumpPrime objects
//         jumpPrime jPrime2 = new jumpPrime(num);
//         jumpPrime jPrime3 = new jumpPrime(num+10); //encapsulating the next number by adding 10 to the random number
//         jumpPrime jPrime4 = new jumpPrime(num);

//         testUpAndDown(jPrime2);
//         Console.WriteLine("******** Function is now returning -1, lets try to revive the object ********");
//         testRevive(jPrime2);

//         Console.WriteLine("******** Checking if object is revived or not ********");
//         status = jPrime2.isActive();
//         if (status.Equals(true))
//         {
//             Console.WriteLine("Object is Revived/Active");
//         }
//         else
//         {
//             Console.WriteLine("Object is Inactive");
//         }

//         Console.WriteLine("******** Testing up() and down() again with a fresh object on "+ (num+10) + " ********");
//         testUpAndDown(jPrime3);

//         Console.WriteLine("******** Function is now returning -1, lets try to reset the object ********");
//         testReset(jPrime2);

//         //Testing revive() on an active object
//         //postCondition: It will cause the object to be permanently deactivated/dead
//         Console.WriteLine("******** Trying to revive an active object ********");
//         testRevive(jPrime4);

//     }

//     static void testRevive(jumpPrime jPrime1)
//     {

//         if (jPrime1.revive())
//         {
//             int downPrime = jPrime1.down();
//             int upPrime = jPrime1.up();
//             Console.WriteLine("Lower Prime number is " + downPrime);
//             Console.WriteLine("Higher Prime number is " + upPrime);

//         }
//         else
//         {
//             Console.WriteLine("Object is now dead");
//         }
//     }

//     static void testUpAndDown(jumpPrime jPrime2)
//     {

//         while (jPrime2.up() != -1 && jPrime2.down() != -1)
//         {
//             Console.WriteLine("Lower Prime number is " + jPrime2.down());
//             Console.WriteLine("Upper Prime number is " + jPrime2.up());
//         }

//     }

//     static void testReset(jumpPrime jumpPrime2)
//     {

//         if (jumpPrime2.reset())
//         {
//             Console.WriteLine("Object is resetted");

//         }
//         else
//         {
//             Console.WriteLine("Object is now dead");
//         }
//     }
// }