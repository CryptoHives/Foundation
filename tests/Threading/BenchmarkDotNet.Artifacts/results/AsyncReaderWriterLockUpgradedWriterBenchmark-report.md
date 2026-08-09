```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    14.74 ns |  0.59 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    23.88 ns |  0.96 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    24.84 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,681.62 ns | 67.71 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    24.66 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    24.72 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,794.27 ns | 72.60 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    24.58 ns |  1.00 |         - | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    20.41 ns |  0.38 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    43.96 ns |  0.81 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    54.35 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,245.72 ns | 41.32 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    65.21 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    75.71 ns |  1.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,275.24 ns | 34.89 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |    91.88 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    25.72 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    53.51 ns |  0.69 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    78.10 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,754.83 ns | 35.27 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    81.30 ns |  0.94 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    86.12 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,797.53 ns | 32.48 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   114.43 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    41.95 ns |  0.30 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    92.53 ns |  0.67 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   138.25 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,308.72 ns | 31.17 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   117.57 ns |  0.74 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   158.24 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,341.37 ns | 27.44 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   178.05 ns |  1.00 |     152 B | 
