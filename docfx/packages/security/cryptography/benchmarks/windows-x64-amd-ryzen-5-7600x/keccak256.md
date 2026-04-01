| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · Managed      | 128B         |     211.1 ns |     0.99 ns |     0.92 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128B         |     281.9 ns |     1.43 ns |     1.27 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128B         |     290.0 ns |     0.61 ns |     0.57 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128B         |     329.4 ns |     2.01 ns |     1.88 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 137B         |     461.2 ns |     1.73 ns |     1.61 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 137B         |     610.6 ns |     1.14 ns |     1.06 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 137B         |     625.8 ns |     3.63 ns |     3.40 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 137B         |     629.5 ns |     1.51 ns |     1.34 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1KB          |   1,609.0 ns |     4.48 ns |     3.74 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1KB          |   2,193.9 ns |     6.43 ns |     6.01 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1KB          |   2,257.0 ns |     5.06 ns |     4.73 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1KB          |   2,456.4 ns |    14.32 ns |    13.39 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 1025B        |   1,611.0 ns |     5.68 ns |     5.32 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 1025B        |   2,196.1 ns |     9.82 ns |     8.70 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 1025B        |   2,255.8 ns |     4.04 ns |     3.78 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 1025B        |   2,447.7 ns |    13.35 ns |    11.84 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 8KB          |  12,023.9 ns |    43.01 ns |    33.58 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 8KB          |  16,455.3 ns |    38.99 ns |    36.47 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 8KB          |  16,902.9 ns |    49.90 ns |    44.24 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 8KB          |  18,508.8 ns |   102.73 ns |    91.07 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-256 · Managed      | 128KB        | 189,312.2 ns |   608.44 ns |   539.36 ns |         - |
| TryComputeHash · Keccak-256 · AVX2         | 128KB        | 259,226.8 ns |   538.46 ns |   503.67 ns |         - |
| TryComputeHash · Keccak-256 · AVX512F      | 128KB        | 266,411.8 ns | 1,337.70 ns | 1,117.04 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128KB        | 291,838.0 ns | 1,090.34 ns |   966.55 ns |         - |