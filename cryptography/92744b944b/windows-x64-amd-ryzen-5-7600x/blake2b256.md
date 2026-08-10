| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      82.86 ns |     0.165 ns |     0.146 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |      98.03 ns |     0.211 ns |     0.197 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |     101.46 ns |     0.320 ns |     0.300 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     127.83 ns |     0.298 ns |     0.264 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     486.74 ns |     2.101 ns |     1.965 ns |    1120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     165.31 ns |     0.513 ns |     0.455 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     179.25 ns |     1.020 ns |     0.904 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     185.48 ns |     0.193 ns |     0.181 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     250.42 ns |     0.504 ns |     0.447 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     891.58 ns |     2.092 ns |     1.854 ns |    1136 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     619.83 ns |     1.204 ns |     0.940 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     644.60 ns |     1.500 ns |     1.329 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     704.40 ns |     2.488 ns |     1.942 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     974.22 ns |     1.992 ns |     1.766 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   2,989.31 ns |     8.220 ns |     7.689 ns |    2016 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     703.04 ns |     1.077 ns |     0.899 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     719.75 ns |     4.123 ns |     3.443 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     791.51 ns |     1.522 ns |     1.424 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,096.33 ns |     1.821 ns |     1.615 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,403.46 ns |     4.860 ns |     4.546 ns |    2024 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   4,916.54 ns |    21.059 ns |    16.442 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,005.50 ns |    13.704 ns |    11.443 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,519.51 ns |    18.966 ns |    15.838 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,746.93 ns |    16.948 ns |    15.853 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  23,031.77 ns |    59.889 ns |    56.021 ns |    9184 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  78,766.37 ns |   290.232 ns |   257.283 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  79,892.70 ns |   277.249 ns |   231.516 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  88,306.89 ns |   307.366 ns |   287.510 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 124,232.82 ns |   252.967 ns |   236.626 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 392,217.20 ns | 1,600.369 ns | 1,496.987 ns |  132078 B |