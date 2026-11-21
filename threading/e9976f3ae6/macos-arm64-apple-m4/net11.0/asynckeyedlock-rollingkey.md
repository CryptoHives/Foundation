| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Error    | StdDev   | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|---------:|---------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   194.3 ns |  0.33 ns |  0.29 ns |  0.87 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   222.6 ns |  0.44 ns |  0.41 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   259.8 ns |  0.43 ns |  0.41 ns |  1.17 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   306.8 ns |  2.73 ns |  2.56 ns |  1.38 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              |   475.1 ns |  0.90 ns |  0.75 ns |  2.13 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              |   515.6 ns |  1.51 ns |  1.41 ns |  2.32 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              |   721.9 ns |  2.39 ns |  2.12 ns |  3.24 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              |   827.9 ns |  0.58 ns |  0.54 ns |  3.72 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   195.8 ns |  0.29 ns |  0.27 ns |  0.84 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   233.8 ns |  0.46 ns |  0.41 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   259.8 ns |  0.22 ns |  0.21 ns |  1.11 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   315.0 ns |  1.70 ns |  1.59 ns |  1.35 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              |   475.7 ns |  0.74 ns |  0.69 ns |  2.03 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              |   514.1 ns |  0.86 ns |  0.81 ns |  2.20 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              |   728.6 ns |  2.97 ns |  2.78 ns |  3.12 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              |   831.0 ns |  0.81 ns |  0.76 ns |  3.55 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   195.5 ns |  0.44 ns |  0.37 ns |  0.85 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   229.7 ns |  0.51 ns |  0.48 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   259.3 ns |  0.48 ns |  0.45 ns |  1.13 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   303.6 ns |  0.97 ns |  0.86 ns |  1.32 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              |   473.2 ns |  0.91 ns |  0.85 ns |  2.06 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              |   517.9 ns |  1.11 ns |  1.04 ns |  2.25 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              |   706.5 ns |  2.81 ns |  2.63 ns |  3.08 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              |   834.7 ns |  1.45 ns |  1.35 ns |  3.63 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              |   755.7 ns |  1.76 ns |  1.64 ns |  0.88 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              |   854.2 ns |  4.44 ns |  3.71 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              |   977.7 ns |  2.79 ns |  2.61 ns |  1.14 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              | 1,089.2 ns | 20.17 ns | 18.87 ns |  1.28 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 1,892.3 ns |  2.58 ns |  2.15 ns |  2.22 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 1,979.6 ns |  6.72 ns |  5.96 ns |  2.32 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 2,847.3 ns | 15.88 ns | 14.85 ns |  3.33 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 3,311.1 ns |  2.64 ns |  2.34 ns |  3.88 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              |   750.8 ns |  1.13 ns |  1.06 ns |  0.87 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              |   862.9 ns |  2.69 ns |  2.52 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              | 1,023.9 ns |  2.76 ns |  2.58 ns |  1.19 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              | 1,117.3 ns |  7.54 ns |  6.30 ns |  1.29 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 1,891.2 ns |  3.70 ns |  3.09 ns |  2.19 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 2,073.5 ns |  4.63 ns |  4.33 ns |  2.40 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 2,858.3 ns | 14.93 ns | 13.97 ns |  3.31 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 3,310.4 ns |  3.25 ns |  3.04 ns |  3.84 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              |   753.8 ns |  1.33 ns |  1.18 ns |  0.86 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              |   873.3 ns |  1.66 ns |  1.38 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              | 1,036.2 ns |  2.32 ns |  2.17 ns |  1.19 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              | 1,110.2 ns |  5.57 ns |  4.65 ns |  1.27 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 1,904.8 ns |  3.92 ns |  3.66 ns |  2.18 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 2,023.1 ns |  5.43 ns |  5.08 ns |  2.32 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 2,851.5 ns |  9.99 ns |  9.34 ns |  3.27 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 3,296.5 ns |  2.01 ns |  1.78 ns |  3.77 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   191.9 ns |  0.35 ns |  0.33 ns |  0.37 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   258.2 ns |  0.98 ns |  0.87 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   298.0 ns |  1.73 ns |  1.61 ns |  0.58 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              |   501.1 ns |  1.44 ns |  1.28 ns |  0.97 |    1152 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              |   514.7 ns |  0.77 ns |  0.72 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              |   528.8 ns |  1.08 ns |  1.01 ns |  1.03 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              |   720.0 ns |  0.59 ns |  0.53 ns |  1.40 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              |   838.3 ns |  0.66 ns |  0.58 ns |  1.63 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   193.5 ns |  0.55 ns |  0.51 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   258.5 ns |  0.69 ns |  0.58 ns |  0.67 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   302.7 ns |  2.19 ns |  2.05 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   385.9 ns |  0.62 ns |  0.58 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              |   493.6 ns |  1.16 ns |  0.97 ns |  1.28 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              |   532.5 ns |  1.13 ns |  1.00 ns |  1.38 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              |   714.5 ns |  0.73 ns |  0.65 ns |  1.85 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              |   827.9 ns |  0.89 ns |  0.84 ns |  2.15 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   193.8 ns |  0.22 ns |  0.20 ns |  0.64 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   258.4 ns |  1.11 ns |  1.04 ns |  0.85 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   303.7 ns |  0.70 ns |  0.66 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   306.9 ns |  2.35 ns |  2.20 ns |  1.01 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              |   485.8 ns |  0.61 ns |  0.51 ns |  1.60 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              |   532.7 ns |  0.96 ns |  0.90 ns |  1.75 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              |   711.2 ns |  1.08 ns |  1.01 ns |  2.34 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              |   829.8 ns |  0.57 ns |  0.53 ns |  2.73 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              |   739.2 ns |  2.14 ns |  2.01 ns |  0.37 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              |   991.0 ns |  2.18 ns |  1.93 ns |  0.49 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              | 1,067.0 ns |  6.48 ns |  6.06 ns |  0.53 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 1,947.4 ns |  6.21 ns |  5.81 ns |  0.96 |    4608 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 2,020.7 ns |  5.41 ns |  5.06 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 2,080.7 ns |  4.18 ns |  3.91 ns |  1.03 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 2,836.8 ns |  3.92 ns |  3.67 ns |  1.40 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 3,291.3 ns |  4.68 ns |  3.90 ns |  1.63 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              |   728.7 ns |  1.47 ns |  1.31 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              |   986.8 ns |  2.38 ns |  2.23 ns |  0.67 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              | 1,111.1 ns | 10.13 ns |  9.48 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 1,464.2 ns |  1.81 ns |  1.69 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 1,912.6 ns |  2.75 ns |  2.44 ns |  1.31 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 2,093.7 ns |  7.31 ns |  6.84 ns |  1.43 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 2,812.3 ns |  2.83 ns |  2.65 ns |  1.92 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 3,287.0 ns |  7.84 ns |  7.34 ns |  2.24 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              |   727.1 ns |  1.94 ns |  1.82 ns |  0.62 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              |   997.8 ns |  1.85 ns |  1.73 ns |  0.85 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              | 1,064.1 ns |  5.18 ns |  4.60 ns |  0.90 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 1,177.4 ns |  2.34 ns |  2.19 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 1,913.5 ns |  2.05 ns |  1.92 ns |  1.63 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 2,115.5 ns |  4.08 ns |  3.81 ns |  1.80 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 2,805.4 ns |  9.39 ns |  8.78 ns |  2.38 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 3,294.0 ns | 16.07 ns | 15.03 ns |  2.80 |   16128 B |