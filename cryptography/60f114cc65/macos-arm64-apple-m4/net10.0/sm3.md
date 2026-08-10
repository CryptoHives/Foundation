| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · BouncyCastle | 128B         |     618.0 ns |     0.95 ns |     0.80 ns |         - |
| TryComputeHash · SM3 · Managed      | 128B         |     630.1 ns |     1.26 ns |     1.05 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 137B         |     619.1 ns |     0.83 ns |     0.69 ns |         - |
| TryComputeHash · SM3 · Managed      | 137B         |     631.4 ns |     1.53 ns |     1.35 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 1KB          |   3,373.4 ns |     1.74 ns |     1.45 ns |         - |
| TryComputeHash · SM3 · Managed      | 1KB          |   3,563.1 ns |    19.58 ns |    17.36 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 1025B        |   3,372.5 ns |     1.39 ns |     1.16 ns |         - |
| TryComputeHash · SM3 · Managed      | 1025B        |   3,561.1 ns |    17.37 ns |    14.50 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 8KB          |  25,331.0 ns |     8.76 ns |     7.77 ns |         - |
| TryComputeHash · SM3 · Managed      | 8KB          |  27,026.8 ns |   206.38 ns |   172.33 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · BouncyCastle | 128KB        | 402,993.6 ns |   121.53 ns |    94.89 ns |         - |
| TryComputeHash · SM3 · Managed      | 128KB        | 435,723.4 ns | 5,778.13 ns | 5,404.87 ns |         - |