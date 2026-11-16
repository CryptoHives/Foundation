| Description                                             | KeySpaceSize | WindowSize | AdvanceDivisor | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------- |----------- |--------------- |-----------:|------:|----------:|
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 1              |   545.4 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 1              |   590.6 ns |  0.83 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 1              |   710.8 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 1              |   791.4 ns |  1.11 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 1              | 1,303.8 ns |  1.83 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 1              | 1,516.1 ns |  2.13 |    1600 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 1              | 1,517.6 ns |  2.14 |     384 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 1              | 2,029.6 ns |  2.86 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 2              |   546.9 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 2              |   591.9 ns |  0.84 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 2              |   701.8 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 2              |   778.4 ns |  1.11 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 2              | 1,298.9 ns |  1.85 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 2              | 1,512.8 ns |  2.16 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 2              | 1,527.9 ns |  2.18 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 2              | 2,033.8 ns |  2.90 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 8          | 4              |   545.2 ns |  0.77 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 8          | 4              |   593.9 ns |  0.84 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 8          | 4              |   704.2 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 8          | 4              |   783.2 ns |  1.11 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 8          | 4              | 1,290.7 ns |  1.83 |    1152 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 8          | 4              | 1,510.7 ns |  2.15 |    1600 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 8          | 4              | 1,514.0 ns |  2.15 |     384 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 8          | 4              | 2,056.4 ns |  2.92 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 1              | 2,122.3 ns |  0.78 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 1              | 2,304.2 ns |  0.85 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 1              | 2,714.9 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 1              | 3,082.3 ns |  1.14 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 1              | 5,093.5 ns |  1.88 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 1              | 5,968.3 ns |  2.20 |    6400 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 1              | 6,074.2 ns |  2.24 |    1536 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 1              | 8,110.8 ns |  2.99 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 2              | 2,131.6 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 2              | 2,309.1 ns |  0.82 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 2              | 2,801.4 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 2              | 3,083.5 ns |  1.10 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 2              | 5,107.8 ns |  1.82 |    4608 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 2              | 5,985.2 ns |  2.14 |    6400 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 2              | 6,000.6 ns |  2.14 |    1536 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 2              | 7,985.2 ns |  2.85 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64           | 32         | 4              | 2,144.8 ns |  0.76 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 64           | 32         | 4              | 2,308.6 ns |  0.82 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 64           | 32         | 4              | 2,811.8 ns |  1.00 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 64           | 32         | 4              | 3,074.2 ns |  1.09 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 64           | 32         | 4              | 5,229.4 ns |  1.86 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 64           | 32         | 4              | 5,994.9 ns |  2.13 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 64           | 32         | 4              | 6,024.0 ns |  2.14 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 64           | 32         | 4              | 8,072.0 ns |  2.87 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 1              |   560.1 ns |  0.39 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 1              |   608.5 ns |  0.43 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 1              |   793.0 ns |  0.56 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 1              | 1,302.0 ns |  0.92 |    1152 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 1              | 1,422.5 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 1              | 1,523.3 ns |  1.07 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 1              | 1,572.1 ns |  1.11 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 1              | 2,037.6 ns |  1.43 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 2              |   558.6 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 2              |   602.3 ns |  0.55 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 2              |   781.9 ns |  0.72 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 2              | 1,088.8 ns |  1.00 |     192 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 2              | 1,309.0 ns |  1.20 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 2              | 1,520.1 ns |  1.40 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 2              | 1,532.8 ns |  1.41 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 2              | 2,046.5 ns |  1.88 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 8          | 4              |   548.6 ns |  0.61 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 8          | 4              |   606.5 ns |  0.67 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 8          | 4              |   781.8 ns |  0.86 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 8          | 4              |   906.3 ns |  1.00 |      96 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 8          | 4              | 1,313.9 ns |  1.45 |    1152 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 8          | 4              | 1,520.0 ns |  1.68 |     384 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 8          | 4              | 1,533.7 ns |  1.69 |    1600 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 8          | 4              | 2,029.0 ns |  2.24 |    4160 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 1              | 2,198.2 ns |  0.39 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 1              | 2,390.5 ns |  0.43 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 1              | 3,081.3 ns |  0.55 |         - | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 1              | 5,082.3 ns |  0.91 |    4608 B | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 1              | 5,613.2 ns |  1.00 |    1536 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 1              | 6,071.4 ns |  1.08 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 1              | 6,103.1 ns |  1.09 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 1              | 8,142.5 ns |  1.45 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 2              | 2,174.0 ns |  0.51 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 2              | 2,336.0 ns |  0.54 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 2              | 3,086.9 ns |  0.72 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 2              | 4,294.1 ns |  1.00 |     768 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 2              | 5,149.8 ns |  1.20 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 2              | 6,075.2 ns |  1.41 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 2              | 6,133.8 ns |  1.43 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 2              | 8,148.3 ns |  1.90 |   16640 B | 
|                                                         |              |            |                |            |       |           | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1024         | 32         | 4              | 2,176.0 ns |  0.61 |         - | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores (Striped) | 1024         | 32         | 4              | 2,329.8 ns |  0.65 |         - | 
| RollingKey · AsyncKeyedLock · AsyncUtilities (Striped)  | 1024         | 32         | 4              | 3,078.2 ns |  0.86 |         - | 
| RollingKey · AsyncKeyedLock · Pooled                    | 1024         | 32         | 4              | 3,567.0 ns |  1.00 |     384 B | 
| RollingKey · AsyncKeyedLock · RefImpl                   | 1024         | 32         | 4              | 5,147.9 ns |  1.44 |    4608 B | 
| RollingKey · AsyncKeyedLock · AsyncKeyedLock            | 1024         | 32         | 4              | 6,074.8 ns |  1.70 |    1536 B | 
| RollingKey · AsyncKeyedLock · KeyedSemaphores           | 1024         | 32         | 4              | 6,103.8 ns |  1.71 |    6400 B | 
| RollingKey · AsyncKeyedLock · Dao.IndividualLock        | 1024         | 32         | 4              | 8,145.5 ns |  2.28 |   16640 B |