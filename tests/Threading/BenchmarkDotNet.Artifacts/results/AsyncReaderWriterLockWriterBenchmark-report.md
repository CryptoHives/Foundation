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
| WriterLock · AsyncRWLock · RWLockSlim     |     6.984 ns |  0.64 |         - | 
| WriterLock · AsyncRWLock · Proto.Promises |     8.782 ns |  0.80 |         - | 
| WriterLock · AsyncRWLock · Pooled         |    10.940 ns |  1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl        |    18.845 ns |  1.72 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx   |    53.959 ns |  4.93 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading   | 1,023.340 ns | 93.54 |     584 B | 
