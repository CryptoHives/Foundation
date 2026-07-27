| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      85.35 ns |     0.772 ns |     0.644 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      96.15 ns |     0.342 ns |     0.267 ns |   8,034 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |      98.35 ns |     0.239 ns |     0.212 ns |   9,742 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     130.08 ns |     0.526 ns |     0.466 ns |  10,142 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     497.77 ns |     5.213 ns |     4.621 ns |   8,860 B |    1120 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     168.44 ns |     1.601 ns |     1.498 ns |   8,063 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     179.38 ns |     1.311 ns |     1.227 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     180.90 ns |     1.525 ns |     1.352 ns |   9,755 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     251.71 ns |     1.325 ns |     1.240 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     916.24 ns |     4.297 ns |     3.810 ns |   9,170 B |    1136 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     632.78 ns |     8.026 ns |     7.115 ns |   8,078 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     653.03 ns |     6.812 ns |     6.372 ns |   8,051 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     716.41 ns |     5.701 ns |     5.333 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     984.18 ns |     5.148 ns |     4.564 ns |  10,138 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,077.69 ns |    17.202 ns |    16.091 ns |   9,063 B |    2016 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     717.41 ns |     6.637 ns |     6.208 ns |   8,065 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     730.86 ns |     7.454 ns |     6.608 ns |   8,020 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     803.34 ns |     5.942 ns |     5.558 ns |   9,755 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,110.21 ns |     5.230 ns |     4.892 ns |  10,132 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,493.21 ns |    15.594 ns |    14.586 ns |   9,108 B |    2024 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   5,015.17 ns |    37.434 ns |    35.016 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,101.36 ns |    58.523 ns |    51.879 ns |   8,290 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,640.47 ns |    52.053 ns |    48.690 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,832.69 ns |    26.477 ns |    23.471 ns |  10,138 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  23,661.16 ns |   127.821 ns |   113.310 ns |   9,110 B |    9184 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  80,303.28 ns |   882.687 ns |   825.666 ns |   8,081 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  81,254.68 ns |   723.297 ns |   676.572 ns |   8,291 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  89,625.60 ns |   799.565 ns |   747.913 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 125,763.17 ns |   708.672 ns |   662.892 ns |  10,148 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 402,082.88 ns | 1,201.400 ns | 1,003.223 ns |   9,103 B |  132078 B |