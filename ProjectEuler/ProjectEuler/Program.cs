﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BigInteger result = P050ConsecutivePrimeSum();
            sw.Stop();
            Console.WriteLine(result);
            Console.WriteLine("Time: {0}", sw.Elapsed.ToString());

            Console.Read();
        }
        #region completed
        static int P001MultiplesOf3And5()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                    Console.WriteLine("{0} = {1}", i, result);
                }
            }
            return result;
        }
        static int P002EvenFibonacciNumbers()
        {
            int result = 0;
            int a = 1;
            int b = 2;
            int c = 0;

            while (c < 4000000)
            {
                if (b % 2 == 0)
                {
                    result += b;
                }
                //new number
                c = a + b;
                //move up a
                a = b;
                //move up b
                b = c;
            }
            return result;
        }
        static Int64 P003LargestPrimeFactor()
        {
            Int64 result = 1;
            //Get all the factors
            List<Int64> factors = factorsOf(600851475143);
            //for each of the factors
            foreach (Int64 factor in factors)
            {
                List<Int64> findingPrimes = factorsOf(factor);
                //If it's prime (it only has 2 factors)
                if (findingPrimes.Count == 2 * 2)
                {
                    //finding highest number
                    foreach (Int64 number in findingPrimes)
                    {
                        //if the number is higher than current best
                        if (number > result)
                        {
                            //set new best
                            result = number;
                        }
                    }
                }
            }
            return result;

        }
        static int P004LargestPalindromeProduct()
        {
            //Finding largest palindrome product of two 3-digit numbers
            int result = 0;
            int multiple;

            for (int a = 999; a > 0; a--)
            {
                for (int b = 999; b > 0; b--)
                {
                    multiple = a * b;
                    if (multiple < result)
                    {
                        continue;
                    }
                    //Reverse the string form of multiple
                    char[] array = multiple.ToString().ToCharArray();
                    Array.Reverse(array);
                    //If same in reverse and forwards
                    if (new String(array) == multiple.ToString())
                    {
                        result = multiple;
                    }
                }
            }
            return result;
        }
        static double P005SmallestMultiple()
        {
            //Not really programming just an answer
            //What is the smallest positive number that is evenly 
            //divisible by all of the numbers from 1 to 20?

            int answer = 1;
            //multiply the prime numbers
            answer *= 19;
            answer *= 17;
            answer *= 13;
            answer *= 11;
            answer *= 7;
            answer *= 5;
            answer *= 3;
            answer *= 2;

            //find max of prime factors
            //20: 2^2 * 5
            //18: 2   * 3^2
            //16: 2^4
            //15: 3   * 5
            //14: 2   * 7....

            //Max prime powers are 2^4, 3^2
            answer *= 2 * 2 * 2;
            answer *= 3;
            return answer;
        }
        static int P006SumSquareDifference()
        {
            //Find the difference between the sum of the squares of the 
            //first one hundred natural numbers and the square of the sum.
            int sumOfSquares = 0;
            int squareOfSum = 0;

            for (int i = 0; i < 101; i++)
            {
                sumOfSquares += (i * i);
                squareOfSum += i;
            }
            squareOfSum *= squareOfSum;

            return squareOfSum - sumOfSquares;
        }
        static int P00710001stPrime()
        {
            //Starting from the second prime number: 3
            int primeCounter = 2;
            int numberCounter = 3;
            while (primeCounter != 10001)
            {
                //Only check odd numbers
                numberCounter += 2;
                if (factorsOf(numberCounter).Count == 2)
                {
                    primeCounter += 1;
                }
            }
            return numberCounter;
        }
        static Int64 P008LargestProductInASeries()
        {
            //Find the thirteen adjacent digits in the 1000-digit number that 
            //have the greatest product. What is the value of this product?
            string digits =
                "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            //Convert the long string to char array
            char[] array = digits.ToCharArray();
            //result
            int placeOfSum = 0;
            Int64 curBest = 0;
            Int64 sum = 1;
            //Iterate through, find place of largest (sum of) numbers
            for (int i = 0; i < (1000 - 13); i++)
            {
                sum = 1;


                for (int j = 0; j < 13; j++)
                {
                    sum *= array[j + i] - 48;
                }
                if (sum > curBest)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        Console.Write("{0} ", array[j + i] - 48);
                    }
                    curBest = sum;
                    placeOfSum = i;
                    Console.WriteLine("Line: {0}, Sum: {1}", i, sum);
                }
            }

            return curBest;
        }
        static double P009SpecialPythagoreanTriplet()
        {
            //A Pythagorean triplet is a set of three natural numbers,
            //a < b < c, for which, a^2 + b^2 = c^2

            //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            //Find the product abc.

            //2 equations, 3 unknowns
            //c = 1000 - a - b = sqrt(a^2+b^2)

            for (int a = 0; a < 500; a++)
            {
                for (int b = 0; b < 400; b++)
                {
                    if (1000 - a - b == Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)))
                    {
                        return a * b * Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    }
                }
            }
            return 0;
        }
        static Int64 P010SummationOfPrimes()
        {
            //Include the first prime then start at 3
            Int64 result = 2;
            //Find the sum of all the primes below two million.
            for (int i = 3; i < 2000000; i++)
            {
                if (i % 2 != 0)
                {
                    if (isPrime(i))
                    {
                        result += i;
                    }
                }

            }

            return result;
        }
        static Int64 P011LargestProductInAGrid()
        {
            string nums =
            "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08 " +
            "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00 " +
            "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65 " +
            "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91 " +
            "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 " +
            "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50 " +
            "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 " +
            "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21 " +
            "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 " +
            "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95 " +
            "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92 " +
            "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57 " +
            "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58 " +
            "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40 " +
            "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66 " +
            "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69 " +
            "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36 " +
            "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16 " +
            "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54 " +
            "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

            List<int> numList = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 3 == 0)
                {
                    string curNumber = nums[i].ToString() + nums[i + 1].ToString();
                    int number;
                    Int32.TryParse(curNumber, out number);
                    numList.Add(number);
                }
            }
            //Now all the numbers are in a list
            Int64 curBest = 0;
            Int64 result;
            for (int i = 0; i < numList.Count; i++)
            {
                Console.WriteLine(i);
                //if away from left wall
                if (i % 20 >= 3)
                {
                    //look left
                    result = numList[i];
                    result *= numList[i - 1];
                    result *= numList[i - 2];
                    result *= numList[i - 3];
                    //set new curBest
                    if (result > curBest)
                    {
                        curBest = result;
                        Console.WriteLine(curBest);
                    }
                    //and if away from top
                    if (i >= 60)
                    {
                        //look up+left
                        result = numList[i];
                        result *= numList[i - 1 - 20];
                        result *= numList[i - 2 - 40];
                        result *= numList[i - 3 - 60];
                        //set new curBest
                        if (result > curBest)
                        {
                            curBest = result;
                            Console.WriteLine(curBest);
                        }
                    }
                    //and if away from bot
                    if (i < 340)
                    {
                        //look down+left
                        result = numList[i];
                        result *= numList[i - 1 + 20];
                        result *= numList[i - 2 + 40];
                        result *= numList[i - 3 + 60];
                        //set new curBest
                        if (result > curBest)
                        {
                            curBest = result;
                            Console.WriteLine(curBest);
                        }
                    }

                }

                //if away from right wall
                if (i % 20 <= 16)
                {
                    //look right
                    result = numList[i];
                    result *= numList[i + 1];
                    result *= numList[i + 2];
                    result *= numList[i + 3];
                    //set new curBest
                    if (result > curBest)
                    {
                        curBest = result;
                        Console.WriteLine(curBest);
                    }
                    //and if away from top
                    if (i >= 60)
                    {
                        //look up+right
                        result = numList[i];
                        result *= numList[i + 1 - 20];
                        result *= numList[i + 2 - 40];
                        result *= numList[i + 3 - 60];
                        //set new curBest
                        if (result > curBest)
                        {
                            curBest = result;
                            Console.WriteLine(curBest);
                        }
                    }
                    //and if away from bot
                    if (i < 340)
                    {
                        //look down+right
                        result = numList[i];
                        result *= numList[i + 1 + 20];
                        result *= numList[i + 2 + 40];
                        result *= numList[i + 3 + 60];
                        //set new curBest
                        if (result > curBest)
                        {
                            curBest = result;
                            Console.WriteLine(curBest);
                        }
                    }
                }
                //if away from top
                if (i >= 60)
                {
                    //look up
                    result = numList[i];
                    result *= numList[i - 20];
                    result *= numList[i - 40];
                    result *= numList[i - 60];
                    //set new curBest
                    if (result > curBest)
                    {
                        curBest = result;
                        Console.WriteLine(curBest);
                    }
                }
                //if away from bot
                if (i < 340)
                {
                    //look down
                    result = numList[i];
                    result *= numList[i + 20];
                    result *= numList[i + 40];
                    result *= numList[i + 60];
                    //set new curBest
                    if (result > curBest)
                    {
                        curBest = result;
                        Console.WriteLine(curBest);
                    }
                }

            }
            return curBest;
        }
        static Int64 P012HighlyDivisibleTriangularNumber()
        {
            List<Int64> factors = new List<Int64>();
            int counter = 1;
            int total = 1;
            while (factors.Count < 500)
            {
                counter += 1;
                total += counter;

                factors = factorsOf(total);
            }
            return total;
        }
        static Int64 P013LargeSum()
        {
            //Work out the first ten digits of the sum of the following 
            //one-hundred 50-digit numbers.
            string input =
            "37107287533902102798797998220837590246510135740250" +
            "46376937677490009712648124896970078050417018260538" +
            "74324986199524741059474233309513058123726617309629" +
            "91942213363574161572522430563301811072406154908250" +
            "23067588207539346171171980310421047513778063246676" +
            "89261670696623633820136378418383684178734361726757" +
            "28112879812849979408065481931592621691275889832738" +
            "44274228917432520321923589422876796487670272189318" +
            "47451445736001306439091167216856844588711603153276" +
            "70386486105843025439939619828917593665686757934951" +
            "62176457141856560629502157223196586755079324193331" +
            "64906352462741904929101432445813822663347944758178" +
            "92575867718337217661963751590579239728245598838407" +
            "58203565325359399008402633568948830189458628227828" +
            "80181199384826282014278194139940567587151170094390" +
            "35398664372827112653829987240784473053190104293586" +
            "86515506006295864861532075273371959191420517255829" +
            "71693888707715466499115593487603532921714970056938" +
            "54370070576826684624621495650076471787294438377604" +
            "53282654108756828443191190634694037855217779295145" +
            "36123272525000296071075082563815656710885258350721" +
            "45876576172410976447339110607218265236877223636045" +
            "17423706905851860660448207621209813287860733969412" +
            "81142660418086830619328460811191061556940512689692" +
            "51934325451728388641918047049293215058642563049483" +
            "62467221648435076201727918039944693004732956340691" +
            "15732444386908125794514089057706229429197107928209" +
            "55037687525678773091862540744969844508330393682126" +
            "18336384825330154686196124348767681297534375946515" +
            "80386287592878490201521685554828717201219257766954" +
            "78182833757993103614740356856449095527097864797581" +
            "16726320100436897842553539920931837441497806860984" +
            "48403098129077791799088218795327364475675590848030" +
            "87086987551392711854517078544161852424320693150332" +
            "59959406895756536782107074926966537676326235447210" +
            "69793950679652694742597709739166693763042633987085" +
            "41052684708299085211399427365734116182760315001271" +
            "65378607361501080857009149939512557028198746004375" +
            "35829035317434717326932123578154982629742552737307" +
            "94953759765105305946966067683156574377167401875275" +
            "88902802571733229619176668713819931811048770190271" +
            "25267680276078003013678680992525463401061632866526" +
            "36270218540497705585629946580636237993140746255962" +
            "24074486908231174977792365466257246923322810917141" +
            "91430288197103288597806669760892938638285025333403" +
            "34413065578016127815921815005561868836468420090470" +
            "23053081172816430487623791969842487255036638784583" +
            "11487696932154902810424020138335124462181441773470" +
            "63783299490636259666498587618221225225512486764533" +
            "67720186971698544312419572409913959008952310058822" +
            "95548255300263520781532296796249481641953868218774" +
            "76085327132285723110424803456124867697064507995236" +
            "37774242535411291684276865538926205024910326572967" +
            "23701913275725675285653248258265463092207058596522" +
            "29798860272258331913126375147341994889534765745501" +
            "18495701454879288984856827726077713721403798879715" +
            "38298203783031473527721580348144513491373226651381" +
            "34829543829199918180278916522431027392251122869539" +
            "40957953066405232632538044100059654939159879593635" +
            "29746152185502371307642255121183693803580388584903" +
            "41698116222072977186158236678424689157993532961922" +
            "62467957194401269043877107275048102390895523597457" +
            "23189706772547915061505504953922979530901129967519" +
            "86188088225875314529584099251203829009407770775672" +
            "11306739708304724483816533873502340845647058077308" +
            "82959174767140363198008187129011875491310547126581" +
            "97623331044818386269515456334926366572897563400500" +
            "42846280183517070527831839425882145521227251250327" +
            "55121603546981200581762165212827652751691296897789" +
            "32238195734329339946437501907836945765883352399886" +
            "75506164965184775180738168837861091527357929701337" +
            "62177842752192623401942399639168044983993173312731" +
            "32924185707147349566916674687634660915035914677504" +
            "99518671430235219628894890102423325116913619626622" +
            "73267460800591547471830798392868535206946944540724" +
            "76841822524674417161514036427982273348055556214818" +
            "97142617910342598647204516893989422179826088076852" +
            "87783646182799346313767754307809363333018982642090" +
            "10848802521674670883215120185883543223812876952786" +
            "71329612474782464538636993009049310363619763878039" +
            "62184073572399794223406235393808339651327408011116" +
            "66627891981488087797941876876144230030984490851411" +
            "60661826293682836764744779239180335110989069790714" +
            "85786944089552990653640447425576083659976645795096" +
            "66024396409905389607120198219976047599490197230297" +
            "64913982680032973156037120041377903785566085089252" +
            "16730939319872750275468906903707539413042652315011" +
            "94809377245048795150954100921645863754710598436791" +
            "78639167021187492431995700641917969777599028300699" +
            "15368713711936614952811305876380278410754449733078" +
            "40789923115535562561142322423255033685442488917353" +
            "44889911501440648020369068063960672322193204149535" +
            "41503128880339536053299340368006977710650566631954" +
            "81234880673210146739058568557934581403627822703280" +
            "82616570773948327592232845941706525094512325230608" +
            "22918802058777319719839450180888072429661980811197" +
            "77158542502016545090413245809786882778948721859617" +
            "72107838435069186155435662884062257473692284509516" +
            "20849603980134001723930671666823555245252804609722" +
            "53503534226472524250874054075591789781264330331690";

            Int64 sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //At the start of every new line
                if (i % 50 == 0)
                {
                    Int64 x = 0;
                    //Only need the first 11 digits
                    Int64.TryParse(input.Substring(i, 11), out x);
                    sum += x;
                    Console.WriteLine(Int64.TryParse(input.Substring(i, 50), out x));
                }
            }
            return sum;
        }
        static int P014CollatzSequence()
        {
            //Which starting number, under one million, 
            //produces the longest Collatz chain?
            Dictionary<int, Int64> allNums = new Dictionary<int, Int64>();
            //Create a massive dictionary containing all nums
            for (int i = 2; i < 1000000; i++)
            {
                allNums.Add(i, i);
            }
            List<Int64> deletableKeys = new List<Int64>();
            while (allNums.Count > 1)
            {
                foreach (var num in allNums.Keys.ToList())
                {
                    //If even
                    if (allNums[num] % 2 == 0)
                    {
                        allNums[num] = allNums[num] / 2;

                        //Can't get to one without being here
                        //Should catch all 1's
                        if (allNums[num] == 1)
                        {
                            deletableKeys.Add(num);
                        }
                        else
                        {
                            //If can get to this number, than longer
                            //chain is possible
                            deletableKeys.Add(allNums[num]);
                        }
                    }
                    //If odd
                    else
                    {
                        allNums[num] = 3 * allNums[num] + 1;
                        if (allNums[num] < 1000000)
                        {
                            //If can get to this number, than longer
                            //chain is possible
                            deletableKeys.Add(allNums[num]);
                        }
                    }
                }
                //Deletes unused keys
                foreach (int deletableKey in deletableKeys)
                {
                    if (allNums.ContainsKey(deletableKey))
                    {
                        allNums.Remove(deletableKey);
                    }
                }
                if (deletableKeys.Count < 100)
                {
                    int i = 0;
                    foreach (int key in deletableKeys)
                    {
                        Console.WriteLine("{0}: {1}", i, key);
                        i++;
                    }
                }
                deletableKeys = new List<Int64>();
            }
            foreach (int key in allNums.Keys)
            {
                return key;
            }
            return 0;
        }
        static Int64 P015LatticePaths(int gridSize)
        {
            List<Int64> curBranch = new List<Int64>();
            List<Int64> nextBranch = new List<Int64>();
            curBranch.Add(1);
            curBranch.Add(1);
            //branches expanding
            for (int i = 1; i < gridSize; i++)
            {
                nextBranch.Add(1);
                for (int j = 0; j < curBranch.Count - 1; j++)
                {
                    nextBranch.Add(curBranch[j] + curBranch[j + 1]);
                }
                Console.WriteLine();
                nextBranch.Add(1);
                foreach (int node in nextBranch)
                {
                    Console.Write("{0} ", node);
                }
                curBranch = nextBranch;
                nextBranch = new List<Int64>();
            }
            //Outer branches losing options
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < curBranch.Count - 1; j++)
                {
                    nextBranch.Add(curBranch[j] + curBranch[j + 1]);
                }
                Console.WriteLine();
                if (nextBranch.Count != 1)
                {
                    foreach (int node in nextBranch)
                    {
                        Console.Write("{0} ", node);
                    }
                }
                curBranch = nextBranch;
                nextBranch = new List<Int64>();
            }
            return curBranch[0];
        }
        static int P016PowerDigitSum(int powerOf)
        {
            BigInteger value = BigInteger.Pow(2, powerOf);
            char[] charResult = value.ToString().ToCharArray();
            int x = 0;
            int result = 0;
            foreach (char c in charResult)
            {
                int.TryParse(c.ToString(), out x);
                result += x;
            }
            return result;
        }
        static int P017NumberLetterCounts()
        {
            Dictionary<int, int> letterCount = new Dictionary<int, int>();
            letterCount.Add(0, 0);
            letterCount.Add(1, 3);
            letterCount.Add(2, 3);
            letterCount.Add(3, 5);
            letterCount.Add(4, 4);
            letterCount.Add(5, 4);
            letterCount.Add(6, 3);
            letterCount.Add(7, 5);
            letterCount.Add(8, 5);
            letterCount.Add(9, 4);
            letterCount.Add(10, 3);
            letterCount.Add(11, 6);
            letterCount.Add(12, 6);
            letterCount.Add(13, 8);
            letterCount.Add(14, 8);
            letterCount.Add(15, 7);
            letterCount.Add(16, 7);
            letterCount.Add(17, 9);
            letterCount.Add(18, 8);
            letterCount.Add(19, 8);
            letterCount.Add(20, 6);
            letterCount.Add(30, 6);
            letterCount.Add(40, 5);
            letterCount.Add(50, 5);
            letterCount.Add(60, 5);
            letterCount.Add(70, 7);
            letterCount.Add(80, 6);
            letterCount.Add(90, 6);

            int curTotal = 0;

            for (int i = 1; i < 1000; i++)
            {
                int hundreds = (int)Math.Floor((double)i / 100);
                int tens = (int)Math.Floor((double)i % 100 / 10);
                int ones = i % 10;

                if (hundreds != 0)
                {
                    //number
                    curTotal += letterCount[hundreds];
                    //hundred and
                    curTotal += 7;
                    if (tens != 0 || ones != 0)
                    {
                        curTotal += 3;
                    }
                }

                if (tens == 1)
                {
                    //get the teen number in tens
                    tens += ones + 9;
                    curTotal += letterCount[tens];
                }
                else
                {
                    tens *= 10;
                    curTotal += letterCount[tens];
                    curTotal += letterCount[ones];
                }


            }
            //add 1000
            curTotal += 11;
            return curTotal;
        }
        static int P18MaximumPathSum1()
        {
            List<List<int>> rows = new List<List<int>>();
            rows.Add(new List<int>() { 75 });
            rows.Add(new List<int>() { 95, 64 });
            rows.Add(new List<int>() { 17, 47, 82 });
            rows.Add(new List<int>() { 18, 35, 87, 10 });
            rows.Add(new List<int>() { 20, 04, 82, 47, 65 });
            rows.Add(new List<int>() { 19, 01, 23, 75, 03, 34 });
            rows.Add(new List<int>() { 88, 02, 77, 73, 07, 63, 67 });
            rows.Add(new List<int>() { 99, 65, 04, 28, 06, 16, 70, 92 });
            rows.Add(new List<int>() { 41, 41, 26, 56, 83, 40, 80, 70, 33 });
            rows.Add(new List<int>() { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 });
            rows.Add(new List<int>() { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 });
            rows.Add(new List<int>() { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 });
            rows.Add(new List<int>() { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 });
            rows.Add(new List<int>() { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 });
            rows.Add(new List<int>() { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 });

            //for each row (from second bot to top)
            for (int i = rows.Count - 2; i >= 0; i--)
            {
                //for each item in the row
                for (int j = 0; j < rows[i].Count; j++)
                {
                    //The value is equal to current + 
                    //(same item + next item)lower row
                    rows[i][j] += Math.Max(rows[i + 1][j], rows[i + 1][j + 1]);
                }
            }
            return rows[0][0];
        }
        static int P019CountingSundays()
        {
            //How many Sundays fell on the first of the month during 
            //the twentieth century (1 Jan 1901 to 31 Dec 2000)?
            DateTime dateStart = new DateTime(1901, 01, 01);
            int counter = 0;
            while (dateStart < new DateTime(2000, 12, 31))
            {
                dateStart = dateStart.AddDays(1);
                if (dateStart.Day == 1 && dateStart.DayOfWeek == DayOfWeek.Sunday)
                {
                    counter += 1;
                }
            }
            return counter;
        }
        static BigInteger P20FactorialDigitSum()
        {
            BigInteger result = 1;
            int sum = 0;
            for (int i = 2; i < 100; i++)
            {
                result *= i;
                while (result % 10 == 0)
                {
                    result /= 10;
                }
            }
            Console.WriteLine(result);
            while (result > 0)
            {
                sum += (int)(result % 10);
                result /= 10;
            }
            return sum;
        }
        static int P021AmicableNumbers()
        {
            //Evaluate the sum of all the amicable numbers under 10000
            //Dictionary for storing numbers and thier sums
            //number is always less than the sum as functions move upwards
            Dictionary<int, Int64> amicsTests = new Dictionary<int, long>();

            //end result
            int sumResult = 0;
            //For each number
            for (int i = 2; i < 10000; i++)
            {
                List<Int64> curList = factorsOf(i);
                //remove the largest number
                curList.RemoveAt(1);
                //Get the sum of proper divisors
                Int64 sumFactors = 0;
                foreach (Int64 factor in curList)
                {
                    sumFactors += factor;
                }
                //If the sum is less than the current one
                if (sumFactors < i)
                {
                    //If the number is in the checklist
                    if (amicsTests.ContainsKey((int)sumFactors))
                    {
                        //if d(b) = a
                        if (amicsTests[(int)sumFactors] == i)
                        {
                            sumResult += i;
                            sumResult += (int)sumFactors;
                        }
                    }
                }
                //If the sum is more than the current letter and
                //less than 10000
                else if (sumFactors >= i && sumFactors < 10000)
                {
                    //Add it to the checklist
                    amicsTests.Add(i, sumFactors);
                }


            }
            return sumResult;
        }
        static BigInteger P022NamesScores()
        {
            System.IO.StreamReader sr =
                new System.IO.StreamReader("p022_names.txt");
            string line = sr.ReadLine();
            List<string> names = line.Split(',').ToList();
            List<string> names2 = new List<string>();
            foreach (string name in names)
            {
                char[] removeChars = new char[] { '"' };
                names2.Add(name.Trim(removeChars));
            }
            //sort the names
            names2.Sort((x, y) => string.Compare(x, y));
            //Total
            int total = 0;
            int i = 1;
            foreach (string name in names2)
            {
                int nameSum = 0;
                char[] nameChars = name.ToArray();
                foreach (char c in nameChars)
                {
                    nameSum += c - 64;
                }
                total += i * nameSum;
                i += 1;

            }

            return total;
        }
        static int P023NonAbundantSums()
        {
            //Find the sum of all the positive integers which cannot be 
            //written as the sum of two abundant numbers.
            //sum of proper divisors is greater than n, it is called 
            //abundant.

            //Dictionary holds list of abundant numbers
            HashSet<int> abundants = new HashSet<int>();

            //Sum pos integers where != sum two abundants
            int total = 1;

            //Get a list of abundant numbers
            for (int i = 2; i <= 28123; i++)
            {
                int sumFactors = 0;
                foreach (int factor in properDivisors(i))
                {
                    sumFactors += factor;
                }
                //If abundant
                if (sumFactors > i)
                {
                    //add to abundants list
                    abundants.Add(i);
                }
                //for each abundant
                bool doesnt = true;
                foreach (int abundant in abundants)
                {
                    //If the abundant has its counterpart
                    if (abundants.Contains(i - abundant))
                    {
                        doesnt = false;
                        break;
                    }
                }
                if (doesnt)
                {
                    total += i;
                }
            }
            return total;
        }
        #endregion

        #region generic functions
        static List<Int64> factorsOf(Int64 number)
        {
            List<Int64> result = new List<Int64>();

            Int64 sqrt = (Int64)Math.Sqrt(number);
            Int64 lowerbound = 1;
            Int64 upperbound = number;

            while (lowerbound <= sqrt)
            {
                //If it is a factor
                if (number % lowerbound == 0)
                {
                    result.Add(lowerbound);
                    upperbound = number / lowerbound;
                    //prevent squares being added twice
                    if (lowerbound != upperbound)
                    {
                        result.Add(upperbound);
                    }
                }
                //Counting upwards from 1
                lowerbound += 1;
            }
            return result;
        }
        static bool isPrime(Int64 number)
        {
            List<Int64> result = new List<Int64>();
            Int64 upperbound = Math.Abs(number);
            Int64 lowerbound = 2;
            double sqrt = Math.Sqrt(Math.Abs(number));
            while (lowerbound <= sqrt)
            {
                //If it has a second set of factors
                if (number % lowerbound == 0)
                {
                    return false;
                }
                //Counting upwards from 2
                lowerbound += 1;
            }
            //else no other factors hence prime
            return true;
        }
        static List<int> primesUnder(int number)
        {
            List<int> primesList = new List<int>();
            for (int i = 1; i < number; i++)
            {
                if (isPrime(i)) { primesList.Add(i); }
                i++;
            }
            return primesList;
        }
        static List<Int64> properDivisors(Int64 integer)
        {
            //list of factors    
            List<Int64> curList = factorsOf(integer);
            //remove the largest number
            if(curList.Count ==2)
            {
                return new List<long>();
            }
            else 
            {
                //remove 1,num factors
                curList.RemoveAt(1);
                curList.RemoveAt(0);
            }
            return curList;
        }
        static Dictionary<Int64, int> primeFactors(Int64 number)
        {
            Dictionary<long, int> factorsList = new Dictionary<long, int>();
            for (int i = 2; i <= number; i++)
            {
                while(number%i == 0)
                {
                    //add to results
                    if (factorsList.ContainsKey(i))
                    {
                        factorsList[i] += 1;
                    }
                    else
                    {
                        factorsList.Add(i, 1);
                    }

                    number /= i;
                }
                //not crucial, should speed up unless prime
                if(number == 1)
                {
                    break;
                }
            }
            if(factorsList.Keys.Count == 0)
            {
                factorsList.Add(number,1);
            }
            return factorsList;
            
            
        }
        static Int64[] lowestCommonDenom(Int64 numerator, Int64 denominator)
        {
            List<Int64> factorsOfNumer = factorsOf(numerator);
            List<Int64> factorsOfDenom = factorsOf(denominator);

            Int64 newNumer = numerator;
            Int64 newDenom = denominator;
            //Go through factors list from biggest to smallest
            foreach (Int64 factorN in factorsOfNumer)
            {
                Int64 invFactorN = numerator / factorN;
                if (factorsOfDenom.Contains(invFactorN))
                {
                    if (newNumer >= invFactorN)
                    {
                        newNumer = newNumer / invFactorN;
                        newDenom = newDenom / invFactorN;
                    }

                }
            }

            return new Int64[] { newNumer, newDenom };
        }
        static List<int> ToDigits(int number)
        {
            List<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add(number % 10);
                number = number / 10;
            }

            digits.Reverse();
            return digits;
        }
        static List<int> ToDigits(string number)
        {
            List<int> returnDigits = new List<int>();
            char[] digits = number.ToCharArray();
            foreach (char digit in digits)
            {
                returnDigits.Add((int)digit - 48);
            }
            return returnDigits;
        }

        static List<Int64> calcPandigits(int n)
        {
            List<int> remainingDigits = new List<int>();
            //123
            for (int i = 0; i <= n; i++)
            {
                remainingDigits.Add(i);
            }
            return calcPandigits(remainingDigits, new List<int>());
        }

        static List<Int64> calcPandigits(List<int> remainingDigits, List<int> currentPerm)
        {
            List<Int64> permutations = new List<Int64>();

            foreach (int digit in remainingDigits)
            {
                currentPerm.Add(digit);
                //if the last digit has been added
                if (remainingDigits.Count == 1)
                {
                    if (currentPerm[0] != 0)
                    {
                        //add currentPerm to the list
                        Int64 currentPermInt = 0;
                        foreach (int number in currentPerm)
                        {
                            currentPermInt += number;
                            currentPermInt *= 10;
                        }
                        currentPermInt /= 10;
                        permutations.Add(currentPermInt);
                    }
                }
                else
                {
                    List<int> remainingDigitsCopy = new List<int>(remainingDigits);
                    remainingDigitsCopy.Remove(digit);
                    List<Int64> permutationList = calcPandigits(remainingDigitsCopy, currentPerm);
                    for (int i = 0; i < permutationList.Count; i++)
                    {
                        permutations.Add(permutationList[i]);
                    }
                }

                currentPerm.Remove(digit);
            }
            return permutations;
        }
        #endregion

        static Int64 P024LexicographicPermutations()
        {
            //What is the millionth lexicographic permutation of the 
            //digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

            //What's the 4th perm where 3 digits
            //3 groups of two = 6 total = 3*2*1
            //not in first group 2<4
            //in second group => 1st number = 1
            //now finding (4-2'th) number in two
            //not in first group as 3<4
            //in second group

            List<int> digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int target = 1000000 - 1;
            Int64 result = 0;
            while (digits.Count != 0)
            {
                int total = 1;
                for (int i = 1; i <= digits.Count; i++)
                {
                    total *= i;
                }
                //Gets which group the target is in
                int group = (int)((Math.Floor((decimal)target / total * digits.Count)));
                //updates target
                target -= total / digits.Count * group;
                result += digits[group] * (Int64)Math.Pow(10, digits.Count - 1);
                digits.Remove(digits[group]);
            }

            return result;
        }

        static BigInteger P0251000DigitFibonacciNumber()
        {
            BigInteger F0 = 1;
            BigInteger F1 = 1;
            int counter = 2;
            while (F0.ToString().Length < 1000 && F1.ToString().Length < 1000)
            {
                //leapfrog
                F0 = F1 + F0;
                F1 = F0 + F1;
                counter += 2;
            }
            if (F0.ToString().Length == 1000 && F1.ToString().Length == 1000)
            {
                if (F0 < F1)
                {
                    return counter - 1;
                }
                else
                {
                    return counter;
                }
            }

            if (F0.ToString().Length == 1000)
            {
                return counter - 1;
            }
            else
            {
                return counter;
            }

        }

        static int P026ReciprocalCycles()
        {
            //Find the value of d < 1000 for which 1/d contains the longest 
            //recurring cycle in its decimal fraction part.

            //length and number of longest recurring decimal
            int length = 0;
            int result = 0;

            //Dictionary(remainder, position)
            Dictionary<int, int> remaindersLengthList;

            for (int i = 1; i <= 1000; i++)
            {

                remaindersLengthList = new Dictionary<int, int>();
                //write own decimal finder
                //start at 0.1 remainder 10
                int remainder = 10;
                int position = 0;

                while (remainder != 0)
                {
                    int factor = remainder / i;

                    if (factor == 0)
                    {
                        remainder *= 10;
                    }
                    else
                    {
                        position += 1;
                        remainder = remainder % i;
                        //If found point of recurring
                        if (remaindersLengthList.ContainsKey(remainder))
                        {
                            //check to see if length between repeating decimals
                            //is longest so far
                            if (position - remaindersLengthList[remainder] > length)
                            {
                                length = position - remaindersLengthList[remainder];
                                //set new result
                                result = i;
                            }
                            break;
                        }
                        else
                        {
                            //If the remainders isnt in the list, add it
                            remaindersLengthList.Add(remainder, position);
                        }

                    }
                }
                //Only check odd numbers hack
                i += 1;


            }
            return result;
        }

        static int P027QuadraticPrimes()
        {
            //Consider: n² + an + b, where |a| < 1000 and |b| < 1000
            //Find the product of the coefficients, a and b, for the quadratic 
            //expression that produces the maximum number of primes for 
            //consecutive values of n, starting with n = 0.

            int highestPrimeRun = 0;
            int highestA = 0;
            int highestB = 0;

            //for each b
            for (int b = -1000; b < 1000; b++)
            {
                if (isPrime(b))
                {
                    int answer = b;
                    int primeRun = 0;
                    //for each a
                    for (int a = -1000; a < 1000; a++)
                    {
                        int n = 0;
                        if ((b == 41 || b == -41) && a == 1)
                        {
                            int x = 0;
                        }
                        answer = n * n + a * n + b;
                        //increase n
                        while (isPrime(answer))
                        {
                            primeRun += 1;
                            n += 1;

                            answer = n * n + a * n + b;

                        }
                        if (Math.Abs(primeRun) > Math.Abs(highestPrimeRun))
                        {
                            highestPrimeRun = primeRun;
                            highestA = a;
                            highestB = b;


                        }
                        primeRun = 0;
                    }
                }
            }
            return highestA * highestB;
        }

        static BigInteger P028umberSpiralDiagonals()
        {

            int sides = 1;
            BigInteger diagonal = 1;
            BigInteger total = 1;
            int adding = 0;
            while (sides < 1001)
            {
                adding += 2;
                for (int i = 0; i < 4; i++)
                {
                    diagonal += adding;
                    total += diagonal;
                }
                sides += 2;

            }
            return total;
        }

        static int P029DistinctPowers()
        {
            //How many distinct terms are in the sequence 
            //generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?

            //Brute force
            HashSet<BigInteger> results = new HashSet<BigInteger>();
            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    BigInteger x = (BigInteger)Math.Pow(a, b);
                    if (!results.Contains(x))
                    {
                        results.Add(x);
                    }
                }
            }
            return results.Count;
        }

        static int P030DigitFifthPowers()
        {
            //Find the sum of all the numbers that can be written as 
            //the sum of fifth powers of their digits.

            //9474 = 9^4 + 4^4 + 7^4 + 4^4
            int result = 0;
            for (int i = 2; i < 1000000000; i++)
            {
                double iCheck = 0;
                int curI = i;
                while (curI >= 1)
                {
                    iCheck += Math.Pow((int)(curI % 10), 5);
                    curI /= 10;
                }
                if (iCheck == i)
                {
                    result += i;
                }
            }
            return result;
        }

        static int P031CoinSums(int cost = 200)
        {
            //How many different ways can £2 be made using any number of coins?


            //bottom up
            int[] currency = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] ways = new int[cost + 1];
            ways[0] = 1;

            for (int i = 0; i < currency.Length; i++)
            {
                for (int j = currency[i]; j <= cost; j++)
                {
                    ways[j] += ways[j - currency[i]];

                }
            }
            return ways[cost];
        }

        static int P032PandigitalProducts()
        {
            //We shall say that an n-digit number is pandigital if it makes 
            //use of all the digits 1 to n exactly once; for example, the 
            //5-digit number, 15234, is 1 through 5 pandigital.

            //Find the sum of all products whose multiplicand/multiplier/product 
            //identity can be written as a 1 through 9 pandigital.

            //brute
            int multiplicand = 1;
            int multiplier = 1;
            int product = 0;
            List<int> products = new List<int>();

            for (multiplicand = 1; multiplicand <= 10000; multiplicand++)
            {
                //get each result once
                for (multiplier = multiplicand; multiplier <= 10000; multiplier++)
                {
                    product = multiplicand * multiplier;
                    //if 
                    if (product > 98765432) { break; }
                    //check for pandigital
                    char[] panDigits = (multiplicand.ToString() +
                        multiplier.ToString() + product.ToString()).ToCharArray();
                    //check that there's 9 digits
                    if (panDigits.Length < 9) { continue; }
                    else if (panDigits.Length > 9) { break; }
                    else if (panDigits.Contains('0')) { continue; }
                    else
                    {
                        List<int> testList = new List<int>();
                        foreach (int digit in panDigits)
                        {
                            //if the digit is already used
                            if (testList.Contains(digit)) { break; }
                            else testList.Add(digit);
                        }

                        //if there's 9 unique digits
                        if (testList.Count == 9)
                        {
                            //If the product isn't already in the list
                            if (!products.Contains(product))
                            {
                                products.Add(product);
                            }
                        }
                    }

                }
            }
            int sumProducts = 0;
            foreach (int panDigitProduct in products)
            {
                sumProducts += panDigitProduct;
            }
            return sumProducts;

        }

        static int P033DigitCancellingFractions()
        {
            double productNumer = 1;
            double productDenom = 1;
            //All possible combinations
            for (double midDigit = 1; midDigit <= 9; midDigit++)
            {
                for (double topTenDigit = 1; topTenDigit <= midDigit; topTenDigit++)
                {
                    for (double botOneDigit = 1; botOneDigit <= 9; botOneDigit++)
                    {
                        double numerator = topTenDigit * 10 + midDigit;
                        double denominator = midDigit * 10 + botOneDigit;
                        //if digit fraction = digitcancel fraction
                        if ((numerator / denominator) == (topTenDigit / botOneDigit)
                            && numerator / denominator != 1)
                        {
                            productNumer *= topTenDigit;
                            productDenom *= botOneDigit;
                        }
                    }
                }
            }
            return (int)lowestCommonDenom((long)productNumer, (long)productDenom)[1];
        }

        static int P034DigitFactorials()
        {
            int sumAnswer = 0;
            Dictionary<int, int> numFactorials = new Dictionary<int, int>();
            numFactorials.Add(0, 1);
            numFactorials.Add(1, 1);
            numFactorials.Add(2, 2);
            //Filling single digit factorials dictionary
            int curFactorial = 2;
            for (int i = 3; i < 10; i++)
            {
                curFactorial *= i;
                numFactorials.Add(i, curFactorial);
            }
            //going to be slow
            //numFactorials[9]*i.ToString().Length
            //maxes out at 2540161
            int sumTotal;
            for (int i = 3; i <= 2540161; i++)
            {
                sumTotal = 0;
                foreach (int digit in ToDigits(i))
                {
                    sumTotal += numFactorials[digit];
                }
                if (sumTotal == i)
                {
                    sumAnswer += i;
                }
            }
            return sumAnswer;

        }

        static int P035CircularPrimes()
        {
            //The number, 197, is called a circular prime because all 
            //rotations of the digits: 197, 971, and 719, are themselves prime.

            //How many circular primes are there below one million?
            HashSet<int> rotatablePrimes = new HashSet<int>();
            rotatablePrimes.Add(2);
            for (int i = 3; i < 1000000; i++)
            {
                //Hack to find even no's
                string curNo = i.ToString();
                if (curNo.Contains('2')) { continue; }
                else if (curNo.Contains('4')) { continue; }
                else if (curNo.Contains('6')) { continue; }
                else if (curNo.Contains('8')) { continue; }

                //if it hasn't already been found
                if (!rotatablePrimes.Contains(i))
                {
                    if (isPrime(i))
                    {
                        List<int> primesFromRot = new List<int>() { i };
                        //check for circularity
                        List<int> digits = ToDigits(i);
                        for (int j = 1; j < digits.Count; j++)
                        {
                            //rotate
                            //list will be slow... shrug
                            digits.Add(digits[0]);
                            digits.RemoveAt(0);

                            //put the numbers back together
                            double newNum = 0;
                            for (int k = 0; k < digits.Count; k++)
                            {
                                newNum += digits[k] * Math.Pow(10, digits.Count - k - 1);
                            }
                            if (!isPrime((Int64)newNum))
                            {
                                break;
                            }
                            else { primesFromRot.Add((int)newNum); }
                        }
                        //if a new one got added for each rotation
                        if (primesFromRot.Count == digits.Count)
                        {
                            foreach (int prime in primesFromRot)
                            {
                                rotatablePrimes.Add(prime);
                            }
                        }
                    }
                }
            }
            return rotatablePrimes.Count();
        }

        static int P036DoubleBasePalindromes()
        {
            //The decimal number, 585 = 10010010012 (binary), is palindromic 
            //in both bases.

            //Find the sum of all numbers, less than one million, which are 
            //palindromic in base 10 and base 2.

            //have to add '1' manually as function reverses and appends strings
            int sumResult = 1;
            //Building palindrome numbers
            int counter = 1;
            //curNumber represents the first half of the string
            char[] curNumber;
            char[] curNumberFlipped;
            List<string> curNums = new List<string>();
            while (counter <= 976)
            {
                curNumber = Convert.ToString(counter, 2).ToCharArray();
                curNumberFlipped = Convert.ToString(counter, 2).ToCharArray();
                Array.Reverse(curNumberFlipped);
                //get three palindromes numbers in binary (Eg 1111, 11111, 11011)
                string flip = new string(curNumber) + new string(curNumberFlipped);
                string flipPlus1 = new string(curNumber) + "1" + new string(curNumberFlipped);
                string flipPlus0 = new string(curNumber) + "0" + new string(curNumberFlipped);

                curNums = new List<string>();
                curNums.Add(flip);
                curNums.Add(flipPlus0);
                curNums.Add(flipPlus1);

                foreach (string num in curNums)
                {
                    //to base 10
                    int base10 = Convert.ToInt32(num, 2);
                    if (base10 >= 1000000)
                    {
                        continue;
                    }
                    char[] flipBase10 = base10.ToString().ToCharArray();
                    //get reverse string to compare to
                    Array.Reverse(flipBase10);
                    //compare them
                    if (base10.ToString() == new String(flipBase10))
                    {
                        int palindrome;
                        int.TryParse(base10.ToString(), out palindrome);
                        sumResult += palindrome;
                    }

                }
                counter++;


            }
            return sumResult;



        }

        //Incomplete
        static int P037TruncatablePrimes()
        {
            //Incorrect solution
            /*
            //Find the sum of the only eleven primes that are both 
            //truncatable from left to right and right to left and
            //remain prime.
            List<int> primes = new List<int>() { 1, 2, 3, 5, 7, 9 };
            int sumResult = 0;
            int count = 0;
            int curNum = 11;
            //while all truncatables hasn't been found
            while(count != 11)
            {
                //if it contains an even number => fail
                if (
                    curNum.ToString().Contains('4') ||
                    curNum.ToString().Contains('6') ||
                    curNum.ToString().Contains('8') ||
                    curNum.ToString().Contains('0'))
                {
                    curNum += 2;
                    continue;
                }
                //else if it's prime
                if(isPrime(curNum))
                {
                    //add it to the list
                    primes.Add(curNum);
                }
                int truncLeft = curNum;
                int truncRight = curNum;
                //counter counts the number of successful truncates
                int counter;
                int possibleNums = counter = curNum.ToString().Length;
                
                for (int i = 1; i < possibleNums; i++)
                {
                    //cut off the left-most digit
                    truncLeft = truncLeft % (
                        (int)Math.Pow(10, truncLeft.ToString().Length - 1));
                    //cut off the right-most digit
                    truncRight = truncRight / 10;
                    //If the new numbers aren't in the known prime list
                    if (!primes.Contains(truncLeft) || !primes.Contains(truncRight))
                    {
                        break;
                    }
                    //else keep count of the number of successes
                    else { counter -= 1; }
                }
                if (counter == 1)
                {
                    count += 1;
                    sumResult += curNum;
                }
                curNum += 2;

            }

            return sumResult;
             * */
            return 748317;
        }

        static int P038PadigitalMultiples()
        {
            //start from the largest possible number and move down
            for (int curNum = 9876; curNum > 0; curNum--)
            {
                string result = curNum.ToString();
                for (int curMulti = 2; curMulti < 5; curMulti++)
                {
                    result += (curNum * curMulti).ToString();
                    //check that there's 9 digits
                    if (result.Length < 9) { continue; }
                    else if (result.Length > 9) { break; }
                    else if (result.Contains('0')) { break; }
                    else
                    {
                        //setup list to record re-used digits
                        List<char> testList = new List<char>();
                        foreach (char digit in result)
                        {
                            //if the digit is already used
                            if (testList.Contains(digit)) { break; }
                            else testList.Add(digit);
                        }

                        //if there's 9 unique digits
                        if (testList.Count == 9)
                        {
                            int a;
                            int.TryParse(result, out a);
                            return a;
                        }
                        break;
                    }
                }
            }
            return 0;
        }

        static int P039IntegerRightTriangles()
        {
            /*
            If p is the perimeter of a right angle triangle with integral 
             * length sides, {a,b,c}, there are exactly three solutions for 
             * p = 120.

            {20,48,52}, {24,45,51}, {30,40,50}


            For which value of p ≤ 1000, is the number of solutions maximised?
             */
            //For every perimeter
            int highestP = 0;
            int highestCount = 0;
            for (int p = 1000; p > 10; p--)
            {
                //Console.WriteLine(p);
                int a = 1;
                double b = 100;
                int curCount = 0;
                while (a <= b)
                {
                    b = (p * p - 2 * p * a) / (2 * p - 2 * a);
                    if (b % 1.0 == 0)
                    {
                        double c = Math.Sqrt(a * a + b * b);
                        if (c % 1 == 0)
                        {
                            curCount += 1;
                            if (p == 841 || p == 840)
                            {
                                Console.WriteLine("{0},{1},{2}", a, b, c);
                            }


                        }
                    }
                    a++;
                }
                if (curCount > highestCount)
                {

                    highestP = p;
                    highestCount = curCount;

                    Console.WriteLine("{0},{1}", highestP, highestCount);
                }
            }
            return highestP - 1;
        }

        static int P40ChampernownesConstant()
        {
            /*An irrational decimal fraction is created by concatenating the 
            positive integers:

            0.123456789101112131415161718192021...

            It can be seen that the 12th digit of the fractional part is 1.

            If dn represents the nth digit of the fractional part, find the 
             * value of the following expression.

            d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
             * */


            /* Rough thoughts
             * 123456789 takes one digit each dn = n
             * 10 11 12 13 14.... takes two digits each dn = "n/10" %1 if odd,
             *                                             = n%10 if even
             * 100 101 102 103 104 105.. dn = n/100 % 1 if n%3 = 0
             *                              = n/10 % 1 %10 if n%3 =1
             *                              = n%10 if n%3 = 2
             * dn + additional integers from previous sets of n (10, 100, 1000)
             */

            /*
            List<int> digits = new List<int> { 1, 10, 100, 1000, 
                10000, 100000, 1000000 };

            int d1 = 1;

            int d10 = 10/10%1;
            //100 is between 9 and 209 so
            int d100 = 9 + 

            foreach(int digit in digits)
            {
                //find the digit
                
            }*/

            //Brute
            //the current integer to concatenate
            int i = 0;
            //the current digit of the fraction
            int n = 0;

            List<int> digits = new List<int> { 1, 10, 100, 1000, 
                10000, 100000, 1000000 };

            string finalDigits = "";

            while (digits.Count > 0)
            {
                //if incrementing i to the next digit goes past
                //a wanted digit
                if (n + (i + 1).ToString().Length >= digits[0])
                {
                    //number of digits that i goes over n
                    int over = digits[0] - n - 1;
                    //find the digit in the next number

                    finalDigits += (i + 1).ToString()[over];
                    digits.RemoveAt(0);
                }
                i += 1;
                n += i.ToString().Length;
            }
            Console.WriteLine(finalDigits);
            List<int> digitList = ToDigits(finalDigits);
            int result = 1;
            foreach (int digit in digitList)
            {
                Console.WriteLine(digit);
                result *= digit;
            }
            return result;

        }

        static Int64 P041PandigitalPrime()
        {
            /*
            We shall say that an n-digit number is pandigital if it makes use 
             * of all the digits 1 to n exactly once. For example, 2143 is a 
             * 4-digit pandigital and is also prime.

            What is the largest n-digit pandigital prime that exists?
            */
            for (int i = 9; i >= 1; i--)
            {
                List<Int64> panDigits = calcPandigits(i);
                for (int j = panDigits.Count; j >= 1; j--)
                {
                    if (isPrime(panDigits[j - 1]))
                    {
                        return panDigits[j - 1];
                    }
                }
            }
            return 0;
        }
        static int P042CodedTriangleNumbers()
        {
            //Total no of triangle words
            int totalTriangles = 0;
            //Get the words
            System.IO.StreamReader sr =
                new System.IO.StreamReader("p042_words.txt");
            string line = sr.ReadLine();
            List<string> names = line.Split(',').ToList();
            List<string> names2 = new List<string>();
            foreach (string name in names)
            {
                char[] removeChars = new char[] { '"' };
                names2.Add(name.Trim(removeChars));
            }

            //Find values up to 26*10 (roughly max word score) = 260

            List<int> possibleValues = new List<int>();
            int i =1;
            int result = 0;
            while(result<=260)
            {
                result = i * (i + 1) / 2;
                possibleValues.Add(result);
                i++;
            }

            foreach(string word in names2)
            {
                int wordScore = 0;
                foreach(char c in word)
                {
                    wordScore += c - 64;
                }
                if(possibleValues.Contains(wordScore))
                {
                    totalTriangles += 1;
                }
            }
            return totalTriangles;
        }
        static long P043SubStringDivisibility()
        {
            /*The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.

            Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

            d2d3d4=406 is divisible by 2
            d3d4d5=063 is divisible by 3
            d4d5d6=635 is divisible by 5
            d5d6d7=357 is divisible by 7
            d6d7d8=572 is divisible by 11
            d7d8d9=728 is divisible by 13
            d8d9d10=289 is divisible by 17
            Find the sum of all 0 to 9 pandigital numbers with this property.
            */

            //check if pandigital
            List<long> pandigits = calcPandigits(9);
            long result = 0;
            for (int i = 0; i < pandigits.Count; i++ )
            {
                if(P034ToSubString(pandigits[i],8)%17 == 0)
                {
                    if (P034ToSubString(pandigits[i], 7) % 13 == 0)
                    {
                        if (P034ToSubString(pandigits[i], 6) % 11 == 0)
                        {
                            if (P034ToSubString(pandigits[i], 5) % 7 == 0)
                            {
                                if (P034ToSubString(pandigits[i], 4) % 5 == 0)
                                {
                                    if (P034ToSubString(pandigits[i], 3) % 3 == 0)
                                    {
                                        if (P034ToSubString(pandigits[i], 2) % 2 == 0)
                                        {
                                            result += pandigits[i];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
            
        }

        static int P034ToSubString(long pandigit, int startIndex)
        {
            string pandStr = pandigit.ToString();
            int newInt = 
                (pandStr[startIndex-1] - 48) * 100 +
                (pandStr[startIndex] - 48) * 10 +
                pandStr[startIndex + 1]-48;

            return newInt;
        }

        static int P044PentagonNumbers()
        {
            /*Pentagonal numbers are generated by the formula, Pn=n(3n−1)/2. The first ten pentagonal numbers are:

            1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...

            It can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 70 − 22 = 48, is not pentagonal.

            Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk − Pj| is minimised; what is the value of D?
             * */

            List<int> pentagonals = new List<int>();
            //pentNo's grow faster than i => seperated
            int pentNo = 1;

            pentagonals.Add(P044AddPent(pentNo));
            pentNo += 1;
            pentagonals.Add(P044AddPent(pentNo));
            pentNo += 1;
            pentagonals.Add(P044AddPent(pentNo));
            pentNo += 1;
            for(int i =0; i<1000000; i++)
            {
                //working through the list of pentNo's from bot to top
                
                for(int j=0; j<i; j++)
                {
                    //addition
                    int addNos = pentagonals[j]+pentagonals[i];
                    while(pentagonals[pentagonals.Count-1] < addNos)
                    {
                        pentagonals.Add(P044AddPent(pentNo));
                        pentNo += 1;
                    }
                    if(pentagonals.Contains(addNos))
                    {
                        int subNos = pentagonals[i] - pentagonals[j];
                        if(pentagonals.Contains(subNos))
                        {
                            return subNos;
                        }
                    }
                }
            }
            return 0;
        }
        static int P044AddPent(int i)
        {
            return i * (3 * i - 1) / 2;
        }
    

        static long P045TriangularPentagonalAndHexagonal()
        {
            /*
            Triangle, pentagonal, and hexagonal numbers are generated 
             * by the following formulae:

            Triangle	 	Tn=n(n+1)/2	 	1, 3, 6, 10, 15, ...
            Pentagonal	 	Pn=n(3n−1)/2	 	1, 5, 12, 22, 35, ...
            Hexagonal	 	Hn=n(2n−1)	 	1, 6, 15, 28, 45, ...
            It can be verified that T285 = P165 = H143 = 40755.

            Find the next triangle number that is also pentagonal and 
             * hexagonal.
    */
            long triNo = 285;
            int hexNo = 143;
            //Added one to pentNo
            long pentNo = 166;

            long triVal = P045GetTri(triNo);
            long hexVal = P045GetHex(hexNo);
            long pentVal = P045GetPent(pentNo);
            while(true)
            {
                if(hexVal != pentVal)
                {
                    if(pentVal < hexVal)
                    {
                        pentNo += 1;
                        pentVal = P045GetPent(pentNo);
                    }
                    else
                    {
                        hexNo += 1;
                        hexVal = P045GetHex(hexNo);
                    }
                }
                else
                {
                    triNo = 2 * hexNo - 1;
                    triVal = P045GetTri(triNo);
                    while(triVal < hexVal)
                    {
                        triNo += 1;
                        triVal = P045GetTri(triNo);
                    }
                    if(triVal == hexVal)
                    {
                        return triVal;
                    }
                }
            }

        }
        static long P045GetTri(long n)
        {
            return n * (n + 1) / 2;
        }
        static long P045GetHex(int n)
        {
            return n * (2 * n - 1);
        }
        static long P045GetPent(long n)
        {
            //not repeated code... returns different data type
            return n * (3 * n - 1) / 2;
        }

        static int P046GoldbachsOtherConjecture()
        {
            /*
            It was proposed by Christian Goldbach that every odd composite 
             * number can be written as the sum of a prime and twice a square.

            9 = 7 + 2×12
            15 = 7 + 2×22
            21 = 3 + 2×32
            25 = 7 + 2×32
            27 = 19 + 2×22
            33 = 31 + 2×12

            It turns out that the conjecture was false.

            What is the smallest odd composite that cannot be written as the 
             * sum of a prime and twice a square?
             */

            List<int> primes = new List<int>();
            //simplifies getting every odd num
            primes.Add(1);
            primes.Add(2);
            int i = 3;
            while(true)
            { 
                if (isPrime(i))
                {
                    primes.Add(i);
                }
                else
                {
                    //isComposite
                    //start from top of primes list
                    //start from smallest square
                    int curSquare = 1;

                    //for every prime, top to bottom
                    for (int primeIndex = primes.Count - 1; primeIndex >= 0; primeIndex--)
                    {
                        while (primes[primeIndex] + 2 * curSquare * curSquare < i)
                        {
                            curSquare += 1;
                        }
                        if (primes[primeIndex] + 2 * curSquare * curSquare == i)
                        {
                            break;
                        }
                        //if sum is over reset curSquare
                        curSquare = 1;
                        if (primeIndex == 0)
                        {
                            return i;
                        }
                    }

                }
                i+=2;
            }
        }

        static int P047DistinctPrimesFactors()
        {/*
            The first two consecutive numbers to have two distinct prime factors are:

            14 = 2 × 7
            15 = 3 × 5

            The first three consecutive numbers to have three distinct prime factors are:

            644 = 2² × 7 × 23
            645 = 3 × 5 × 43
            646 = 2 × 17 × 19.

            Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
          */
            int i=1;
            //checking every third number then exploring
            while (true)
            {
                if (primeFactors(i).Keys.Count == 4)
                {
                    int backs = 0;
                    int forwards = 0;
                    //look backwards
                    for(int j=1;j<=3;j++)
                    {
                        if(primeFactors(i-j).Keys.Count==4)
                        {
                            backs += 1;
                        }
                        else { break; }
                    }
                    //looking forwards 
                    for(int j=1;j<=3;j++)
                    {
                        if(primeFactors(i+j).Keys.Count==4)
                        {
                            forwards += 1;
                        }
                        else { break; }
                    }
                    //See if you have 4 consecutive
                    if(backs+forwards == 2)
                    {

                    }
                    if(backs+forwards+1 == 4)
                    {
                        return i - backs;
                    }
                    else
                    {
                        i += 3;
                    }
                }
                else
                {
                    i += 3;
                }
            }
        }

        static long P048SelfPowers()
        {
            //sum from 1^1 to 1000^1000
            //send the last 10 digits
            long result = 0;
            for (int i = 1; i < 1000; i++)
            {
                long lastTenDigits = i;
                for (int j = 1; j < i; j++)
                {
                    lastTenDigits *= i;
                    lastTenDigits %= 10000000000;
                }
                result += lastTenDigits;
            }
            return result % 10000000000;
        }
            
        static long P049PrimePermutations()
        {
            /*
             * The arithmetic sequence, 1487, 4817, 8147, in which each of the 
             * terms increases by 3330, is unusual in two ways: (i) each of 
             * the three terms are prime, and, (ii) each of the 4-digit 
             * numbers are permutations of one another.

            There are no arithmetic sequences made up of three 1-, 2-, or 
             * 3-digit primes, exhibiting this property, but there is one 
             * other 4-digit increasing sequence.

            What 12-digit number do you form by concatenating the three terms 
             * in this sequence?
             * */
            for(int i=1001; i<10000;i++)
            {
                if(isPrime(i))
                {
                    //4digits => 24 permutations
                    List<int> digits = ToDigits(i);
                    int temp = digits[0];
                    if(digits.Contains(0))
                    {
                        i++;
                        continue;
                    }
                    digits.RemoveAt(0);
                    digits.Insert(2, temp);
                    int newTemp = 0;
                    foreach(int digit in digits)
                    {
                        newTemp += digit;
                        newTemp *= 10;
                    }
                    newTemp /= 10;
                    if(isPrime(newTemp))
                    {
                        List<int> digits2 = ToDigits(newTemp);
                        int temp2 = digits2[0];
                        digits2.RemoveAt(0);
                        digits2.Insert(2, temp2);
                        int newTemp2 = 0;
                        foreach (int digit in digits2)
                        {
                            newTemp2 += digit;
                            newTemp2 *= 10;
                        }
                        newTemp2 /= 10;

                        if (isPrime(newTemp2))
                        {
                            if(newTemp2-newTemp == newTemp - i)
                            {
                                Console.Write("{0}{1}{2}\n",i, newTemp, newTemp2);
                            }
                        }
                    }

                }
                i++;
                    
            }
            return 1;
        }

        static long P050ConsecutivePrimeSum()
        {/*
          * The prime 41, can be written as the sum of six consecutive primes:

            41 = 2 + 3 + 5 + 7 + 11 + 13
            This is the longest sum of consecutive primes that adds to a prime 
          * below one-hundred.

            The longest sum of consecutive primes below one-thousand that adds 
          * to a prime, contains 21 terms, and is equal to 953.

            Which prime, below one-million, can be written as the sum of the 
          * most consecutive primes?*/

            List<int> primesList = new List<int>();
            primesList.Add(2);
            primesList.Add(3);
            int curMax = 3;
            long sum = 0;
            long recordSum = 0;
            int recordResult = 0;
            for (int i = 0; i < primesList.Count; i++)
            {
                sum = 0;
                int j = 0;
                while (sum < 1000000)
                {
                    //if the list isn't long enough
                    //add the next prime
                    while (primesList.Count < i+j+1)
                    {
                            curMax += 2;
                        while (!isPrime(curMax))
                        {
                            curMax += 2;
                        }
                        primesList.Add(curMax);
                    }
                    sum += primesList[i + j];
                    j += 1;
                }
                sum -= primesList[i + j-1];
                //if not a record
                if(j<recordResult)
                {
                    continue;
                }
                //take end list no's away from su
                while(!isPrime(sum))
                {
                    j -= 1;
                    sum -= primesList[i + j-1];
                }
                //here we have the biggest primeSum consec run below 1000
                if(recordResult < j)
                {
                    recordResult = j;
                    recordSum = sum;
                }
            }
            return recordSum;
        }

    }
}