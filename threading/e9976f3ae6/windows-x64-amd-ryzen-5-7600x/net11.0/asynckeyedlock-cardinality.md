| Description                                              | KeyCount | Mean        | Error     | StdDev    | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|----------:|----------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    28.24 ns |  0.119 ns |  0.111 ns |  0.83 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    33.92 ns |  0.025 ns |  0.022 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    35.12 ns |  0.093 ns |  0.077 ns |  1.04 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    43.58 ns |  0.057 ns |  0.051 ns |  1.28 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    70.93 ns |  0.091 ns |  0.076 ns |  2.09 |     144 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    73.44 ns |  0.083 ns |  0.070 ns |  2.17 |      48 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    92.88 ns |  0.306 ns |  0.271 ns |  2.74 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   108.46 ns |  0.412 ns |  0.365 ns |  3.20 |     504 B | 
|                                                          |          |             |           |           |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    96.44 ns |  0.221 ns |  0.184 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   124.46 ns |  0.182 ns |  0.152 ns |  0.96 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   129.91 ns |  0.268 ns |  0.238 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   160.17 ns |  0.154 ns |  0.129 ns |  1.23 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   250.58 ns |  0.732 ns |  0.649 ns |  1.93 |     576 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   276.63 ns |  0.988 ns |  0.771 ns |  2.13 |     192 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   349.21 ns |  0.952 ns |  0.795 ns |  2.69 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   433.85 ns |  1.203 ns |  1.005 ns |  3.34 |    2016 B | 
|                                                          |          |             |           |           |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   367.33 ns |  1.396 ns |  1.238 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   495.94 ns |  2.057 ns |  1.924 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   502.44 ns |  0.580 ns |  0.453 ns |  1.01 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   617.82 ns |  2.247 ns |  1.992 ns |  1.25 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,050.64 ns | 19.845 ns | 16.571 ns |  2.12 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       | 1,077.90 ns |  1.292 ns |  1.079 ns |  2.17 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,382.92 ns |  4.853 ns |  4.052 ns |  2.79 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,640.71 ns | 12.221 ns | 10.833 ns |  3.31 |    8064 B | 
|                                                          |          |             |           |           |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,451.74 ns |  3.563 ns |  2.976 ns |  0.70 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 2,019.84 ns |  3.493 ns |  3.097 ns |  0.98 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,068.17 ns | 33.470 ns | 31.308 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 2,489.42 ns |  4.216 ns |  3.738 ns |  1.20 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 3,917.25 ns | 11.655 ns |  9.732 ns |  1.89 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 4,241.61 ns | 13.025 ns | 12.184 ns |  2.05 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 5,474.42 ns | 33.015 ns | 30.882 ns |  2.65 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,434.75 ns | 27.469 ns | 21.446 ns |  3.11 |   32256 B |