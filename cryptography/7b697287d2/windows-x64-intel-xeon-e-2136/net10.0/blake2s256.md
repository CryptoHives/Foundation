| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |        104.56 ns |      0.081 ns |      0.076 ns |   3,000 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |        118.78 ns |      0.118 ns |      0.111 ns |   2,965 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |        133.66 ns |      0.102 ns |      0.095 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        145.22 ns |      0.143 ns |      0.134 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |        160.28 ns |      0.263 ns |      0.233 ns |   6,646 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         98.35 ns |      0.089 ns |      0.079 ns |   2,963 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |        113.62 ns |      0.100 ns |      0.093 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |        125.16 ns |      0.071 ns |      0.059 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        145.39 ns |      0.154 ns |      0.144 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |        154.80 ns |      0.231 ns |      0.216 ns |   6,646 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        200.14 ns |      0.100 ns |      0.094 ns |   2,982 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        227.37 ns |      0.082 ns |      0.077 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        228.98 ns |      0.108 ns |      0.096 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        250.21 ns |      0.309 ns |      0.289 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        305.29 ns |      0.439 ns |      0.411 ns |   6,643 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        191.19 ns |      0.079 ns |      0.066 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        219.62 ns |      0.126 ns |      0.105 ns |   2,964 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        224.82 ns |      0.087 ns |      0.077 ns |   5,405 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        247.60 ns |      0.198 ns |      0.176 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        299.88 ns |      0.447 ns |      0.418 ns |   6,666 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        292.56 ns |      0.159 ns |      0.148 ns |   2,985 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        321.05 ns |      0.146 ns |      0.122 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        335.38 ns |      0.165 ns |      0.138 ns |   2,955 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        354.17 ns |      0.183 ns |      0.171 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        450.25 ns |      0.291 ns |      0.272 ns |   6,643 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,474.17 ns |      1.170 ns |      1.095 ns |   2,994 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,631.65 ns |      0.651 ns |      0.609 ns |   5,407 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,690.61 ns |      0.896 ns |      0.838 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,742.96 ns |      1.178 ns |      0.984 ns |   2,964 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      2,367.48 ns |      2.302 ns |      2.040 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,666.62 ns |      1.376 ns |      1.287 ns |   2,981 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,700.28 ns |      0.915 ns |      0.856 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,788.14 ns |      0.688 ns |      0.610 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,858.77 ns |      1.413 ns |      1.180 ns |   2,955 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      2,517.99 ns |      2.589 ns |      2.295 ns |   6,643 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |     11,642.49 ns |     18.259 ns |     17.079 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     12,242.34 ns |      6.196 ns |      5.796 ns |   5,654 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     13,308.92 ns |      8.547 ns |      7.995 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |     13,444.47 ns |      7.003 ns |      6.550 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     18,488.24 ns |     18.966 ns |     17.741 ns |   6,915 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     94,542.33 ns |     61.751 ns |     57.762 ns |   3,225 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     97,384.93 ns |     10.892 ns |     10.189 ns |   5,653 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |    106,349.22 ns |    186.855 ns |    174.784 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |    109,754.28 ns |     85.748 ns |     80.209 ns |   3,223 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |    150,829.32 ns |    148.863 ns |    139.246 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    186,475.07 ns |    249.012 ns |    220.743 ns |   3,225 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    194,701.86 ns |     63.850 ns |     56.602 ns |   5,648 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    210,890.89 ns |    235.213 ns |    208.510 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    215,355.07 ns |    129.233 ns |    114.562 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    295,714.65 ns |    253.275 ns |    224.522 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,431,007.36 ns |    760.757 ns |    635.267 ns |   3,257 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,486,034.41 ns |    492.838 ns |    461.001 ns |   5,658 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,609,724.50 ns |    875.112 ns |    775.764 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,652,975.47 ns |  1,264.067 ns |  1,120.562 ns |   3,220 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  2,275,451.12 ns |  1,118.322 ns |    991.363 ns |   6,935 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 14,408,229.90 ns | 15,026.088 ns | 14,055.412 ns |   3,257 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 14,969,821.88 ns |  6,180.281 ns |  5,160.815 ns |   5,660 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 16,263,784.13 ns | 15,166.516 ns | 12,664.727 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 16,571,342.71 ns | 17,756.620 ns | 16,609.553 ns |   3,238 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 22,730,283.54 ns | 30,640.541 ns | 28,661.181 ns |   6,926 B |         - |