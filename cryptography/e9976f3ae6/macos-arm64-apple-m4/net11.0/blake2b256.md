| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |         91.43 ns |       0.291 ns |       0.272 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |         95.23 ns |       0.270 ns |       0.253 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        118.20 ns |       0.155 ns |       0.145 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 4B           |        161.85 ns |       0.156 ns |       0.146 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        709.34 ns |       2.019 ns |       1.889 ns |      992 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |         91.72 ns |       0.200 ns |       0.187 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |         94.53 ns |       0.151 ns |       0.126 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        121.24 ns |       0.170 ns |       0.159 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64B          |        161.50 ns |       0.172 ns |       0.161 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        685.41 ns |       3.177 ns |       2.972 ns |     1048 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |         92.63 ns |       0.314 ns |       0.294 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |         95.53 ns |       0.345 ns |       0.306 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        118.68 ns |       0.101 ns |       0.095 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 65B          |        161.84 ns |       0.112 ns |       0.104 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        682.52 ns |       3.175 ns |       2.970 ns |     1056 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |         93.23 ns |       0.265 ns |       0.248 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |         93.85 ns |       0.284 ns |       0.266 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        117.49 ns |       0.620 ns |       0.550 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |        162.63 ns |       0.383 ns |       0.358 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        659.13 ns |       3.462 ns |       3.238 ns |     1112 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        171.55 ns |       0.423 ns |       0.395 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        188.41 ns |       0.712 ns |       0.631 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        223.10 ns |       0.570 ns |       0.533 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 129B         |        326.27 ns |       1.236 ns |       1.156 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,247.37 ns |       5.381 ns |       5.034 ns |     1120 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        654.06 ns |       3.375 ns |       3.157 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |        736.46 ns |       2.469 ns |       2.188 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        850.97 ns |       2.162 ns |       2.022 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |      1,321.22 ns |       3.756 ns |       3.513 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      4,289.79 ns |      23.814 ns |      22.276 ns |     2008 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        735.42 ns |       2.711 ns |       2.403 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |        831.50 ns |       3.540 ns |       3.311 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        960.45 ns |       3.250 ns |       3.040 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |      1,474.40 ns |       6.337 ns |       5.927 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      4,883.31 ns |      29.799 ns |      27.874 ns |     2016 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,162.88 ns |      29.506 ns |      27.600 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      5,866.72 ns |      29.222 ns |      27.335 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,721.35 ns |      14.750 ns |      13.797 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |     10,499.18 ns |      26.887 ns |      25.151 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     33,343.95 ns |     189.373 ns |     177.140 ns |     9176 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     41,233.96 ns |     127.870 ns |     113.353 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     46,866.00 ns |     234.895 ns |     208.228 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     53,224.44 ns |     148.991 ns |     139.367 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64KB         |     83,999.56 ns |     173.485 ns |     162.278 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    263,203.70 ns |   1,990.458 ns |   1,861.876 ns |    66520 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     82,396.83 ns |     304.837 ns |     270.230 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |     93,834.36 ns |     239.089 ns |     223.644 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    106,319.72 ns |     159.074 ns |     141.015 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        |    168,036.34 ns |     459.849 ns |     430.143 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    536,566.21 ns |   3,013.677 ns |   2,818.996 ns |   132082 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    629,742.23 ns |   2,965.773 ns |   2,774.186 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |    717,115.58 ns |   3,999.787 ns |   3,741.404 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    810,396.62 ns |   1,265.416 ns |   1,121.759 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1MB          |  1,285,988.94 ns |   3,373.279 ns |   3,155.367 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  4,029,112.28 ns |  37,157.763 ns |  34,757.394 ns |  1002548 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,307,104.56 ns |  17,840.819 ns |  16,688.313 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         |  7,181,276.82 ns |  22,747.523 ns |  21,278.047 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  8,105,292.10 ns |  16,794.769 ns |  15,709.838 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 10MB         | 12,878,496.66 ns |  31,489.777 ns |  29,455.557 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 40,661,825.65 ns | 281,778.724 ns | 263,575.994 ns | 10001511 B |