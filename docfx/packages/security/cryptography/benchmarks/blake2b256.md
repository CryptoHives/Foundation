| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (BouncyCastle) | 128B         |     127.7 ns |     0.66 ns |     0.62 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (AVX2)         | 128B         |     139.9 ns |     0.65 ns |     0.61 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (Managed)      | 128B         |     393.3 ns |     2.81 ns |     2.62 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (BouncyCastle) | 137B         |     206.8 ns |     1.20 ns |     1.06 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (AVX2)         | 137B         |     241.6 ns |     1.15 ns |     1.07 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (Managed)      | 137B         |     746.8 ns |     3.64 ns |     3.41 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (BouncyCastle) | 1KB          |     743.7 ns |     3.26 ns |     3.05 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (AVX2)         | 1KB          |     870.3 ns |    13.57 ns |    12.69 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (Managed)      | 1KB          |   2,880.2 ns |    24.72 ns |    23.13 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (BouncyCastle) | 1025B        |     831.1 ns |     4.03 ns |     3.58 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (AVX2)         | 1025B        |     970.1 ns |     6.18 ns |     4.83 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (Managed)      | 1025B        |   3,244.7 ns |    20.78 ns |    19.44 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (BouncyCastle) | 8KB          |   5,638.6 ns |    34.33 ns |    32.11 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (AVX2)         | 8KB          |   6,983.8 ns |    34.27 ns |    26.76 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (Managed)      | 8KB          |  22,775.7 ns |   162.82 ns |   152.30 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (BouncyCastle) | 128KB        |  89,808.0 ns |   379.88 ns |   355.34 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (AVX2)         | 128KB        | 111,718.7 ns |   694.86 ns |   649.97 ns |     112 B |
| ComputeHash | BLAKE2b-256 | BLAKE2b-256 (Managed)      | 128KB        | 364,233.6 ns | 3,360.33 ns | 3,143.25 ns |     112 B |