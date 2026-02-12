| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 128B         |     101.7 ns |     1.84 ns |     1.73 ns |     101.0 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 128B         |     117.3 ns |     1.01 ns |     0.84 ns |     117.3 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 128B         |     371.3 ns |     5.46 ns |     4.84 ns |     371.1 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 137B         |     188.1 ns |     1.55 ns |     1.29 ns |     188.1 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 137B         |     209.6 ns |     2.98 ns |     2.64 ns |     208.9 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 137B         |     733.3 ns |    11.64 ns |    10.89 ns |     730.3 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 1KB          |     718.7 ns |    14.15 ns |    14.53 ns |     710.2 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 1KB          |     809.9 ns |    16.02 ns |    26.77 ns |     793.1 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 1KB          |   2,858.5 ns |    19.61 ns |    15.31 ns |   2,856.2 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 1025B        |     795.1 ns |     4.80 ns |     3.75 ns |     795.0 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 1025B        |     892.1 ns |     5.95 ns |     4.97 ns |     892.5 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 1025B        |   3,247.6 ns |    62.03 ns |    58.02 ns |   3,272.2 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 8KB          |   5,731.8 ns |   112.41 ns |   138.04 ns |   5,727.1 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 8KB          |   6,470.2 ns |   128.09 ns |   234.22 ns |   6,387.4 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 8KB          |  22,835.7 ns |   382.39 ns |   357.69 ns |  22,710.2 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 128KB        |  90,654.3 ns | 1,619.08 ns | 1,514.48 ns |  89,858.8 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 128KB        | 102,047.4 ns | 1,267.48 ns | 1,244.84 ns | 101,892.2 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 128KB        | 376,342.3 ns | 5,848.16 ns | 5,470.37 ns | 377,698.6 ns |         - |