| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   192.4 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   237.3 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   241.4 ns |  0.97 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   249.5 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              |   451.6 ns |  1.81 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              |   468.0 ns |  1.88 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              |   628.7 ns |  2.52 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              |   752.4 ns |  3.02 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   195.5 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   239.3 ns |  0.94 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   242.1 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   254.4 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              |   450.8 ns |  1.77 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              |   460.7 ns |  1.81 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              |   626.3 ns |  2.46 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              |   740.2 ns |  2.91 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   194.2 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   242.3 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   244.1 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   256.2 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              |   451.5 ns |  1.76 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              |   468.0 ns |  1.83 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              |   626.7 ns |  2.45 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              |   747.2 ns |  2.92 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              |   748.0 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              |   901.3 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              |   939.0 ns |  0.99 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              |   946.1 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 1,794.0 ns |  1.90 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 1,849.2 ns |  1.96 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 2,606.9 ns |  2.76 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 2,961.1 ns |  3.13 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              |   742.8 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              |   902.1 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              |   937.0 ns |  0.99 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              |   947.9 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 1,788.1 ns |  1.89 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 1,850.5 ns |  1.95 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 2,613.0 ns |  2.76 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 2,953.3 ns |  3.12 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              |   762.3 ns |  0.80 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              |   903.6 ns |  0.94 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              |   943.1 ns |  0.98 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              |   958.7 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 1,763.2 ns |  1.84 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 1,845.0 ns |  1.92 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 2,501.4 ns |  2.61 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 2,969.8 ns |  3.10 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   192.6 ns |  0.41 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   232.7 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   240.8 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              |   468.5 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              |   473.3 ns |  1.01 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              |   478.0 ns |  1.02 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              |   683.1 ns |  1.46 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              |   756.5 ns |  1.61 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   191.6 ns |  0.52 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   235.8 ns |  0.64 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   241.6 ns |  0.65 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   370.6 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              |   473.4 ns |  1.28 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              |   473.8 ns |  1.28 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              |   678.2 ns |  1.83 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              |   758.8 ns |  2.05 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   188.0 ns |  0.62 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   237.4 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   239.4 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   304.6 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              |   468.4 ns |  1.54 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              |   474.8 ns |  1.56 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              |   639.5 ns |  2.10 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              |   754.3 ns |  2.48 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              |   740.8 ns |  0.41 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              |   883.2 ns |  0.49 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              |   930.8 ns |  0.52 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 1,790.5 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 1,854.3 ns |  1.04 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 1,913.6 ns |  1.07 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 2,652.2 ns |  1.48 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 2,981.8 ns |  1.67 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              |   733.5 ns |  0.55 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              |   885.6 ns |  0.66 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              |   930.9 ns |  0.69 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 1,342.5 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 1,846.8 ns |  1.38 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 1,867.5 ns |  1.39 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 2,617.0 ns |  1.95 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 3,001.7 ns |  2.24 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              |   734.2 ns |  0.64 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              |   888.1 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              |   931.4 ns |  0.81 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 1,155.0 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 1,825.3 ns |  1.58 |    1536 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 1,915.4 ns |  1.66 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 2,717.3 ns |  2.35 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 2,965.8 ns |  2.57 |   16640 B |