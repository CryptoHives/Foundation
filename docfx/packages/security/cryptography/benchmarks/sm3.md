| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · Managed      | 128B         |     694.4 ns |     2.18 ns |     2.04 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128B         |     786.7 ns |     1.94 ns |     1.72 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 137B         |     697.2 ns |     2.32 ns |     2.17 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 137B         |     814.0 ns |     2.53 ns |     2.11 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1KB          |   3,854.9 ns |    11.09 ns |     9.26 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1KB          |   4,412.8 ns |    13.62 ns |    11.37 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1025B        |   3,878.1 ns |    14.23 ns |    12.61 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1025B        |   4,417.6 ns |    13.30 ns |    12.44 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 8KB          |  29,225.9 ns |   148.63 ns |   139.02 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 8KB          |  33,399.6 ns |   199.64 ns |   186.74 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 128KB        | 464,075.7 ns | 2,000.02 ns | 1,870.82 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128KB        | 531,631.9 ns | 2,292.58 ns | 2,144.48 ns |         - |