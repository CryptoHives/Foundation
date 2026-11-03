| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |         76.38 ns |      0.066 ns |      0.058 ns |   2,856 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |         80.74 ns |      0.035 ns |      0.031 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         93.88 ns |      0.108 ns |      0.101 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         94.60 ns |      0.135 ns |      0.119 ns |   6,608 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        100.98 ns |      0.069 ns |      0.061 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         77.99 ns |      0.042 ns |      0.039 ns |   2,864 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |         80.19 ns |      0.016 ns |      0.013 ns |   2,952 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         90.94 ns |      0.146 ns |      0.136 ns |   6,623 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |        100.32 ns |      0.056 ns |      0.050 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        100.41 ns |      0.085 ns |      0.079 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        153.60 ns |      0.184 ns |      0.154 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        161.50 ns |      0.036 ns |      0.030 ns |   2,941 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        173.15 ns |      0.098 ns |      0.086 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        180.31 ns |      0.226 ns |      0.200 ns |   6,605 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        189.91 ns |      0.149 ns |      0.124 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        151.06 ns |      0.079 ns |      0.074 ns |   2,868 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        156.33 ns |      0.105 ns |      0.093 ns |   2,956 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        171.84 ns |      0.099 ns |      0.088 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        177.26 ns |      0.294 ns |      0.261 ns |   6,620 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        190.16 ns |      0.082 ns |      0.076 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        228.30 ns |      0.264 ns |      0.247 ns |   2,853 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        237.75 ns |      0.047 ns |      0.037 ns |   2,941 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        252.06 ns |      0.116 ns |      0.103 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        266.95 ns |      0.488 ns |      0.456 ns |   6,612 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        268.09 ns |      0.136 ns |      0.127 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,186.45 ns |      0.205 ns |      0.172 ns |   2,868 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,223.74 ns |      0.390 ns |      0.365 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,266.26 ns |      0.403 ns |      0.337 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,369.08 ns |      0.575 ns |      0.480 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,389.26 ns |      3.073 ns |      2.874 ns |   6,620 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,261.52 ns |      0.323 ns |      0.287 ns |   2,853 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,305.21 ns |      0.252 ns |      0.211 ns |   2,941 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,343.80 ns |      0.406 ns |      0.379 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,437.27 ns |      0.338 ns |      0.300 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,471.38 ns |      2.431 ns |      2.274 ns |   6,619 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |      9,434.22 ns |      3.262 ns |      3.051 ns |   3,118 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |      9,763.68 ns |      1.975 ns |      1.751 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     10,023.21 ns |      4.659 ns |      4.358 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     10,741.24 ns |      3.757 ns |      3.514 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     11,079.20 ns |     16.080 ns |     14.255 ns |   6,620 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     75,574.82 ns |     23.912 ns |     22.368 ns |   3,111 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |     78,102.14 ns |     21.668 ns |     20.269 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     79,990.19 ns |     15.564 ns |     12.997 ns |   6,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     85,509.04 ns |     26.008 ns |     24.328 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     88,476.82 ns |    160.256 ns |    142.063 ns |   6,873 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    151,128.76 ns |     58.300 ns |     54.534 ns |   3,111 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    156,161.20 ns |     39.811 ns |     37.239 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    159,970.54 ns |     46.535 ns |     41.252 ns |   6,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    171,516.96 ns |     46.214 ns |     43.228 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    177,133.00 ns |    255.059 ns |    238.582 ns |   6,863 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,154,394.04 ns |    443.963 ns |    393.562 ns |   3,111 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,192,240.33 ns |    521.356 ns |    487.676 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,221,148.91 ns |    558.958 ns |    522.850 ns |   6,132 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,306,788.12 ns |    373.038 ns |    348.940 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,352,076.59 ns |  2,962.956 ns |  2,771.551 ns |   6,863 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 11,517,952.52 ns |  3,102.796 ns |  2,590.975 ns |   3,140 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 11,924,036.98 ns |  4,443.494 ns |  4,156.447 ns |   3,228 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 12,211,550.56 ns |  2,120.768 ns |  1,880.006 ns |   6,132 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 13,097,918.12 ns |  3,062.968 ns |  2,865.102 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 13,617,644.27 ns | 17,463.620 ns | 16,335.481 ns |   6,892 B |         - |