using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerformanceOfOperations
{
    class PerformanceOfOperationsExample
    {
        static void Main()
        {
            List<int> operationsCount = new List<int> { 100, 500, 1000 };

            Stopwatch timer = new Stopwatch();

            List<TimeSpan> sumIntTimes = CalcSumIntPerformance(timer, operationsCount);
            var averageSumIntTime = CalcAveragePerformanceTime(sumIntTimes);
            Console.WriteLine(averageSumIntTime);

            List<TimeSpan> sumLongTimes = CalcSumLongPerformance(timer, operationsCount);
            var averageSumLongTime = CalcAveragePerformanceTime(sumLongTimes);
            Console.WriteLine(averageSumLongTime);

            List<TimeSpan> sumDoubleTimes = CalcSumDoublePerformance(timer, operationsCount);
            var averageSumDoubleTime = CalcAveragePerformanceTime(sumDoubleTimes);
            Console.WriteLine(averageSumDoubleTime);

            List<TimeSpan> sumDecimalTimes = CalcSumDecimalPerformance(timer, operationsCount);
            var averageSumDecimalTime = CalcAveragePerformanceTime(sumDecimalTimes);
            Console.WriteLine(averageSumDecimalTime);

            List<TimeSpan> substractIntTimes = CalcSubstractIntPerformance(timer, operationsCount);
            var averageSubstractIntTime = CalcAveragePerformanceTime(substractIntTimes);
            Console.WriteLine(averageSubstractIntTime);

            List<TimeSpan> substractLongTimes = CalcSubstractLongPerformance(timer, operationsCount);
            var averageSubstractLongTime = CalcAveragePerformanceTime(substractLongTimes);
            Console.WriteLine(averageSubstractLongTime);

            List<TimeSpan> substractDoubleTimes = CalcSubstractDoublePerformance(timer, operationsCount);
            var averageSubstractDoubleTime = CalcAveragePerformanceTime(substractDoubleTimes);
            Console.WriteLine(averageSubstractDoubleTime);

            List<TimeSpan> substractDecimalTimes = CalcSubstractDecimalPerformance(timer, operationsCount);
            var averageSubstractDecimalTime = CalcAveragePerformanceTime(substractDecimalTimes);
            Console.WriteLine(averageSubstractDecimalTime);

            List<TimeSpan> prefixIntTimes = CalcPrefixIntPerformance(timer, operationsCount);
            var averagePrefixIntTime = CalcAveragePerformanceTime(prefixIntTimes);
            Console.WriteLine(averagePrefixIntTime);

            List<TimeSpan> prefixLongTimes = CalcPrefixLongPerformance(timer, operationsCount);
            var averagePrefixLongTime = CalcAveragePerformanceTime(prefixLongTimes);
            Console.WriteLine(averagePrefixLongTime);

            List<TimeSpan> prefixDoubleTimes = CalcPrefixDoublePerformance(timer, operationsCount);
            var averagePrefixDoubleTime = CalcAveragePerformanceTime(prefixDoubleTimes);
            Console.WriteLine(averagePrefixDoubleTime);

            List<TimeSpan> prefixDecimalTimes = CalcPrefixDecimalPerformance(timer, operationsCount);
            var averagePrefixDeciamlTime = CalcAveragePerformanceTime(prefixDecimalTimes);
            Console.WriteLine(averagePrefixDeciamlTime);

            List<TimeSpan> postfixIntTimes = CalcPostfixIntPerformance(timer, operationsCount);
            var averagePostfixIntTime = CalcAveragePerformanceTime(postfixIntTimes);
            Console.WriteLine(averagePostfixIntTime);

            List<TimeSpan> postfixLongTimes = CalcPostfixLongPerformance(timer, operationsCount);
            var averagePostfixLongTime = CalcAveragePerformanceTime(postfixLongTimes);
            Console.WriteLine(averagePostfixLongTime);

            List<TimeSpan> postfixDoubleTimes = CalcPostfixDoublePerformance(timer, operationsCount);
            var averagePostfixDoubleTime = CalcAveragePerformanceTime(postfixDoubleTimes);
            Console.WriteLine(averagePostfixDoubleTime);

            List<TimeSpan> postfixDecimalTimes = CalcPostfixDecimalPerformance(timer, operationsCount);
            var averagePostfixDecimalTime = CalcAveragePerformanceTime(postfixDecimalTimes);
            Console.WriteLine(averagePostfixDecimalTime);

            List<TimeSpan> increaseIntTimes = CalcIncreaseIntPerformance(timer, operationsCount);
            var averageIncreaseIntTime = CalcAveragePerformanceTime(increaseIntTimes);
            Console.WriteLine(averageIncreaseIntTime);

            List<TimeSpan> increaseLongTimes = CalcIncreaseLongPerformance(timer, operationsCount);
            var averageIncreaseLongTime = CalcAveragePerformanceTime(increaseLongTimes);
            Console.WriteLine(averageIncreaseLongTime);

            List<TimeSpan> increaseDoubleTimes = CalcIncreaseDoublePerformance(timer, operationsCount);
            var averageIncreaseDoubleTime = CalcAveragePerformanceTime(increaseDoubleTimes);
            Console.WriteLine(averageIncreaseDoubleTime);

            List<TimeSpan> increaseDecimalTimes = CalcIncreaseDecimalPerformance(timer, operationsCount);
            var averageIncreaseDecimalTime = CalcAveragePerformanceTime(increaseDecimalTimes);
            Console.WriteLine(averageIncreaseDecimalTime);

            List<TimeSpan> multiplyIntTimes = CalcMultiplyIntPerformance(timer, operationsCount);
            var averageMultiplyIntTime = CalcAveragePerformanceTime(multiplyIntTimes);
            Console.WriteLine(averageMultiplyIntTime);

            List<TimeSpan> multiplyLongTimes = CalcMultiplyLongPerformance(timer, operationsCount);
            var averageMultiplyLongTime = CalcAveragePerformanceTime(multiplyLongTimes);
            Console.WriteLine(averageMultiplyLongTime);

            List<TimeSpan> multiplyDoubleTimes = CalcMultiplyDoublePerformance(timer, operationsCount);
            var averageMultiplyDoubleTime = CalcAveragePerformanceTime(multiplyDoubleTimes);
            Console.WriteLine(averageMultiplyDoubleTime);

            List<TimeSpan> multiplyDecimalTimes = CalcMultiplyDecimalPerformance(timer, operationsCount);
            var averageMultiplyDecimalTime = CalcAveragePerformanceTime(multiplyDecimalTimes);
            Console.WriteLine(averageMultiplyDecimalTime);

            List<TimeSpan> divideIntTimes = CalcDivideIntPerformance(timer, operationsCount);
            var averageDivideIntTime = CalcAveragePerformanceTime(divideIntTimes);
            Console.WriteLine(averageDivideIntTime);

            List<TimeSpan> divideLongTimes = CalcDivideLongPerformance(timer, operationsCount);
            var averageDivideLongTime = CalcAveragePerformanceTime(divideLongTimes);
            Console.WriteLine(averageDivideLongTime);

            List<TimeSpan> divideDoubleTimes = CalcDivideDoublePerformance(timer, operationsCount);
            var averageDivideDoubleTime = CalcAveragePerformanceTime(divideDoubleTimes);
            Console.WriteLine(averageDivideDoubleTime);

            List<TimeSpan> divideDecimalTimes = CalcDivideDecimalPerformance(timer, operationsCount);
            var averageDivideDecimalTime = CalcAveragePerformanceTime(divideDecimalTimes);
            Console.WriteLine(averageDivideDecimalTime);

            List<TimeSpan> sqrtDoubleTimes = CalcSqrtDoublePerformance(timer, operationsCount);
            var averageSqrtDoubleTime = CalcAveragePerformanceTime(sqrtDoubleTimes);
            Console.WriteLine(averageSqrtDoubleTime);

            List<TimeSpan> sqrtDecimalTimes = CalcSqrtDecimalPerformance(timer, operationsCount);
            var averageSqrtDecimalTime = CalcAveragePerformanceTime(sqrtDecimalTimes);
            Console.WriteLine(averageSqrtDecimalTime);

            List<TimeSpan> logDoubleTimes = CalcLogDoublePerformance(timer, operationsCount);
            var averageLogDoubleTime = CalcAveragePerformanceTime(logDoubleTimes);
            Console.WriteLine(averageLogDoubleTime);

            List<TimeSpan> logDecimalTimes = CalcLogDecimalPerformance(timer, operationsCount);
            var averageLogDecimalTime = CalcAveragePerformanceTime(logDecimalTimes);
            Console.WriteLine(averageLogDecimalTime);

            List<TimeSpan> sinDoubleTimes = CalcSinDoublePerformance(timer, operationsCount);
            var averageSinDoubleTime = CalcAveragePerformanceTime(sinDoubleTimes);
            Console.WriteLine(averageSinDoubleTime);

            List<TimeSpan> sinDecimalTimes = CalcSinDecimalPerformance(timer, operationsCount);
            var averageSinDecimalTime = CalcAveragePerformanceTime(sinDecimalTimes);
            Console.WriteLine(averageSinDecimalTime);
        }

        private static TimeSpan CalcAveragePerformanceTime(List<TimeSpan> times)
        {
            double averageSumTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan averageSumTime = new TimeSpan(Convert.ToInt64(averageSumTicks));

            return averageSumTime;
        }

        private static List<TimeSpan> CalcSumIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum = sum + index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSumLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 0;
                for (long index = 0; index < numberOfOperations; index++)
                {
                    sum = sum + index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSumDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 0;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    sum = sum + index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSumDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 0;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    sum = sum + index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSubstractIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 10000;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum = sum - index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSubstractLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 10000;
                for (long index = 0; index < numberOfOperations; index++)
                {
                    sum = sum - index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSubstractDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 10000;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    sum = sum - index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSubstractDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 10000;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    sum = sum - index;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPrefixIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    ++sum;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPrefixLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 0;
                for (long index = 0; index < numberOfOperations; index++)
                {
                    ++sum;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPrefixDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 0;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    ++sum;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPrefixDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 0;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    ++sum;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPostfixIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum++;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPostfixLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 0;
                for (long index = 0; index < numberOfOperations; index++)
                {
                    sum++;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPostfixDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 0;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    sum++;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcPostfixDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 0;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    sum++;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcIncreaseIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum += 1;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcIncreaseLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum += 1;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcIncreaseDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum += 1;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcIncreaseDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum += 1;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcMultiplyIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum *= 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcMultiplyLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum *= 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcMultiplyDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum *= 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcMultiplyDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 0;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum *= 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcDivideIntPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                int sum = 10000;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum = sum/2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcDivideLongPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                long sum = 10000;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum = sum / 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcDivideDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double sum = 10000;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum = sum / 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcDivideDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                decimal sum = 10000;
                for (int index = 0; index < numberOfOperations; index++)
                {
                    sum = sum / 2;
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSqrtDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double result = 0;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    result = Math.Sqrt(index);
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSqrtDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double result = 0;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    result = Math.Sqrt(Convert.ToDouble(index));
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcLogDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double result = 0;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    result = Math.Log(index);
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcLogDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double result = 0;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    result = Math.Log(Convert.ToDouble(index));
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSinDoublePerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double result = 0;
                for (double index = 0; index < numberOfOperations; index++)
                {
                    result = Math.Sin(index);
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }

        private static List<TimeSpan> CalcSinDecimalPerformance(Stopwatch timer, List<int> operationsCount)
        {
            List<TimeSpan> performanceTimes = new List<TimeSpan>();

            timer.Restart();
            timer.Start();

            for (int i = 0; i < operationsCount.Count; i++)
            {
                int numberOfOperations = operationsCount[i];
                double result = 0;
                for (decimal index = 0; index < numberOfOperations; index++)
                {
                    result = Math.Sin(Convert.ToDouble(index));
                }

                timer.Stop();
                performanceTimes.Add(timer.Elapsed);
            }

            return performanceTimes;
        }
    }
}
