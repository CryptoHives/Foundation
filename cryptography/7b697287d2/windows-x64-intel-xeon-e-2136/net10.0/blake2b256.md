| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Code Size | Allocated  |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |        141.9 ns |      0.11 ns |      0.10 ns |   6,263 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        149.7 ns |      0.23 ns |      0.21 ns |   5,899 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        162.8 ns |      0.27 ns |      0.24 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        214.0 ns |      0.23 ns |      0.22 ns |   8,229 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |      1,237.8 ns |      2.11 ns |      1.87 ns |   8,706 B |     1000 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |        136.6 ns |      0.22 ns |      0.19 ns |   6,253 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        149.6 ns |      0.26 ns |      0.24 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        165.2 ns |      0.23 ns |      0.21 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        212.0 ns |      0.27 ns |      0.24 ns |   8,226 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |      1,119.0 ns |      2.49 ns |      2.21 ns |   8,692 B |     1056 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |        140.4 ns |      0.20 ns |      0.19 ns |   6,256 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        151.8 ns |      0.24 ns |      0.20 ns |   5,889 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        164.2 ns |      0.18 ns |      0.15 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        212.9 ns |      0.26 ns |      0.23 ns |   8,248 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |      1,111.8 ns |      3.08 ns |      2.88 ns |   8,695 B |     1064 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |        131.3 ns |      0.18 ns |      0.17 ns |   6,252 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        147.6 ns |      0.39 ns |      0.35 ns |   5,921 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        164.1 ns |      0.33 ns |      0.29 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        207.1 ns |      0.25 ns |      0.24 ns |   8,211 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        985.1 ns |      1.89 ns |      1.58 ns |   8,699 B |     1120 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        262.8 ns |      0.28 ns |      0.26 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        267.7 ns |      0.87 ns |      0.77 ns |   5,899 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        288.8 ns |      0.48 ns |      0.42 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        412.8 ns |      0.65 ns |      0.54 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,989.4 ns |      4.31 ns |      3.82 ns |   9,538 B |     1128 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        948.2 ns |      2.26 ns |      2.11 ns |   5,915 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        980.1 ns |      1.75 ns |      1.64 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |      1,054.0 ns |      1.52 ns |      1.42 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,640.3 ns |      1.40 ns |      1.24 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      5,895.6 ns |      5.88 ns |      4.91 ns |   9,467 B |     2016 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |      1,070.6 ns |      0.82 ns |      0.72 ns |   5,893 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |      1,116.9 ns |      2.36 ns |      2.21 ns |   6,264 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |      1,176.4 ns |      0.64 ns |      0.54 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,855.0 ns |      2.03 ns |      1.80 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      6,845.9 ns |      8.50 ns |      7.53 ns |   9,497 B |     2024 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      7,324.0 ns |     21.88 ns |     20.46 ns |   6,159 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      7,795.2 ns |     14.21 ns |     11.87 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      8,151.2 ns |     26.60 ns |     24.88 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |     12,698.8 ns |     12.62 ns |     10.54 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     44,925.2 ns |     27.92 ns |     21.80 ns |   9,497 B |     9184 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     58,504.7 ns |    195.92 ns |    183.26 ns |   6,163 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     62,021.8 ns |     84.80 ns |     79.33 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     65,348.2 ns |    128.90 ns |    120.57 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |    101,767.6 ns |    111.08 ns |    103.90 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    361,329.7 ns |    401.40 ns |    375.47 ns |   9,478 B |    66528 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |    116,819.6 ns |    268.01 ns |    250.70 ns |   6,163 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |    125,209.3 ns |    302.20 ns |    282.68 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    132,034.5 ns |    135.75 ns |    126.98 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    204,521.5 ns |    300.66 ns |    281.24 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    781,559.6 ns |    343.69 ns |    268.33 ns |   9,517 B |   132078 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    892,107.9 ns |  2,006.50 ns |  1,876.88 ns |   5,872 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    963,283.8 ns |  2,020.88 ns |  1,890.33 ns |   6,247 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |  1,010,690.3 ns |    809.39 ns |    757.11 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,552,569.2 ns |  1,581.24 ns |  1,479.09 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  5,527,670.9 ns |  3,921.75 ns |  3,274.84 ns |   9,503 B |  1001756 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  9,047,010.6 ns | 21,157.36 ns | 19,790.61 ns |   6,165 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  9,657,940.2 ns | 17,459.23 ns | 16,331.38 ns |   6,533 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         | 10,268,257.8 ns | 12,709.95 ns | 11,267.04 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 15,696,332.8 ns | 36,401.39 ns | 32,268.88 ns |   8,492 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 55,993,250.8 ns | 97,270.43 ns | 86,227.70 ns |   9,496 B | 10001061 B |