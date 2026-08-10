| Description                                  | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128B         |       113.9 ns |     0.33 ns |     0.29 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 128B         |       394.7 ns |     7.36 ns |     6.88 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128B         |       578.7 ns |     3.92 ns |     3.47 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128B         |     1,269.4 ns |     8.29 ns |     7.75 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 137B         |       159.6 ns |     0.71 ns |     0.63 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 137B         |       447.9 ns |     3.69 ns |     3.45 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 137B         |       844.3 ns |     4.36 ns |     4.08 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 137B         |     1,906.6 ns |    16.77 ns |    15.69 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1KB          |       779.9 ns |    11.28 ns |    19.76 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 1KB          |     1,308.1 ns |     4.45 ns |     3.95 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1KB          |     4,236.8 ns |    28.46 ns |    25.23 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1KB          |     9,749.2 ns |    49.48 ns |    46.29 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1025B        |       871.8 ns |     3.72 ns |     3.30 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 1025B        |     1,461.1 ns |     6.18 ns |     5.78 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1025B        |     4,811.5 ns |    39.66 ns |    37.10 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1025B        |    10,928.1 ns |    74.54 ns |    62.24 ns |     168 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 8KB          |     1,193.5 ns |     6.21 ns |     5.51 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 8KB          |    10,394.3 ns |    44.93 ns |    39.83 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 8KB          |    35,864.1 ns |   271.80 ns |   254.24 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 8KB          |    78,753.0 ns |   537.47 ns |   448.81 ns |     504 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128KB        |    14,354.8 ns |    61.19 ns |    51.09 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 128KB        |   170,125.4 ns | 1,113.94 ns | 1,041.98 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128KB        |   573,408.3 ns | 3,574.45 ns | 3,343.54 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128KB        | 1,289,131.0 ns | 8,806.67 ns | 8,237.77 ns |    7224 B |