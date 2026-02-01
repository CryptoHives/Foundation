| Description                                  | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128B         |       113.9 ns |     0.40 ns |     0.36 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 128B         |       385.8 ns |     1.62 ns |     1.51 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128B         |       578.5 ns |     1.59 ns |     1.32 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128B         |     1,267.6 ns |     7.09 ns |     6.63 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 137B         |       160.3 ns |     0.48 ns |     0.45 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 137B         |       447.4 ns |     1.27 ns |     1.19 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 137B         |       843.6 ns |     3.69 ns |     3.45 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 137B         |     1,894.7 ns |     9.58 ns |     8.96 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1KB          |       763.8 ns |     1.47 ns |     1.31 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 1KB          |     1,299.1 ns |     2.10 ns |     1.97 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1KB          |     4,223.0 ns |    14.97 ns |    14.01 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1KB          |     9,697.9 ns |    29.10 ns |    25.80 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1025B        |       868.1 ns |     2.17 ns |     1.82 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 1025B        |     1,451.8 ns |     4.22 ns |     3.74 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1025B        |     4,809.6 ns |    13.86 ns |    12.97 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1025B        |    10,656.9 ns |    40.92 ns |    34.17 ns |     168 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 8KB          |     1,194.4 ns |     8.74 ns |     7.30 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 8KB          |    10,342.4 ns |    29.21 ns |    27.32 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 8KB          |    35,551.2 ns |   249.25 ns |   233.15 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 8KB          |    80,067.6 ns |   302.25 ns |   282.72 ns |     504 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128KB        |    14,298.0 ns |    50.12 ns |    44.43 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 128KB        |   168,508.7 ns |   315.41 ns |   295.03 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128KB        |   570,334.1 ns | 1,265.17 ns |   987.76 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128KB        | 1,318,919.4 ns | 6,010.79 ns | 5,622.49 ns |    7224 B |