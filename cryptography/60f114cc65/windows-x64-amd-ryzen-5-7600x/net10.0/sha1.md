| Description                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native    | 128B         |     229.2 ns |     1.10 ns |     0.92 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128B         |     438.5 ns |     1.99 ns |     1.77 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128B         |     457.8 ns |     2.01 ns |     1.68 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 137B         |     227.9 ns |     1.14 ns |     1.01 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 137B         |     438.9 ns |     1.87 ns |     1.66 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 137B         |     455.3 ns |     1.84 ns |     1.72 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1KB          |   1,101.7 ns |     7.39 ns |     6.17 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1KB          |   2,439.1 ns |    18.72 ns |    17.51 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1KB          |   2,458.5 ns |    12.13 ns |    10.75 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1025B        |   1,102.2 ns |     5.61 ns |     5.24 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1025B        |   2,432.2 ns |    16.83 ns |    14.92 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1025B        |   2,457.8 ns |    12.24 ns |     9.56 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 8KB          |   8,097.2 ns |    38.90 ns |    34.49 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 8KB          |  18,347.5 ns |   119.05 ns |   111.35 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 8KB          |  18,432.2 ns |   105.03 ns |    98.24 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 128KB        | 127,875.0 ns |   456.97 ns |   405.09 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128KB        | 290,954.6 ns | 1,626.67 ns | 1,521.59 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128KB        | 293,075.3 ns | 2,814.77 ns | 2,632.94 ns |         - |