| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |         75.65 ns |      0.065 ns |      0.058 ns |   2,864 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |         81.38 ns |      0.027 ns |      0.026 ns |   2,940 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         92.38 ns |      0.069 ns |      0.065 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         95.21 ns |      0.170 ns |      0.159 ns |   6,616 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |         99.01 ns |      0.081 ns |      0.076 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         77.56 ns |      0.046 ns |      0.043 ns |   2,864 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |         80.82 ns |      0.031 ns |      0.029 ns |   2,957 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         90.89 ns |      0.225 ns |      0.200 ns |   6,614 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         92.39 ns |      0.056 ns |      0.053 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |         99.43 ns |      0.071 ns |      0.063 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        154.34 ns |      0.390 ns |      0.364 ns |   2,849 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        162.19 ns |      0.061 ns |      0.054 ns |   2,938 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        172.23 ns |      0.106 ns |      0.099 ns |   5,857 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        180.56 ns |      0.328 ns |      0.274 ns |   6,602 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        183.08 ns |      0.055 ns |      0.049 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        151.19 ns |      0.058 ns |      0.051 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        157.03 ns |      0.043 ns |      0.036 ns |   2,954 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        172.19 ns |      0.101 ns |      0.094 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        177.50 ns |      0.293 ns |      0.274 ns |   6,632 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        182.52 ns |      0.112 ns |      0.099 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        228.52 ns |      0.081 ns |      0.076 ns |   2,851 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        237.01 ns |      0.072 ns |      0.064 ns |   2,938 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        251.75 ns |      0.169 ns |      0.158 ns |   5,857 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        266.32 ns |      0.083 ns |      0.069 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        267.92 ns |      0.509 ns |      0.476 ns |   6,616 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,183.80 ns |      0.326 ns |      0.289 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,224.47 ns |      0.357 ns |      0.334 ns |   2,954 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,264.31 ns |      0.410 ns |      0.364 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,355.91 ns |      0.293 ns |      0.245 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,386.65 ns |      2.705 ns |      2.398 ns |   6,632 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,260.50 ns |      0.258 ns |      0.215 ns |   2,849 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,303.77 ns |      0.334 ns |      0.296 ns |   2,955 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,345.72 ns |      0.376 ns |      0.352 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,436.75 ns |      0.277 ns |      0.259 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,482.10 ns |      3.226 ns |      3.018 ns |   6,601 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |      9,451.54 ns |      3.302 ns |      3.089 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |      9,764.48 ns |      2.246 ns |      2.101 ns |   3,207 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     10,010.08 ns |      2.355 ns |      1.967 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     10,709.85 ns |      4.058 ns |      3.796 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     11,065.45 ns |     19.537 ns |     17.319 ns |   6,618 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     75,435.02 ns |     18.423 ns |     15.384 ns |   3,123 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |     78,100.49 ns |     37.018 ns |     34.627 ns |   3,197 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     79,996.96 ns |     27.296 ns |     24.198 ns |   6,125 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     85,675.31 ns |     25.899 ns |     24.226 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     88,359.04 ns |    125.923 ns |    111.628 ns |   6,871 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    151,148.58 ns |     44.730 ns |     41.840 ns |   3,109 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    156,153.97 ns |     40.596 ns |     37.974 ns |   3,208 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    159,968.03 ns |     40.976 ns |     38.329 ns |   6,125 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    171,596.11 ns |     35.890 ns |     31.815 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    176,938.21 ns |    223.694 ns |    198.299 ns |   6,861 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,153,609.53 ns |    414.233 ns |    387.474 ns |   3,109 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,191,876.86 ns |    499.395 ns |    442.701 ns |   3,204 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,221,329.94 ns |    451.539 ns |    400.277 ns |   6,130 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,304,417.63 ns |    540.509 ns |    479.147 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,348,505.59 ns |  2,680.425 ns |  2,507.271 ns |   6,861 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 11,516,005.92 ns |  2,285.971 ns |  2,026.453 ns |   3,115 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 11,923,347.10 ns |  3,973.611 ns |  3,522.503 ns |   3,204 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 12,212,390.73 ns |  4,908.433 ns |  4,591.352 ns |   6,130 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 13,044,937.95 ns |  2,946.160 ns |  2,611.695 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 13,546,858.59 ns | 14,911.194 ns | 13,218.385 ns |   6,867 B |         - |