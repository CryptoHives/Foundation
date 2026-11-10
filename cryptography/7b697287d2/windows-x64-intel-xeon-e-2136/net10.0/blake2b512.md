| Description                                       | TestDataSize | Mean            | Error         | StdDev        | Code Size | Allocated  |
|-------------------------------------------------- |------------- |----------------:|--------------:|--------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |        142.6 ns |       0.29 ns |       0.27 ns |   6,263 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        159.2 ns |       0.13 ns |       0.11 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        171.4 ns |       0.31 ns |       0.27 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        214.0 ns |       0.33 ns |       0.29 ns |   8,229 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |      1,282.8 ns |       2.88 ns |       2.70 ns |   8,774 B |     1096 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |        142.6 ns |       0.26 ns |       0.25 ns |   6,253 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        154.9 ns |       0.31 ns |       0.29 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        175.0 ns |       0.18 ns |       0.16 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        213.3 ns |       0.26 ns |       0.23 ns |   8,232 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |      1,147.4 ns |       2.77 ns |       2.59 ns |   8,745 B |     1152 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |        139.8 ns |       0.30 ns |       0.28 ns |   6,274 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        149.8 ns |       0.26 ns |       0.23 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        170.8 ns |       0.23 ns |       0.19 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        214.4 ns |       0.39 ns |       0.36 ns |   8,240 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |      1,141.2 ns |       2.78 ns |       2.60 ns |   8,734 B |     1160 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |        130.8 ns |       0.37 ns |       0.34 ns |   6,245 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        153.9 ns |       0.34 ns |       0.30 ns |   5,916 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        171.4 ns |       0.32 ns |       0.30 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        207.8 ns |       0.43 ns |       0.41 ns |   8,211 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |      1,023.7 ns |       2.39 ns |       2.23 ns |   8,720 B |     1216 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        263.3 ns |       0.58 ns |       0.54 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        272.0 ns |       0.56 ns |       0.52 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        295.7 ns |       0.42 ns |       0.39 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        414.6 ns |       0.54 ns |       0.50 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      2,008.0 ns |       4.29 ns |       4.02 ns |   9,565 B |     1224 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        957.4 ns |       3.88 ns |       3.63 ns |   5,910 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        994.0 ns |       0.84 ns |       0.74 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |      1,067.0 ns |       1.19 ns |       1.12 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,640.0 ns |       1.81 ns |       1.51 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      5,942.4 ns |       5.53 ns |       4.90 ns |   9,454 B |     2112 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |      1,065.2 ns |       2.46 ns |       2.31 ns |   5,891 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |      1,110.5 ns |       2.32 ns |       2.17 ns |   6,264 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |      1,195.7 ns |       1.87 ns |       1.56 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,846.2 ns |       1.60 ns |       1.50 ns |   8,234 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      6,897.6 ns |       7.79 ns |       6.91 ns |   9,497 B |     2120 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      7,323.5 ns |      16.79 ns |      15.71 ns |   6,159 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      7,792.5 ns |      10.98 ns |       9.73 ns |   6,510 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      8,156.6 ns |      12.97 ns |      12.13 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |     12,654.8 ns |      22.60 ns |      20.03 ns |   8,479 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     44,974.5 ns |      47.72 ns |      42.31 ns |   9,497 B |     9280 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     58,453.5 ns |     173.08 ns |     161.90 ns |   6,158 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     61,983.7 ns |     128.28 ns |     119.99 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     65,849.1 ns |      48.44 ns |      42.94 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |    101,783.1 ns |     146.89 ns |     137.40 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    357,373.6 ns |     324.52 ns |     270.99 ns |   9,489 B |    66624 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |    116,946.2 ns |     222.79 ns |     208.40 ns |   6,158 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |    124,286.2 ns |     327.75 ns |     306.57 ns |   6,510 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    133,218.8 ns |     150.25 ns |     133.19 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    204,807.2 ns |     265.03 ns |     247.91 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    788,411.7 ns |   3,533.93 ns |   3,132.74 ns |   9,481 B |   132174 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    891,491.9 ns |   2,246.09 ns |   2,100.99 ns |   5,872 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    952,614.7 ns |   2,366.36 ns |   2,213.50 ns |   6,247 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |  1,017,582.7 ns |   1,490.57 ns |   1,394.28 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,552,458.1 ns |   3,012.81 ns |   2,818.18 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  5,552,302.0 ns |   7,432.38 ns |   6,588.62 ns |   9,501 B |  1001849 B |
|                                                   |              |                 |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  9,029,511.4 ns |  36,784.63 ns |  34,408.36 ns |   6,160 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  9,708,037.1 ns |  17,389.15 ns |  16,265.82 ns |   6,533 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         | 10,313,588.4 ns |   7,651.02 ns |   7,156.77 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 15,686,477.7 ns |  26,143.90 ns |  23,175.88 ns |   8,503 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 56,312,592.6 ns | 153,273.91 ns | 143,372.51 ns |   9,496 B | 10001157 B |