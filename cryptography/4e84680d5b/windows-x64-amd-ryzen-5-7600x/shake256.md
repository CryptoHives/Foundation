| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128B         |     287.6 ns |     3.18 ns |     2.97 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128B         |     345.3 ns |     4.74 ns |     4.43 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 128B         |     365.1 ns |     4.17 ns |     3.90 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128B         |     365.2 ns |     1.41 ns |     1.17 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 128B         |     392.3 ns |     3.79 ns |     3.55 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 137B         |     537.9 ns |     5.26 ns |     4.92 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 137B         |     629.8 ns |     3.79 ns |     3.36 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 137B         |     667.4 ns |     5.49 ns |     4.29 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 137B         |     676.9 ns |     1.81 ns |     1.69 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 137B         |     713.9 ns |     2.49 ns |     2.08 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1KB          |   1,726.6 ns |     3.03 ns |     2.37 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 1KB          |   2,064.4 ns |    18.61 ns |    15.54 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1KB          |   2,299.1 ns |    38.20 ns |    31.90 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 1KB          |   2,360.3 ns |     5.73 ns |     5.36 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1KB          |   2,518.8 ns |    10.64 ns |     9.43 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1025B        |   1,729.5 ns |     9.20 ns |     8.61 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 1025B        |   2,075.1 ns |    12.26 ns |    10.87 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1025B        |   2,278.2 ns |     6.12 ns |     4.78 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 1025B        |   2,414.8 ns |     5.17 ns |     4.84 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1025B        |   2,537.0 ns |    25.73 ns |    24.06 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 8KB          |  12,531.4 ns |    45.63 ns |    42.68 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 8KB          |  14,745.8 ns |   213.13 ns |   177.97 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 8KB          |  16,739.3 ns |    49.32 ns |    38.51 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 8KB          |  17,346.1 ns |    49.04 ns |    45.87 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 8KB          |  18,855.3 ns |   119.97 ns |   106.35 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128KB        | 196,090.7 ns |   885.09 ns |   827.92 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 128KB        | 229,815.9 ns | 1,229.15 ns | 1,149.75 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128KB        | 262,048.0 ns |   708.45 ns |   662.68 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 128KB        | 275,025.0 ns | 3,847.49 ns | 3,598.94 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128KB        | 296,339.1 ns | 2,794.90 ns | 2,614.35 ns |     176 B |