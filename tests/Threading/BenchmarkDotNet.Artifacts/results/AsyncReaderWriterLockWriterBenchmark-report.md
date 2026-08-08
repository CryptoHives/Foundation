```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                               | Mean         | Ratio | Allocated | 
|------------------------------------------ |-------------:|------:|----------:|
| WriterLock · AsyncRWLock · RWLockSlim     |     7.054 ns |  0.60 |         - | 
| WriterLock · AsyncRWLock · Proto.Promises |     8.856 ns |  0.75 |         - | 
| WriterLock · AsyncRWLock · Pooled         |    11.766 ns |  1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl        |    18.849 ns |  1.60 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx   |    54.377 ns |  4.62 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading   | 1,053.228 ns | 89.52 |     584 B | 
