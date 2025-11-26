```

BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
cancellationToken=Syste(...)Token [34]  

```
| Method                                                       | Iterations | ct    | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |------ |--------------:|------:|----------:|------------:|
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None  |      28.85 ns |  0.95 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None  |      29.23 ns |  0.97 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None  |      30.24 ns |  1.00 |      96 B |        1.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | None  |      31.21 ns |  1.03 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None  |      31.61 ns |  1.05 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None  |      36.10 ns |  1.19 |     160 B |        1.67 |
| PooledAsTaskContSync                                         | 1          | None  |      45.04 ns |  1.49 |      80 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None  |     367.44 ns | 12.15 |     232 B |        2.42 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | Token |      45.97 ns |     ? |      64 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | Token |      46.05 ns |     ? |      64 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | Token |      48.49 ns |     ? |      64 B |           ? |
| PooledAsTaskContSync                                         | 1          | Token |      64.69 ns |     ? |     144 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | Token |      75.35 ns |     ? |      64 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | Token |     344.53 ns |     ? |     400 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | Token |     475.52 ns |     ? |     296 B |           ? |
|                                                              |            |       |               |       |           |             |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None  |      56.80 ns |  1.00 |     192 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None  |      66.36 ns |  1.17 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None  |      66.78 ns |  1.18 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | None  |      70.33 ns |  1.24 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None  |      71.51 ns |  1.26 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None  |      73.98 ns |  1.30 |     320 B |        1.67 |
| PooledAsTaskContSync                                         | 2          | None  |     111.76 ns |  1.97 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None  |     804.94 ns | 14.17 |     344 B |        1.79 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | Token |     103.67 ns |     ? |     128 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | Token |     107.73 ns |     ? |     128 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | Token |     107.94 ns |     ? |     128 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | Token |     113.13 ns |     ? |     128 B |           ? |
| PooledAsTaskContSync                                         | 2          | Token |     142.72 ns |     ? |     288 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | Token |     594.73 ns |     ? |     800 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | Token |     966.97 ns |     ? |     472 B |           ? |
|                                                              |            |       |               |       |           |             |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None  |     300.42 ns |  1.00 |     960 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None  |     309.50 ns |  1.03 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None  |     312.02 ns |  1.04 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None  |     346.64 ns |  1.15 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None  |     347.22 ns |  1.16 |    1600 B |        1.67 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | None  |     348.55 ns |  1.16 |         - |        0.00 |
| PooledAsTaskContSync                                         | 10         | None  |     492.12 ns |  1.64 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None  |   2,461.95 ns |  8.20 |    1240 B |        1.29 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | Token |     515.73 ns |     ? |     640 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | Token |     518.59 ns |     ? |     640 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | Token |     559.07 ns |     ? |     640 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | Token |     565.19 ns |     ? |     640 B |           ? |
| PooledAsTaskContSync                                         | 10         | Token |     764.75 ns |     ? |    1440 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | Token |   3,149.21 ns |     ? |    1880 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | Token |   3,167.35 ns |     ? |    4000 B |           ? |
|                                                              |            |       |               |       |           |             |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None  |   2,877.40 ns |  1.00 |    9600 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None  |   3,175.37 ns |  1.10 |    5896 B |        0.61 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None  |   3,187.68 ns |  1.11 |    5896 B |        0.61 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None  |   3,559.46 ns |  1.24 |    5896 B |        0.61 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None  |   3,599.06 ns |  1.25 |   16000 B |        1.67 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | None  |   4,136.83 ns |  1.44 |    5896 B |        0.61 |
| PooledAsTaskContSync                                         | 100        | None  |   4,916.44 ns |  1.71 |   13896 B |        1.45 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None  |  15,525.58 ns |  5.40 |   17216 B |        1.79 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | Token |   5,242.70 ns |     ? |   12296 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | Token |   5,290.97 ns |     ? |   12296 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | Token |   5,726.57 ns |     ? |   12296 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | Token |   5,786.60 ns |     ? |   12296 B |           ? |
| PooledAsTaskContSync                                         | 100        | Token |   7,165.53 ns |     ? |   20296 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | Token |  43,293.76 ns |     ? |   40000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | Token | 174,224.80 ns |     ? |   23642 B |           ? |
