| Description                                  | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128B         |       113.4 ns |     0.21 ns |     0.19 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 128B         |       387.8 ns |     2.77 ns |     2.59 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128B         |       574.7 ns |     1.64 ns |     1.45 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128B         |     1,256.8 ns |     5.59 ns |     4.66 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 137B         |       159.8 ns |     0.37 ns |     0.32 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 137B         |       447.0 ns |     1.41 ns |     1.31 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 137B         |       837.1 ns |     2.76 ns |     2.58 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 137B         |     1,910.5 ns |     8.91 ns |     8.34 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1KB          |       764.5 ns |     1.29 ns |     1.20 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 1KB          |     1,307.3 ns |     3.42 ns |     3.20 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1KB          |     4,310.1 ns |    13.92 ns |    13.02 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1KB          |     9,802.4 ns |    48.23 ns |    40.28 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1025B        |       869.7 ns |     3.62 ns |     3.03 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 1025B        |     1,457.9 ns |     3.95 ns |     3.69 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1025B        |     4,792.9 ns |    22.15 ns |    20.72 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1025B        |    10,715.8 ns |    33.38 ns |    31.23 ns |     168 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 8KB          |     1,189.1 ns |     4.73 ns |     3.95 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 8KB          |    10,365.8 ns |    15.47 ns |    13.71 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 8KB          |    35,442.7 ns |    79.81 ns |    74.65 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 8KB          |    79,372.6 ns |   373.50 ns |   331.10 ns |     504 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128KB        |    14,322.3 ns |    18.89 ns |    14.75 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (SSSE3)        | 128KB        |   168,857.9 ns |   485.94 ns |   454.55 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128KB        |   570,692.6 ns | 1,288.26 ns | 1,075.75 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128KB        | 1,370,440.2 ns | 3,535.86 ns | 2,952.60 ns |    7224 B |