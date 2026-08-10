| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128B         |     130.8 ns |     0.97 ns |     0.91 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128B         |     141.3 ns |     0.59 ns |     0.52 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128B         |     399.3 ns |     2.02 ns |     1.79 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 137B         |     211.6 ns |     1.02 ns |     0.90 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 137B         |     244.7 ns |     1.57 ns |     1.47 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 137B         |     747.1 ns |     3.33 ns |     3.11 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1KB          |     748.0 ns |     1.88 ns |     1.67 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1KB          |     865.1 ns |     5.45 ns |     5.10 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1KB          |   2,857.0 ns |     5.81 ns |     4.85 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1025B        |     830.1 ns |     2.11 ns |     1.65 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1025B        |     981.5 ns |    15.54 ns |    14.54 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1025B        |   3,217.3 ns |     6.16 ns |     5.46 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 8KB          |   5,619.7 ns |    18.10 ns |    15.11 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 8KB          |   7,004.8 ns |    25.24 ns |    21.08 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 8KB          |  22,521.8 ns |    86.18 ns |    80.61 ns |     176 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128KB        |  89,354.0 ns |   224.36 ns |   187.35 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128KB        | 111,026.2 ns | 1,198.34 ns | 1,120.93 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128KB        | 360,984.4 ns | 1,333.34 ns | 1,247.21 ns |     176 B |