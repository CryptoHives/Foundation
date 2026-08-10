| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      90.09 ns |     0.290 ns |     0.271 ns |      90.05 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      94.51 ns |     0.378 ns |     0.335 ns |      94.58 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     126.66 ns |     0.156 ns |     0.138 ns |     126.70 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     168.61 ns |     1.059 ns |     0.939 ns |     168.58 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     606.43 ns |    11.953 ns |    18.254 ns |     614.08 ns |    1120 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     169.01 ns |     0.278 ns |     0.232 ns |     168.99 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     190.02 ns |     3.180 ns |     6.568 ns |     186.46 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     232.34 ns |     0.340 ns |     0.318 ns |     232.18 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     358.43 ns |     1.618 ns |     1.435 ns |     358.69 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   1,098.53 ns |    12.144 ns |    10.766 ns |   1,093.54 ns |    1136 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     647.91 ns |     1.581 ns |     1.402 ns |     648.04 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     729.72 ns |     2.691 ns |     2.517 ns |     729.47 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     871.22 ns |     0.850 ns |     0.795 ns |     871.36 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   1,483.93 ns |     2.575 ns |     2.283 ns |   1,484.01 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,756.68 ns |    30.537 ns |    28.564 ns |   3,751.53 ns |    2016 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     725.72 ns |     2.288 ns |     2.141 ns |     724.92 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |     818.62 ns |     3.075 ns |     2.876 ns |     818.54 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     975.06 ns |     1.233 ns |     1.153 ns |     975.16 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   1,668.99 ns |     2.164 ns |     1.918 ns |   1,668.54 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   4,230.54 ns |    25.087 ns |    22.239 ns |   4,230.03 ns |    2024 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,101.80 ns |    17.069 ns |    15.966 ns |   5,104.16 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,770.21 ns |    25.357 ns |    23.719 ns |   5,769.81 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,797.81 ns |     5.632 ns |     4.992 ns |   6,799.71 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  11,950.63 ns |     1.545 ns |     1.445 ns |  11,950.18 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  28,730.66 ns |    98.118 ns |    91.780 ns |  28,731.31 ns |    9184 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  81,778.96 ns |   254.385 ns |   237.952 ns |  81,747.10 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  92,546.43 ns |   346.204 ns |   323.839 ns |  92,624.49 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 108,467.23 ns |    26.923 ns |    23.867 ns | 108,466.47 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 192,047.47 ns |    29.348 ns |    26.016 ns | 192,052.68 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 465,228.76 ns | 1,685.835 ns | 1,494.449 ns | 464,909.40 ns |  132092 B |