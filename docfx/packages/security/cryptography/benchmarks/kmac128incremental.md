| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · IncrementalHash · OS Native    | 128B         |     324.3 ns |     1.58 ns |     1.32 ns |         - |
| ComputeMac · IncrementalHash · Managed      | 128B         |     736.9 ns |     5.14 ns |     4.81 ns |     208 B |
| ComputeMac · IncrementalHash · BouncyCastle | 128B         |   1,981.4 ns |     7.72 ns |     7.22 ns |     288 B |
|                                             |              |              |             |             |           |
| ComputeMac · IncrementalHash · OS Native    | 137B         |     324.5 ns |     1.11 ns |     0.98 ns |         - |
| ComputeMac · IncrementalHash · Managed      | 137B         |     732.7 ns |     4.27 ns |     3.78 ns |     216 B |
| ComputeMac · IncrementalHash · BouncyCastle | 137B         |   2,012.9 ns |     7.57 ns |     7.08 ns |     288 B |
|                                             |              |              |             |             |           |
| ComputeMac · IncrementalHash · OS Native    | 1KB          |   1,742.8 ns |     6.61 ns |     6.19 ns |         - |
| ComputeMac · IncrementalHash · Managed      | 1KB          |   1,975.4 ns |    11.34 ns |    10.05 ns |     320 B |
| ComputeMac · IncrementalHash · BouncyCastle | 1KB          |   3,813.8 ns |    23.64 ns |    22.12 ns |     288 B |
|                                             |              |              |             |             |           |
| ComputeMac · IncrementalHash · OS Native    | 1025B        |   1,754.4 ns |     6.59 ns |     5.84 ns |         - |
| ComputeMac · IncrementalHash · Managed      | 1025B        |   1,982.3 ns |    14.83 ns |    13.88 ns |     320 B |
| ComputeMac · IncrementalHash · BouncyCastle | 1025B        |   3,801.4 ns |    13.05 ns |    10.90 ns |     288 B |
|                                             |              |              |             |             |           |
| ComputeMac · IncrementalHash · Managed      | 8KB          |  10,382.4 ns |    80.84 ns |    75.61 ns |    1216 B |
| ComputeMac · IncrementalHash · OS Native    | 8KB          |  11,729.5 ns |    40.24 ns |    37.64 ns |         - |
| ComputeMac · IncrementalHash · BouncyCastle | 8KB          |  16,706.0 ns |    67.89 ns |    56.69 ns |     288 B |
|                                             |              |              |             |             |           |
| ComputeMac · IncrementalHash · Managed      | 128KB        | 156,083.7 ns |   462.84 ns |   410.29 ns |   16576 B |
| ComputeMac · IncrementalHash · OS Native    | 128KB        | 185,440.0 ns | 1,124.84 ns | 1,052.17 ns |         - |
| ComputeMac · IncrementalHash · BouncyCastle | 128KB        | 240,037.3 ns |   494.50 ns |   438.36 ns |     288 B |