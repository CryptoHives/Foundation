| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   226.8 ns |  0.80 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   246.9 ns |  0.87 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   284.4 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   449.7 ns |  1.58 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              |   479.1 ns |  1.68 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              |   512.2 ns |  1.80 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              |   612.2 ns |  2.15 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              |   801.8 ns |  2.82 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   228.9 ns |  0.81 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   246.7 ns |  0.87 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   284.3 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   429.9 ns |  1.51 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              |   485.0 ns |  1.71 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              |   515.5 ns |  1.81 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              |   612.6 ns |  2.15 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              |   788.7 ns |  2.77 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   225.6 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   246.9 ns |  0.84 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   292.8 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   429.1 ns |  1.47 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              |   477.7 ns |  1.63 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              |   508.7 ns |  1.74 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              |   623.6 ns |  2.13 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              |   783.2 ns |  2.67 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              |   876.3 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              |   944.1 ns |  0.85 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              | 1,109.5 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              | 1,740.5 ns |  1.57 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 1,880.1 ns |  1.69 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 1,983.6 ns |  1.79 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 2,553.7 ns |  2.30 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 3,087.9 ns |  2.78 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              |   864.3 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              |   939.9 ns |  0.85 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              | 1,100.2 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 1,873.4 ns |  1.70 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 2,014.3 ns |  1.83 |    1536 B | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              | 2,280.6 ns |  2.07 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 2,423.8 ns |  2.20 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 3,058.7 ns |  2.78 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              |   879.0 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              |   932.0 ns |  0.81 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              | 1,145.1 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              | 1,695.1 ns |  1.48 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 1,876.3 ns |  1.64 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 1,975.5 ns |  1.73 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 2,389.8 ns |  2.09 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 3,106.3 ns |  2.71 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   228.3 ns |  0.39 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   250.5 ns |  0.43 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   426.8 ns |  0.74 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              |   496.6 ns |  0.86 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              |   516.3 ns |  0.89 |     384 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              |   579.3 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              |   639.9 ns |  1.10 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              |   790.1 ns |  1.36 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   228.3 ns |  0.52 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   248.3 ns |  0.57 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   434.8 ns |  0.99 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   439.3 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              |   499.0 ns |  1.14 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              |   515.8 ns |  1.17 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              |   621.1 ns |  1.41 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              |   803.0 ns |  1.83 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   228.2 ns |  0.64 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   250.7 ns |  0.70 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   358.4 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   425.0 ns |  1.19 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              |   483.2 ns |  1.35 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              |   514.3 ns |  1.44 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              |   624.9 ns |  1.74 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              |   786.3 ns |  2.19 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              |   867.5 ns |  0.38 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              |   956.4 ns |  0.42 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              | 1,691.8 ns |  0.74 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 1,913.9 ns |  0.84 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 2,014.6 ns |  0.88 |    1536 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 2,291.5 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 2,465.0 ns |  1.08 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 3,060.6 ns |  1.34 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              |   868.7 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              |   931.2 ns |  0.54 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 1,713.7 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              | 1,714.5 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 1,960.2 ns |  1.14 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 2,002.6 ns |  1.17 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 2,585.5 ns |  1.51 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 3,038.4 ns |  1.77 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              |   869.5 ns |  0.61 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              |   935.0 ns |  0.66 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 1,416.8 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              | 1,716.5 ns |  1.21 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 1,919.3 ns |  1.35 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 1,982.5 ns |  1.40 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 2,433.0 ns |  1.72 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 3,054.7 ns |  2.16 |   16640 B |