```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   228.5 ns |  0.69 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   268.8 ns |  0.82 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   329.5 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   429.1 ns |  1.30 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              |   553.6 ns |  1.68 |    2048 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              |   631.7 ns |  1.92 |    1600 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              |   657.0 ns |  1.99 |     384 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              |   809.4 ns |  2.46 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   227.1 ns |  0.71 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   247.0 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   318.6 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   437.0 ns |  1.37 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              |   515.5 ns |  1.62 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              |   555.7 ns |  1.74 |    2048 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              |   614.7 ns |  1.93 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              |   802.1 ns |  2.52 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   227.8 ns |  0.69 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   247.6 ns |  0.75 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   329.2 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   429.9 ns |  1.31 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              |   516.5 ns |  1.57 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              |   539.8 ns |  1.64 |    2048 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              |   615.4 ns |  1.87 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              |   793.7 ns |  2.41 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              |   878.7 ns |  0.70 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              |   931.0 ns |  0.74 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              | 1,262.2 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              | 1,722.8 ns |  1.36 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 2,007.5 ns |  1.59 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 2,128.9 ns |  1.69 |    8192 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 2,427.9 ns |  1.92 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 3,121.5 ns |  2.47 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              |   875.5 ns |  0.69 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              |   962.6 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              | 1,274.9 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              | 1,711.8 ns |  1.34 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 2,023.9 ns |  1.59 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 2,112.2 ns |  1.66 |    8192 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 2,419.6 ns |  1.90 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 3,088.7 ns |  2.42 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              |   884.8 ns |  0.71 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              |   931.0 ns |  0.75 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              | 1,238.3 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              | 1,701.9 ns |  1.37 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 2,001.5 ns |  1.62 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 2,159.8 ns |  1.74 |    8192 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 2,475.1 ns |  2.00 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 3,110.5 ns |  2.51 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   231.7 ns |  0.37 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   248.2 ns |  0.40 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   433.9 ns |  0.70 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              |   516.3 ns |  0.83 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              |   567.6 ns |  0.92 |    2048 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              |   618.6 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              |   634.7 ns |  1.03 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              |   817.0 ns |  1.32 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   231.5 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   248.6 ns |  0.54 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   429.0 ns |  0.93 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   461.3 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              |   518.2 ns |  1.12 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              |   557.6 ns |  1.21 |    2048 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              |   625.4 ns |  1.36 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              |   789.9 ns |  1.71 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   228.9 ns |  0.58 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   250.8 ns |  0.64 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   394.4 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   425.8 ns |  1.08 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              |   520.9 ns |  1.32 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              |   554.1 ns |  1.40 |    2048 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              |   619.6 ns |  1.57 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              |   798.4 ns |  2.02 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              |   900.6 ns |  0.38 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              |   953.0 ns |  0.40 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              | 1,682.7 ns |  0.71 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 2,005.9 ns |  0.85 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 2,195.9 ns |  0.93 |    8192 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 2,372.8 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 2,524.1 ns |  1.06 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 3,222.8 ns |  1.36 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              |   875.5 ns |  0.47 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              |   924.7 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              | 1,692.6 ns |  0.91 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 1,867.7 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 2,035.6 ns |  1.09 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 2,164.4 ns |  1.16 |    8192 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 2,598.7 ns |  1.39 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 3,173.9 ns |  1.70 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              |   895.1 ns |  0.57 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              |   927.4 ns |  0.59 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 1,583.2 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              | 1,722.6 ns |  1.09 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 2,041.5 ns |  1.29 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 2,161.5 ns |  1.37 |    8192 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 2,444.3 ns |  1.54 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 3,161.1 ns |  2.00 |   16640 B | 
