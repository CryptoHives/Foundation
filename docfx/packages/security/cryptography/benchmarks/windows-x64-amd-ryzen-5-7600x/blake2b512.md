| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      83.55 ns |     0.246 ns |     0.205 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      96.08 ns |     0.258 ns |     0.229 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     102.50 ns |     0.277 ns |     0.259 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     127.03 ns |     0.332 ns |     0.278 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     500.22 ns |     1.819 ns |     1.613 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     168.30 ns |     0.420 ns |     0.393 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     176.58 ns |     0.364 ns |     0.304 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     188.88 ns |     1.610 ns |     1.506 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     250.73 ns |     1.781 ns |     1.487 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     910.21 ns |     2.522 ns |     2.106 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     623.14 ns |     1.473 ns |     1.378 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     648.10 ns |     1.258 ns |     1.050 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     713.05 ns |     1.679 ns |     1.571 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     975.43 ns |     2.749 ns |     2.571 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,039.86 ns |    18.663 ns |    16.544 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     709.10 ns |     1.395 ns |     1.305 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     726.74 ns |     1.937 ns |     1.811 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     803.67 ns |     1.483 ns |     1.388 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,100.42 ns |     4.588 ns |     4.292 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,450.92 ns |    16.711 ns |    15.631 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   4,960.94 ns |     8.272 ns |     6.908 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,043.40 ns |    12.442 ns |    11.030 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,560.84 ns |    15.159 ns |    13.438 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   7,774.46 ns |    28.585 ns |    26.739 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  23,108.56 ns |    64.988 ns |    57.610 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  79,307.44 ns |   148.809 ns |   139.196 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  80,579.10 ns |   231.713 ns |   205.408 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  88,814.68 ns |   211.523 ns |   197.859 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 124,896.52 ns |   354.125 ns |   313.923 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 393,971.05 ns | 1,732.514 ns | 1,535.829 ns |  132174 B |