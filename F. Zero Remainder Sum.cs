//https://codeforces.com/contest/1433/problem/F
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using static System.Math;
using System.Numerics;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Diagnostics;
//using nint=System.Int32;
class Program
{
    static int n, m, k, lim;
    static long[,,,] dp = new long[72,72,36,72];
    static int[,] ara = new int[72,72];
    static long fun(int r, int c, int cnt, int rem)
    {
        if(r>n)
        {
            if (rem % k == 0)
                return 0;
            return -1000000000;
        }
        if (dp[r, c, cnt, rem] != -1)
            return dp[r, c, cnt, rem];
        long ret = 0;
        if (c > m || cnt >= lim)
            ret += fun(r + 1, 1, 0, rem);
        else
            ret = Math.Max(fun(r, c + 1, cnt, rem), ara[r, c] + fun(r, c + 1, cnt + 1, (rem + ara[r, c]) % k));
        return dp[r, c, cnt, rem] = ret;
    }
    static void Main()
    {
        Sc sc = new Sc();
        var x = sc.Ia;
        n = x[0];
        m = x[1];
        k = x[2];
        lim = m / 2;
        for( int i = 0; i <= 71; i++)
        {
            for( int j = 0; j <= 71; j++)
            {
                for( int l = 0; l <= 35; l++ )
                {
                    for( int y = 0; y <= 71; y++)
                    {
                        dp[i, j, l, y] = -1;
                    }
                }
            }
        }
        for( int i = 1; i <= n; i++)
        {
            x = sc.Ia;
            for (int j = 0; j < m; j++)
            {
                ara[i, j+1] = x[j];
            }
        }
        Console.WriteLine(fun(1, 1, 0, 0));
    }
}

public class Sc
{
    public int I { get { return int.Parse(Console.ReadLine()); } }
    public long L { get { return long.Parse(Console.ReadLine()); } }
    public double D { get { return double.Parse(Console.ReadLine()); } }
    public string S { get { return Console.ReadLine(); } }
    public int[] Ia { get { return Array.ConvertAll(Console.ReadLine().Split(), int.Parse); } }
    public long[] La { get { return Array.ConvertAll(Console.ReadLine().Split(), long.Parse); } }
    public double[] Da { get { return Array.ConvertAll(Console.ReadLine().Split(), double.Parse); } }
    public string[] Sa { get { return Console.ReadLine().Split(); } }
    public object[] Oa { get { return Console.ReadLine().Split(); } }
    public int[] Ia2 { get { return Array.ConvertAll(("0 " + Console.ReadLine() + " 0").Split(), int.Parse); } }
    public int[] Ia3(string a, string b)
    {
        return Array.ConvertAll((a + Console.ReadLine() + b).Split(), int.Parse);
    }
    public int[] Ia3(int a)
    {
        return Array.ConvertAll((Console.ReadLine() + " " + a.ToString()).Split(), int.Parse);
    }
    public long[] La2 { get { return Array.ConvertAll(("0 " + Console.ReadLine() + " 0").Split(), long.Parse); } }
    public long[] La3(string a, string b)
    {
        return Array.ConvertAll((a + Console.ReadLine() + b).Split(), long.Parse);
    }
    public long[] La3(int a)
    {
        return Array.ConvertAll((Console.ReadLine() + " " + a.ToString()).Split(), long.Parse);
    }
    public double[] Da2 { get { return Array.ConvertAll(("0 " + Console.ReadLine() + " 0").Split(), double.Parse); } }
    public double[] Da3(string a, string b)
    {
        return Array.ConvertAll((a + Console.ReadLine() + b).Split(), double.Parse);
    }
    public T[] Arr<T>(int n, Func<T> f)
    {
        var a = new T[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = f();
        }
        return a;
    }
    public T[] Arr<T>(int n, Func<int, T> f)
    {
        var a = new T[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = f(i);
        }
        return a;
    }
    public T[] Arr<T>(int n, Func<string[], T> f)
    {
        var a = new T[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = f(Console.ReadLine().Split());
        }
        return a;
    }
    public T[] Arr<T>(int n, Func<int, string[], T> f)
    {
        var a = new T[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = f(i, Console.ReadLine().Split());
        }
        return a;
    }
}
