﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace Test.FAKECore
{
    public static class Extensions
    {
        public static FSharpFunc<T, T2> Convert<T, T2>(this Func<T, T2> func)
        {
            return FSharpFunc<T, T2>.FromConverter(new Converter<T, T2>(func));
        }

        public static FSharpList<T> ToFSharpList<T>(this IEnumerable<T> list)
        {
            return list.Reverse().Aggregate(FSharpList<T>.Empty, (current, item) => FSharpList<T>.Cons(item, current));
        }
    }
}