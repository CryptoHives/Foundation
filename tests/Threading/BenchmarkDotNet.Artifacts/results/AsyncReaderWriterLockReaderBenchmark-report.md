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
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      6.902 ns |  0.41 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     16.770 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.171 ns |  1.08 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     20.180 ns |  1.20 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     42.837 ns |  2.55 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    232.527 ns | 13.87 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.842 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     27.382 ns |  1.63 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     42.113 ns |  2.50 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    229.773 ns | 13.64 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     12.400 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     28.568 ns |  0.78 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     33.406 ns |  0.91 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     36.608 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     84.602 ns |  2.31 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    531.589 ns | 14.52 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.859 ns |  0.78 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     36.789 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     85.976 ns |  2.34 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    529.064 ns | 14.38 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     62.412 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    141.484 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    147.317 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    193.963 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    495.874 ns |  2.56 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,696.621 ns | 19.06 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    145.454 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    192.635 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    469.393 ns |  2.44 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,772.068 ns | 19.58 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    571.473 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,235.386 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,266.030 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,706.169 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,861.497 ns |  2.85 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 86,382.519 ns | 50.63 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,252.585 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,719.206 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,495.125 ns |  2.61 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 88,106.049 ns | 51.25 |   21008 B | 
