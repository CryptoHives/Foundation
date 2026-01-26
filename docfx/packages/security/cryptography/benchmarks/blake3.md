| Description                                  | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|--------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128B         |       115.9 ns |      1.10 ns |      0.97 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128B         |       393.5 ns |      5.46 ns |      5.11 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128B         |     1,299.2 ns |     16.56 ns |     15.49 ns |     112 B |
|                                              |              |                |              |              |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 137B         |       162.7 ns |      0.91 ns |      0.81 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 137B         |       459.6 ns |      7.07 ns |      6.62 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 137B         |     1,915.0 ns |     12.75 ns |     10.65 ns |     112 B |
|                                              |              |                |              |              |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1KB          |       768.5 ns |      5.94 ns |      4.96 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1KB          |     1,317.9 ns |     11.14 ns |      9.88 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1KB          |     9,533.4 ns |    116.75 ns |    109.21 ns |     112 B |
|                                              |              |                |              |              |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 1025B        |       873.1 ns |      4.28 ns |      3.58 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1025B        |     1,468.5 ns |      9.76 ns |      7.62 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1025B        |    11,026.0 ns |    160.82 ns |    150.43 ns |     168 B |
|                                              |              |                |              |              |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 8KB          |     1,203.9 ns |     15.02 ns |     14.05 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 8KB          |    10,508.4 ns |     64.59 ns |     57.26 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 8KB          |    80,729.9 ns |    570.96 ns |    506.14 ns |     504 B |
|                                              |              |                |              |              |           |
| ComputeHash · BLAKE3 · BLAKE3 (Native)       | 128KB        |    14,426.7 ns |    159.75 ns |    133.40 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128KB        |   172,633.2 ns |  1,745.90 ns |  1,633.12 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128KB        | 1,303,640.1 ns | 14,067.38 ns | 13,158.64 ns |    7224 B |