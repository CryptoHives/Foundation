| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   194.1 ns |  0.83 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   232.8 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   236.5 ns |  1.02 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   244.7 ns |  1.05 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              |   473.6 ns |  2.03 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              |   481.4 ns |  2.07 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              |   633.6 ns |  2.72 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              |   738.9 ns |  3.17 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   193.6 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   241.5 ns |  0.99 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   243.7 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   249.2 ns |  1.02 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              |   465.5 ns |  1.91 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              |   481.9 ns |  1.98 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              |   653.4 ns |  2.68 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              |   747.8 ns |  3.07 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   194.5 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   242.8 ns |  0.98 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   246.6 ns |  0.99 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   248.8 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              |   468.5 ns |  1.88 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              |   481.7 ns |  1.94 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              |   635.0 ns |  2.55 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              |   751.0 ns |  3.02 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              |   730.7 ns |  0.80 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              |   915.7 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              |   916.5 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              |   929.7 ns |  1.01 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 1,807.2 ns |  1.97 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 1,883.5 ns |  2.06 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 2,623.4 ns |  2.86 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 2,908.7 ns |  3.17 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              |   738.4 ns |  0.80 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              |   920.7 ns |  0.99 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              |   927.7 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              |   943.1 ns |  1.02 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 1,782.9 ns |  1.92 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 1,889.2 ns |  2.04 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 2,630.2 ns |  2.84 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 2,878.2 ns |  3.10 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              |   731.1 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              |   908.5 ns |  0.94 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              |   940.7 ns |  0.97 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              |   965.0 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 1,828.3 ns |  1.89 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 1,885.4 ns |  1.95 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 2,659.5 ns |  2.76 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 2,904.8 ns |  3.01 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   190.8 ns |  0.40 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   227.6 ns |  0.48 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   245.0 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              |   477.9 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              |   482.3 ns |  1.01 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              |   495.8 ns |  1.04 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              |   681.2 ns |  1.43 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              |   761.1 ns |  1.59 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   190.5 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   233.2 ns |  0.61 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   247.8 ns |  0.65 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   381.3 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              |   488.2 ns |  1.28 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              |   492.3 ns |  1.29 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              |   641.5 ns |  1.68 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              |   758.0 ns |  1.99 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   189.0 ns |  0.58 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   235.1 ns |  0.72 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   246.5 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   326.1 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              |   486.4 ns |  1.49 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              |   491.1 ns |  1.51 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              |   639.9 ns |  1.96 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              |   754.8 ns |  2.31 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              |   725.6 ns |  0.40 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              |   877.8 ns |  0.48 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              |   937.5 ns |  0.52 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 1,814.6 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 1,845.2 ns |  1.02 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 1,959.9 ns |  1.08 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 2,689.1 ns |  1.48 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 2,951.1 ns |  1.63 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              |   716.5 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              |   883.1 ns |  0.63 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              |   933.4 ns |  0.66 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 1,404.8 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 1,872.4 ns |  1.33 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 1,908.8 ns |  1.36 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 2,499.0 ns |  1.78 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 2,957.0 ns |  2.10 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              |   739.5 ns |  0.61 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              |   895.3 ns |  0.74 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              |   933.9 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 1,206.4 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 1,848.0 ns |  1.53 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 1,883.9 ns |  1.56 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 2,658.5 ns |  2.20 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 3,021.0 ns |  2.50 |   16640 B |