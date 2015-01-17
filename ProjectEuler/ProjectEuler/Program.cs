using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BigInteger result = P30DigitFifthPowers();
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

        #region generic
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
        static List<Int64> properDivisors(Int64 integer)
        {
            //list of factors    
            List<Int64> curList = factorsOf(integer);
            //remove the largest number
            curList.RemoveAt(1);
            return curList;
        }
        static Dictionary<Int64, int> primeFactors(Int64 number, Dictionary<Int64, int> current = null)
        {
            if(current == null)
            {
                current = new Dictionary<long, int>();
            }
            List<Int64> factors = properDivisors(number);
            //Hack for square-root numbers
            if(Math.Sqrt(number)%1 == 0)
            {
                factors.Add((int)Math.Sqrt(number));
            }
            foreach(int factor in factors)
            {
                if (isPrime(factor))
                {
                    //add to results
                    if (current.ContainsKey(factor))
                    {
                        current[factor] += 1;
                    }
                    else
                    {
                        current.Add(factor, 1);
                    }
                }
                else
                {
                    //if not prime get factors (recursive)
                    current = primeFactors(factor, current);
                }
            }
            return current;
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

            List<int> digits = new List<int>(){0,1,2,3,4,5,6,7,8,9};
            int target = 1000000-1;
            Int64 result = 0;
            while(digits.Count != 0)
            {
                int total = 1;
                for(int i=1;i<=digits.Count;i++)
                {
                    total *= i;
                }
                //Gets which group the target is in
                int group = (int)((Math.Floor((decimal)target / total * digits.Count)));
                //updates target
                target -= total/digits.Count * group;
                result += digits[group] * (Int64)Math.Pow(10, digits.Count-1);
                digits.Remove(digits[group]);
            }

            return result;
        }

        static BigInteger P0251000DigitFibonacciNumber()
        {
            BigInteger F0 = 1;
            BigInteger F1 = 1;
            int counter = 2;
            while(F0.ToString().Length <1000 && F1.ToString().Length<1000)
            {
                //leapfrog
                F0 = F1 + F0;
                F1 = F0 + F1;
                counter += 2;
            }
            if(F0.ToString().Length ==1000 && F1.ToString().Length==1000)
            {
                if(F0<F1)
                {
                    return counter-1;
                }
                else
                {
                    return counter;
                }
            }

            if (F0.ToString().Length == 1000)
            {
                return counter-1;
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
            int length =0;
            int result =0;

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
            for(int b = -1000; b<1000; b++)
            {
                if(isPrime(b))
                {
                    int answer = b;
                    int primeRun = 0;
                    //for each a
                    for (int a = -1000; a < 1000; a++)
                    {
                        int n = 0;
                        if ((b == 41 || b==-41) && a == 1)
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
                        if(Math.Abs(primeRun) > Math.Abs(highestPrimeRun))
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
            
            int sides =1;
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
            for(int a =2; a<=100;a++)
            {
                for(int b = 2; b<=100; b++)
                {
                    BigInteger x = (BigInteger)Math.Pow(a,b);
                    if(!results.Contains(x))
                    {
                        results.Add(x);
                    }
                }
            }
            return results.Count;
        }

        static int P30DigitFifthPowers()
        {
            //Find the sum of all the numbers that can be written as 
            //the sum of fifth powers of their digits.

            //9474 = 9^4 + 4^4 + 7^4 + 4^4
            int result = 0;
            for(int i=2; i<1000000000; i++)
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
    }
}
