| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |        105.9 ns |      0.12 ns |      0.11 ns |  11,872 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |        119.2 ns |      0.19 ns |      0.18 ns |   5,533 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |        129.4 ns |      0.06 ns |      0.06 ns |  14,008 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        136.5 ns |      0.10 ns |      0.10 ns |  15,301 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |        160.0 ns |      0.48 ns |      0.45 ns |  15,556 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |        109.8 ns |      0.05 ns |      0.04 ns |   5,797 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |        119.4 ns |      0.24 ns |      0.23 ns |   5,793 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |        126.3 ns |      0.09 ns |      0.08 ns |   7,944 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        137.4 ns |      0.15 ns |      0.14 ns |   8,756 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |        155.9 ns |      0.41 ns |      0.39 ns |  15,816 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        202.0 ns |      0.11 ns |      0.10 ns |  11,885 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        228.9 ns |      0.07 ns |      0.06 ns |  14,008 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        230.7 ns |      0.06 ns |      0.05 ns |  12,071 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        230.8 ns |      0.18 ns |      0.16 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        309.1 ns |      0.56 ns |      0.52 ns |  15,759 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        197.8 ns |      0.12 ns |      0.11 ns |  12,320 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        221.2 ns |      0.53 ns |      0.50 ns |   5,791 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        226.5 ns |      0.07 ns |      0.07 ns |  14,468 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        230.8 ns |      0.30 ns |      0.28 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        303.0 ns |      0.53 ns |      0.49 ns |  16,004 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        298.4 ns |      1.26 ns |      1.05 ns |  11,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        323.7 ns |      0.45 ns |      0.43 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        329.2 ns |      0.12 ns |      0.11 ns |  14,198 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        335.6 ns |      0.36 ns |      0.30 ns |  11,881 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        452.7 ns |      0.56 ns |      0.50 ns |  15,569 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,464.7 ns |      1.17 ns |      1.04 ns |  12,320 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,607.3 ns |     16.44 ns |     15.38 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,630.7 ns |      0.50 ns |      0.39 ns |   7,944 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,743.9 ns |      0.77 ns |      0.72 ns |  12,316 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      2,367.4 ns |      6.13 ns |      5.74 ns |   9,479 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,631.2 ns |      0.24 ns |      0.20 ns |   5,550 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,685.7 ns |      1.14 ns |      1.07 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,697.2 ns |      1.34 ns |      1.12 ns |   7,672 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,856.3 ns |      0.43 ns |      0.36 ns |   5,546 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      2,514.2 ns |      6.60 ns |      6.17 ns |  15,759 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |     11,667.7 ns |     15.84 ns |     14.81 ns |   5,795 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     12,225.9 ns |      2.73 ns |      2.42 ns |  14,279 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     12,288.2 ns |     32.70 ns |     30.58 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |     13,839.7 ns |     14.30 ns |     13.38 ns |   5,791 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     18,467.6 ns |     56.28 ns |     46.99 ns |  15,814 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     95,142.1 ns |    122.58 ns |    114.66 ns |   5,809 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     95,401.0 ns |     71.57 ns |     55.88 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     97,553.6 ns |     18.97 ns |     14.81 ns |  14,469 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |    109,969.0 ns |     34.68 ns |     28.96 ns |  12,140 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |    148,143.3 ns |    474.05 ns |    443.42 ns |   9,493 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    188,450.1 ns |    691.57 ns |    646.89 ns |  12,334 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    192,738.3 ns |    181.30 ns |    160.72 ns |  15,091 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    194,344.5 ns |     30.81 ns |     28.82 ns |   7,949 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    216,380.6 ns |     64.12 ns |     56.85 ns |  12,140 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    297,522.6 ns |    412.88 ns |    366.01 ns |  15,821 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,439,686.6 ns |  1,453.08 ns |  1,288.12 ns |  12,137 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,472,562.8 ns |  5,011.66 ns |  4,687.91 ns |  15,042 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,482,868.8 ns |    399.67 ns |    354.30 ns |   9,519 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,653,945.2 ns |    681.37 ns |    604.01 ns |  12,133 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  2,268,050.3 ns |  7,241.70 ns |  6,773.90 ns |  16,011 B |         - |
|                                                   |              |                 |              |              |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 14,530,208.0 ns | 35,786.41 ns | 33,474.63 ns |  12,088 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 14,861,472.4 ns | 17,211.12 ns | 16,099.29 ns |  15,281 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 14,933,501.0 ns |  8,553.56 ns |  8,001.01 ns |  14,284 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 16,660,154.7 ns | 21,194.45 ns | 18,788.33 ns |  12,133 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 22,687,817.5 ns | 48,915.26 ns | 45,755.37 ns |  15,772 B |         - |