| Description                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native    | 128B         |     228.4 ns |     0.75 ns |     0.70 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128B         |     441.7 ns |     1.51 ns |     1.41 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128B         |     455.4 ns |     2.53 ns |     2.37 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 137B         |     226.8 ns |     0.62 ns |     0.55 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 137B         |     439.0 ns |     1.81 ns |     1.70 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 137B         |     452.8 ns |     1.66 ns |     1.55 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1KB          |   1,098.1 ns |     5.82 ns |     5.44 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1KB          |   2,426.2 ns |     9.21 ns |     8.62 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1KB          |   2,447.8 ns |     7.84 ns |     7.34 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1025B        |   1,097.4 ns |     5.38 ns |     5.03 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1025B        |   2,419.9 ns |     8.67 ns |     6.77 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1025B        |   2,449.6 ns |    15.64 ns |    14.63 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 8KB          |   8,029.1 ns |    10.25 ns |     8.01 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 8KB          |  18,214.6 ns |    50.03 ns |    41.78 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 8KB          |  18,331.6 ns |    64.63 ns |    60.46 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 128KB        | 127,393.9 ns |   355.35 ns |   332.39 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128KB        | 290,083.7 ns | 1,440.77 ns | 1,347.69 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128KB        | 291,925.0 ns |   902.88 ns |   800.38 ns |         - |