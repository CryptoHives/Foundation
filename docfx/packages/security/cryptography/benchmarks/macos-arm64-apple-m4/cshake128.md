| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE128 · BouncyCastle | 128B         |     180.6 ns |     0.87 ns |     0.81 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 128B         |     263.0 ns |     3.16 ns |     2.96 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 137B         |     180.4 ns |     0.75 ns |     0.70 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 137B         |     244.0 ns |     2.93 ns |     2.74 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1KB          |   1,122.1 ns |     0.68 ns |     0.57 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 1KB          |   1,407.2 ns |     6.56 ns |     6.13 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1025B        |   1,117.6 ns |     1.26 ns |     0.99 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 1025B        |   1,402.1 ns |     6.56 ns |     6.14 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 8KB          |   7,698.3 ns |     6.80 ns |     5.31 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 8KB          |   7,933.8 ns |    11.49 ns |    10.75 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128KB        | 122,753.4 ns | 1,120.55 ns | 1,048.17 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 128KB        | 125,003.6 ns |   176.54 ns |   165.14 ns |         - |