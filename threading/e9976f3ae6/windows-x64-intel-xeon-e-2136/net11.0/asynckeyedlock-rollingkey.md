| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Error    | StdDev    | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|---------:|----------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   449.2 ns |  1.80 ns |   3.30 ns |  0.73 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   585.7 ns |  0.85 ns |   1.54 ns |  0.96 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   612.9 ns |  1.70 ns |   3.06 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   617.2 ns |  1.52 ns |   2.75 ns |  1.01 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              | 1,197.7 ns |  2.82 ns |   5.30 ns |  1.95 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              | 1,322.7 ns |  3.34 ns |   6.36 ns |  2.16 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              | 1,498.0 ns |  5.01 ns |   9.29 ns |  2.44 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              | 1,956.1 ns |  5.74 ns |  10.21 ns |  3.19 |    4032 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   450.9 ns |  1.55 ns |   2.88 ns |  0.73 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   583.8 ns |  1.01 ns |   1.85 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   617.1 ns |  1.63 ns |   3.11 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   619.6 ns |  1.36 ns |   2.48 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              | 1,198.8 ns |  3.27 ns |   5.90 ns |  1.94 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              | 1,316.3 ns |  1.78 ns |   3.26 ns |  2.13 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              | 1,505.1 ns |  6.25 ns |  11.90 ns |  2.44 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              | 1,943.3 ns |  3.19 ns |   5.83 ns |  3.15 |    4032 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   449.0 ns |  0.97 ns |   1.82 ns |  0.73 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   589.7 ns |  2.86 ns |   5.22 ns |  0.97 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   611.0 ns |  2.39 ns |   4.49 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   617.9 ns |  2.70 ns |   4.94 ns |  1.01 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              | 1,195.9 ns |  1.16 ns |   2.04 ns |  1.96 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              | 1,326.1 ns |  5.84 ns |  10.97 ns |  2.17 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              | 1,500.4 ns |  9.28 ns |  16.97 ns |  2.46 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              | 1,943.9 ns |  3.43 ns |   6.26 ns |  3.18 |    4032 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              | 1,736.2 ns |  4.01 ns |   7.23 ns |  0.72 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              | 2,290.8 ns |  8.56 ns |  15.44 ns |  0.96 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              | 2,398.7 ns | 11.23 ns |  20.81 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              | 2,402.7 ns |  5.04 ns |   9.35 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 4,742.4 ns | 10.12 ns |  19.00 ns |  1.98 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 5,178.3 ns |  5.09 ns |   9.31 ns |  2.16 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 6,013.1 ns | 38.70 ns |  72.70 ns |  2.51 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 7,717.4 ns | 17.87 ns |  33.13 ns |  3.22 |   16128 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              | 1,734.1 ns |  4.96 ns |   9.31 ns |  0.71 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              | 2,286.6 ns |  8.36 ns |  15.07 ns |  0.93 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              | 2,407.9 ns |  5.17 ns |   9.84 ns |  0.98 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              | 2,450.7 ns | 31.47 ns |  64.28 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 4,732.1 ns |  5.97 ns |  11.21 ns |  1.93 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 5,223.5 ns | 10.06 ns |  18.89 ns |  2.13 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 5,974.7 ns | 22.97 ns |  42.57 ns |  2.44 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 7,822.6 ns | 89.18 ns | 169.68 ns |  3.19 |   16128 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              | 1,746.4 ns | 11.46 ns |  21.80 ns |  0.73 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              | 2,277.4 ns |  2.97 ns |   5.21 ns |  0.95 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              | 2,405.5 ns |  5.64 ns |  10.32 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              | 2,406.0 ns |  9.21 ns |  17.06 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 4,759.4 ns | 20.00 ns |  36.07 ns |  1.98 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 5,187.2 ns |  4.74 ns |   8.67 ns |  2.16 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 5,992.7 ns | 39.38 ns |  73.97 ns |  2.49 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 7,741.9 ns | 13.72 ns |  25.77 ns |  3.22 |   16128 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   461.8 ns |  1.20 ns |   2.26 ns |  0.35 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   604.8 ns |  4.53 ns |   8.62 ns |  0.46 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   612.8 ns |  0.39 ns |   0.72 ns |  0.46 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              | 1,206.0 ns |  3.09 ns |   5.64 ns |  0.91 |    1152 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              | 1,326.9 ns |  6.36 ns |  11.94 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              | 1,335.1 ns |  3.87 ns |   7.28 ns |  1.01 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              | 1,529.0 ns |  2.93 ns |   5.36 ns |  1.15 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              | 1,959.2 ns | 12.38 ns |  22.64 ns |  1.48 |    4032 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   454.5 ns |  0.87 ns |   1.58 ns |  0.46 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   592.8 ns |  0.79 ns |   1.43 ns |  0.60 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   613.6 ns |  0.48 ns |   0.90 ns |  0.62 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              |   992.7 ns |  4.09 ns |   7.78 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              | 1,199.6 ns |  1.58 ns |   2.93 ns |  1.21 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              | 1,333.0 ns |  4.72 ns |   8.63 ns |  1.34 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              | 1,511.7 ns |  3.47 ns |   6.52 ns |  1.52 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              | 1,950.1 ns |  6.91 ns |  12.81 ns |  1.96 |    4032 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   460.8 ns |  9.91 ns |  17.86 ns |  0.57 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   590.4 ns |  0.96 ns |   1.71 ns |  0.73 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   614.7 ns |  1.20 ns |   2.09 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   808.1 ns |  2.08 ns |   3.86 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              | 1,207.7 ns |  5.84 ns |  11.11 ns |  1.49 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              | 1,331.0 ns |  4.70 ns |   8.94 ns |  1.65 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              | 1,534.1 ns |  7.75 ns |  14.36 ns |  1.90 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              | 1,951.6 ns |  4.46 ns |   8.15 ns |  2.41 |    4032 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              | 1,768.2 ns |  7.62 ns |  13.74 ns |  0.34 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              | 2,338.7 ns |  6.44 ns |  11.94 ns |  0.45 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              | 2,404.9 ns |  3.78 ns |   7.18 ns |  0.46 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 4,782.2 ns | 17.57 ns |  32.12 ns |  0.91 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 5,230.3 ns |  5.06 ns |   9.50 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 5,234.2 ns |  7.49 ns |  14.06 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 6,133.0 ns | 49.28 ns |  93.77 ns |  1.17 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 7,758.1 ns | 32.30 ns |  61.45 ns |  1.48 |   16128 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              | 1,761.1 ns |  9.89 ns |  18.08 ns |  0.45 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              | 2,353.9 ns | 31.06 ns |  59.84 ns |  0.61 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              | 2,420.2 ns |  5.98 ns |  11.24 ns |  0.62 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 3,884.5 ns | 32.34 ns |  61.53 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 4,745.3 ns |  5.77 ns |  10.40 ns |  1.22 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 5,237.3 ns |  9.36 ns |  17.57 ns |  1.35 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 6,039.2 ns | 15.18 ns |  28.89 ns |  1.56 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 7,753.9 ns | 34.98 ns |  64.83 ns |  2.00 |   16128 B | 
|                                                         |              |            |                |            |          |           |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              | 1,737.5 ns |  1.66 ns |   3.04 ns |  0.55 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              | 2,399.5 ns | 33.71 ns |  70.36 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              | 2,425.7 ns | 11.63 ns |  21.55 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 3,174.5 ns | 29.50 ns |  53.20 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 4,749.6 ns |  6.64 ns |  12.13 ns |  1.50 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 5,255.6 ns | 26.03 ns |  49.52 ns |  1.66 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 6,118.6 ns | 40.05 ns |  74.24 ns |  1.93 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 7,761.9 ns | 27.31 ns |  51.97 ns |  2.45 |   16128 B |