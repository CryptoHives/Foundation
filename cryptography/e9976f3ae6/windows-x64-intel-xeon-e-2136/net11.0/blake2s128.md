| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |        105.7 ns |      0.10 ns |      0.10 ns |   5,537 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |        122.8 ns |      0.42 ns |      0.39 ns |   5,533 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |        130.9 ns |      0.07 ns |      0.07 ns |  14,008 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        131.4 ns |      0.19 ns |      0.18 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |        160.1 ns |      0.52 ns |      0.49 ns |  15,746 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |        104.0 ns |      0.13 ns |      0.12 ns |  12,322 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |        114.8 ns |      0.19 ns |      0.18 ns |   5,793 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |        127.2 ns |      0.06 ns |      0.05 ns |  14,279 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        131.3 ns |      0.18 ns |      0.17 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |        155.9 ns |      0.30 ns |      0.28 ns |   9,481 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        203.1 ns |      0.18 ns |      0.16 ns |  11,885 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        227.4 ns |      0.07 ns |      0.06 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        228.6 ns |      0.03 ns |      0.03 ns |  14,008 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        236.9 ns |      0.05 ns |      0.04 ns |  11,881 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        308.6 ns |      0.95 ns |      0.89 ns |  15,569 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        193.4 ns |      0.10 ns |      0.09 ns |   5,795 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        221.0 ns |      0.28 ns |      0.26 ns |  12,126 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        223.9 ns |      0.31 ns |      0.29 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        227.3 ns |      0.04 ns |      0.04 ns |   7,944 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        302.4 ns |      1.11 ns |      1.04 ns |  16,024 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        303.8 ns |      0.41 ns |      0.32 ns |   5,550 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        318.3 ns |      0.26 ns |      0.24 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        322.9 ns |      0.25 ns |      0.23 ns |  14,198 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        335.8 ns |      0.32 ns |      0.27 ns |  11,881 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        452.8 ns |      1.13 ns |      1.05 ns |   9,234 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,463.6 ns |      0.75 ns |      0.62 ns |  12,130 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,603.2 ns |      2.82 ns |      2.50 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,630.6 ns |      0.41 ns |      0.34 ns |  14,468 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,743.5 ns |      0.83 ns |      0.74 ns |   5,791 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      2,362.7 ns |      6.05 ns |      5.66 ns |  15,814 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,637.0 ns |      0.43 ns |      0.40 ns |  11,885 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,675.5 ns |      1.67 ns |      1.56 ns |   8,756 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,702.8 ns |      0.58 ns |      0.54 ns |  14,198 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,859.1 ns |      0.80 ns |      0.75 ns |  11,881 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      2,514.3 ns |      6.42 ns |      6.00 ns |  15,759 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |     11,647.2 ns |     10.34 ns |      8.64 ns |  12,320 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     11,999.2 ns |     10.49 ns |      9.81 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     12,217.2 ns |      2.12 ns |      1.77 ns |  14,279 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |     13,484.3 ns |      6.74 ns |      5.97 ns |  12,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     18,523.8 ns |     23.53 ns |     22.01 ns |   9,479 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     94,587.6 ns |     82.89 ns |     73.48 ns |  12,144 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     96,528.1 ns |     90.88 ns |     85.01 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     97,224.8 ns |     20.25 ns |     17.95 ns |  14,279 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |    112,219.6 ns |     57.92 ns |     54.18 ns |   5,805 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |    147,662.3 ns |    188.47 ns |    176.29 ns |  15,828 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    187,748.6 ns |    154.24 ns |    144.28 ns |   5,809 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    192,670.0 ns |    272.99 ns |    213.13 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    194,307.6 ns |     42.73 ns |     37.88 ns |  14,284 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    216,508.1 ns |     87.97 ns |     77.98 ns |  12,330 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    295,352.3 ns |    734.22 ns |    686.79 ns |  16,011 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,435,145.0 ns |  4,960.29 ns |  4,639.86 ns |   5,802 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,482,518.7 ns |    189.90 ns |    158.57 ns |  14,284 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,484,035.7 ns |    719.98 ns |    601.22 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,651,421.8 ns |    819.64 ns |    766.69 ns |   5,798 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  2,255,349.1 ns |  6,132.84 ns |  5,736.66 ns |  16,022 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 14,449,330.3 ns | 38,868.28 ns | 36,357.41 ns |  12,137 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 14,933,953.6 ns | 11,091.09 ns | 10,374.62 ns |  14,235 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 15,125,234.2 ns | 11,837.84 ns | 11,073.12 ns |  15,232 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 16,644,311.8 ns | 10,835.77 ns |  9,605.63 ns |  12,538 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 22,833,912.3 ns | 69,244.75 ns | 64,771.58 ns |  16,011 B |         - |