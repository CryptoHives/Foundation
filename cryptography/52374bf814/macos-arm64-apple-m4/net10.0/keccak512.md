| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · BouncyCastle | 128B         |     332.0 ns |     1.61 ns |     1.35 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 128B         |     339.6 ns |     1.09 ns |     1.02 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 137B         |     325.5 ns |     0.82 ns |     0.73 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 137B         |     326.6 ns |     0.47 ns |     0.44 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 1KB          |   2,294.5 ns |    13.52 ns |    11.99 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 1KB          |   2,465.2 ns |     6.21 ns |     5.50 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 1025B        |   2,293.8 ns |     7.79 ns |     7.28 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 1025B        |   2,471.1 ns |     3.73 ns |     3.49 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 8KB          |  17,241.7 ns |    79.50 ns |    74.36 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 8KB          |  17,902.8 ns |    14.14 ns |    11.80 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 128KB        | 276,515.7 ns | 1,643.96 ns | 1,457.33 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 128KB        | 285,609.2 ns |   310.91 ns |   275.61 ns |         - |