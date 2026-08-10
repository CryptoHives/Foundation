| Description                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native    | 128B         |     268.5 ns |     1.77 ns |     1.57 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128B         |     484.1 ns |     1.26 ns |     0.98 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128B         |     528.5 ns |     0.78 ns |     0.69 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 137B         |     255.5 ns |     2.69 ns |     2.39 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 137B         |     488.7 ns |     2.59 ns |     2.02 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 137B         |     524.0 ns |     0.49 ns |     0.43 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1KB          |     525.3 ns |     0.93 ns |     0.82 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1KB          |   2,700.8 ns |     3.21 ns |     3.00 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1KB          |   2,850.0 ns |     6.20 ns |     5.80 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 1025B        |     523.7 ns |     1.71 ns |     1.33 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 1025B        |   2,691.3 ns |     3.89 ns |     3.45 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 1025B        |   2,844.0 ns |    11.49 ns |    10.18 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 8KB          |   2,632.5 ns |     2.37 ns |     2.10 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 8KB          |  20,328.0 ns |   112.22 ns |    99.48 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 8KB          |  21,302.8 ns |    77.97 ns |    69.12 ns |         - |
|                                       |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native    | 128KB        |  38,798.5 ns |    40.70 ns |    33.99 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle | 128KB        | 320,712.7 ns | 2,903.44 ns | 2,573.83 ns |         - |
| TryComputeHash · SHA-1 · Managed      | 128KB        | 336,643.0 ns | 1,221.10 ns | 1,082.47 ns |         - |