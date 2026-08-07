```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                                          | KeyCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |      31.04 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |      59.49 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |      60.93 ns |  1.02 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |      74.72 ns |  1.26 |      48 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |      83.35 ns |  1.40 |     256 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |     102.56 ns |  1.72 |     520 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |      32.27 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |      60.03 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |      60.27 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |      75.19 ns |  1.25 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |     105.15 ns |  1.74 |     520 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |     112.61 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     563.14 ns |  5.00 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     706.09 ns |  6.27 |     544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     713.78 ns |  6.34 |     632 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     724.48 ns |  6.43 |     952 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     840.36 ns |  7.46 |     432 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |     127.70 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     669.98 ns |  5.25 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     802.75 ns |  6.29 |     832 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     872.66 ns |  6.83 |    1240 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     960.34 ns |  7.52 |     720 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     732.49 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |   3,906.84 ns |  5.33 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |   3,914.03 ns |  5.34 |    2456 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |   4,016.00 ns |  5.48 |    2720 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |   4,151.58 ns |  5.67 |    2520 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |   4,640.13 ns |  6.33 |    4144 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     900.63 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |   5,801.05 ns |  6.44 |    5336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |   5,872.59 ns |  6.52 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |   6,435.39 ns |  7.15 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |   7,230.30 ns |  8.03 |    7024 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |   6,616.33 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |  38,474.04 ns |  5.82 |   29527 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |  38,729.01 ns |  5.85 |   23399 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |  38,838.91 ns |  5.87 |   23663 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |  39,795.47 ns |  6.01 |   23458 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |  44,533.45 ns |  6.73 |   40208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |   8,486.06 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |  56,757.26 ns |  6.69 |   52200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |  60,165.91 ns |  7.09 |   58328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |  65,680.26 ns |  7.74 |   52260 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |  73,732.31 ns |  8.69 |   69008 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |      97.42 ns |  0.47 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |     205.19 ns |  0.99 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |     207.74 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |     279.06 ns |  1.34 |     192 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |     299.79 ns |  1.44 |    1024 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |     399.72 ns |  1.92 |    2080 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |     100.55 ns |  0.48 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |     208.83 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |     209.98 ns |  1.01 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |     273.97 ns |  1.31 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |     409.52 ns |  1.96 |    2080 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |     419.39 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |   1,524.87 ns |  3.64 |    1064 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |   1,632.15 ns |  3.89 |    2068 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |   1,737.17 ns |  4.14 |    3333 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |   1,753.35 ns |  4.18 |    1224 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |   2,079.48 ns |  4.96 |    1744 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     517.86 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |   2,240.20 ns |  4.33 |    2216 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |   2,376.02 ns |  4.59 |    2416 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |   2,404.80 ns |  4.64 |    4522 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |   2,960.15 ns |  5.72 |    2896 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |   3,431.32 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |  16,845.06 ns |  4.91 |   10480 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |  17,900.39 ns |  5.22 |    9666 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |  18,242.38 ns |  5.32 |    9480 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |  18,749.13 ns |  5.46 |   13802 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |  21,577.68 ns |  6.29 |   16208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |   3,483.35 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |  25,381.88 ns |  7.29 |   25327 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |  25,508.36 ns |  7.32 |   20999 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |  27,291.27 ns |  7.83 |   21201 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |  32,138.18 ns |  9.23 |   27728 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |  35,624.73 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             | 135,096.77 ns |  3.79 |   94032 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             | 138,071.55 ns |  3.88 |   93000 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             | 139,563.75 ns |  3.92 |  117488 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             | 146,916.25 ns |  4.12 |   93208 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             | 157,626.44 ns |  4.42 |  160208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |  39,039.70 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     | 202,733.23 ns |  5.19 |  208200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     | 207,120.45 ns |  5.31 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     | 225,148.32 ns |  5.77 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     | 258,824.56 ns |  6.63 |  275408 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |     398.17 ns |  0.53 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     750.27 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |     773.92 ns |  1.03 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |   1,063.74 ns |  1.42 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |   1,173.07 ns |  1.56 |    4096 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |   1,569.55 ns |  2.09 |    8320 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |     372.25 ns |  0.49 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     758.83 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     771.09 ns |  1.02 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |   1,082.87 ns |  1.43 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |   1,679.58 ns |  2.21 |    8320 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |   1,820.49 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |   5,159.18 ns |  2.83 |    3849 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |   5,756.25 ns |  3.16 |    4487 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |   5,817.86 ns |  3.20 |    7824 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |   6,479.12 ns |  3.56 |   12942 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |   8,375.81 ns |  4.60 |    6560 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |   1,919.93 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |   7,175.28 ns |  3.74 |    9123 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |   7,922.13 ns |  4.13 |   17590 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |   9,005.70 ns |  4.69 |    8471 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |  16,118.71 ns |  8.40 |   11215 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |  11,386.56 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |  56,764.52 ns |  4.99 |   41424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |  56,807.89 ns |  4.99 |   37320 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |  57,185.15 ns |  5.02 |   38104 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |  58,470.86 ns |  5.14 |   54608 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |  69,995.59 ns |  6.15 |   64208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |  15,952.46 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |  85,068.18 ns |  5.33 |   83400 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |  89,148.84 ns |  5.59 |   84184 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |  89,663.03 ns |  5.62 |  100688 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     | 111,774.01 ns |  7.01 |  110288 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             | 118,724.37 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             | 523,051.64 ns |  4.41 |  372184 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             | 525,149.39 ns |  4.42 |  375504 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             | 535,112.99 ns |  4.51 |  469328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             | 535,928.67 ns |  4.51 |  371400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 617,289.18 ns |  5.20 |  640208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     | 148,651.57 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 776,862.68 ns |  5.23 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 783,732.57 ns |  5.27 |  832200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 814,898.90 ns |  5.48 |  832984 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 972,015.56 ns |  6.54 | 1101008 B | 
