| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      83.69 ns |     0.203 ns |     0.190 ns |   7,804 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      97.62 ns |     1.207 ns |     1.008 ns |   8,034 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |      98.42 ns |     0.286 ns |     0.267 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     132.76 ns |     0.759 ns |     0.673 ns |  10,195 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     499.17 ns |     4.296 ns |     4.018 ns |   8,847 B |    1120 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     165.94 ns |     0.626 ns |     0.586 ns |   7,794 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     178.99 ns |     0.588 ns |     0.550 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     183.72 ns |     3.410 ns |     3.349 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     253.67 ns |     1.180 ns |     1.046 ns |  10,185 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     920.94 ns |     6.169 ns |     5.469 ns |   9,167 B |    1136 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     631.65 ns |    11.610 ns |     9.695 ns |   7,804 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     651.08 ns |     2.733 ns |     2.556 ns |   8,047 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     711.63 ns |     1.972 ns |     1.647 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     979.88 ns |     4.842 ns |     4.530 ns |  10,193 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,083.71 ns |    12.159 ns |    10.153 ns |   9,067 B |    2016 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     711.87 ns |     2.775 ns |     2.318 ns |   7,807 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     732.28 ns |    10.275 ns |     8.580 ns |   8,024 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     801.26 ns |    10.093 ns |     8.428 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,102.65 ns |     5.972 ns |     5.294 ns |  10,187 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,511.28 ns |    19.631 ns |    17.402 ns |   9,116 B |    2024 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   4,983.24 ns |    14.541 ns |    13.601 ns |   7,812 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,069.79 ns |    18.658 ns |    17.453 ns |   8,290 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,620.87 ns |    17.875 ns |    16.720 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,729.98 ns |    32.382 ns |    30.290 ns |  10,200 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  23,841.90 ns |   135.942 ns |   127.161 ns |   9,110 B |    9184 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  79,419.27 ns |   382.414 ns |   339.000 ns |   7,802 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  81,115.24 ns |   552.492 ns |   461.356 ns |   8,293 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  89,072.20 ns |   277.763 ns |   259.819 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 124,834.23 ns | 2,352.926 ns | 2,310.888 ns |  10,193 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 404,568.48 ns | 1,039.543 ns |   868.065 ns |   9,096 B |  132078 B |