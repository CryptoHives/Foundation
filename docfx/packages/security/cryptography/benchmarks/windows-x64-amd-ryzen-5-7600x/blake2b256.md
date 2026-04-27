| Description                                       | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      84.13 ns |     0.231 ns |   0.216 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      95.14 ns |     0.235 ns |   0.220 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |      98.38 ns |     0.237 ns |   0.222 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     125.63 ns |     0.368 ns |   0.326 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     477.98 ns |     2.509 ns |   2.095 ns |    1120 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     167.69 ns |     0.887 ns |   0.786 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     176.19 ns |     0.513 ns |   0.480 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     187.81 ns |     0.925 ns |   0.865 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     250.36 ns |     0.820 ns |   0.640 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     893.34 ns |     2.880 ns |   2.694 ns |    1136 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     624.09 ns |     1.834 ns |   1.531 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     648.11 ns |     1.603 ns |   1.421 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     711.96 ns |     1.558 ns |   1.458 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     974.45 ns |     1.498 ns |   1.328 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,001.37 ns |    12.792 ns |  11.966 ns |    2016 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     705.76 ns |     1.482 ns |   1.386 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     725.73 ns |     2.113 ns |   1.764 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     792.97 ns |     1.867 ns |   1.746 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,099.43 ns |     5.725 ns |   5.075 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,418.95 ns |    13.789 ns |  12.898 ns |    2024 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   4,951.41 ns |    12.769 ns |  11.945 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,045.12 ns |    14.065 ns |  12.468 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,566.68 ns |    13.028 ns |  12.186 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,761.69 ns |    17.765 ns |  15.748 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  23,117.83 ns |    77.921 ns |  72.887 ns |    9184 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  79,256.51 ns |   237.781 ns | 210.787 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  80,655.84 ns |   470.832 ns | 417.381 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  88,701.72 ns |    98.943 ns |  87.711 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 122,577.99 ns |   358.781 ns | 318.050 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 393,151.26 ns | 1,067.332 ns | 998.383 ns |  132078 B |