| Description                                       | TestDataSize | Mean          | Error        | StdDev     | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      83.93 ns |     0.410 ns |   0.342 ns |   8,075 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     100.09 ns |     0.238 ns |   0.223 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |     102.75 ns |     0.258 ns |   0.241 ns |   8,036 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     131.94 ns |     0.283 ns |   0.265 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     500.64 ns |     2.252 ns |   2.107 ns |   8,826 B |    1120 B |
|                                                   |              |               |              |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     166.70 ns |     0.591 ns |   0.524 ns |   8,063 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     178.74 ns |     0.793 ns |   0.662 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     187.50 ns |     0.410 ns |   0.384 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     257.75 ns |     0.677 ns |   0.600 ns |  10,137 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     925.15 ns |     1.242 ns |   1.037 ns |   9,227 B |    1136 B |
|                                                   |              |               |              |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     630.72 ns |     1.958 ns |   1.736 ns |   8,078 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     656.03 ns |     1.772 ns |   1.480 ns |   8,047 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     715.15 ns |     1.614 ns |   1.510 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |   1,003.20 ns |     2.409 ns |   2.135 ns |  10,145 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,139.72 ns |     7.710 ns |   6.834 ns |   9,075 B |    2016 B |
|                                                   |              |               |              |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     711.04 ns |     3.080 ns |   2.572 ns |   8,065 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     729.24 ns |     2.851 ns |   2.667 ns |   8,024 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     806.42 ns |     3.414 ns |   2.851 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,124.61 ns |     4.848 ns |   4.298 ns |  10,145 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,559.87 ns |    10.689 ns |   9.999 ns |   9,116 B |    2024 B |
|                                                   |              |               |              |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   4,996.83 ns |    12.459 ns |  11.045 ns |   8,078 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,097.81 ns |     9.154 ns |   8.115 ns |   8,294 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,592.23 ns |    28.564 ns |  23.852 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,989.97 ns |    20.806 ns |  18.444 ns |  10,138 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  24,184.30 ns |    49.135 ns |  45.961 ns |   9,105 B |    9184 B |
|                                                   |              |               |              |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  79,649.93 ns |   240.693 ns | 213.368 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  80,804.45 ns |   181.008 ns | 160.459 ns |   8,289 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  89,520.29 ns |   340.330 ns | 301.693 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 128,248.06 ns |   204.085 ns | 190.901 ns |  10,138 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 410,410.06 ns | 1,022.404 ns | 798.226 ns |   9,133 B |  132078 B |