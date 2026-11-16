| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |         91.36 ns |       0.161 ns |       0.150 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |         93.86 ns |       0.127 ns |       0.106 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        122.40 ns |       0.212 ns |       0.198 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 4B           |        160.64 ns |       0.226 ns |       0.189 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        704.17 ns |       3.215 ns |       3.007 ns |     1000 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |         90.89 ns |       0.158 ns |       0.148 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |         93.75 ns |       0.292 ns |       0.273 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        123.18 ns |       0.320 ns |       0.300 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64B          |        160.54 ns |       0.129 ns |       0.121 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        680.69 ns |       2.502 ns |       2.340 ns |     1056 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |         91.49 ns |       0.154 ns |       0.144 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |         93.64 ns |       0.173 ns |       0.144 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        123.28 ns |       0.119 ns |       0.105 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 65B          |        160.77 ns |       0.210 ns |       0.196 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        683.99 ns |       2.416 ns |       2.142 ns |     1064 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |         91.01 ns |       0.150 ns |       0.140 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |         91.35 ns |       0.329 ns |       0.291 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        124.15 ns |       0.123 ns |       0.115 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |        160.50 ns |       0.194 ns |       0.181 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        659.77 ns |       2.869 ns |       2.684 ns |     1120 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        169.13 ns |       0.307 ns |       0.272 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        184.89 ns |       0.356 ns |       0.333 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        229.67 ns |       0.213 ns |       0.200 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 129B         |        324.47 ns |       0.517 ns |       0.483 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,241.66 ns |       5.804 ns |       5.429 ns |     1128 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        650.15 ns |       1.497 ns |       1.401 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |        730.69 ns |       2.165 ns |       2.025 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        873.39 ns |       0.791 ns |       0.740 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |      1,310.89 ns |       1.391 ns |       1.301 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      4,259.23 ns |      19.790 ns |      18.512 ns |     2016 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        738.13 ns |       1.287 ns |       1.075 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |        830.78 ns |       1.604 ns |       1.340 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        977.88 ns |       1.851 ns |       1.731 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |      1,475.75 ns |       2.088 ns |       1.953 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      4,837.39 ns |      15.187 ns |      12.682 ns |     2024 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,142.17 ns |      13.264 ns |      12.407 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      5,824.31 ns |      17.950 ns |      16.791 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,843.79 ns |       6.130 ns |       5.734 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |     10,489.07 ns |       9.363 ns |       8.300 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     33,123.45 ns |     189.526 ns |     177.283 ns |     9184 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     41,223.40 ns |     177.276 ns |     165.824 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     46,604.60 ns |     116.052 ns |      96.909 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     54,585.04 ns |      51.180 ns |      47.874 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64KB         |     83,921.72 ns |     106.227 ns |      99.365 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    263,223.88 ns |   1,778.908 ns |   1,663.992 ns |    66528 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     82,404.33 ns |     303.028 ns |     268.627 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |     93,603.65 ns |     387.225 ns |     362.210 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    109,663.00 ns |     307.814 ns |     287.930 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        |    168,525.41 ns |     548.511 ns |     513.078 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    534,673.66 ns |   3,255.673 ns |   3,045.358 ns |   132092 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    629,157.83 ns |   3,238.922 ns |   3,029.690 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |    715,371.49 ns |   2,768.793 ns |   2,589.931 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    836,552.42 ns |   1,220.267 ns |     952.704 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1MB          |  1,286,516.79 ns |   3,838.443 ns |   3,590.482 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,977,971.75 ns |  33,433.799 ns |  31,273.996 ns |  1002599 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,324,165.02 ns |  16,178.878 ns |  15,133.732 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         |  7,180,909.33 ns |  31,580.889 ns |  29,540.783 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  8,357,972.61 ns |  26,676.573 ns |  24,953.283 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 10MB         | 12,877,719.11 ns |  36,072.950 ns |  33,742.660 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 40,446,149.36 ns | 217,271.608 ns | 203,235.997 ns | 10001193 B |