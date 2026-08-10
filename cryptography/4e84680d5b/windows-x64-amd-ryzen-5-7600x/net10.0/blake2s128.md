| Description                                            | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128B         |     186.8 ns |      1.06 ns |      0.99 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128B         |     187.5 ns |      0.60 ns |      0.56 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128B         |     188.9 ns |      0.47 ns |      0.44 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128B         |     189.9 ns |      0.50 ns |      0.44 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128B         |     616.9 ns |      1.93 ns |      1.81 ns |      80 B |
|                                                        |              |              |              |              |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 137B         |     259.3 ns |      1.22 ns |      1.08 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 137B         |     266.8 ns |      2.17 ns |      2.03 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 137B         |     273.3 ns |      1.42 ns |      1.33 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 137B         |     274.7 ns |      1.26 ns |      1.17 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 137B         |     919.5 ns |      3.41 ns |      3.02 ns |      80 B |
|                                                        |              |              |              |              |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1KB          |   1,263.8 ns |      4.76 ns |      3.97 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1KB          |   1,266.7 ns |     13.69 ns |     12.81 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1KB          |   1,267.6 ns |     15.03 ns |     13.32 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1KB          |   1,285.8 ns |      3.84 ns |      3.59 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1KB          |   4,754.8 ns |     34.78 ns |     30.83 ns |      80 B |
|                                                        |              |              |              |              |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1025B        |   1,334.2 ns |      4.81 ns |      4.50 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1025B        |   1,340.3 ns |      3.84 ns |      3.21 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1025B        |   1,343.6 ns |     12.11 ns |     11.33 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1025B        |   1,369.9 ns |      7.52 ns |      6.66 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1025B        |   5,098.1 ns |     79.08 ns |     73.97 ns |      80 B |
|                                                        |              |              |              |              |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 8KB          |   9,833.3 ns |     35.27 ns |     29.45 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 8KB          |   9,873.6 ns |    187.70 ns |    175.57 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 8KB          |   9,876.2 ns |     94.27 ns |     88.18 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 8KB          |  10,038.6 ns |     31.55 ns |     27.97 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 8KB          |  37,598.9 ns |    174.35 ns |    163.09 ns |      80 B |
|                                                        |              |              |              |              |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128KB        | 157,381.0 ns |  2,483.94 ns |  2,323.48 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128KB        | 158,049.3 ns |  2,626.82 ns |  2,457.13 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128KB        | 159,432.3 ns |  3,117.62 ns |  2,916.23 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128KB        | 162,076.9 ns |  2,582.40 ns |  2,415.58 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128KB        | 617,076.0 ns | 12,172.19 ns | 17,063.72 ns |      80 B |