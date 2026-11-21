| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Error    | StdDev   | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|---------:|---------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   215.9 ns |  0.26 ns |  0.23 ns |  0.75 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   278.8 ns |  2.73 ns |  2.42 ns |  0.97 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   286.6 ns |  0.48 ns |  0.43 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   349.4 ns |  0.32 ns |  0.28 ns |  1.22 |         - | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              |   538.0 ns |  1.43 ns |  1.27 ns |  1.88 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              |   540.4 ns |  0.80 ns |  0.62 ns |  1.89 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              |   707.1 ns |  4.99 ns |  4.43 ns |  2.47 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              |   833.7 ns |  2.92 ns |  2.28 ns |  2.91 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   216.3 ns |  0.52 ns |  0.46 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   277.4 ns |  0.73 ns |  0.64 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   283.1 ns |  0.58 ns |  0.54 ns |  1.02 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   345.0 ns |  0.66 ns |  0.55 ns |  1.24 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              |   529.7 ns |  1.99 ns |  1.76 ns |  1.91 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              |   541.2 ns |  1.16 ns |  0.97 ns |  1.95 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              |   690.2 ns |  3.09 ns |  2.41 ns |  2.49 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              |   826.2 ns |  2.54 ns |  2.12 ns |  2.98 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   215.3 ns |  0.35 ns |  0.31 ns |  0.72 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   280.7 ns |  1.12 ns |  0.99 ns |  0.94 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   297.2 ns |  0.47 ns |  0.42 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   346.1 ns |  0.86 ns |  0.72 ns |  1.16 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              |   527.5 ns |  1.05 ns |  0.94 ns |  1.77 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              |   547.8 ns |  1.49 ns |  1.33 ns |  1.84 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              |   703.1 ns |  3.29 ns |  2.92 ns |  2.37 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              |   838.6 ns |  5.89 ns |  5.51 ns |  2.82 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              |   848.6 ns |  1.76 ns |  1.47 ns |  0.73 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              | 1,109.1 ns |  2.64 ns |  2.06 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              | 1,170.5 ns | 14.65 ns | 12.98 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              | 1,367.1 ns |  3.49 ns |  3.27 ns |  1.17 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 2,031.7 ns |  8.75 ns |  6.83 ns |  1.74 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 2,147.4 ns |  9.70 ns |  8.60 ns |  1.83 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 2,833.0 ns |  6.10 ns |  5.09 ns |  2.42 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 3,301.3 ns | 19.81 ns | 17.56 ns |  2.82 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              |   849.7 ns |  1.18 ns |  0.98 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              | 1,085.4 ns |  7.73 ns |  6.45 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              | 1,103.7 ns |  3.75 ns |  3.32 ns |  1.02 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              | 1,403.0 ns |  3.99 ns |  3.54 ns |  1.29 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 2,085.5 ns |  5.70 ns |  4.76 ns |  1.92 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 2,174.7 ns |  6.59 ns |  6.16 ns |  2.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 2,947.2 ns | 42.90 ns | 38.03 ns |  2.72 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 3,274.3 ns |  3.82 ns |  3.19 ns |  3.02 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              |   845.4 ns |  2.25 ns |  1.76 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              | 1,073.4 ns |  4.39 ns |  3.89 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              | 1,121.0 ns |  3.96 ns |  3.09 ns |  1.04 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              | 1,377.1 ns |  2.59 ns |  2.16 ns |  1.28 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 2,043.1 ns | 20.48 ns | 19.16 ns |  1.90 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 2,391.2 ns | 32.62 ns | 30.51 ns |  2.23 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 2,814.6 ns | 38.51 ns | 34.14 ns |  2.62 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 3,308.6 ns | 45.26 ns | 37.79 ns |  3.08 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   217.0 ns |  0.40 ns |  0.35 ns |  0.37 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   290.1 ns |  2.01 ns |  1.57 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   347.2 ns |  0.65 ns |  0.58 ns |  0.60 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              |   546.8 ns |  1.66 ns |  1.38 ns |  0.94 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              |   558.9 ns |  2.37 ns |  2.10 ns |  0.96 |     384 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              |   580.0 ns |  3.56 ns |  3.33 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              |   709.1 ns |  3.73 ns |  3.11 ns |  1.22 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              |   836.9 ns |  5.81 ns |  5.43 ns |  1.44 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   224.3 ns |  0.67 ns |  0.59 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   285.2 ns |  0.85 ns |  0.76 ns |  0.65 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   346.3 ns |  0.28 ns |  0.24 ns |  0.79 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   440.8 ns |  1.31 ns |  1.16 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              |   546.9 ns |  1.29 ns |  1.08 ns |  1.24 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              |   556.1 ns |  2.66 ns |  2.36 ns |  1.26 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              |   740.1 ns |  6.42 ns |  6.00 ns |  1.68 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              |   835.5 ns |  3.36 ns |  2.98 ns |  1.90 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   219.8 ns |  0.25 ns |  0.21 ns |  0.59 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   282.9 ns |  0.53 ns |  0.47 ns |  0.75 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   350.1 ns |  1.88 ns |  1.57 ns |  0.93 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   375.4 ns |  1.23 ns |  1.09 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              |   543.9 ns |  2.36 ns |  2.09 ns |  1.45 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              |   547.2 ns |  1.20 ns |  0.94 ns |  1.46 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              |   759.1 ns |  1.51 ns |  1.26 ns |  2.02 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              |   834.0 ns |  2.19 ns |  1.83 ns |  2.22 |    4032 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              |   851.4 ns |  1.87 ns |  1.66 ns |  0.38 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              | 1,108.3 ns |  2.31 ns |  1.93 ns |  0.49 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              | 1,401.7 ns |  2.50 ns |  2.21 ns |  0.62 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 2,133.2 ns | 16.11 ns | 14.29 ns |  0.94 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 2,171.5 ns |  7.19 ns |  6.38 ns |  0.96 |    1536 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 2,268.9 ns |  5.80 ns |  5.14 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 3,002.0 ns | 34.47 ns | 32.25 ns |  1.32 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 3,513.5 ns | 14.28 ns | 12.66 ns |  1.55 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              |   850.9 ns |  1.56 ns |  1.39 ns |  0.50 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              | 1,117.6 ns |  2.74 ns |  2.14 ns |  0.66 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              | 1,375.6 ns |  2.73 ns |  2.42 ns |  0.81 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 1,705.6 ns |  5.50 ns |  4.88 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 2,124.7 ns |  8.72 ns |  7.28 ns |  1.25 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 2,158.1 ns |  4.31 ns |  3.36 ns |  1.27 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 3,049.9 ns |  9.19 ns |  8.15 ns |  1.79 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 3,330.9 ns |  7.41 ns |  6.57 ns |  1.95 |   16128 B | 
|                                                         |              |            |                |            |          |          |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              |   850.3 ns |  1.63 ns |  1.36 ns |  0.58 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              | 1,112.4 ns |  2.00 ns |  1.67 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              | 1,411.0 ns |  4.19 ns |  3.92 ns |  0.97 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 1,461.7 ns |  4.72 ns |  4.18 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 2,140.8 ns | 20.02 ns | 18.73 ns |  1.46 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 2,197.9 ns |  3.44 ns |  2.87 ns |  1.50 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 2,952.7 ns |  5.51 ns |  4.60 ns |  2.02 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 3,276.9 ns | 18.79 ns | 17.58 ns |  2.24 |   16128 B |