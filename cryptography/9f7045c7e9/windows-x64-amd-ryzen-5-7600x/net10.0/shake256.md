| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128B         |     279.0 ns |     4.49 ns |     4.20 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128B         |     352.1 ns |     1.48 ns |     1.23 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128B         |     359.4 ns |     2.81 ns |     2.63 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 128B         |     365.1 ns |     1.98 ns |     1.86 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 128B         |     385.4 ns |     2.39 ns |     2.12 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 137B         |     518.1 ns |     4.40 ns |     4.12 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 137B         |     624.1 ns |     4.00 ns |     3.34 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 137B         |     657.2 ns |     2.10 ns |     1.86 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 137B         |     668.3 ns |     2.20 ns |     1.84 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 137B         |     689.5 ns |     1.47 ns |     1.22 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1KB          |   1,671.4 ns |     6.55 ns |     6.13 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 1KB          |   2,035.9 ns |    13.59 ns |    12.05 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1KB          |   2,259.2 ns |     8.94 ns |     6.98 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 1KB          |   2,358.0 ns |     9.87 ns |     9.23 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1KB          |   2,493.2 ns |    16.75 ns |    13.99 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1025B        |   1,671.3 ns |     6.95 ns |     6.50 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 1025B        |   2,027.8 ns |    14.00 ns |    13.09 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1025B        |   2,267.5 ns |     8.44 ns |     7.05 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 1025B        |   2,354.1 ns |     7.16 ns |     5.98 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1025B        |   2,484.6 ns |    10.75 ns |    10.06 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 8KB          |  12,117.4 ns |    73.97 ns |    69.19 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 8KB          |  14,541.5 ns |   151.92 ns |   142.11 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 8KB          |  16,577.7 ns |    63.91 ns |    53.37 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 8KB          |  17,256.3 ns |    40.58 ns |    35.98 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 8KB          |  18,595.7 ns |   127.87 ns |   113.35 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128KB        | 190,218.9 ns |   694.80 ns |   649.92 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 128KB        | 226,332.3 ns |   752.03 ns |   703.45 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128KB        | 259,860.6 ns | 1,119.48 ns |   934.82 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 128KB        | 271,158.9 ns |   818.13 ns |   765.28 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128KB        | 294,207.2 ns | 1,705.68 ns | 1,424.32 ns |     176 B |