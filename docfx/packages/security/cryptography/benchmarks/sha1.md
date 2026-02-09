| Description                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native    | 128B         |     227.8 ns |     0.96 ns |     0.90 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128B         |     434.9 ns |     1.45 ns |     1.35 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128B         |     456.4 ns |     2.25 ns |     2.11 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 137B         |     233.5 ns |     0.50 ns |     0.45 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 137B         |     437.4 ns |     1.68 ns |     1.57 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 137B         |     453.4 ns |     1.03 ns |     0.97 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1KB          |   1,096.1 ns |     3.44 ns |     3.05 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1KB          |   2,418.0 ns |    11.92 ns |    11.15 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1KB          |   2,449.2 ns |    11.50 ns |    10.76 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1025B        |   1,098.8 ns |     3.32 ns |     3.10 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1025B        |   2,420.0 ns |    13.36 ns |    12.49 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1025B        |   2,445.9 ns |     6.40 ns |     5.99 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 8KB          |   8,037.7 ns |    23.54 ns |    22.02 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 8KB          |  18,211.1 ns |    63.05 ns |    52.65 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 8KB          |  18,305.6 ns |    50.34 ns |    42.03 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 128KB        | 127,145.3 ns |   348.90 ns |   326.36 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128KB        | 289,652.4 ns | 1,753.58 ns | 1,640.30 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128KB        | 291,416.7 ns | 2,489.95 ns | 2,079.22 ns |         - |