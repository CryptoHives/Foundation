| Description                                 | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128B         |     163.6 ns |      2.62 ns |      2.45 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128B         |     167.0 ns |      2.29 ns |      2.03 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128B         |     170.1 ns |      2.20 ns |      2.05 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128B         |     171.6 ns |      3.41 ns |      3.93 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128B         |     620.3 ns |     11.68 ns |     12.98 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 137B         |     245.8 ns |      4.93 ns |      6.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 137B         |     248.6 ns |      4.64 ns |      4.34 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 137B         |     252.2 ns |      4.90 ns |      4.58 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 137B         |     254.4 ns |      2.65 ns |      2.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 137B         |     925.6 ns |     17.20 ns |     16.09 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1KB          |   1,238.4 ns |      6.67 ns |      5.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1KB          |   1,249.6 ns |     16.04 ns |     14.22 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1KB          |   1,261.5 ns |     24.49 ns |     22.91 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1KB          |   1,291.1 ns |     25.50 ns |     23.86 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1KB          |   4,847.6 ns |     96.28 ns |    141.12 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1025B        |   1,323.2 ns |     18.23 ns |     17.05 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1025B        |   1,325.8 ns |     21.09 ns |     18.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1025B        |   1,329.7 ns |     17.24 ns |     15.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1025B        |   1,352.8 ns |     11.58 ns |      9.04 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1025B        |   5,140.9 ns |    101.05 ns |    120.29 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 8KB          |  10,017.1 ns |    199.27 ns |    195.71 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 8KB          |  10,065.4 ns |    200.26 ns |    205.65 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 8KB          |  10,106.4 ns |    197.75 ns |    341.12 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 8KB          |  10,260.6 ns |    155.21 ns |    137.59 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 8KB          |  39,579.9 ns |    776.06 ns |  1,338.67 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128KB        | 159,927.2 ns |  2,391.88 ns |  2,237.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128KB        | 160,064.2 ns |  3,163.61 ns |  2,959.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128KB        | 161,897.3 ns |  3,208.98 ns |  3,820.06 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128KB        | 164,015.7 ns |  2,791.75 ns |  2,611.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128KB        | 629,794.4 ns | 11,517.18 ns | 15,764.85 ns |         - |