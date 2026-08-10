| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · Managed      | 128B         |     402.4 ns |     1.96 ns |     1.84 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128B         |     549.6 ns |     0.94 ns |     0.88 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128B         |     566.7 ns |     1.54 ns |     1.44 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128B         |     625.9 ns |     2.26 ns |     2.12 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 137B         |     399.1 ns |     1.11 ns |     0.99 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 137B         |     545.8 ns |     1.67 ns |     1.56 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 137B         |     568.2 ns |     1.27 ns |     1.12 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 137B         |     624.9 ns |     2.09 ns |     1.86 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1KB          |   2,936.7 ns |    12.89 ns |    12.06 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1KB          |   4,029.4 ns |    13.89 ns |    11.60 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1KB          |   4,154.9 ns |    14.25 ns |    12.63 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1KB          |   4,509.7 ns |     6.93 ns |     5.41 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1025B        |   2,937.1 ns |    16.07 ns |    15.03 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1025B        |   4,040.1 ns |    12.55 ns |    11.74 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1025B        |   4,160.6 ns |    13.79 ns |    12.90 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1025B        |   4,499.2 ns |    18.01 ns |    15.97 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 8KB          |  22,091.8 ns |   103.18 ns |    91.46 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 8KB          |  30,444.7 ns |    52.96 ns |    49.54 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 8KB          |  31,330.5 ns |    63.21 ns |    59.12 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 8KB          |  34,086.9 ns |    99.24 ns |    82.87 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 128KB        | 353,099.0 ns | 1,907.87 ns | 1,784.63 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128KB        | 485,847.9 ns |   574.51 ns |   509.29 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128KB        | 500,355.1 ns | 1,233.11 ns | 1,153.45 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128KB        | 553,680.8 ns | 2,674.98 ns | 2,371.30 ns |         - |