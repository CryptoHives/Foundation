| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native    | 128B         |     260.7 ns |   1.80 ns |   1.60 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128B         |     481.0 ns |   5.05 ns |   4.73 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128B         |     528.1 ns |   0.79 ns |   0.74 ns |         - |
|                                       |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native    | 137B         |     250.3 ns |   2.18 ns |   2.04 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 137B         |     486.7 ns |   0.91 ns |   0.85 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 137B         |     524.1 ns |   0.82 ns |   0.77 ns |         - |
|                                       |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native    | 1KB          |     522.2 ns |   0.33 ns |   0.26 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1KB          |   2,691.7 ns |   1.64 ns |   1.45 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1KB          |   2,849.8 ns |   7.80 ns |   6.92 ns |         - |
|                                       |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native    | 1025B        |     522.2 ns |   0.37 ns |   0.31 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1025B        |   2,687.9 ns |   3.84 ns |   3.41 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1025B        |   2,845.2 ns |   7.65 ns |   7.16 ns |         - |
|                                       |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native    | 8KB          |   2,629.9 ns |   0.37 ns |   0.35 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 8KB          |  20,276.1 ns | 172.11 ns | 160.99 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 8KB          |  21,347.4 ns |  57.49 ns |  53.78 ns |         - |
|                                       |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native    | 128KB        |  38,761.1 ns |   7.45 ns |   6.22 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128KB        | 322,922.5 ns | 915.59 ns | 856.44 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128KB        | 337,926.0 ns | 907.62 ns | 848.99 ns |         - |