```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      6.801 ns |  0.42 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     16.032 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.424 ns |  1.15 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     18.616 ns |  1.16 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     40.682 ns |  2.54 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    227.192 ns | 14.17 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.072 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     20.230 ns |  1.26 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     42.239 ns |  2.63 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    226.348 ns | 14.08 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     12.397 ns |  0.29 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     29.058 ns |  0.68 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     33.827 ns |  0.79 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     42.594 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     87.592 ns |  2.06 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    526.042 ns | 12.35 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.964 ns |  0.77 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     37.398 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     86.311 ns |  2.31 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    557.187 ns | 14.90 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     62.985 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    143.183 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    146.447 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    192.283 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    469.303 ns |  2.44 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,626.892 ns | 18.86 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    147.027 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    193.260 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    470.602 ns |  2.44 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,621.503 ns | 18.74 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    574.361 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,230.982 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,259.292 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,724.833 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,500.950 ns |  2.61 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 86,265.216 ns | 50.01 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,259.797 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,706.143 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,519.428 ns |  2.65 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 87,708.054 ns | 51.41 |   21008 B | 
