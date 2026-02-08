| Description                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native    | 128B         |     227.6 ns |     1.15 ns |     1.08 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128B         |     438.5 ns |     2.07 ns |     1.93 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128B         |     456.8 ns |     1.57 ns |     1.39 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 137B         |     227.6 ns |     1.02 ns |     0.95 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 137B         |     436.3 ns |     1.51 ns |     1.41 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 137B         |     454.4 ns |     1.21 ns |     1.13 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1KB          |   1,100.3 ns |     5.20 ns |     4.86 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1KB          |   2,422.6 ns |    11.57 ns |    10.82 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1KB          |   2,450.0 ns |     7.56 ns |     6.70 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1025B        |   1,098.2 ns |     4.44 ns |     4.16 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1025B        |   2,412.4 ns |     6.99 ns |     6.54 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1025B        |   2,445.6 ns |    10.55 ns |     9.35 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 8KB          |   8,074.5 ns |    40.21 ns |    35.65 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 8KB          |  18,300.1 ns |   125.33 ns |   117.23 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 8KB          |  18,365.9 ns |    94.27 ns |    88.18 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 128KB        | 127,604.9 ns |   586.09 ns |   548.23 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128KB        | 289,428.4 ns | 1,139.04 ns | 1,065.46 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128KB        | 291,174.8 ns | 1,719.10 ns | 1,608.05 ns |         - |