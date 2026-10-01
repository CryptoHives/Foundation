| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |         76.28 ns |      0.095 ns |      0.088 ns |   2,886 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |         81.14 ns |      0.053 ns |      0.047 ns |   2,982 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         93.51 ns |      0.059 ns |      0.046 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         96.11 ns |      0.191 ns |      0.179 ns |   6,639 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |         98.24 ns |      0.110 ns |      0.103 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         78.72 ns |      0.063 ns |      0.053 ns |   2,918 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |         80.37 ns |      0.047 ns |      0.041 ns |   2,999 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         91.37 ns |      0.152 ns |      0.143 ns |   6,661 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         93.47 ns |      0.104 ns |      0.097 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |         98.08 ns |      0.081 ns |      0.075 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        153.91 ns |      0.153 ns |      0.143 ns |   2,912 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        161.86 ns |      0.084 ns |      0.074 ns |   2,997 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        174.19 ns |      0.089 ns |      0.083 ns |   5,857 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        181.70 ns |      0.289 ns |      0.271 ns |   6,662 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        182.16 ns |      0.119 ns |      0.111 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        152.25 ns |      0.170 ns |      0.159 ns |   2,900 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        156.71 ns |      0.066 ns |      0.062 ns |   3,002 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        171.37 ns |      0.113 ns |      0.101 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        179.28 ns |      0.291 ns |      0.258 ns |   6,652 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        182.64 ns |      0.094 ns |      0.083 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        228.74 ns |      0.223 ns |      0.209 ns |   2,910 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        238.28 ns |      0.131 ns |      0.123 ns |   2,997 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        251.88 ns |      0.143 ns |      0.127 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        267.28 ns |      0.266 ns |      0.249 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        267.32 ns |      0.451 ns |      0.400 ns |   6,661 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,181.35 ns |      0.625 ns |      0.585 ns |   2,907 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,225.73 ns |      0.799 ns |      0.708 ns |   2,988 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,270.31 ns |      0.378 ns |      0.354 ns |   6,126 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,358.24 ns |      0.598 ns |      0.530 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,389.62 ns |      1.805 ns |      1.689 ns |   6,662 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,262.61 ns |      0.476 ns |      0.445 ns |   2,909 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,310.43 ns |      0.919 ns |      0.859 ns |   3,011 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,344.06 ns |      0.752 ns |      0.704 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,437.74 ns |      0.561 ns |      0.497 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,475.38 ns |      2.763 ns |      2.584 ns |   6,661 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |      9,435.24 ns |      3.676 ns |      3.438 ns |   3,150 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |      9,792.42 ns |      4.234 ns |      3.960 ns |   3,231 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     10,024.95 ns |      3.979 ns |      3.722 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     10,746.05 ns |      4.570 ns |      4.275 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     11,077.47 ns |     17.907 ns |     16.751 ns |   6,652 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     75,605.60 ns |     26.087 ns |     24.402 ns |   3,157 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |     78,110.05 ns |     38.961 ns |     36.444 ns |   3,245 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     80,037.01 ns |     49.841 ns |     46.622 ns |   6,125 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     86,096.17 ns |     40.666 ns |     38.039 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     88,406.79 ns |    166.037 ns |    155.311 ns |   6,909 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    151,168.63 ns |     69.135 ns |     64.669 ns |   3,157 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    156,625.30 ns |     61.438 ns |     57.469 ns |   3,231 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    160,502.19 ns |     84.113 ns |     74.564 ns |   6,125 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    172,156.14 ns |     87.034 ns |     81.412 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    176,023.58 ns |    257.567 ns |    228.326 ns |   6,895 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,158,762.99 ns |    467.352 ns |    437.162 ns |   3,150 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,192,505.35 ns |    482.025 ns |    450.887 ns |   3,231 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,221,734.61 ns |    516.003 ns |    482.670 ns |   6,131 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,304,588.65 ns |    486.355 ns |    454.937 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,349,893.75 ns |  2,427.449 ns |  2,270.637 ns |   6,895 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 11,521,126.79 ns |  4,677.989 ns |  4,146.915 ns |   3,150 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 11,925,331.36 ns |  4,925.115 ns |  4,365.986 ns |   3,238 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 12,247,362.61 ns |  4,181.397 ns |  3,706.700 ns |   6,130 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 13,049,609.04 ns |  3,652.184 ns |  3,237.566 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 13,433,166.04 ns | 17,662.957 ns | 16,521.941 ns |   6,902 B |         - |