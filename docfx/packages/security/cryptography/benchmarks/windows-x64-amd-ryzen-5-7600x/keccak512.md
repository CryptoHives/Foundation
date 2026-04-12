| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · Managed      | 128B         |     415.7 ns |     2.11 ns |     1.98 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128B         |     559.9 ns |     1.13 ns |     1.06 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128B         |     580.4 ns |     2.45 ns |     2.29 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128B         |     630.2 ns |     2.69 ns |     2.25 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 137B         |     405.2 ns |     1.62 ns |     1.44 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 137B         |     548.9 ns |     1.74 ns |     1.45 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 137B         |     562.4 ns |     1.76 ns |     1.64 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 137B         |     632.6 ns |     3.73 ns |     3.49 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1KB          |   2,986.2 ns |    17.71 ns |    14.79 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1KB          |   4,045.4 ns |    14.76 ns |    13.08 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1KB          |   4,161.9 ns |    11.96 ns |    10.61 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1KB          |   4,558.8 ns |    24.84 ns |    22.02 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 1025B        |   2,979.8 ns |    11.42 ns |    10.68 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 1025B        |   4,046.3 ns |    15.03 ns |    14.06 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 1025B        |   4,167.3 ns |    20.43 ns |    18.11 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 1025B        |   4,553.2 ns |    43.99 ns |    36.73 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 8KB          |  22,533.4 ns |   233.83 ns |   218.73 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 8KB          |  30,520.6 ns |   136.97 ns |   128.12 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 8KB          |  31,270.6 ns |    90.83 ns |    75.85 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 8KB          |  34,727.8 ns |   185.94 ns |   173.92 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-512 · Managed      | 128KB        | 358,614.8 ns | 2,964.79 ns | 2,773.27 ns |         - |
| TryComputeHash · Keccak-512 · AVX2         | 128KB        | 487,102.1 ns |   804.18 ns |   712.88 ns |         - |
| TryComputeHash · Keccak-512 · AVX512F      | 128KB        | 500,460.3 ns | 1,475.25 ns | 1,379.95 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle | 128KB        | 558,585.5 ns | 3,479.17 ns | 3,084.20 ns |         - |